using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using NpgsqlTypes;

namespace Npgsql {
	partial class Executer {
		async public Task ExecuteReaderAsync(Func<NpgsqlDataReader, Task> readerHander, CommandType cmdType, string cmdText, params NpgsqlParameter[] cmdParms) {
			DateTime dt = DateTime.Now;
			NpgsqlCommand cmd = new NpgsqlCommand();
			string logtxt = "";
			DateTime logtxt_dt = DateTime.Now;
			var pc = PrepareCommand(cmd, cmdType, cmdText, cmdParms, ref logtxt);
			if (IsTracePerformance) logtxt += $"PrepareCommand: {DateTime.Now.Subtract(logtxt_dt).TotalMilliseconds}ms Total: {DateTime.Now.Subtract(dt).TotalMilliseconds}ms\r\n";
			Exception ex = null;
			try {
				if (IsTracePerformance) logtxt_dt = DateTime.Now;
				if (cmd.Connection.State == ConnectionState.Closed) await cmd.Connection.OpenAsync();
				if (IsTracePerformance) {
					logtxt += $"Open: {DateTime.Now.Subtract(logtxt_dt).TotalMilliseconds}ms Total: {DateTime.Now.Subtract(dt).TotalMilliseconds}ms\r\n";
					logtxt_dt = DateTime.Now;
				}
				NpgsqlDataReader dr = await cmd.ExecuteReaderAsync() as NpgsqlDataReader;
				if (IsTracePerformance) logtxt += $"ExecuteReader: {DateTime.Now.Subtract(logtxt_dt).TotalMilliseconds}ms Total: {DateTime.Now.Subtract(dt).TotalMilliseconds}ms\r\n";
				while (true) {
					if (IsTracePerformance) logtxt_dt = DateTime.Now;
					bool isread = await dr.ReadAsync();
					if (IsTracePerformance) logtxt += $"	dr.Read: {DateTime.Now.Subtract(logtxt_dt).TotalMilliseconds}ms Total: {DateTime.Now.Subtract(dt).TotalMilliseconds}ms\r\n";
					if (isread == false) break;

					if (readerHander != null) {
						object[] values = null;
						if (IsTracePerformance) {
							logtxt_dt = DateTime.Now;
							values = new object[dr.FieldCount];
							for (int a = 0; a < values.Length; a++) values[a] = await dr.GetFieldValueAsync<object>(a);
							logtxt += $"	dr.GetValues: {DateTime.Now.Subtract(logtxt_dt).TotalMilliseconds}ms Total: {DateTime.Now.Subtract(dt).TotalMilliseconds}ms\r\n";
							logtxt_dt = DateTime.Now;
						}
						await readerHander(dr);
						if (IsTracePerformance) logtxt += $"	readerHander: {DateTime.Now.Subtract(logtxt_dt).TotalMilliseconds}ms Total: {DateTime.Now.Subtract(dt).TotalMilliseconds}ms ({string.Join(",", values)})\r\n";
					}
				}
				if (IsTracePerformance) logtxt_dt = DateTime.Now;
				dr.Dispose();
				if (IsTracePerformance) logtxt += $"ExecuteReader_dispose: {DateTime.Now.Subtract(logtxt_dt).TotalMilliseconds}ms Total: {DateTime.Now.Subtract(dt).TotalMilliseconds}ms\r\n";
			} catch (Exception ex2) {
				ex = ex2;
			}

			if (IsTracePerformance) logtxt_dt = DateTime.Now;
			if (pc.Tran == null) this.Pool.ReleaseConnection(pc.Conn);
			if (IsTracePerformance) logtxt += $"ReleaseConnection: {DateTime.Now.Subtract(logtxt_dt).TotalMilliseconds}ms Total: {DateTime.Now.Subtract(dt).TotalMilliseconds}ms";
			LoggerException(cmd, ex, dt, logtxt);
		}
		async public Task<object[][]> ExeucteArrayAsync(CommandType cmdType, string cmdText, params NpgsqlParameter[] cmdParms) {
			List<object[]> ret = new List<object[]>();
			await ExecuteReaderAsync(async dr => {
				object[] values = new object[dr.FieldCount];
				for (int a = 0; a < values.Length; a++) values[a] = await dr.GetFieldValueAsync<object>(a);
				ret.Add(values);
			}, cmdType, cmdText, cmdParms);
			return ret.ToArray();
		}
		async public Task<int> ExecuteNonQueryAsync(CommandType cmdType, string cmdText, params NpgsqlParameter[] cmdParms) {
			DateTime dt = DateTime.Now;
			NpgsqlCommand cmd = new NpgsqlCommand();
			string logtxt = "";
			var pc = PrepareCommand(cmd, cmdType, cmdText, cmdParms, ref logtxt);
			int val = 0;
			Exception ex = null;
			try {
				if (cmd.Connection.State == ConnectionState.Closed) await cmd.Connection.OpenAsync();
				val = await cmd.ExecuteNonQueryAsync();
			} catch (Exception ex2) {
				ex = ex2;
			}

			if (pc.Tran == null) this.Pool.ReleaseConnection(pc.Conn);
			LoggerException(cmd, ex, dt, "");
			cmd.Parameters.Clear();
			return val;
		}
		async public Task<object> ExecuteScalarAsync(CommandType cmdType, string cmdText, params NpgsqlParameter[] cmdParms) {
			DateTime dt = DateTime.Now;
			NpgsqlCommand cmd = new NpgsqlCommand();
			string logtxt = "";
			var pc = PrepareCommand(cmd, cmdType, cmdText, cmdParms, ref logtxt);
			object val = null;
			Exception ex = null;
			try {
				if (cmd.Connection.State == ConnectionState.Closed) await cmd.Connection.OpenAsync();
				val = await cmd.ExecuteScalarAsync();
			} catch (Exception ex2) {
				ex = ex2;
			}

			if (pc.Tran == null) this.Pool.ReleaseConnection(pc.Conn);
			LoggerException(cmd, ex, dt, "");
			cmd.Parameters.Clear();
			return val;
		}
	}
}
