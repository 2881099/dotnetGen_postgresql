using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using NpgsqlTypes;

namespace Npgsql {
	public partial class Executer : IDisposable {

		public ILogger Log { get; set; }
		public ConnectionPool Pool { get; }
		public Executer() { }
		public Executer(ILogger log, string connectionString) {
			this.Log = log;
			this.Pool = new ConnectionPool(connectionString);
		}

		void LoggerException(NpgsqlCommand cmd, Exception e) {
			if (e == null) return;
			string log = $"数据库出错（执行SQL）〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓\r\n{cmd.CommandText}\r\n";
			foreach (NpgsqlParameter parm in cmd.Parameters) {
				log += Lib.PadRight(parm.ParameterName, 20) + " = " + Lib.PadRight(parm.Value == null ? "NULL" : parm.Value, 20) + "\r\n";
			}
			log += e.Message;
			Log.LogError(log);

			RollbackTransaction();
			cmd.Parameters.Clear();
			throw e;
		}

		public static string Addslashes(string filter, params object[] parms) {
			if (filter == null || parms == null) return string.Empty;
			if (parms.Length == 0) return filter;
			object[] nparms = new object[parms.Length];
			for (int a = 0; a < parms.Length; a++) {
				if (parms[a] == null) nparms[a] = "NULL";
				else {
					decimal trydec;
					if (parms[a] is bool || parms[a] is bool?)
						nparms[a] = (bool)parms[a] ? "'t'" : "'f'";
					else if (parms[a] is string || parms[a] is Enum)
						nparms[a] = string.Concat("'", parms[a].ToString().Replace("'", "''"), "'");
					else if (decimal.TryParse(string.Concat(parms[a]), out trydec))
						nparms[a] = parms[a];
					else if (parms[a] is DateTime) {
						DateTime dt = (DateTime)parms[a];
						nparms[a] = string.Concat("'", dt.ToString("yyyy-MM-dd HH:mm:ss"), "'");
					} else if (parms[a] is DateTime?) {
						DateTime? dt = parms[a] as DateTime?;
						nparms[a] = string.Concat("'", dt.Value.ToString("yyyy-MM-dd HH:mm:ss"), "'");
					} else {
						nparms[a] = string.Concat("'", parms[a].ToString().Replace("'", "''"), "'");
						//if (parms[a] is string) nparms[a] = string.Concat('N', nparms[a]);
					}
				}
			}
			try { string ret = string.Format(filter, nparms); return ret; } catch { return filter; }
		}
		public void ExecuteReader(Action<NpgsqlDataReader> readerHander, CommandType cmdType, string cmdText, params NpgsqlParameter[] cmdParms) {
			NpgsqlCommand cmd = new NpgsqlCommand();
			var pc = PrepareCommand(cmd, cmdType, cmdText, cmdParms);
			Exception ex = Lib.Trys(delegate () {
				if (cmd.Connection.State == ConnectionState.Closed) cmd.Connection.Open();
				try {
					using (NpgsqlDataReader dr = cmd.ExecuteReader()) {
						while (dr.Read())
							if (readerHander != null) readerHander(dr);
					}
				} catch {
					throw;
				}
			}, 1);

			if (pc.Tran == null) this.Pool.ReleaseConnection(pc.Conn);
			LoggerException(cmd, ex);
		}
		public object[][] ExeucteArray(CommandType cmdType, string cmdText, params NpgsqlParameter[] cmdParms) {
			List<object[]> ret = new List<object[]>();
			ExecuteReader(dr => {
				object[] item = new object[dr.FieldCount];
				dr.GetValues(item);
				ret.Add(item);
			}, cmdType, cmdText, cmdParms);
			return ret.ToArray();
		}
		public int ExecuteNonQuery(CommandType cmdType, string cmdText, params NpgsqlParameter[] cmdParms) {
			NpgsqlCommand cmd = new NpgsqlCommand();
			var pc = PrepareCommand(cmd, cmdType, cmdText, cmdParms);
			int val = 0;
			Exception ex = Lib.Trys(delegate () {
				if (cmd.Connection.State == ConnectionState.Closed) cmd.Connection.Open();
				try {
					val = cmd.ExecuteNonQuery();
				} catch {
					throw;
				}
			}, 1);

			if (pc.Tran == null) this.Pool.ReleaseConnection(pc.Conn);
			LoggerException(cmd, ex);
			cmd.Parameters.Clear();
			return val;
		}
		public object ExecuteScalar(CommandType cmdType, string cmdText, params NpgsqlParameter[] cmdParms) {
			NpgsqlCommand cmd = new NpgsqlCommand();
			var pc = PrepareCommand(cmd, cmdType, cmdText, cmdParms);
			object val = null;
			Exception ex = Lib.Trys(delegate () {
				if (cmd.Connection.State == ConnectionState.Closed) cmd.Connection.Open();
				try {
					val = cmd.ExecuteScalar();
				} catch {
					throw;
				}
			}, 1);

			if (pc.Tran == null) this.Pool.ReleaseConnection(pc.Conn);
			LoggerException(cmd, ex);
			cmd.Parameters.Clear();
			return val;
		}

		private PrepareCommandReturnInfo PrepareCommand(NpgsqlCommand cmd, CommandType cmdType, string cmdText, NpgsqlParameter[] cmdParms) {
			cmd.CommandType = cmdType;
			cmd.CommandText = cmdText;

			if (cmdParms != null) {
				foreach (NpgsqlParameter parm in cmdParms) {
					if (parm == null) continue;
					if (parm.Value == null) parm.Value = DBNull.Value;
					cmd.Parameters.Add(parm);
				}
			}

			Connection2 conn = null;
			NpgsqlTransaction tran = CurrentThreadTransaction;
			if (tran == null) {
				conn = this.Pool.GetConnection();
				cmd.Connection = conn.SqlConnection;
			} else {
				cmd.Connection = tran.Connection;
				cmd.Transaction = tran;
			}

			AutoCommitTransaction();
			return new PrepareCommandReturnInfo { Conn = conn, Tran = tran };
		}

		class PrepareCommandReturnInfo {
			public Connection2 Conn;
			public NpgsqlTransaction Tran;
		}

		#region 事务处理

		class SqlTransaction2 {
			internal Connection2 Conn;
			internal NpgsqlTransaction Transaction;
			internal DateTime RunTime;
			internal TimeSpan Timeout;

			public SqlTransaction2(Connection2 conn, NpgsqlTransaction tran, TimeSpan timeout) {
				Conn = conn;
				Transaction = tran;
				RunTime = DateTime.Now;
				Timeout = timeout;
			}
		}

		private Dictionary<int, SqlTransaction2> _trans = new Dictionary<int, SqlTransaction2>();
		private List<SqlTransaction2> _trans_tmp = new List<SqlTransaction2>();
		private object _trans_lock = new object();

		private NpgsqlTransaction CurrentThreadTransaction {
			get {
				int tid = Thread.CurrentThread.ManagedThreadId;
				if (_trans.ContainsKey(tid) && _trans[tid].Transaction.Connection != null)
					return _trans[tid].Transaction;
				return null;
			}
		}

		/// <summary>
		/// 启动事务
		/// </summary>
		public void BeginTransaction() {
			BeginTransaction(TimeSpan.FromSeconds(10));
		}
		public void BeginTransaction(TimeSpan timeout) {
			int tid = Thread.CurrentThread.ManagedThreadId;
			var conn = this.Pool.GetConnection();
			SqlTransaction2 tran = null;

			Exception ex = Lib.Trys(delegate () {
				if (conn.SqlConnection.State == ConnectionState.Closed) conn.SqlConnection.Open();
				tran = new SqlTransaction2(conn, conn.SqlConnection.BeginTransaction(), timeout);
			}, 1);

			if (ex != null) {
				Log.LogError(new EventId(9999, "数据库出错（开启事务）"), ex, "数据库出错（开启事务）");
				throw ex;
			}

			if (_trans.ContainsKey(tid))
				CommitTransaction();

			lock (_trans_lock) {
				_trans.Add(tid, tran);
				_trans_tmp.Add(tran);
			}
		}

		/// <summary>
		/// 自动提交事务
		/// </summary>
		private void AutoCommitTransaction() {
			if (_trans_tmp.Count > 0) {
				List<SqlTransaction2> trans = null;
				lock (_trans_lock)
					trans = _trans_tmp.FindAll(st2 => DateTime.Now.Subtract(st2.RunTime) > st2.Timeout);
				foreach (SqlTransaction2 tran in trans)
					CommitTransaction(true, tran);
			}
		}
		private void CommitTransaction(bool isCommit, SqlTransaction2 tran) {
			if (tran == null || tran.Transaction == null || tran.Transaction.Connection == null) return;

			lock (_trans_lock) {
				_trans.Remove(tran.Conn.ThreadId);
				_trans_tmp.Remove(tran);
			}

			try {
				if (isCommit)
					tran.Transaction.Commit();
				else
					tran.Transaction.Rollback();
				this.Pool.ReleaseConnection(tran.Conn);
			} catch { }
		}
		private void CommitTransaction(bool isCommit) {
			int tid = Thread.CurrentThread.ManagedThreadId;

			if (_trans.ContainsKey(tid))
				CommitTransaction(isCommit, _trans[tid]);
		}
		/// <summary>
		/// 提交事务
		/// </summary>
		public void CommitTransaction() {
			CommitTransaction(true);
		}
		/// <summary>
		/// 回滚事务
		/// </summary>
		public void RollbackTransaction() {
			CommitTransaction(false);
		}

		public void Dispose() {
			SqlTransaction2[] trans = null;
			lock (_trans_lock)
				trans = _trans_tmp.ToArray();
			foreach (SqlTransaction2 tran in trans)
				CommitTransaction(false, tran);
		}
		#endregion

		public static NpgsqlRange<T> ParseNpgsqlRange<T>(string s) {
			if (string.IsNullOrEmpty(s) || s == "empty") return NpgsqlRange<T>.Empty();
			string s1 = s.Trim('(', ')', '[', ']');
			string[] ss = s1.Split(new char[] { ',' }, 2);
			if (ss.Length != 2) return NpgsqlRange<T>.Empty();
			T t1 = default(T);
			T t2 = default(T);
			if (!string.IsNullOrEmpty(ss[0])) t1 = (T)Convert.ChangeType(ss[0], typeof(T));
			if (!string.IsNullOrEmpty(ss[1])) t2 = (T)Convert.ChangeType(ss[1], typeof(T));
			return new NpgsqlRange<T>(t1, s[0] == '[', s[0] == '(', t2, s[s.Length - 1] == ']', s[s.Length - 1] == ')');
		}
		/// <summary>
		/// 将 1010101010 这样的二进制字符串转换成 BitArray
		/// </summary>
		/// <param name="_1010">1010101010</param>
		/// <returns></returns>
		public static BitArray Parse1010(string _1010) {
			BitArray ret = new BitArray(_1010.Length);
			for (int a = 0; a < _1010.Length; a++) ret[a] = _1010[a] == '1';
			return ret;
		}
	}
}

public static partial class Npgsql_ExtensionMethods {
	public static string To1010(this BitArray ba) {
		char[] ret = new char[ba.Length];
		for (int a = 0; a < ba.Length; a++) ret[a] = ba[a] ? '1' : '0';
		return ret.ToString();
	}
}