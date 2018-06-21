using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Model;

namespace Server {

	internal partial class CodeBuild {

		protected class CONST {
			public static readonly string corePath = @"src\";
			public static readonly string moduleAdminPath = @"src\Module\Admin\";
			public static readonly string webHostPath = @"src\WebHost\";
			public static readonly string sln =
			#region ����̫���ѱ�����
 @"
Microsoft Visual Studio Solution File, Format Version 12.00
# Visual Studio 14
VisualStudioVersion = 14.0.25420.1
MinimumVisualStudioVersion = 10.0.40219.1
Project(""{{2150E333-8FDC-42A3-9474-1A3956D46DE8}}"") = ""src"", ""src"", ""{{{1}}}""
EndProject
Project(""{{2150E333-8FDC-42A3-9474-1A3956D46DE8}}"") = ""Solution Items"", ""Solution Items"", ""{{{2}}}""
	ProjectSection(SolutionItems) = preProject
		build.bat = build.bat
		readme.md = readme.md
	EndProjectSection
EndProject
Project(""{{2150E333-8FDC-42A3-9474-1A3956D46DE8}}"") = ""Module"", ""Module"", ""{{{3}}}""
EndProject
Project(""{{2150E333-8FDC-42A3-9474-1A3956D46DE8}}"") = ""Test"", ""Test"", ""{{{4}}}""
EndProject
Project(""{{9A19103F-16F7-4668-BE54-9A1E7A4F7556}}"") = ""{0}.db"", ""src\{0}.db\{0}.db.csproj"", ""{{{6}}}""
EndProject
Project(""{{9A19103F-16F7-4668-BE54-9A1E7A4F7556}}"") = ""Infrastructure"", ""src\Infrastructure\Infrastructure.csproj"", ""{{{7}}}""
EndProject
Project(""{{9A19103F-16F7-4668-BE54-9A1E7A4F7556}}"") = ""WebHost"", ""src\WebHost\WebHost.csproj"", ""{{{8}}}""
EndProject
Project(""{{9A19103F-16F7-4668-BE54-9A1E7A4F7556}}"") = ""Admin"", ""src\Module\Admin\Admin.csproj"", ""{{{9}}}""
EndProject
Project(""{{9A19103F-16F7-4668-BE54-9A1E7A4F7556}}"") = ""Test"", ""src\Module\Test\Test.csproj"", ""{{{10}}}""
EndProject
Global
	GlobalSection(SolutionConfigurationPlatforms) = preSolution
		Debug|Any CPU = Debug|Any CPU
		Release|Any CPU = Release|Any CPU
	EndGlobalSection
	GlobalSection(ProjectConfigurationPlatforms) = postSolution
		{{{6}}}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{{{6}}}.Debug|Any CPU.Build.0 = Debug|Any CPU
		{{{6}}}.Release|Any CPU.ActiveCfg = Release|Any CPU
		{{{6}}}.Release|Any CPU.Build.0 = Release|Any CPU
		{{{7}}}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{{{7}}}.Debug|Any CPU.Build.0 = Debug|Any CPU
		{{{7}}}.Release|Any CPU.ActiveCfg = Release|Any CPU
		{{{7}}}.Release|Any CPU.Build.0 = Release|Any CPU
		{{{8}}}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{{{8}}}.Debug|Any CPU.Build.0 = Debug|Any CPU
		{{{8}}}.Release|Any CPU.ActiveCfg = Release|Any CPU
		{{{8}}}.Release|Any CPU.Build.0 = Release|Any CPU
		{{{9}}}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{{{9}}}.Debug|Any CPU.Build.0 = Debug|Any CPU
		{{{9}}}.Release|Any CPU.ActiveCfg = Release|Any CPU
		{{{9}}}.Release|Any CPU.Build.0 = Release|Any CPU
		{{{10}}}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{{{10}}}.Debug|Any CPU.Build.0 = Debug|Any CPU
		{{{10}}}.Release|Any CPU.ActiveCfg = Release|Any CPU
		{{{10}}}.Release|Any CPU.Build.0 = Release|Any CPU
	EndGlobalSection
	GlobalSection(SolutionProperties) = preSolution
		HideSolutionNode = FALSE
	EndGlobalSection
	GlobalSection(NestedProjects) = preSolution
		{{{3}}} = {{{1}}}
		{{{6}}} = {{{1}}}
		{{{7}}} = {{{1}}}
		{{{8}}} = {{{1}}}
		{{{9}}} = {{{3}}}
		{{{10}}} = {{{3}}}
	EndGlobalSection
EndGlobal
";
			#endregion

			public static readonly string DAL_DBUtility_PSqlHelper_cs =
			#region ����̫���ѱ�����
 @"using System;
using System.Collections;
using System.Data;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Npgsql;
using NpgsqlTypes;

namespace {0}.BLL {{
	/// <summary>
	/// ���ݿ���������࣬ȫ��֧��������
	/// </summary>
	public abstract partial class PSqlHelper : Npgsql.PSqlHelper {{

		new public static void Initialization(IDistributedCache cache, IConfiguration cacheStrategy, string connectionString, ILogger log) {{
			var nameTranslator = new NpgsqlMapNameTranslator();{2}
			Npgsql.PSqlHelper.Initialization(cache, cacheStrategy, connectionString, log);
		}}
		public class NpgsqlMapNameTranslator : INpgsqlNameTranslator {{
			public string TranslateMemberName(string clrName) => clrName;
			public string TranslateTypeName(string clrName) => clrName;
		}}
	}}
}}";
			#endregion
			public static readonly string BLL_Build_ItemCache_cs =
			#region ����̫���ѱ�����
 @"using System;
using System.Collections.Generic;

namespace {0}.BLL {{
	public partial class ItemCache {{

		private static Dictionary<string, long> _dic1 = new Dictionary<string, long>();
		private static Dictionary<long, Dictionary<string, string>> _dic2 = new Dictionary<long, Dictionary<string, string>>();
		private static LinkedList<long> _linked = new LinkedList<long>();
		private static object _dic1_lock = new object();
		private static object _dic2_lock = new object();
		private static object _linked_lock = new object();

		public static void Clear() {{
			lock(_dic1_lock) {{
				_dic1.Clear();
			}}
			lock(_dic2_lock) {{
				_dic2.Clear();
			}}
			lock(_linked_lock) {{
				_linked.Clear();
			}}
		}}
		public static void Remove(string key) {{
			if (string.IsNullOrEmpty(key)) return;
			long time;
			if (_dic1.TryGetValue(key, out time) == false) return;

			lock (_dic1_lock) {{
				_dic1.Remove(key);
			}}
			if (_dic2.ContainsKey(time)) {{
				lock (_dic2_lock) {{
					_dic2.Remove(time);
				}}
			}}
			lock (_linked_lock) {{
				_linked.Remove(time);
			}}
		}}
		public static string Get(string key) {{
			if (string.IsNullOrEmpty(key)) return null;
			long time;
			if (_dic1.TryGetValue(key, out time) == false) return null;
			Dictionary<string, string> dic;
			if (_dic2.TryGetValue(time, out dic) == false) {{
				if (_dic1.ContainsKey(key)) {{
					lock (_dic1_lock) {{
						_dic1.Remove(key);
					}}
				}}
				return null;
			}}
			if (DateTime.Now.Subtract(new DateTime(2016, 5, 1)).TotalSeconds > time) {{
				if (_dic1.ContainsKey(key)) {{
					lock (_dic1_lock) {{
						_dic1.Remove(key);
					}}
				}}
				if (_dic2.ContainsKey(time)) {{
					lock (_dic2_lock) {{
						_dic2.Remove(time);
					}}
				}}
				lock (_linked_lock) {{
					_linked.Remove(time);
				}}
				return null;
			}}
			string ret;
			if (dic.TryGetValue(key, out ret) == false) return null;
			return ret;
		}}
		public static void Set(string key, string value, int expire) {{
			if (string.IsNullOrEmpty(key) || expire <= 0) return;
			long time_cur = (long)DateTime.Now.Subtract(new DateTime(2016, 5, 1)).TotalSeconds;
			long time = time_cur + expire;
			long time2;
			if (_dic1.TryGetValue(key, out time2) == false) {{
				lock (_dic1_lock) {{
					if (_dic1.TryGetValue(key, out time2) == false) {{
						_dic1.Add(key, time2 = time);
					}}
				}}
			}}
			if (time2 != time) {{
				lock (_dic1_lock) {{
					_dic1[key] = time;
				}}
				lock (_dic2_lock) {{
					_dic2.Remove(time2);
				}}
			}}
			Dictionary<string, string> dic;
			bool isNew = false;
			if (_dic2.TryGetValue(time, out dic) == false) {{
				lock (_dic2_lock) {{
					if (_dic2.TryGetValue(time, out dic) == false) {{
						_dic2.Add(time, dic = new Dictionary<string, string>());
						isNew = true;
					}}
					if (dic.ContainsKey(key) == false) dic.Add(key, value);
					else dic[key] = value;
				}}
			}} else {{
				lock (_dic2_lock) {{
					if (dic.ContainsKey(key) == false) dic.Add(key, value);
					else dic[key] = value;
				}}
			}}
			if (isNew == true) {{
				lock (_linked_lock) {{
					if (_linked.Count == 0) {{
						_linked.AddFirst(time);
					}} else {{
						LinkedListNode<long> node = _linked.First;
						while (node != null) {{
							if (node.Value < time_cur) {{
								_linked.Remove(node);
								Dictionary<string, string> dic_del;
								if (_dic2.TryGetValue(node.Value, out dic_del)) {{
									lock (_dic2_lock) {{
										_dic2.Remove(node.Value);
										foreach (KeyValuePair<string, string> dic_del_in in dic_del) {{
											if (_dic1.ContainsKey(dic_del_in.Key)) {{
												lock (_dic1_lock) {{
													_dic1.Remove(dic_del_in.Key);
												}}
											}}
										}}
									}}
								}}
								node = _linked.First;
							}} else break;
						}}
						if (node == null)
							_linked.AddFirst(time);
						else if (node != null && _linked.Last.Value < time)
							_linked.AddLast(time);
						else {{
							while (node != null && node.Value < time) node = node.Next;
							if (node != null && node.Value != time) {{
								_linked.AddBefore(node, time);
							}}
						}}
					}}
				}}
			}}
		}}
	}}
}}";
			#endregion
			public static readonly string BLL_Build_CSRedisClient_cs =
			#region ����̫���ѱ�����
 @"using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace {0}.BLL {{

	public partial class CSRedisClient : CSRedis.CSRedisClient {{
		
		public static CSRedisClient Default {{ get; set; }}
		public CSRedisClient(string ip, int port = 6379, string pass = """", int poolsize = 50, int database = 0, string name = """")
			: base(ip, port, pass, poolsize, database, name) {{}}

		#region �����
		/// <summary>
		/// �����
		/// </summary>
		/// <typeparam name=""T"">��������</typeparam>
		/// <param name=""key"">����prefixǰ�</param>
		/// <param name=""timeoutSeconds"">��������</param>
		/// <param name=""getData"">��ȡԴ���ݵĺ���</param>
		/// <returns></returns>
		public T CacheShell<T>(string key, int timeoutSeconds, Func<T> getData) => CacheShell(key, timeoutSeconds, getData, data => Newtonsoft.Json.JsonConvert.SerializeObject(data), cacheValue => Newtonsoft.Json.JsonConvert.DeserializeObject<T>(cacheValue));
		/// <summary>
		/// �����(��ϣ��)
		/// </summary>
		/// <typeparam name=""T"">��������</typeparam>
		/// <param name=""key"">����prefixǰ�</param>
		/// <param name=""field"">�ֶ�</param>
		/// <param name=""timeoutSeconds"">��������</param>
		/// <param name=""getData"">��ȡԴ���ݵĺ���</param>
		/// <returns></returns>
		public T CacheShell<T>(string key, string field, int timeoutSeconds, Func<T> getData) => CacheShell(key, field, timeoutSeconds, getData, data => Newtonsoft.Json.JsonConvert.SerializeObject(data), cacheValue => Newtonsoft.Json.JsonConvert.DeserializeObject<(T, long)>(cacheValue));
		/// <summary>
		/// �����
		/// </summary>
		/// <typeparam name=""T"">��������</typeparam>
		/// <param name=""key"">����prefixǰ�</param>
		/// <param name=""timeoutSeconds"">��������</param>
		/// <param name=""getDataAsync"">��ȡԴ���ݵĺ���</param>
		/// <returns></returns>
		async public Task<T> CacheShellAsync<T>(string key, int timeoutSeconds, Func<Task<T>> getDataAsync) => await CacheShellAsync(key, timeoutSeconds, getDataAsync, data => Newtonsoft.Json.JsonConvert.SerializeObject(data), cacheValue => Newtonsoft.Json.JsonConvert.DeserializeObject<T>(cacheValue));
		/// <summary>
		/// �����(��ϣ��)
		/// </summary>
		/// <typeparam name=""T"">��������</typeparam>
		/// <param name=""key"">����prefixǰ�</param>
		/// <param name=""field"">�ֶ�</param>
		/// <param name=""timeoutSeconds"">��������</param>
		/// <param name=""getDataAsync"">��ȡԴ���ݵĺ���</param>
		/// <returns></returns>
		async public Task<T> CacheShellAsync<T>(string key, string field, int timeoutSeconds, Func<Task<T>> getDataAsync) => await CacheShellAsync(key, field, timeoutSeconds, getDataAsync, data => Newtonsoft.Json.JsonConvert.SerializeObject(data), cacheValue => Newtonsoft.Json.JsonConvert.DeserializeObject<(T, long)>(cacheValue));
		#endregion
	}}
}}

public static partial class {0}BLLExtensionMethods {{

}}
";
			#endregion
			public static readonly string Model_Build__ExtensionMethods_cs =
			#region ����̫���ѱ�����
 @"using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using NpgsqlTypes;
using {0}.Model;

public static partial class {0}ExtensionMethods {{
{1}
	public static IDictionary[] GetBson(IEnumerable items, Delegate func = null) {{
		List<IDictionary> ret = new List<IDictionary>();
		IEnumerator ie = items.GetEnumerator();
		while (ie.MoveNext()) {{
			if (ie.Current == null) ret.Add(null);
			else if (func == null) ret.Add(ie.Current.GetType().GetMethod(""ToBson"").Invoke(ie.Current, new object[] {{ false }}) as IDictionary);
			else {{
				object obj = func.GetMethodInfo().Invoke(func.Target, new object[] {{ ie.Current }});
				if (obj is IDictionary) ret.Add(obj as IDictionary);
				else {{
					Hashtable ht = new Hashtable();
					PropertyInfo[] pis = obj.GetType().GetProperties();
					foreach (PropertyInfo pi in pis) ht[pi.Name] = pi.GetValue(obj);
					ret.Add(ht);
				}}
			}}
		}}
		return ret.ToArray();
	}}
}}";
			#endregion

			public static readonly string Db_csproj =
			#region ����̫���ѱ�����
 @"<Project Sdk=""Microsoft.NET.Sdk"">
	<PropertyGroup>
		<TargetFramework>netstandard2.0</TargetFramework>
		<AssemblyName>{0}.db</AssemblyName>
	</PropertyGroup>
	<ItemGroup>
		<PackageReference Include=""dng.Pgsql"" Version=""1.1.1"" />
		<PackageReference Include=""CSRedisCore"" Version=""2.3.0"" />
	</ItemGroup>
</Project>
";
			#endregion

			public static readonly string Infrastructure_csproj =
			#region ����̫���ѱ�����
 @"<Project Sdk=""Microsoft.NET.Sdk"">
	<PropertyGroup>
		<TargetFramework>netstandard2.0</TargetFramework>
		<WarningLevel>3</WarningLevel>
	</PropertyGroup>
	<ItemGroup>
		<ProjectReference Include=""..\{0}.db\{0}.db.csproj"" />
	</ItemGroup>
	<ItemGroup>
		<PackageReference Include=""Caching.CSRedis"" Version=""2.3.0"" />
		<PackageReference Include=""Microsoft.AspNetCore.Mvc"" Version=""2.1.0"" />
		<PackageReference Include=""Microsoft.AspNetCore.Session"" Version=""2.1.0"" />
		<PackageReference Include=""Microsoft.AspNetCore.Diagnostics"" Version=""2.1.0"" />
		<PackageReference Include=""Microsoft.Extensions.Configuration.EnvironmentVariables"" Version=""2.1.0"" />
		<PackageReference Include=""Microsoft.Extensions.Configuration.FileExtensions"" Version=""2.1.0"" />
		<PackageReference Include=""Microsoft.Extensions.Configuration.Json"" Version=""2.1.0"" />
		<PackageReference Include=""NLog.Extensions.Logging"" Version=""1.1.0"" />
		<PackageReference Include=""NLog.Web.AspNetCore"" Version=""4.5.4"" />
		<PackageReference Include=""Swashbuckle.AspNetCore"" Version=""2.5.0"" />
		<PackageReference Include=""System.Text.Encoding.CodePages"" Version=""4.5.0"" />
	</ItemGroup>
</Project>
";
			#endregion

			public static readonly string WebHost_Extensions_StarupExtensions_cs =
			#region ����̫���ѱ�����
 @"using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.CodeAnalysis;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;

public static class StarupExtensions {{
	public static ConfigurationBuilder LoadInstalledModules(this ConfigurationBuilder build, IList<ModuleInfo> modules, IHostingEnvironment env) {{
		var moduleRootFolder = new DirectoryInfo(Path.Combine(env.ContentRootPath, ""Module""));
		var moduleFolders = moduleRootFolder.GetDirectories();

		foreach (var moduleFolder in moduleFolders) {{
			Assembly assembly;
			try {{
				assembly = AssemblyLoadContext.Default.LoadFromAssemblyPath(Path.Combine(moduleFolder.FullName, moduleFolder.Name + "".dll""));
			}} catch (FileLoadException) {{
				throw;
			}}
			if (assembly.FullName.Contains(moduleFolder.Name))
				modules.Add(new ModuleInfo {{
					Name = moduleFolder.Name,
					Assembly = assembly,
					Path = moduleFolder.FullName
				}});
		}}

		return build;
	}}

	public static ConfigurationBuilder AddCustomizedJsonFile(this ConfigurationBuilder build, IList<ModuleInfo> modules, IHostingEnvironment env, string productPath) {{
		build.SetBasePath(env.ContentRootPath).AddJsonFile(""appsettings.json"", true, true);
		foreach (var module in modules) {{
			var jsonpath = $""Module/{{module.Name}}/appsettings.json"";
			if (File.Exists(Path.Combine(env.ContentRootPath, jsonpath)))
				build.AddJsonFile(jsonpath, true, true);
		}}
		if (env.IsProduction()) {{
			build.AddJsonFile(Path.Combine(productPath, ""appsettings.json""), true, true);
			foreach (var module in modules) {{
				var jsonpath = Path.Combine(productPath, $""Module_{{module.Name}}_appsettings.json"");
				if (File.Exists(Path.Combine(env.ContentRootPath, jsonpath)))
					build.AddJsonFile(jsonpath, true, true);
			}}
		}}
		return build;
	}}

	public static IServiceCollection AddCustomizedMvc(this IServiceCollection services, IList<ModuleInfo> modules) {{
		var mvcBuilder = services.AddMvc().AddJsonOptions(a => {{
				a.SerializerSettings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());
				a.SerializerSettings.DateFormatHandling = Newtonsoft.Json.DateFormatHandling.IsoDateFormat;
				a.SerializerSettings.DateTimeZoneHandling = Newtonsoft.Json.DateTimeZoneHandling.Utc;
			}})
			.AddRazorOptions(o => {{
				foreach (var module in modules) {{
					var a = MetadataReference.CreateFromFile(module.Assembly.Location);
					o.AdditionalCompilationReferences.Add(a);
				}}
			}})
			.AddViewLocalization()
			.AddDataAnnotationsLocalization();

		foreach (var module in modules)
			mvcBuilder.AddApplicationPart(module.Assembly);

		return services;
	}}

	public static IApplicationBuilder UseCustomizedMvc(this IApplicationBuilder app, IList<ModuleInfo> modules) {{
		foreach (var module in modules) {{
			var moduleInitializerType =
				module.Assembly.GetTypes().FirstOrDefault(x => typeof(IModuleInitializer).IsAssignableFrom(x));
			if ((moduleInitializerType != null) && (moduleInitializerType != typeof(IModuleInitializer))) {{
				var moduleInitializer = (IModuleInitializer)Activator.CreateInstance(moduleInitializerType);
				moduleInitializer.Init(app);
			}}
		}}
		return app.UseMvc();
	}}
	public static IApplicationBuilder UseCustomizedStaticFiles(this IApplicationBuilder app, IList<ModuleInfo> modules) {{
		app.UseDefaultFiles();
		app.UseStaticFiles(new StaticFileOptions() {{
			OnPrepareResponse = (context) => {{
				var headers = context.Context.Response.GetTypedHeaders();
				headers.CacheControl = new CacheControlHeaderValue() {{
					Public = true,
					MaxAge = TimeSpan.FromDays(60)
				}};
			}}
		}});
		return app;
	}}
}}
";
			#endregion
			public static readonly string WebHost_Extensions_SwaggerExtensions_cs =
			#region ����̫���ѱ�����
 @"using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.IO;
using System.Linq;

namespace Swashbuckle.AspNetCore.Swagger {{
	public class FormDataOperationFilter : IOperationFilter {{
		public void Apply(Operation operation, OperationFilterContext context) {{
			var actattrs = context.ApiDescription.ActionAttributes();
			if (actattrs.OfType<HttpPostAttribute>().Any() ||
				actattrs.OfType<HttpPutAttribute>().Any())
				if (operation.Consumes.Count == 0)
					operation.Consumes.Add(""multipart/form-data"");
		}}
	}}

	public static class SwashbuckleSwaggerExtensions {{
		public static IServiceCollection AddCustomizedSwaggerGen(this IServiceCollection services) {{
			services.AddSwaggerGen(options => {{
				foreach (var doc in _docs) options.SwaggerDoc(doc, new Info {{ Version = doc }});
				options.DocInclusionPredicate((docName, apiDesc) => {{
					var versions = apiDesc.ControllerAttributes()
						.OfType<ApiExplorerSettingsAttribute>()
						.Select(attr => attr.GroupName);
					if (docName == ""δ����"" && versions.Count() == 0) return true;
					return versions.Any(v => v == docName);
				}});
				options.IgnoreObsoleteActions();
				//options.IgnoreObsoleteControllers(); // �ࡢ������� [Obsolete]��������ֹ��Swagger�ĵ�������
				options.DescribeAllEnumsAsStrings();
				options.CustomSchemaIds(a => a.FullName);
				options.OperationFilter<FormDataOperationFilter>();

				string root = Path.Combine(Directory.GetCurrentDirectory(), ""Module"");
				string xmlFile = string.Empty;
				string[] dirs = Directory.GetDirectories(root);
				foreach (var d in dirs) {{
					xmlFile = Path.Combine(d, $""{{new DirectoryInfo(d).Name}}.xml"");
					if (File.Exists(xmlFile))
						options.IncludeXmlComments(xmlFile); // ʹ��ǰ�迪����Ŀע�� xmldoc
				}}
				var InfrastructureXml = Directory.GetFiles(Directory.GetCurrentDirectory(), ""Infrastructure.xml"", SearchOption.AllDirectories);
				if (InfrastructureXml.Any())
					options.IncludeXmlComments(InfrastructureXml[0]);
			}});
			return services;
		}}
		static string[] _docs = new[] {{ ""δ����"", ""�����̨"", ""��������Ա��̨"", ""APP��̨"", ""����"", ""APP��̨_����"", ""����"", ""APP��̨_����"" }};
		public static IApplicationBuilder UseCustomizedSwagger(this IApplicationBuilder app, IHostingEnvironment env) {{
			return app.UseSwagger().UseSwaggerUI(options => {{
				foreach (var doc in _docs) options.SwaggerEndpoint($""/swagger/{{doc}}/swagger.json"", doc);
			}});
		}}
	}}
}}
";
			#endregion
			public static readonly string WebHost_nlog_config =
			#region ����̫���ѱ�����
 @"<?xml version=""1.0"" encoding=""utf-8"" ?>
<nlog xmlns=""http://www.nlog-project.org/schemas/NLog.xsd"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance""
	autoReload=""true""
	internalLogLevel=""Warn""
	internalLogFile=""internal-nlog.txt"">

	<!-- Load the ASP.NET Core plugin -->
	<extensions>
		<add assembly=""NLog.Web.AspNetCore""/>
	</extensions>

	<!-- Layout: https://github.com/NLog/NLog/wiki/Layout%20Renderers -->
	<targets>
		<target xsi:type=""File"" name=""allfile"" fileName=""../nlog/all-${{shortdate}}.log""
			layout=""${{longdate}}|${{logger}}|${{uppercase:${{level}}}}|${{message}} ${{exception}}|${{aspnet-Request-Url}}"" />

		<target xsi:type=""File"" name=""ownFile-web"" fileName=""../nlog/own-${{shortdate}}.log""
			layout=""${{longdate}}|${{logger}}|${{uppercase:${{level}}}}|  ${{message}} ${{exception}}|${{aspnet-Request-Url}}"" />

		<target xsi:type=""File"" name=""SQLExecuter"" fileName=""../nlog/SQLExecuter-${{shortdate}}.log""
			layout=""${{longdate}} ${{message}} ${{exception}}|${{aspnet-Request-Url}} ${{document-uri}} "" />

		<target xsi:type=""Null"" name=""blackhole"" />
	</targets>

	<rules>
		<logger name=""*"" minlevel=""Error"" writeTo=""allfile"" />
		<logger name=""Microsoft.*"" minlevel=""Error"" writeTo=""blackhole"" final=""true"" />
		<logger name=""*"" minlevel=""Error"" writeTo=""ownFile-web"" />
		<logger name=""{0}_DAL_psqlhelper"" minlevel=""Warn"" writeTo=""SQLExecuter"" />
	</rules>
</nlog>
";
			#endregion
			public static readonly string WebHost_appsettings_json =
			#region ����̫���ѱ�����
 @"{{
	""Logging"": {{
		""IncludeScopes"": false,
		""LogLevel"": {{
			""Default"": ""Debug"",
			""System"": ""Information"",
			""Microsoft"": ""Information""
		}}
	}},
	""ConnectionStrings"": {{
		""{0}_npgsql"": ""{{connectionString}};Pooling=true;Maximum Pool Size=100"",
		""redis"": {{
			""ip"": ""127.0.0.1"",
			""port"": 6379,
			""pass"": """",
			""database"": 13,
			""poolsize"": 50,
			""name"": ""{0}""
		}}
	}},
	""{0}_BLL_ITEM_CACHE"": {{
		""Timeout"": 180
	}}
}}
";
			#endregion
			public static readonly string WebHost_Program_cs =
			#region ����̫���ѱ�����
 @"using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace {0}.WebHost {{
	public class Program {{
		public static void Main(string[] args) {{
			var host = new WebHostBuilder()
				.UseUrls(""http://*:5000"", ""http://*:5001"")
				.UseKestrel()
				.UseContentRoot(Directory.GetCurrentDirectory())
				.UseIISIntegration()
				.UseStartup<Startup>()
				.Build();

			host.Run();
		}}
	}}
}}
";
			#endregion
			public static readonly string WebHost_Startup_cs =
			#region ����̫���ѱ�����
 @"using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.Text;

namespace {0}.WebHost {{
	public class Startup {{
		public Startup(IHostingEnvironment env) {{
			var builder = new ConfigurationBuilder()
				.LoadInstalledModules(Modules, env)
				.AddCustomizedJsonFile(Modules, env, ""/var/webos/{0}/"");

			this.Configuration = builder.AddEnvironmentVariables().Build();
			this.env = env;

			Newtonsoft.Json.JsonConvert.DefaultSettings = () => {{
				var st = new Newtonsoft.Json.JsonSerializerSettings();
				st.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());
				st.DateFormatHandling = Newtonsoft.Json.DateFormatHandling.IsoDateFormat;
				st.DateTimeZoneHandling = Newtonsoft.Json.DateTimeZoneHandling.RoundtripKind;
				return st;
			}};
			{0}.BLL.CSRedisClient.Default = new {0}.BLL.CSRedisClient(Configuration[""ConnectionStrings:redis:ip""],
				int.TryParse(Configuration[""ConnectionStrings:redis:port""], out var port) ? port : 6379, Configuration[""ConnectionStrings:redis:pass""], 
				int.TryParse(Configuration[""ConnectionStrings:redis:poolsize""], out var poolsize) ? poolsize : 50,
				int.TryParse(Configuration[""ConnectionStrings:redis:database""], out var database) ? database : 0, Configuration[""ConnectionStrings:redis:name""]);
		}}

		public static IList<ModuleInfo> Modules = new List<ModuleInfo>();
		public IConfiguration Configuration {{ get; }}
		public IHostingEnvironment env {{ get; }}

		public void ConfigureServices(IServiceCollection services) {{
			services.AddSingleton<IDistributedCache>(new Microsoft.Extensions.Caching.Redis.CSRedisCache({0}.BLL.CSRedisClient.Default));
			services.AddSingleton<IConfiguration>(Configuration);
			services.AddSingleton<IHostingEnvironment>(env);
			services.AddScoped<CustomExceptionFilter>();

			services.AddSession(a => {{
				a.IdleTimeout = TimeSpan.FromMinutes(30);
				a.Cookie.Name = ""Session_{0}"";
			}});
			services.AddCors(options => options.AddPolicy(""cors_all"", builder => builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()));
			services.AddCustomizedMvc(Modules);
			services.Configure<RazorViewEngineOptions>(options => {{ options.ViewLocationExpanders.Add(new ModuleViewLocationExpander()); }});

			if (env.IsDevelopment())
				services.AddCustomizedSwaggerGen();
		}}

		public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, IApplicationLifetime lifetime) {{
			Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
			Console.OutputEncoding = Encoding.GetEncoding(""GB2312"");
			Console.InputEncoding = Encoding.GetEncoding(""GB2312"");

			loggerFactory.AddConsole(Configuration.GetSection(""Logging""));
			loggerFactory.AddNLog().AddDebug();
			NLog.LogManager.LoadConfiguration(""nlog.config"");

			if (env.IsDevelopment())
				app.UseDeveloperExceptionPage();

			{0}.BLL.PSqlHelper.Initialization(app.ApplicationServices.GetService<IDistributedCache>(), Configuration.GetSection(""{0}_BLL_ITEM_CACHE""),
				Configuration[""ConnectionStrings:{0}_npgsql""], loggerFactory.CreateLogger(""{0}_DAL_psqlhelper""));

			app.UseSession();
			app.UseCors(""cors_all"");
			app.UseCustomizedMvc(Modules);
			app.UseCustomizedStaticFiles(Modules);

			if (env.IsDevelopment())
				app.UseCustomizedSwagger(env);
		}}
	}}
}}
";
			#endregion
			public static readonly string WebHost_csproj =
			#region ����̫���ѱ�����
 @"<Project Sdk=""Microsoft.NET.Sdk.Web"">
	<PropertyGroup>
		<TargetFramework>netcoreapp2.1</TargetFramework>
		<WarningLevel>3</WarningLevel>
		<PostBuildEvent>gulp --gulpfile ../../../gulpfile.js copy-module</PostBuildEvent>
	</PropertyGroup>
	<ItemGroup>
		<Folder Include=""wwwroot\"" />
		<Compile Remove=""Module\**"" />
		<Compile Remove=""wwwroot\module\**"" />
		<Content Remove=""Module\**"" />
		<Content Remove=""wwwroot\module\**"" />
		<EmbeddedResource Remove=""Module\**"" />
		<EmbeddedResource Remove=""wwwroot\module\**"" />
		<None Remove=""Module\**"" />
		<None Remove=""wwwroot\module\**"" />
		<Content Update=""nlog.config"">
			<CopyToOutputDirectory>Always</CopyToOutputDirectory>
		</Content>
	</ItemGroup>
	<ItemGroup>
		<ProjectReference Include=""..\Infrastructure\Infrastructure.csproj"" />
	</ItemGroup>
	<ItemGroup>
		<PackageReference Include=""Microsoft.AspNetCore.App"" />
	</ItemGroup>
</Project>
";
			#endregion

			public static readonly string Module_Admin_Controllers_SysController =
			#region ����̫���ѱ�����
 @"using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using {0}.BLL;
using {0}.Model;

namespace {0}.Module.Admin.Controllers {{
	[Route(""[controller]"")]
	[Obsolete]
	public class SysController : Controller {{
		[HttpGet(@""connection"")]
		public object Get_connection() {{
			List<Hashtable> ret = new List<Hashtable>();
			foreach (var conn in PSqlHelper.Instance.Pool.AllConnections) {{
				ret.Add(new Hashtable() {{
						{{ ""���ݿ�"", conn.SqlConnection.Database }},
						{{ ""״̬"", conn.SqlConnection.State }},
						{{ ""���"", conn.LastActive }},
						{{ ""��ȡ����"", conn.UseSum }}
					}});
			}}
			return new {{
				FreeConnections = PSqlHelper.Instance.Pool.FreeConnections.Count,
				AllConnections = PSqlHelper.Instance.Pool.AllConnections.Count,
				GetConnectionQueue = PSqlHelper.Instance.Pool.GetConnectionQueue.Count,
				GetConnectionAsyncQueue = PSqlHelper.Instance.Pool.GetConnectionAsyncQueue.Count,
				List = ret
			}};
		}}
		[HttpGet(@""connection/redis"")]
		public object Get_connection_redis() {{
			List<Hashtable> ret = new List<Hashtable>();
			foreach (var conn in CSRedisClient.Default.Pool.AllConnections) {{
				ret.Add(new Hashtable() {{
						{{ ""���"", conn.LastActive }},
						{{ ""��ȡ����"", conn.UseSum }}
					}});
			}}
			return new {{
				FreeConnections = CSRedisClient.Default.Pool.FreeConnections.Count,
				AllConnections = CSRedisClient.Default.Pool.AllConnections.Count,
				GetConnectionQueue = CSRedisClient.Default.Pool.GetConnectionQueue.Count,
				GetConnectionAsyncQueue = CSRedisClient.Default.Pool.GetConnectionAsyncQueue.Count,
				List = ret
			}};
		}}

		[HttpGet(@""init_sysdir"")]
		public APIReturn Get_init_sysdir() {{
			/*
			if (Sysdir.SelectByParent_id(null).Count() > 0)
				return new APIReturn(-33, ""��ϵͳ�Ѿ���ʼ������ҳ��û�����κβ����˳���"");

			SysdirInfo dir1, dir2, dir3;
			dir1 = Sysdir.Insert(null, DateTime.Now, ""��Ӫ����"", 1, null);{1}
			*/
			return new APIReturn(0, ""����Ŀ¼�ѳ�ʼ����ɡ�"");
		}}
	}}
}}
";
			#endregion
			public static readonly string Module_Admin_Controllers_LoginController =
			#region ����̫���ѱ�����
 @"using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using {0}.BLL;
using {0}.Model;

namespace {0}.Module.Admin.Controllers {{
	[Route(""[controller]"")]
	[Obsolete]
	public class LoginController : BaseController {{

		public LoginController(ILogger<LoginController> logger) : base(logger) {{ }}

		[HttpGet]
		[��������]
		public ViewResult Index() {{
			return View();
		}}
		[HttpPost]
		[��������]
		public APIReturn Post(LoginModel data) {{
			HttpContext.Session.SetString(""login.username"", data.Username);
			return APIReturn.�ɹ�;
		}}

		public class LoginModel {{
			[FromForm]
			[Required(ErrorMessage = ""�������½��"")]
			public string Username {{ get; set; }}

			[FromForm]
			[Required(ErrorMessage = ""����������"")]
			public string Password {{ get; set; }}
		}}
	}}
}}
";
			#endregion
			public static readonly string Module_Admin_Views_Login_Index_cshtml =
			#region ����̫���ѱ�����
 @"@{{
	Layout = """";
}}

<!DOCTYPE html>
<html>
<head>
	<meta charset=""utf-8"">
	<meta http-equiv=""X-UA-Compatible"" content=""IE=edge"">
	<title>{0}��̨�������� - ��½</title>
	<!-- Tell the browser to be responsive to screen width -->
	<meta content=""width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no"" name=""viewport"">
	<link rel=""stylesheet"" href=""/module/admin/htm/bootstrap/css/bootstrap.min.css"">
	<link rel=""stylesheet"" href=""/module/admin/htm/plugins/font-awesome/css/font-awesome.min.css"" />
	<link rel=""stylesheet"" href=""/module/admin/htm/css/system.css"">
	<script type=""text/javascript"" src=""/module/admin/htm/js/jQuery-2.1.4.min.js""></script>
	<script type=""text/javascript"" src=""/module/admin/htm/js/lib.js""></script>
	<!--[if lt IE 9]>
	<script type='text/javascript' src='/module/admin/htm/plugins/html5shiv/html5shiv.min.js'></script>
	<script type='text/javascript' src='/module/admin/htm/plugins/respond/respond.min.js'></script>
	<![endif]-->

<style type=""text/css"">
.login-box-body--has-errors{{animation:shake .5s .25s 1;-webkit-animation:shake .5s .25s 1}}
@@keyframes shake{{0%,100%{{transform:translateX(0)}}20%,60%{{transform:translateX(-10px)}}40%,80%{{transform:translateX(10px)}}}}
@@-webkit-keyframes shake{{0%,100%{{-webkit-transform:translateX(0)}}20%,60%{{-webkit-transform:translateX(-10px)}}40%,80%{{-webkit-transform:translateX(10px)}}}}
</style>

</head>
<body class=""hold-transition login-page"">
	<div class=""login-box"">
		<div class=""login-logo"">
			<a href=""/module/admin/""><b>{0}</b>��̨��������</a>
		</div>

		<div id=""error_msg"" style=""display:none;"">
			<div class=""alert alert-warning alert-dismissible"">
				<button type=""button"" class=""close"" data-dismiss=""alert"" aria-hidden=""true"">��</button>
				<h4><i class=""icon fa fa-warning""></i>����!</h4>
				{{0}}
			</div>
		</div>

		<!-- /.login-logo -->
		<div class=""login-box-body"">
			<p class=""login-box-msg""></p>

			<iframe name=""iframe_form_login"" hidden></iframe>
			<form id=""form_login"" method=""post"" target=""iframe_form_login"">
				@Html.AntiForgeryToken()
				<input type=""hidden"" name=""__callback"" value=""login_callback"" />
				<div class=""form-group has-feedback"">
					<input name=""username"" type=""text"" class=""form-control"" placeholder=""Username"">
					<span class=""glyphicon glyphicon-envelope form-control-feedback""></span>
				</div>
				<div class=""form-group has-feedback"">
					<input name=""password"" type=""password"" class=""form-control"" placeholder=""Password"">
					<span class=""glyphicon glyphicon-lock form-control-feedback""></span>
				</div>
				<div class=""row"">
					<div class=""col-xs-8"">
					</div>
					<!-- /.col -->
					<div class=""col-xs-4"">
						<button type=""submit"" class=""btn btn-primary btn-block btn-flat"">�� ½</button>
					</div>
					<!-- /.col -->
				</div>
			</form>

		</div>
		<!-- /.login-box-body -->
	</div>
	<!-- /.login-box -->

	<!-- jQuery 2.2.0 -->
	<script src=""/module/admin/htm/plugins/jQuery/jQuery-2.2.0.min.js""></script>
	<script src=""/module/admin/htm/bootstrap/js/bootstrap.min.js""></script>

<script type=""text/javascript"">
	(function () {{
		var msgtpl = $('#error_msg').html();
		top.login_callback = function (rt) {{
			if (rt.success) return location.href = '/module/admin/';
			$('#error_msg').html(msgtpl.format(rt.message)).show();
			$('div.login-box-body').addClass('login-box-body--has-errors');
			setTimeout(function () {{
				$('div.login-box-body').removeClass('login-box-body--has-errors');
			}}, 2000);
		}};
	}})();
</script>
</body>
</html>
";
			#endregion

			public static readonly string Module_Admin_Controller =
			#region ����̫���ѱ�����
			@"using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using NpgsqlTypes;
using {0}.BLL;
using {0}.Model;

namespace {0}.Module.Admin.Controllers {{
	[Route(""[controller]"")]
	public class {1}Controller : BaseController {{
		public {1}Controller(ILogger<{1}Controller> logger) : base(logger) {{ }}

		[HttpGet]
		async public Task<ActionResult> List([FromServices]IConfiguration cfg, {12}[FromQuery] int limit = 20, [FromQuery] int page = 1) {{
			var select = {19}{1}.Select{8};{9}
			long count;
			var items = await select.Count(out count){14}.Page(page, limit).ToListAsync();
			ViewBag.items = items;
			ViewBag.count = count;
			return View();
		}}

		[HttpGet(@""add"")]
		public ActionResult Edit() {{
			return View();
		}}
		[HttpGet(@""edit"")]
		async public Task<ActionResult> Edit({4}) {{
			{1}Info item = await {19}{1}.GetItemAsync({5});
			if (item == null) return APIReturn.��¼������_����û��Ȩ��;
			ViewBag.item = item;
			return View();
		}}

		/***************************************** POST *****************************************/
		[HttpPost(@""add"")]
		[ValidateAntiForgeryToken]
		async public Task<APIReturn> _Add({10}) {{
			{1}Info item = new {1}Info();{13}{7}
			item = await {19}{1}.InsertAsync(item);{16}
			return APIReturn.�ɹ�.SetData(""item"", item.ToBson());
		}}
		[HttpPost(@""edit"")]
		[ValidateAntiForgeryToken]
		async public Task<APIReturn> _Edit({4}{11}) {{
			{1}Info item = await {19}{1}.GetItemAsync({5});
			if (item == null) return APIReturn.��¼������_����û��Ȩ��;{6}{7}
			int affrows = await {19}{1}.UpdateAsync(item);{17}
			if (affrows > 0) return APIReturn.�ɹ�.SetMessage($""���³ɹ���Ӱ��������{{affrows}}"");
			return APIReturn.ʧ��;
		}}

		[HttpPost(""del"")]
		[ValidateAntiForgeryToken]{18}
	}}
}}
";
			#endregion
			public static readonly string Module_Admin_wwwroot_index_html =
			#region ����̫���ѱ�����
			@"<!DOCTYPE html>
<html lang=""zh-cmn-Hans"">
<head>
	<meta charset=""utf-8"" />
	<meta http-equiv=""X-UA-Compatible"" content=""IE=edge"" />
	<title>{0}����ϵͳ</title>
	<meta content=""width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no"" name=""viewport"" />
	<link href=""./htm/bootstrap/css/bootstrap.min.css"" rel=""stylesheet"" />
	<link href=""./htm/plugins/font-awesome/css/font-awesome.min.css"" rel=""stylesheet"" />
	<link href=""./htm/css/skins/_all-skins.css"" rel=""stylesheet"" />
	<link href=""./htm/plugins/pace/pace.min.css"" rel=""stylesheet"" />
	<link href=""./htm/plugins/datepicker/datepicker3.css"" rel=""stylesheet"" />
	<link href=""./htm/plugins/timepicker/bootstrap-timepicker.min.css"" rel=""stylesheet"" />
	<link href=""./htm/plugins/select2/select2.min.css"" rel=""stylesheet"" />
	<link href=""./htm/plugins/treetable/css/jquery.treetable.css"" rel=""stylesheet"" />
	<link href=""./htm/plugins/treetable/css/jquery.treetable.theme.default.css"" rel=""stylesheet"" />
	<link href=""./htm/plugins/multiple-select/multiple-select.css"" rel=""stylesheet"" />
	<link href=""./htm/css/system.css"" rel=""stylesheet"" />
	<link href=""./htm/css/index.css"" rel=""stylesheet"" />
	<script type=""text/javascript"" src=""./htm/js/jQuery-2.1.4.min.js""></script>
	<script type=""text/javascript"" src=""./htm/bootstrap/js/bootstrap.min.js""></script>
	<script type=""text/javascript"" src=""./htm/plugins/pace/pace.min.js""></script>
	<script type=""text/javascript"" src=""./htm/plugins/datepicker/bootstrap-datepicker.js""></script>
	<script type=""text/javascript"" src=""./htm/plugins/timepicker/bootstrap-timepicker.min.js""></script>
	<script type=""text/javascript"" src=""./htm/plugins/select2/select2.full.min.js""></script>
	<script type=""text/javascript"" src=""./htm/plugins/input-mask/jquery.inputmask.js""></script>
	<script type=""text/javascript"" src=""./htm/plugins/input-mask/jquery.inputmask.date.extensions.js""></script>
	<script type=""text/javascript"" src=""./htm/plugins/input-mask/jquery.inputmask.extensions.js""></script>
	<script type=""text/javascript"" src=""./htm/plugins/treetable/jquery.treetable.js""></script>
	<script type=""text/javascript"" src=""./htm/plugins/multiple-select/multiple-select.js""></script>
	<script type=""text/javascript"" src=""./htm/js/lib.js""></script>
	<script type=""text/javascript"" src=""./htm/js/bmw.js""></script>
	<!--[if lt IE 9]>
	<script type='text/javascript' src='./htm/plugins/html5shiv/html5shiv.min.js'></script>
	<script type='text/javascript' src='./htm/plugins/respond/respond.min.js'></script>
	<![endif]-->
</head>
<body class=""hold-transition skin-blue sidebar-mini"">
	<div class=""wrapper"">
		<!-- Main Header-->
		<header class=""main-header"">
			<!-- Logo--><a href=""./"" class=""logo"">
				<!-- mini logo for sidebar mini 50x50 pixels--><span class=""logo-mini""><b>{0}</b></span>
				<!-- logo for regular state and mobile devices--><span class=""logo-lg""><b>{0}����ϵͳ</b></span>
			</a>
			<!-- Header Navbar-->
			<nav role=""navigation"" class=""navbar navbar-static-top"">
				<!-- Sidebar toggle button--><a href=""#"" data-toggle=""offcanvas"" role=""button"" class=""sidebar-toggle""><span class=""sr-only"">Toggle navigation</span></a>
				<!-- Navbar Right Menu-->
				<div class=""navbar-custom-menu"">
					<ul class=""nav navbar-nav"">
						<!-- User Account Menu-->
						<li class=""dropdown user user-menu"">
							<!-- Menu Toggle Button--><a href=""#"" data-toggle=""dropdown"" class=""dropdown-toggle"">
								<!-- The user image in the navbar--><img src=""/htm/img/user2-160x160.jpg"" alt=""User Image"" class=""user-image"">
								<!-- hidden-xs hides the username on small devices so only the image appears.--><span class=""hidden-xs""></span>
							</a>
							<ul class=""dropdown-menu"">
								<!-- The user image in the menu-->
								<li class=""user-header"">
									<img src=""/htm/img/user2-160x160.jpg"" alt=""User Image"" class=""img-circle"">
									<p></p>
								</li>
								<!-- Menu Footer-->
								<li class=""user-footer"">
									<div class=""pull-right"">
										<a href=""#"" onclick=""$('form#form_logout').submit();return false;"" class=""btn btn-default btn-flat"">��ȫ�˳�</a>
										<form id=""form_logout"" method=""post"" action=""./exit.aspx""></form>
									</div>
								</li>
							</ul>
						</li>
					</ul>
				</div>
			</nav>
		</header>
		<!-- Left side column. contains the logo and sidebar-->
		<aside class=""main-sidebar"">
			<!-- sidebar: style can be found in sidebar.less-->
			<section class=""sidebar"">
				<!-- Sidebar Menu-->
				<ul class=""sidebar-menu"">
					<!-- Optionally, you can add icons to the links-->

					<li class=""treeview active"">
						<a href=""#""><i class=""fa fa-laptop""></i><span>ͨ�ù���</span><i class=""fa fa-angle-left pull-right""></i></a>
						<ul class=""treeview-menu"">{1}
						</ul>
					</li>

				</ul>
				<!-- /.sidebar-menu-->
			</section>
			<!-- /.sidebar-->
		</aside>
		<!-- Content Wrapper. Contains page content-->
		<div class=""content-wrapper"">
			<!-- Main content-->
			<section id=""right_content"" class=""content"">
				<div style=""display:none;"">
					<!-- Your Page Content Here-->
					<h1>����һ��������ҳ</h1>
					<h2>swagger webapi��<a href='/swagger/' target='_blank'>/swagger/</a><h2>
					<h2>��½��ַ��<a href='/login' target='_blank'>/login</a><h2>

					<h2><a href='/sys/connection' target='_blank'>�鿴 Npgsql���ӳ�</a><h2>
					<h2><a href='/sys/connection/redis' target='_blank'>�鿴 Redis���ӳ�</a><h2>
				</div>
			</section>
			<!-- /.content-->
		</div>
		<!-- /.content-wrapper-->
	</div>
	<!-- ./wrapper-->
	<script type=""text/javascript"" src=""./htm/js/system.js""></script>
	<script type=""text/javascript"" src=""./htm/js/admin.js""></script>
	<script type=""text/javascript"">
		if (!location.hash) $('#right_content div:first').show();
		// ·�ɹ���
		//��������html��ʼ��·���б�
		function hash_encode(str) {{ return url_encode(base64.encode(str)).replace(/%/g, '_'); }}
		function hash_decode(str) {{ return base64.decode(url_decode(str.replace(/_/g, '%'))); }}
		window.div_left_router = {{}};
		$('li.treeview.active ul li a').each(function(index, ele) {{
			var href = $(ele).attr('href');
			$(ele).attr('href', '#base64url' + hash_encode(href));
			window.div_left_router[href] = $(ele).text();
		}});
		(function () {{
			function Vipspa() {{
			}}
			Vipspa.prototype.start = function (config) {{
				Vipspa.mainView = $(config.view);
				startRouter();
				window.onhashchange = function () {{
					if (location._is_changed) return location._is_changed = false;
					startRouter();
				}};
			}};
			function startRouter() {{
				var hash = location.hash;
				if (hash === '') return //location.hash = $('li.treeview.active ul li a:first').attr('href');//'#base64url' + hash_encode('/resume_type/');
				if (hash.indexOf('#base64url') !== 0) return;
				var act = hash_decode(hash.substr(10, hash.length - 10));
				//Ҷ�������ӵĴ��룬���ػ����ύform����ʾ����
				function ajax_success(refererUrl) {{
					if (refererUrl == location.pathname) {{ startRouter(); return function(){{}}; }}
					var hash = '#base64url' + hash_encode(refererUrl);
					if (location.hash != hash) {{
						location._is_changed = true;
						location.hash = hash;
					}}'\''
					return function (data, status, xhr) {{
						var div;
						Function.prototype.ajax = $.ajax;
						top.mainViewNav = {{
							url: refererUrl,
							trans: function (url) {{
								var act = url;
								act = act.substr(0, 1) === '/' || act.indexOf('://') !== -1 || act.indexOf('data:') === 0 ? act : join_url(refererUrl, act);
								return act;
							}},
							goto: function (url_or_form, target) {{
								var form = url_or_form;
								if (typeof form === 'string') {{
									var act = this.trans(form);
									if (String(target).toLowerCase() === '_blank') return window.open(act);
									location.hash = '#base64url' + hash_encode(act);
								}}
								else {{
									if (!window.ajax_form_iframe_max) window.ajax_form_iframe_max = 1;
									window.ajax_form_iframe_max++;
									var iframe = $('<iframe name=""ajax_form_iframe{{0}}""></iframe>'.format(window.ajax_form_iframe_max));
									Vipspa.mainView.append(iframe);
									var act = $(form).attr('action') || '';
									act = act.substr(0, 1) === '/' || act.indexOf('://') !== -1 ? act : join_url(refererUrl, act);
									if ($(form).find(':file[name]').length > 0) $(form).attr('enctype', 'multipart/form-data');
									$(form).attr('action', act);
									$(form).attr('target', iframe.attr('name'));
									iframe.on('load', function () {{
										var doc = this.contentWindow ? this.contentWindow.document : this.document;
										if (doc.body.innerHTML.length === 0) return;
										if (doc.body.innerHTML.indexOf('Error:') === 0) return alert(doc.body.innerHTML.substr(6));
										//���� '<script ' + '�Ƿ�ֹ�뱾ҳ����ƥ�䣬��Ҫɾ��
										if (doc.body.innerHTML.indexOf('<script ' + 'type=""text/javascript"">location.href=""') === -1) {{
											ajax_success(doc.location.pathname + doc.location.search)(doc.body.innerHTML, 200, null);
										}}
									}});
								}}
							}},
							reload: startRouter,
							query: qs_parseByUrl(refererUrl)
						}};
						top.mainViewInit = function () {{
							if (!div) return setTimeout(top.mainViewInit, 10);
							admin_init(function (selector) {{
								if (/<[^>]+>/.test(selector)) return $(selector);
								return div.find(selector);
							}}, top.mainViewNav);
						}};
						if (/<body[^>]*>/i.test(data))
							data = data.match(/<body[^>]*>(([^<]|<(?!\/body>))*)<\/body>/i)[1];
						div = Vipspa.mainView.html(data);
					}};
				}};
				$.ajax({{
					type: 'GET',
					url: act,
					dataType: 'html',
					success: ajax_success(act),
					error: function (jqXHR, textStatus, errorThrown) {{
						var data = jqXHR.responseText;
						if (/<body[^>]*>/i.test(data))
							data = data.match(/<body[^>]*>(([^<]|<(?!\/body>))*)<\/body>/i)[1];
						Vipspa.mainView.html(data);
					}}
				}});
			}}
			window.vipspa = new Vipspa();
		}})();
		$(function () {{
			vipspa.start({{
				view: '#right_content',
			}});
		}});
		// ҳ����ؽ�����
		$(document).ajaxStart(function() {{ Pace.restart(); }});
	</script>
</body>
</html>";
			#endregion

			public static readonly string Module_Test_Controller =
			#region ����̫���ѱ�����
			@"using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using NpgsqlTypes;
using {0}.BLL;
using {0}.Model;

namespace {0}.Module.Admin.Controllers {{
	[Route(""[controller]"")]
	public class {1}Controller : BaseController {{
		public {1}Controller(ILogger<{1}Controller> logger) : base(logger) {{ }}

		[HttpGet]
		public APIReturn List([FromServices]IConfiguration cfg) {{
			return APIReturn.�ɹ�;
		}}
	}}
}}
";
			#endregion

			public static readonly string Module_csproj =
			#region ����̫���ѱ�����
 @"<Project Sdk=""Microsoft.NET.Sdk"">
	<PropertyGroup>
		<TargetFramework>netstandard2.0</TargetFramework>
		<WarningLevel>3</WarningLevel>
	</PropertyGroup>
	<ItemGroup>
		<ProjectReference Include=""..\..\Infrastructure\Infrastructure.csproj"" />
	</ItemGroup>
</Project>
";
			#endregion
		}
	}
}

