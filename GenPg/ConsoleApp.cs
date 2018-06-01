using Model;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Threading;

namespace GenPg {
	public class ConsoleApp {

		ClientInfo _client;
		ClientSocket _socket;
		public string ConnectionString {
			get {
				string connStr = "Host={0};Port={1};Username={2};Password={3};Database={4};";
				return string.Format(connStr, this._client.Server, this._client.Port, this._client.Username, this._client.Password, this._client.Database);
			}
		}
		public string Server;
		public int Port;
		public string Username;
		public string Password;
		public string Database;

		public string SolutionName;
		public bool IsMakeSolution;
		public bool IsMakeWebAdmin;
		public bool IsDownloadRes;
		public string OutputPath;

		public ConsoleApp(string[] args, ManualResetEvent wait) {
			this.OutputPath = AppContext.BaseDirectory;
			string args0 = args[0].Trim().ToLower();
			if (args[0] == "?" || args0 == "--help" || args0 == "-help") {
				Console.WriteLine(@"
## .NETCore 2.1 + PostgreSQL 生成器 ##

用于快速创建和更新 .NETCore 2.1 + PostgreSQL 项目，非常合适敏捷开发；
Github: https://github.com/2881099/dotnetgen_postgresql

Example：

	> GenPg 127.0.0.1[:5432] -U postgres -P 123456 -D dyschool -N dyschool -S -A -R

		-U	PostgreSQL账号
		-P	PostgreSQL密码
		-D	需要生成的数据库

		-N	字符串，生成代码的解决方案名和命名空间
		-S	生成解决方案，在项目第一次生成时使用
		-A	生成后台管理
		-R	下载资源
		
		-O	输出路径(默认:当前目录)");
				wait.Set();
				return;
			}
			string[] ss = args[0].Split(new char[] { ':' }, 2);
			this.Server = ss[0];
			if (int.TryParse(ss.Length == 2 ? ss[1] : "5432", out this.Port) == false) this.Port = 5432;
			for (int a = 1; a < args.Length; a++) {
				switch (args[a]) {
					case "-U":
						if (a + 1 >= args.Length) Console.WriteLine("-U 参数错误");
						else this.Username = args[a + 1];
						a++;
						break;
					case "-P":
						if (a + 1 >= args.Length) Console.WriteLine("-P 参数错误");
						else this.Password = args[a + 1];
						a++;
						break;
					case "-D":
						if (a + 1 >= args.Length) Console.WriteLine("-D 参数错误");
						else this.Database = args[a + 1];
						a++;
						break;
					case "-N":
						if (a + 1 >= args.Length) Console.WriteLine("-N 参数错误");
						else this.SolutionName = args[a + 1];
						a++;
						break;
					case "-O":
						if (a + 1 >= args.Length) Console.WriteLine("-O 参数错误");
						else this.OutputPath = args[a + 1];
						a++;
						break;
					case "-S":
						this.IsMakeSolution = true;
						break;
					case "-A":
						this.IsMakeWebAdmin = true;
						break;
					case "-R":
						this.IsDownloadRes = true;
						break;
				}
			}
			this._client = new ClientInfo(this.Server, this.Port, this.Username, this.Password);
			StreamReader sr = new StreamReader(System.Net.WebRequest.Create("https://files.cnblogs.com/files/kellynic/GenPg_server.css").GetResponse().GetResponseStream(), Encoding.UTF8);
			string server = sr.ReadToEnd()?.Trim();
			//server = "127.0.0.1:38888";
			Uri uri = new Uri("tcp://" + server + "/");
			this._socket = new ClientSocket();
			this._socket.Error += Socket_OnError;
			this._socket.Receive += Socket_OnReceive;
			this._socket.Connect(uri.Host, uri.Port);
			Thread.CurrentThread.Join(TimeSpan.FromSeconds(1));
			if (this._socket.Running == false) {
				wait.Set();
				return;
			}

			SocketMessager messager = new SocketMessager("GetDatabases", this._client);
			this._socket.Write(messager, delegate (object sender2, ClientSocketReceiveEventArgs e2) {
				List<DatabaseInfo> dbs = e2.Messager.Arg as List<DatabaseInfo>;
			});
			this._client.Database = this.Database;
			List<TableInfo> tables = null;
			messager = new SocketMessager("GetTablesByDatabase", this._client.Database);
			this._socket.Write(messager, delegate (object sender2, ClientSocketReceiveEventArgs e2) {
				tables = e2.Messager.Arg as List<TableInfo>;
			});
			if (tables == null) {
				Console.WriteLine("[" + DateTime.Now.ToString("MM-dd HH:mm:ss") + "] 无法读取表");
				this._socket.Close();
				this._socket.Dispose();

				wait.Set();
				return;
			}
			tables.ForEach(a => a.IsOutput = true);
			List<BuildInfo> bs = null;
			messager = new SocketMessager("Build", new object[] {
				SolutionName,
				IsMakeSolution,
				string.Join("", tables.ConvertAll<string>(delegate(TableInfo table){
					return string.Concat(table.IsOutput ? 1 : 0);
				}).ToArray()),
				IsMakeWebAdmin,
				IsDownloadRes
			});
			this._socket.Write(messager, delegate (object sender2, ClientSocketReceiveEventArgs e2) {
				bs = e2.Messager.Arg as List<BuildInfo>;
				if (e2.Messager.Arg is Exception) throw e2.Messager.Arg as Exception;
			}, TimeSpan.FromSeconds(60 * 5));
			if (bs != null) {
				foreach (BuildInfo b in bs) {
					string path = Path.Combine(OutputPath, b.Path);
					Directory.CreateDirectory(Path.GetDirectoryName(path));
					string fileName = Path.GetFileName(b.Path);
					string ext = Path.GetExtension(b.Path);
					Encoding encode = Encoding.UTF8;

					if (fileName.EndsWith(".rar") || fileName.EndsWith(".zip") || fileName.EndsWith(".dll")) {
						using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write)) {
							fs.Write(b.Data, 0, b.Data.Length);
							fs.Close();
						}
						continue;
					}

					byte[] data = Deflate.Decompress(b.Data);
					string content = Encoding.UTF8.GetString(data);

					if (string.Compare(fileName, "web.config") == 0) {
						string place = System.Web.HttpUtility.HtmlEncode(this.ConnectionString);
						content = content.Replace("{connectionString}", place);
					}
					if (fileName.EndsWith(".json")) {
						content = content.Replace("{connectionString}", this.ConnectionString);
					}
					if (string.Compare(ext, ".refresh") == 0) {
						encode = Encoding.Unicode;
					}
					using (StreamWriter sw = new StreamWriter(path, false, encode)) {
						sw.Write(content);
						sw.Close();
					}
				}
			}
			this._socket.Close();
			this._socket.Dispose();
			GC.Collect();

			ConsoleColor fc = Console.ForegroundColor;
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("[" + DateTime.Now.ToString("MM-dd HH:mm:ss") + "] The code files be maked in \"" + OutputPath + "\", please check.");
			Console.ForegroundColor = fc;
			wait.Set();
		}
		private void Socket_OnError(object sender, ClientSocketErrorEventArgs e) {
			Console.WriteLine("[" + DateTime.Now.ToString("MM-dd HH:mm:ss") + "] " + e.Exception.Message);
		}

		private void Socket_OnReceive(object sender, ClientSocketReceiveEventArgs e) {
			SocketMessager messager = null;
			switch (e.Messager.Action) {
				case "ExecuteDataSet":
					string sql = e.Messager.Arg.ToString();
					object[][] ds = null;
					try {
						ds = ConsoleApp.ExecuteDataSet(this.ConnectionString, sql);
					} catch (Exception ex) {
						this.Socket_OnError(this, new ClientSocketErrorEventArgs(ex, 0));
					}
					messager = new SocketMessager(e.Messager.Action, ds);
					messager.Id = e.Messager.Id;
					this._socket.Write(messager);
					break;
				case "ExecuteNonQuery":
					string sql2 = e.Messager.Arg.ToString();
					int val = 0;
					try {
						val = ConsoleApp.ExecuteNonQuery(this.ConnectionString, sql2);
					} catch (Exception ex) {
						this.Socket_OnError(this, new ClientSocketErrorEventArgs(ex, 0));
					}
					messager = new SocketMessager(e.Messager.Action, val);
					messager.Id = e.Messager.Id;
					this._socket.Write(messager);
					break;
				default:
					Console.WriteLine("[" + DateTime.Now.ToString("MM-dd HH:mm:ss") + "] " + "您当前使用的版本未能实现功能！");
					break;
			}
		}

		public static int ExecuteNonQuery(string connectionString, string cmdText) {
			int val = 0;
			using (NpgsqlConnection conn = new NpgsqlConnection(connectionString)) {
				NpgsqlCommand cmd = new NpgsqlCommand(cmdText, conn);
				try {
					cmd.Connection.Open();
					val = cmd.ExecuteNonQuery();
				} catch {
					cmd.Parameters.Clear();
					cmd.Connection.Close();
					throw;
				}
			}
			return val;
		}
		public static object[][] ExecuteDataSet(string connectionString, string cmdText) {
			List<object[]> ret = new List<object[]>();
			using (NpgsqlConnection conn = new NpgsqlConnection(connectionString)) {
				NpgsqlCommand cmd = new NpgsqlCommand(cmdText, conn);
				try {
					cmd.Connection.Open();
					using (var dr = cmd.ExecuteReader()) {
						while(dr.Read()) {
							object[] vals = new object[dr.FieldCount];
							dr.GetValues(vals);
							ret.Add(vals);
						}
					}
				} catch {
					cmd.Parameters.Clear();
					cmd.Connection.Close();
					throw;
				}
				cmd.Connection.Close();
				cmd.Parameters.Clear();
			}
			return ret.ToArray();
		}
	}
}
