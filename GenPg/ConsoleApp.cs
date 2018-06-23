﻿using Model;
using Newtonsoft.Json.Linq;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
			this.OutputPath = Directory.GetCurrentDirectory();
			string args0 = args[0].Trim().ToLower();
			if (args[0] == "?" || args0 == "--help" || args0 == "-help") {
				var bgcolor = Console.BackgroundColor;
				var fgcolor = Console.ForegroundColor;

				Console.BackgroundColor = ConsoleColor.DarkCyan;
				Console.ForegroundColor = ConsoleColor.White;
				Console.Write("##");
				Console.Write("######################################");
				Console.Write("##");
				Console.BackgroundColor = bgcolor;
				Console.ForegroundColor = fgcolor;
				Console.WriteLine("");

				Console.BackgroundColor = ConsoleColor.DarkCyan;
				Console.ForegroundColor = ConsoleColor.White;
				Console.Write("##");
				Console.BackgroundColor = ConsoleColor.DarkCyan;
				Console.ForegroundColor = ConsoleColor.DarkRed;
				Console.Write("                                      ");
				Console.BackgroundColor = ConsoleColor.DarkCyan;
				Console.ForegroundColor = ConsoleColor.White;
				Console.Write("##");
				Console.BackgroundColor = bgcolor;
				Console.ForegroundColor = fgcolor;
				Console.WriteLine("");

				Console.BackgroundColor = ConsoleColor.DarkCyan;
				Console.ForegroundColor = ConsoleColor.White;
				Console.Write("##");
				Console.BackgroundColor = ConsoleColor.DarkCyan;
				Console.ForegroundColor = ConsoleColor.DarkRed;
				Console.Write("   .NETCore 2.1 + PostgreSQL 生成器   ");
				Console.BackgroundColor = ConsoleColor.DarkCyan;
				Console.ForegroundColor = ConsoleColor.White;
				Console.Write("##");
				Console.BackgroundColor = bgcolor;
				Console.ForegroundColor = fgcolor;
				Console.WriteLine("");

				Console.BackgroundColor = ConsoleColor.DarkCyan;
				Console.ForegroundColor = ConsoleColor.White;
				Console.Write("##");
				Console.BackgroundColor = ConsoleColor.DarkCyan;
				Console.ForegroundColor = ConsoleColor.DarkRed;
				Console.Write("                                      ");
				Console.BackgroundColor = ConsoleColor.DarkCyan;
				Console.ForegroundColor = ConsoleColor.White;
				Console.Write("##");
				Console.BackgroundColor = bgcolor;
				Console.ForegroundColor = fgcolor;
				Console.WriteLine("");

				Console.BackgroundColor = ConsoleColor.DarkCyan;
				Console.ForegroundColor = ConsoleColor.White;
				Console.Write("##");
				Console.Write("######################################");
				Console.Write("##");

				Console.BackgroundColor = bgcolor;
				Console.ForegroundColor = ConsoleColor.DarkCyan;
				Console.Write(@"

用于快速创建和更新 .NETCore 2.1 + PostgreSQL 项目，非常合适敏捷开发；
Github: https://github.com/2881099/dotnetgen_postgresql

");
				Console.ForegroundColor = ConsoleColor.DarkCyan;
				Console.Write("Example：");
				Console.ForegroundColor = fgcolor;
				Console.WriteLine(@"

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
				var appsettingsPath = Path.Combine(OutputPath, "appsettings.json");
				var appsettingsPathWebHost = Path.Combine(OutputPath, @"src\WebHost\appsettings.json");
				//如果三个选项为false，并且 src\WebHost\appsettings.json 不存在，则在当前目录使用 appsettings.json
				if (this.IsDownloadRes == false && this.IsMakeSolution == false && this.IsMakeWebAdmin == false && File.Exists(appsettingsPathWebHost) == false) {
					var appsettings = Newtonsoft.Json.JsonConvert.DeserializeObject(File.Exists(appsettingsPath) ? File.ReadAllText(appsettingsPath) : "{}") as JToken;
					var oldtxt = appsettings.ToString();
					if (appsettings["ConnectionStrings"] == null) appsettings["ConnectionStrings"] = new JObject();
					if (appsettings["ConnectionStrings"][$"{this.SolutionName}_npgsql"] == null) appsettings["ConnectionStrings"][$"{this.SolutionName}_npgsql"] = this.ConnectionString + "Pooling=true;Maximum Pool Size=100";
					if (appsettings["ConnectionStrings"]["redis1"] == null) appsettings["ConnectionStrings"]["redis1"] = $"127.0.0.1:6379,password=,defaultDatabase=13,poolsize=10,ssl=false,writeBuffer=20480,prefix={this.SolutionName}";
					if (appsettings["ConnectionStrings"]["redis2"] == null) appsettings["ConnectionStrings"]["redis2"] = $"127.0.0.1:6379,password=,defaultDatabase=13,poolsize=10,ssl=false,writeBuffer=20480,prefix={this.SolutionName}";
					if (appsettings[$"{this.SolutionName}_BLL_ITEM_CACHE"] == null) appsettings[$"{this.SolutionName}_BLL_ITEM_CACHE"] = JToken.FromObject(new {
						Timeout = 180
					});
					if (appsettings["Logging"] == null) appsettings["Logging"] = new JObject();
					if (appsettings["Logging"]["IncludeScopes"] == null) appsettings["Logging"]["IncludeScopes"] = false;
					if (appsettings["Logging"]["LogLevel"] == null) appsettings["Logging"]["LogLevel"] = new JObject();
					if (appsettings["Logging"]["LogLevel"]["Default"] == null) appsettings["Logging"]["LogLevel"]["Default"] = "Debug";
					if (appsettings["Logging"]["LogLevel"]["System"] == null) appsettings["Logging"]["LogLevel"]["System"] = "Information";
					if (appsettings["Logging"]["LogLevel"]["Microsoft"] == null) appsettings["Logging"]["LogLevel"]["Microsoft"] = "Information";
					var newtxt = appsettings.ToString();
					if (newtxt != oldtxt) File.WriteAllText(appsettingsPath, newtxt, Encoding.UTF8);
					//增加当前目录 .csproj nuguet 引用 <PackageReference Include="dng.Pgsql" Version="1.1.3" />
					string csprojPath = Directory.GetFiles(OutputPath, "*.csproj").FirstOrDefault();
					if (!string.IsNullOrEmpty(csprojPath) && File.Exists(csprojPath)) {
						if (Regex.IsMatch(File.ReadAllText(csprojPath), @"dng\.Pgsql""\s+Version=""1\.1\.3", RegexOptions.IgnoreCase) == false) {
							System.Diagnostics.Process pro = new System.Diagnostics.Process();
							pro.StartInfo = new System.Diagnostics.ProcessStartInfo("dotnet", "add package dng.Pgsql --version 1.1.3") {
								WorkingDirectory = OutputPath
							};
							pro.Start();
							pro.WaitForExit();
						}
						if (Regex.IsMatch(File.ReadAllText(csprojPath), @"CSRedisCore""\s+Version=""2\.3\.4", RegexOptions.IgnoreCase) == false) {
							System.Diagnostics.Process pro = new System.Diagnostics.Process();
							pro.StartInfo = new System.Diagnostics.ProcessStartInfo("dotnet", "add package CSRedisCore --version 2.3.4") {
								WorkingDirectory = OutputPath
							};
							pro.Start();
							pro.WaitForExit();
						}
					}
					//向startup.cs注入代码
					string startupPath = Path.Combine(OutputPath, "Startup.cs");
					if (!string.IsNullOrEmpty(startupPath) && File.Exists(startupPath)) {

						//web项目才需要 Caching.CSRedis
						if (Regex.IsMatch(File.ReadAllText(csprojPath), @"Caching.CSRedis""\s+Version=""2\.3\.4", RegexOptions.IgnoreCase) == false) {
							System.Diagnostics.Process pro = new System.Diagnostics.Process();
							pro.StartInfo = new System.Diagnostics.ProcessStartInfo("dotnet", "add package Caching.CSRedis --version 2.3.4") {
								WorkingDirectory = OutputPath
							};
							pro.Start();
							pro.WaitForExit();
						}

						bool isChanged = false;
						var startupCode = File.ReadAllText(startupPath);
						if (Regex.IsMatch(startupCode, @"using\s+Microsoft\.Extensions\.Caching\.Distributed;") == false) {
							isChanged = true;
							startupCode = "using Microsoft.Extensions.Caching.Distributed;\r\n" + startupCode;
						}
						if (Regex.IsMatch(startupCode, @"using\s+Microsoft\.Extensions\.Logging;") == false) {
							isChanged = true;
							startupCode = "using Microsoft.Extensions.Logging;\r\n" + startupCode;
						}
						if (Regex.IsMatch(startupCode, @"using\s+Microsoft\.Extensions\.Configuration;") == false) {
							isChanged = true;
							startupCode = "using Microsoft.Extensions.Configuration;\r\n" + startupCode;
						}

						var servicesName = "services";
						if (startupCode.IndexOf("RedisHelper.Initialization") == -1) {
							startupCode = Regex.Replace(startupCode, @"[\t ]+public\s+void\s+ConfigureServices\s*\(\s*IServiceCollection\s+(\w+)[^\{]+\{", m => {
								isChanged = true;

								var connStr1 = @"Configuration[""ConnectionStrings:redis2""]";
								var connStr2 = @"Configuration[""ConnectionStrings:redis1""]";
								if (File.Exists(appsettingsPath) == false) {
									connStr1 = $"127.0.0.1:6379,password=,defaultDatabase=13,poolsize=50,ssl=false,writeBuffer=20480,prefix={this.SolutionName}";
									connStr2 = $"127.0.0.1:6379,password=,defaultDatabase=13,poolsize=50,ssl=false,writeBuffer=20480,prefix={this.SolutionName}";
								}

								return m.Groups[0].Value + $@"


			//单redis节点模式，如需开启集群负载，请将注释去掉并做相应配置
			RedisHelper.Initialization(
				csredis: new CSRedis.CSRedisClient(//null,
					//{connStr1},
					{connStr2}),
				serialize: value => Newtonsoft.Json.JsonConvert.SerializeObject(value),
				deserialize: (data, type) => Newtonsoft.Json.JsonConvert.DeserializeObject(data, type));
			{servicesName = m.Groups[1].Value}.AddSingleton<IDistributedCache>(new Microsoft.Extensions.Caching.Redis.CSRedisCache(RedisHelper.Instance));


";
							}, RegexOptions.Multiline);
						}
						if (Regex.IsMatch(startupCode, @"\s+IConfiguration(Root)?\s+Configuration(;|\s+\{)") == false) {
							startupCode = Regex.Replace(startupCode, @"[\t ]+public\s+void\s+ConfigureServices\s*\(\s*IServiceCollection\s+(\w+)[^\{]+\{", m => {
								isChanged = true;
								return $@"
		public IConfiguration Configuration {{ get; set; }}
{m.Groups[0].Value}

			Configuration = {servicesName = m.Groups[1].Value}.BuildServiceProvider().GetService<IConfiguration>();";
							}, RegexOptions.Multiline);
						}
						if (startupCode.IndexOf(this.SolutionName + ".BLL.PSqlHelper.Initialization") == -1) {
							startupCode = Regex.Replace(startupCode, @"([\t ]+public\s+void\s+Configure\s*\()([^\{]+)\{", m => {
								isChanged = true;
								var str1 = m.Groups[1].Value;
								var str2 = m.Groups[2].Value;
								var loggerFactory = Regex.Match(str2, @"\bILoggerFactory\s+(\w+)");
								if (loggerFactory.Success == false) str2 = "ILoggerFactory loggerFactory, " + str2;
								loggerFactory = Regex.Match(str2, @"\bILoggerFactory\s+(\w+)");
								var appName = Regex.Match(str2, @"\bIApplicationBuilder\s+(\w+)");
								if (appName.Success == false) str2 = "IApplicationBuilder app, " + str2;
								appName = Regex.Match(str2, @"\bIApplicationBuilder\s+(\w+)");

								var connStr = $@"Configuration[""ConnectionStrings:{this.SolutionName}_npgsql""]";
								if (File.Exists(appsettingsPath) == false) {
									connStr = $"{this.ConnectionString};Pooling=true;Maximum Pool Size=100";
								}

								return str1 + str2 + $@"{{

			
			{this.SolutionName}.BLL.PSqlHelper.Initialization({appName.Groups[1].Value}.ApplicationServices.GetService<IDistributedCache>(), Configuration.GetSection(""{this.SolutionName}_BLL_ITEM_CACHE""),
				{connStr}, {loggerFactory.Groups[1].Value}.CreateLogger(""{this.SolutionName}_DAL_psqlhelper""));


";
							}, RegexOptions.Multiline);
						}
						if (isChanged) File.WriteAllText(startupPath, startupCode);
					}
				}
				if (File.Exists(Path.Combine(OutputPath, "GenPg只更新db.bat")) == false) {
					var batPath = Path.Combine(OutputPath, $"GenPg_{this.SolutionName}_{this.Server}_{this.Database}.bat");
					if (File.Exists(batPath) == false) File.WriteAllText(batPath, $@"
GenPg {this.Server}:{this.Port} -U {this.Username} -P {this.Password} -D {this.Database} -N {this.SolutionName}");
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

