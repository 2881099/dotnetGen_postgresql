using System;
using System.Collections.Generic;
using System.Threading;
using System.Text.RegularExpressions;
using Microsoft.Extensions.Logging;

namespace Npgsql {
	/// <summary>
	/// 数据库链接池
	/// </summary>
	public partial class ConnectionPool {

		public int MaxPoolSize = 32;
		public List<Connection2> AllConnections = new List<Connection2>();
		public Queue<Connection2> FreeConnections = new Queue<Connection2>();
		public Queue<ManualResetEvent> GetConnectionQueue = new Queue<ManualResetEvent>();
		private static object _lock = new object();
		private static object _lock_GetConnectionQueue = new object();
		private string _connectionString;
		public string ConnectionString {
			get { return _connectionString; }
			set {
				_connectionString = value;
				if (string.IsNullOrEmpty(_connectionString)) return;
				Match m = Regex.Match(_connectionString, @"Maximum\s*pool\s*size\s*=\s*(\d+)", RegexOptions.IgnoreCase);
				if (m.Success) int.TryParse(m.Groups[1].Value, out MaxPoolSize);
				else MaxPoolSize = 32;
				if (MaxPoolSize <= 0) MaxPoolSize = 32;
			}
		}

		public ConnectionPool(string connectionString) {
			ConnectionString = connectionString;
		}

		public Connection2 GetConnection() {
			Connection2 conn = null;
			if (FreeConnections.Count > 0)
				lock (_lock)
					if (FreeConnections.Count > 0)
						conn = FreeConnections.Dequeue();
			if (conn == null && AllConnections.Count < MaxPoolSize) {
				lock (_lock)
					if (AllConnections.Count < MaxPoolSize) {
						conn = new Connection2();
						AllConnections.Add(conn);
					}
				if (conn != null) {
					conn.ThreadId = Thread.CurrentThread.ManagedThreadId;
					conn.SqlConnection = new NpgsqlConnection(ConnectionString);
				}
			}
			if (conn == null) {
				ManualResetEvent wait = new ManualResetEvent(false);
				lock (_lock_GetConnectionQueue)
					GetConnectionQueue.Enqueue(wait);
				if (wait.WaitOne(TimeSpan.FromSeconds(10)))
					return GetConnection();
				return null;
			}
			conn.ThreadId = Thread.CurrentThread.ManagedThreadId;
			conn.LastActive = DateTime.Now;
			Interlocked.Increment(ref conn.UseSum);
			return conn;
		}

		public void ReleaseConnection(Connection2 conn) {
			conn.SqlConnection.Close();
			lock (_lock)
				FreeConnections.Enqueue(conn);

			if (GetConnectionQueue.Count > 0) {
				ManualResetEvent wait = null;
				lock (_lock_GetConnectionQueue)
					if (GetConnectionQueue.Count > 0)
						wait = GetConnectionQueue.Dequeue();
				if (wait != null) wait.Set();
			}
		}
	}

	public class Connection2 {
		public NpgsqlConnection SqlConnection;
		public DateTime LastActive;
		public long UseSum;
		internal int ThreadId;
	}
}