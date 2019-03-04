﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Text.RegularExpressions;
using Model;

namespace Server {

	internal partial class CodeBuild {
		public void SetOutput(bool[] outputs) {
			if (this._tables.Count == outputs.Length) {
				for (int a = 0; a < outputs.Length; a++) {
					this._tables[a].IsOutput = outputs[a];
				}
			}
		}

		protected Dictionary<string, string> dic_globalnpgtypes = new Dictionary<string, string>();
		public List<BuildInfo> Build(string solutionName, bool isSolution, bool isMakeAdmin, bool isDownloadRes) {
			dic_globalnpgtypes.Clear();
			Logger.remotor.Info("Build: " + solutionName + ",isSolution: " + isSolution + ",isMakeAdmin: " + isMakeAdmin + ",isDownloadRes: " + isDownloadRes + "(" + _client.Server + "," + _client.Username + "," + _client.Password + "," + _client.Database + ")");
			List<BuildInfo> loc1 = new List<BuildInfo>();

			//solutionName = UFString(solutionName);
			string dbName = UFString(GetCSName(_client.Database));
			string connectionStringName = _client.Database + "ConnectionString";
			string basicName = "Build";

			string wwwroot_sitemap = "";

			Dictionary<string, bool> isMakedHtmlSelect = new Dictionary<string, bool>();
			StringBuilder Model_Build_ExtensionMethods_cs = new StringBuilder();
			List<string> admin_controllers_syscontroller_init_sysdir = new List<string>();

			StringBuilder sb1 = new StringBuilder();
			StringBuilder sb2 = new StringBuilder();
			StringBuilder sb3 = new StringBuilder();
			StringBuilder sb4 = new StringBuilder();
			StringBuilder sb5 = new StringBuilder();
			StringBuilder sb6 = new StringBuilder();
			StringBuilder sb7 = new StringBuilder();
			StringBuilder sb8 = new StringBuilder();
			StringBuilder sb9 = new StringBuilder();
			StringBuilder sb10 = new StringBuilder();
			StringBuilder sb11 = new StringBuilder();
			StringBuilder sb12 = new StringBuilder();
			StringBuilder sb13 = new StringBuilder();
			StringBuilder sb14 = new StringBuilder();
			StringBuilder sb15 = new StringBuilder();
			StringBuilder sb16 = new StringBuilder();
			StringBuilder sb17 = new StringBuilder();
			StringBuilder sb18 = new StringBuilder();
			StringBuilder sb19 = new StringBuilder();
			StringBuilder sb20 = new StringBuilder();
			StringBuilder sb21 = new StringBuilder();
			StringBuilder sb22 = new StringBuilder();
			StringBuilder sb23 = new StringBuilder();
			StringBuilder sb24 = new StringBuilder();
			StringBuilder sb25 = new StringBuilder();
			StringBuilder sb26 = new StringBuilder();
			StringBuilder sb27 = new StringBuilder();
			StringBuilder sb28 = new StringBuilder();
			StringBuilder sb29 = new StringBuilder();
			AnonymousHandler clearSb = delegate () {
				sb1.Remove(0, sb1.Length);
				sb2.Remove(0, sb2.Length);
				sb3.Remove(0, sb3.Length);
				sb4.Remove(0, sb4.Length);
				sb5.Remove(0, sb5.Length);
				sb6.Remove(0, sb6.Length);
				sb7.Remove(0, sb7.Length);
				sb8.Remove(0, sb8.Length);
				sb9.Remove(0, sb9.Length);
				sb10.Remove(0, sb10.Length);
				sb11.Remove(0, sb11.Length);
				sb12.Remove(0, sb12.Length);
				sb13.Remove(0, sb13.Length);
				sb14.Remove(0, sb14.Length);
				sb15.Remove(0, sb15.Length);
				sb16.Remove(0, sb16.Length);
				sb17.Remove(0, sb17.Length);
				sb18.Remove(0, sb18.Length);
				sb19.Remove(0, sb19.Length);
				sb20.Remove(0, sb20.Length);
				sb21.Remove(0, sb21.Length);
				sb22.Remove(0, sb22.Length);
				sb23.Remove(0, sb23.Length);
				sb24.Remove(0, sb24.Length);
				sb25.Remove(0, sb25.Length);
				sb26.Remove(0, sb26.Length);
				sb27.Remove(0, sb27.Length);
				sb28.Remove(0, sb28.Length);
				sb29.Remove(0, sb29.Length);
			};

			if (isSolution) {
				#region solution.sln
				sb1.AppendFormat(CONST.sln, solutionName, 
					Guid.NewGuid().ToString().ToUpper(), 
					Guid.NewGuid().ToString().ToUpper(), 
					Guid.NewGuid().ToString().ToUpper(), 
					Guid.NewGuid().ToString().ToUpper(),
					Guid.NewGuid().ToString().ToUpper(),
					Guid.NewGuid().ToString().ToUpper(),
					Guid.NewGuid().ToString().ToUpper(),
					Guid.NewGuid().ToString().ToUpper(),
					Guid.NewGuid().ToString().ToUpper(),
					Guid.NewGuid().ToString().ToUpper());
				loc1.Add(new BuildInfo(string.Concat(CONST.corePath, @"..\", solutionName, ".sln"), Deflate.Compress(sb1.ToString())));
				clearSb();
				#endregion

				#region Project Infrastructure
				#region Controllers\BaseController.cs
				sb1.Append(Server.Properties.Resources.Infrastructure_Controllers_BaseController_cs);
				loc1.Add(new BuildInfo(string.Concat(CONST.corePath, @"Infrastructure\Controllers\BaseController.cs"), Deflate.Compress(sb1.ToString())));
				clearSb();
				#endregion
				#region Controllers\CustomExceptionFilter.cs
				sb1.Append(Server.Properties.Resources.Infrastructure_Controllers_CustomExceptionFilter_cs);
				loc1.Add(new BuildInfo(string.Concat(CONST.corePath, @"Infrastructure\Controllers\CustomExceptionFilter.cs"), Deflate.Compress(sb1.ToString())));
				clearSb();
				#endregion
				#region Extensions\GlobalExtensions.cs
				sb1.Append(Server.Properties.Resources.Infrastructure_Extensions_GlobalExtensions_cs);
				loc1.Add(new BuildInfo(string.Concat(CONST.corePath, @"Infrastructure\Extensions\GlobalExtensions.cs"), Deflate.Compress(sb1.ToString())));
				clearSb();
				#endregion
				#region ModuleBasic\IModuleInitializer.cs
				sb1.Append(Server.Properties.Resources.Infrastructure_ModuleBasic_IModuleInitializer_cs);
				loc1.Add(new BuildInfo(string.Concat(CONST.corePath, @"Infrastructure\ModuleBasic\IModuleInitializer.cs"), Deflate.Compress(sb1.ToString())));
				clearSb();
				#endregion
				#region ModuleBasic\ModuleInfo.cs
				sb1.Append(Server.Properties.Resources.Infrastructure_ModuleBasic_ModuleInfo_cs);
				loc1.Add(new BuildInfo(string.Concat(CONST.corePath, @"Infrastructure\ModuleBasic\ModuleInfo.cs"), Deflate.Compress(sb1.ToString())));
				clearSb();
				#endregion
				#region ModuleBasic\ModuleViewLocationExpander.cs
				sb1.Append(Server.Properties.Resources.Infrastructure_ModuleBasic_ModuleViewLocationExpander_cs);
				loc1.Add(new BuildInfo(string.Concat(CONST.corePath, @"Infrastructure\ModuleBasic\ModuleViewLocationExpander.cs"), Deflate.Compress(sb1.ToString())));
				clearSb();
				#endregion
				#region Infrastructure.csproj
				sb1.AppendFormat(CONST.Infrastructure_csproj, solutionName);
				loc1.Add(new BuildInfo(string.Concat(CONST.corePath, @"Infrastructure\Infrastructure.csproj"), Deflate.Compress(sb1.ToString())));
				clearSb();
				#endregion
				#endregion
			}

			string PSqlHelperMapTypeGlobally = "";

			#region 生成自定义枚举 _Enum.cs
			List<string> owners = new List<string>();
			foreach (TableInfo t in _tables) {
				string ow = string.IsNullOrEmpty(t.Owner) ? "public" : t.Owner;
				if (!owners.Contains(ow)) owners.Add(ow);
			}
			string sql = string.Format(@"
select
ns.nspname || '.' || a.typname,
b.enumlabel
from pg_type a
inner join pg_enum b on b.enumtypid = a.oid
inner join pg_namespace ns on ns.oid = a.typnamespace
where a.typtype = 'e' and ns.nspname in ('{0}')", string.Join("','", owners.ToArray()));
			object[][] ds = this.GetDataSet(sql);
			Dictionary<string, string> _types = new Dictionary<string, string>();
			int unknow_idx = 0;
			foreach (object[] dr in ds) {
				string dr1 = string.Concat(dr[0]);
				string dr2 = string.Concat(dr[1]);
				dr1 = UFString(dr1.StartsWith("public.") ? dr1.Substring(7) : dr1.Replace(".", "_"));
				bool isFirst = !_types.ContainsKey(dr1);
				if (isFirst) _types.Add(dr1, "");

				string str2 = dr2;
				if (Regex.IsMatch(str2, @"^[\u0391-\uFFE5a-zA-Z_\$][\u0391-\uFFE5a-zA-Z_\$\d]*$"))
					_types[dr1] += ", " + str2;
				else
					_types[dr1] += string.Format(@", 
		/// <summary>
		/// {0}
		/// </summary>
		[PgName(""{0}"")]
		Unknow{1}", str2.Replace("\"", "\\\""), ++unknow_idx);

				if (isFirst) {
					_types[dr1] += " = 1";
					PSqlHelperMapTypeGlobally += string.Format(@"
			NpgsqlConnection.GlobalTypeMapper.MapEnum<Model.{0}ENUM>(""{1}"", nameTranslator);", dr1, dr[0]);
					string dic_globalnpgtypes_key = string.Format("{0}ENUM", dr1);
					if (!dic_globalnpgtypes.ContainsKey(dic_globalnpgtypes_key)) dic_globalnpgtypes.Add(dic_globalnpgtypes_key, "");
					dic_globalnpgtypes[dic_globalnpgtypes_key] = string.Concat(dr[0]);
				}
			}
			string code = string.Format(@"using System;
using NpgsqlTypes;
using Npgsql.LegacyPostgis;

namespace {0}.Model {{
", solutionName);
			foreach (string xxx in _types.Keys) {
				code += string.Format(@"
	public enum {0}ENUM {{
		{1}
	}}", xxx, _types[xxx].Substring(2).TrimStart('\r', '\n', '\t'));
			}
			code = string.Concat(code, @"
}
/*
var a = `将_Enum.cs的内容复制进来，然后去chrome控制台运行，得到枚举创建sql`;

var sb = '';
var b = a.replace(/public enum\s+Et_([^ ]+) \{([^\}]+)\}/g, function($0, $1, $2) {
var c = $2.replace(/[ \t\n]/g, '').replace(/(=1)?,/g, ""','"");
sb += 'create type et_' + $1.replace('ENUM', '') + ' as enum(\'' + c + '\');\r\n'
});

console.log(sb);
*/");
			loc1.Add(new BuildInfo(string.Concat(CONST.corePath, solutionName, @".db\Model\", basicName, @"\_Enum.cs"), Deflate.Compress(code)));
			#endregion

			#region 生成自定义模型 _Composite.cs
			sql = string.Format(@"
select
ns.nspname || '.' || a.typname,
c.attname,
d.typname,
d.typtype,
c.attndims,
ns2.nspname
from pg_type a
inner join pg_class b on b.reltype = a.oid and b.relkind = 'c'
inner join pg_attribute c on c.attrelid = b.oid and c.attnum > 0
inner join pg_type d on d.oid = c.atttypid
inner join pg_namespace ns on ns.oid = a.typnamespace
left join pg_namespace ns2 on ns2.oid = d.typnamespace
where ns.nspname || '.' || a.typname not in ('public.reclassarg','public.geomval','public.addbandarg','public.agg_samealignment','public.geometry_dump','public.summarystats','public.agg_count','public.valid_detail','public.rastbandarg','public.unionarg')
and ns.nspname in ('{0}')", string.Join("','", owners.ToArray()));
			ds = this.GetDataSet(sql);
			_types = new Dictionary<string, string>();
			foreach (object[] dr in ds) {
				string dr1 = string.Concat(dr[0]);
				string dr2 = string.Concat(dr[1]);
				string type = string.Concat(dr[2]);
				string typ = string.Concat(dr[3]);
				int attndims;
				int.TryParse(string.Concat(dr[4]), out attndims);
				if (type.StartsWith("_")) {
					type = type.Substring(1);
					if (attndims == 0) attndims++;
				}
				string dr5 = string.Concat(dr[5]);
				string enumType = UFString(dr5 == "public" ? type : (dr5 + "_" + type));
				if (typ == "c") enumType += "TYPE";
				if (typ == "e") enumType += "ENUM";
				dr1 = UFString(dr1.StartsWith("public.") ? dr1.Substring(7) : dr1.Replace(".", "_"));
				bool isFirst = !_types.ContainsKey(dr1);
				if (isFirst) _types.Add(dr1, "");

				_types[dr1] += string.Format(@"
		[JsonProperty] public {0} {1} {{ get; set; }}", GetCSType(GetDBType(type, typ), attndims, enumType), UFString(dr2));

				if (isFirst) {
					PSqlHelperMapTypeGlobally += string.Format(@"
			NpgsqlConnection.GlobalTypeMapper.MapComposite<Model.{0}TYPE>(""{1}"");", dr1, dr[0]);
					string dic_globalnpgtypes_key = string.Format("{0}TYPE", dr1);
					if (!dic_globalnpgtypes.ContainsKey(dic_globalnpgtypes_key)) dic_globalnpgtypes.Add(dic_globalnpgtypes_key, "");
					dic_globalnpgtypes[dic_globalnpgtypes_key] = string.Concat(dr[0]);
				}
			}
			code = string.Format(@"using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Net;
using System.Net.NetworkInformation;
using Newtonsoft.Json;
using NpgsqlTypes;
using Npgsql.LegacyPostgis;

namespace {0}.Model {{
", solutionName);
			foreach (string xxx in _types.Keys) {
				code += string.Format(@"
	[JsonObject(MemberSerialization.OptIn)]
	public partial struct {0}TYPE {{{1}
	}}", xxx, _types[xxx]);
			}
			loc1.Add(new BuildInfo(string.Concat(CONST.corePath, solutionName, @".db\Model\", basicName, @"\_Composite.cs"), Deflate.Compress(code + "\r\n}")));
			#endregion

			foreach (TableInfo table in _tables) {
				if (table.IsOutput == false) continue;
				if (table.Type == "P") continue;

				//if (table.Uniques.Count == 0)
				//	throw new Exception("检查到表 “" + table.Owner + "." + table.Name + "” 没有设定惟一键！");
				if (table.Columns.Count == 0) continue;

				#region commom variable define
				string uClass_Name = UFString(table.ClassName);
				string nClass_Name = table.ClassName;
				string nTable_Name = string.Concat(string.IsNullOrEmpty(table.Owner) ? string.Empty : string.Concat(@"""""", table.Owner, @"""""."), @"""""", table.Name, @"""""");
				string Class_Name_BLL_Full = string.Format(@"{0}.BLL.{1}", solutionName, uClass_Name);
				string Class_Name_Model_Full = string.Format(@"{0}.Model.{1}", solutionName, uClass_Name);

				string pkCsParam = "";
				string pkCsParamNoType = "";
				string pkCsParamNoTypeFieldInit = "";
				string pkCsParamNoTypeByval = "";
				string pkSqlParamFormat = "";
				string pkSqlParam = "";
				string pkEvalsQuerystring = "";
				string CsParam1 = "";
				string CsParamNoType1 = "";
				string CsParam2 = "";
				string CsParamNoType2 = "";
				string CsParam3 = "";
				string CsParamNoType3 = "";
				string csItemAllFieldCopy = "";
				string pkMvcRoute = "";
				string orderBy = table.Clustereds.Count > 0 ?
					string.Join(", ", table.Clustereds.ConvertAll<string>(delegate (ColumnInfo cli) {
						return @"a.""""" + cli.Name + @"""""" + (cli.Orderby == DataSort.ASC ? string.Empty : string.Concat(" ", cli.Orderby));
					}).ToArray()) :
						table.Uniques.Count > 0 ?
							string.Join(", ", table.Uniques[0].ConvertAll<string>(delegate (ColumnInfo cli) {
								return @"a.""""" + cli.Name + @"""""" + (cli.Orderby == DataSort.ASC ? string.Empty : string.Concat(" ", cli.Orderby));
							}).ToArray()) : "";

				int pkSqlParamFormat_idx = -1;
				if (table.PrimaryKeys.Count > 0) {
					foreach (ColumnInfo columnInfo in table.PrimaryKeys) {
						pkCsParam += columnInfo.CsType + " " + UFString(columnInfo.Name) + ", ";
						pkCsParamNoType += UFString(columnInfo.Name) + ", ";
						pkCsParamNoTypeFieldInit += UFString(columnInfo.Name) + " = " + UFString(columnInfo.Name) + ", ";
						pkCsParamNoTypeByval += string.Format(GetCSTypeValue(columnInfo.Type), UFString(columnInfo.Name)) + ", ";
						pkSqlParamFormat += @"""""" + columnInfo.Name + @""""" = {" + ++pkSqlParamFormat_idx + "} AND ";
						pkSqlParam += @"""""" + columnInfo.Name + @""""" = ?" + columnInfo.Name + " AND ";
						pkEvalsQuerystring += string.Format("{0}=<%# Eval(\"{0}\") %>&", UFString(columnInfo.Name));
						pkMvcRoute += "{" + UFString(columnInfo.Name) + "}/";
					}
					pkCsParam = pkCsParam.Substring(0, pkCsParam.Length - 2);
					pkCsParamNoType = pkCsParamNoType.Substring(0, pkCsParamNoType.Length - 2);
					pkCsParamNoTypeByval = pkCsParamNoTypeByval.Substring(0, pkCsParamNoTypeByval.Length - 2);
					pkSqlParamFormat = pkSqlParamFormat.Substring(0, pkSqlParamFormat.Length - 5);
					pkSqlParam = pkSqlParam.Substring(0, pkSqlParam.Length - 5);
					pkEvalsQuerystring = pkEvalsQuerystring.Substring(0, pkEvalsQuerystring.Length - 1);
				}
				foreach (ColumnInfo columnInfo in table.Columns) {
					CsParam1 += columnInfo.CsType + " " + UFString(columnInfo.Name) + ", ";
					CsParamNoType1 += UFString(columnInfo.Name) + ", ";
					csItemAllFieldCopy += string.Format(@"
			item.{0} = newitem.{0};", UFString(columnInfo.Name));
					if (columnInfo.IsIdentity) {
						//CsParamNoType2 += "0, ";
					} else if (columnInfo.IsPrimaryKey && columnInfo.CsType == "Guid?" && table.PrimaryKeys.Count == 1) {

					} else {
						CsParam2 += columnInfo.CsType + " " + UFString(columnInfo.Name) + ", ";
						CsParamNoType2 += string.Format("\r\n				{0} = {0}, ", UFString(columnInfo.Name));

						if (columnInfo.CsType == "DateTime?" && (columnInfo.Name.ToLower() == "create_time" || columnInfo.Name.ToLower() == "update_time") ||
							columnInfo.CsType == "bool?" && (columnInfo.Name.ToLower() == "is_deleted")) ;
						else {
							CsParam3 += columnInfo.CsType + " " + UFString(columnInfo.Name) + ", ";
							CsParamNoType3 += string.Format("\r\n				{0} = {0}, ", UFString(columnInfo.Name));
						}
					}
				}
				CsParam1 = CsParam1.Substring(0, CsParam1.Length - 2);
				CsParamNoType1 = CsParamNoType1.Substring(0, CsParamNoType1.Length - 2);
				if (CsParam2.Length > 0) CsParam2 = CsParam2.Substring(0, CsParam2.Length - 2);
				if (CsParamNoType2.Length > 0) CsParamNoType2 = CsParamNoType2.Substring(0, CsParamNoType2.Length - 2);
				if (CsParam3.Length > 0) CsParam3 = CsParam3.Substring(0, CsParam3.Length - 2);
				if (CsParamNoType3.Length > 0) CsParamNoType3 = CsParamNoType3.Substring(0, CsParamNoType3.Length - 2);
				#endregion

				#region Model *.cs
				sb1.AppendFormat(
	@"using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Net;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NpgsqlTypes;
using Npgsql.LegacyPostgis;

namespace {0}.Model {{
	[JsonObject(MemberSerialization.OptIn)]
	public partial class {1}Info {{
		#region fields
", solutionName, uClass_Name);
				Dictionary<string, string> innerjoinObjs = new Dictionary<string, string>();
				bool Is_System_ComponentModel = false;
				int column_idx = -1;
				foreach (ColumnInfo column in table.Columns) {
					column_idx++;
					string csType = column.CsType;
					string nColumn_Name = column.Name;
					string uColumn_Name = UFString(column.Name);
					string comment = _column_coments.ContainsKey(table.FullName) && _column_coments[table.FullName].ContainsKey(column.Name) ? _column_coments[table.FullName][column.Name] : column.Name;
					string prototype_comment = comment == column.Name ? "" : string.Format(@"/// <summary>
		/// {0}
		/// </summary>
		", comment.Replace("\r\n", "\n").Replace("\n", "\r\n		/// "));

					sb1.AppendFormat(
	@"		{0} {1} _{2};
", csType == "JToken" ? "internal" : "private", csType == "JToken" ? "string" : csType, uColumn_Name);

					string tmpinfo = string.Empty;
					List<string> tsvarr = new List<string>();
					List<ForeignKeyInfo> fks = table.ForeignKeys.FindAll(delegate (ForeignKeyInfo fk) {
						int fkc1idx = 0;
						string fkcsBy = "By";
						string fkcsParms = string.Empty;
						string fkcsIfNull = string.Empty;
						ColumnInfo fkc = fk.Columns.Find(delegate (ColumnInfo c1) {
							fkc1idx++;
							fkcsParms += string.Format(GetCSTypeValue(c1.Type), "_" + UFString(c1.Name)) + ", ";
							fkcsIfNull += " && _" + UFString(c1.Name) + " != null";
							return c1.Name == column.Name;
						});
						if (fk.ReferencedTable != null) {
							fk.ReferencedColumns.ForEach(delegate (ColumnInfo c1) {
								fkcsBy += UFString(c1.Name) + "And";
							});
						} else {
							fk.ReferencedColumnNames.ForEach(delegate (string c1) {
								fkcsBy += UFString(c1) + "And";
							});
						}
						if (fkc == null) return false;
						string FK_uClass_Name = fk.ReferencedTable != null ? UFString(fk.ReferencedTable.ClassName) :
							UFString(TableInfo.GetClassName(fk.ReferencedTableName));
						string FK_uClass_Name_full = fk.ReferencedTable != null ? FK_uClass_Name :
							string.Format(@"{0}.Model.{1}", solutionName, FK_uClass_Name);
						string FK_uEntry_Name = fk.ReferencedTable != null ? GetCSName(fk.ReferencedTable.Name) :
							GetCSName(TableInfo.GetEntryName(fk.ReferencedTableName));
						string tableNamefe3 = fk.ReferencedTable != null ? fk.ReferencedTable.Name : FK_uEntry_Name;
						string memberName = fk.Columns[0].Name.IndexOf(tableNamefe3) == -1 ? tableNamefe3 :
							(fk.Columns[0].Name.Substring(0, fk.Columns[0].Name.IndexOf(tableNamefe3)) + tableNamefe3);
						if (fk.Columns[0].Name.IndexOf(tableNamefe3) == 0 && fk.ReferencedTable != null) memberName = fk.ReferencedTable.ClassName;

						tsvarr.Add(string.Format(@"_obj_{0} = null;", memberName));
						if (fkc1idx == fk.Columns.Count) {
							fkcsBy = fkcsBy.Remove(fkcsBy.Length - 3);
							fkcsParms = fkcsParms.Remove(fkcsParms.Length - 2);
							if (fk.ReferencedColumns.Count > 0 && fk.ReferencedColumns[0].IsPrimaryKey ||
								fk.ReferencedTable == null && fk.ReferencedIsPrimaryKey) {
								fkcsBy = string.Empty;
							}
							sb1.AppendFormat(
@"		private {0}Info _obj_{1};
", FK_uClass_Name_full, memberName);
							tmpinfo += string.Format(
@"		public {0}Info Obj_{1} {{
			get {{
				if (_obj_{1} == null{6}) _obj_{1} = BLL.{5}.GetItem{3}({4});
				return _obj_{1};
			}}
			internal set {{ _obj_{1} = value; }}
		}}

", FK_uClass_Name_full, memberName, solutionName, fkcsBy, fkcsParms, FK_uClass_Name, fkcsIfNull);
							//若不存在 Obj_外键表名，则增加，否则InnerJoin.ToList时会报错 “Obj_外键表名 不存在”
							//比如表只有一 creator_person_id 时，需附加成生一个 Obj_person 属性
							string fkTableClassName = fk.ReferencedTable.ClassName;
							if (memberName == fkTableClassName) {
								//如果有 Obj_外键表名 属性，则不增加什么代码
								if (innerjoinObjs.ContainsKey(fkTableClassName)) innerjoinObjs.Remove(fkTableClassName);
								innerjoinObjs.Add(fkTableClassName, "");
							} else {
								if (innerjoinObjs.ContainsKey(fkTableClassName)) {
									if (!string.IsNullOrEmpty(innerjoinObjs[fkTableClassName]))
										//如果有多个相同外键，比如 a_person_id, b_person_id
										innerjoinObjs[fkTableClassName] = string.Format(
	@"
		/// <summary>
		/// 配合 InnerJoin .ToList 查询临时使用
		/// </summary>
		public {0}Info Obj_{1} {{ get; internal set; }}", UFString(fkTableClassName), fkTableClassName, memberName);
								} else
									//如果只有一个外键，比如 a_person_id
									innerjoinObjs.Add(fkTableClassName, string.Format(
@"
		/// <summary>
		/// 与 Obj_{2} 同引用
		/// </summary>
		public {0}Info Obj_{1} {{
			get {{ return this.Obj_{2}; }}
			internal set {{ this.Obj_{2} = value; }}
		}}", UFString(fkTableClassName), fkTableClassName, memberName));
							}
						}
						return fkc != null;
					});
					string JsonConverter = "";
					#region JsonConverter
					bool isJsonConverter = csType.Contains("BitArray") ||

						csType.Contains("NpgsqlPoint") ||
						csType.Contains("NpgsqlLine") ||
						csType.Contains("NpgsqlLSeg") ||
						csType.Contains("NpgsqlBox") ||
						csType.Contains("NpgsqlPath") ||
						csType.Contains("NpgsqlPolygon") ||
						csType.Contains("NpgsqlCircle") ||

						csType.Contains("(IPAddress Address, int Subnet)") ||
						csType.Contains("IPAddress") ||
						csType.Contains("PhysicalAddress") ||

						csType.Contains("NpgsqlRange<int>") ||
						csType.Contains("NpgsqlRange<long>") ||
						csType.Contains("NpgsqlRange<decimal>") ||
						csType.Contains("NpgsqlRange<DateTime>");
					if (isJsonConverter)
						JsonConverter = "[JsonConverter(typeof(NpgsqlTypesConverter))]\r\n		";
					#endregion

					if (fks.Count > 0) {
						string tmpsetvalue = string.Format(
@"		{2}{3}[JsonProperty] public {0} {1} {{
			get {{ return _{1}; }}
			set {{
				if (_{1} != value) ", csType, uColumn_Name, prototype_comment, JsonConverter);
						string tsvstr = string.Join(@"
					", tsvarr.ToArray());
						if (fks.Count > 1) {
							tmpsetvalue += string.Format(@"{{
					{0}
				}}", tsvstr);
						} else {
							tmpsetvalue += tsvstr;
						}
						tmpsetvalue += string.Format(@"
				_{0} = value;
			}}
		}}

", uColumn_Name);
						sb2.Append(tmpsetvalue);
						sb2.Append(tmpinfo);
					} else if (csType == "JToken") {
						sb2.AppendFormat(
@"		private {0} __{1};
		{2}{3}[JsonProperty] public {0} {1} {{
			get {{ return __{1} ?? (__{1} = string.IsNullOrEmpty(_{1}) ? null : JToken.Parse(_{1})); }}
			set {{ __{1} = value?.Type == JTokenType.Null ? null : value; _{1} = value?.ToString(); }}
		}}

", csType, uColumn_Name, prototype_comment, JsonConverter);
					} else {
						sb2.AppendFormat(
@"		{2}{3}[JsonProperty] public {0} {1} {{
			get {{ return _{1}; }}
			set {{ _{1} = value; }}
		}}

", csType, uColumn_Name, prototype_comment, JsonConverter);
					}
					sb3.AppendFormat("{0} {1}, ", csType, uColumn_Name);
					sb4.AppendFormat(
	@"			_{0} = {0};
", uColumn_Name);
					sb5.AppendFormat(@"
				__jsonIgnore.ContainsKey(""{0}"") ? string.Empty : string.Format("",{0}:{{0}}"", {1}),", uColumn_Name, GetToStringFieldConcat(column, uClass_Name + column.Name.ToUpper()));

					sb10.AppendFormat(@"
			if (allField || !__jsonIgnore.ContainsKey(""{0}"")) ht[""{0}""] = {1};", uColumn_Name,
						csType.Contains("(IPAddress Address, int Subnet)") ||
						csType.Contains("IPAddress") ||
						csType.Contains("PhysicalAddress") ? column.Attndims > 0 ?
							string.Format("NpgsqlTypesConverter.GetJObject({0}, new int[{1}], 0)", "_" + uColumn_Name, column.Attndims) :
							"_" + uColumn_Name + "?.ToString()" : (
								csType == "JToken" ? ("this." + uColumn_Name) : ("_" + uColumn_Name)
						));
					sb7.AppendFormat(@"
				{0}, ""|"",", GetToStringStringify(column));
					//		sb8.AppendFormat(@"
					//if (string.Compare(""null"", ret[{2}]) != 0) _{0} = {1};",
					//			uColumn_Name, string.Format(GetStringifyParse(column.Type, column.CsType), "ret[" + column_idx + "]"), column_idx);
					sb8.AppendFormat(@"
			if (ht[""{0}""] != null) _{0} = {1};",
						uColumn_Name, string.Format(GetObjectConvertToCsTypeMethod(column.Type, column.CsType), "ht[\"" + uColumn_Name + "\"]"));
				}

				if (sb2.Length != 0) {
					sb2.Remove(sb2.Length - 2, 2);
					sb3.Remove(sb3.Length - 2, 2);
					sb5.Remove(sb5.Length - 1, 1);
					sb7.Remove(sb7.Length - 6, 6);
				}

				Dictionary<string, string> dic_objs = new Dictionary<string, string>();
				// m -> n
				_tables.ForEach(delegate (TableInfo t2) {
					if (t2.ForeignKeys.Count > 2) {
						foreach (TableInfo t3 in _tables) {
							if (t3.FullName == t2.FullName) continue;
							ForeignKeyInfo fk3 = t3.ForeignKeys.Find(delegate (ForeignKeyInfo ffk3) {
								return ffk3.ReferencedTable.FullName == t2.FullName;
							});
							if (fk3 != null) {
								if (fk3.Columns[0].IsPrimaryKey)
									if (fk3.Table.PrimaryKeys.Count == 1) return; //如果有外键是主键，并且它不是复合组合，则跳过
							}
						}
					}
					ForeignKeyInfo fk_Common = null;
					List<ForeignKeyInfo> fks = t2.ForeignKeys.FindAll(delegate (ForeignKeyInfo ffk) {
						if (ffk.ReferencedTable.FullName == table.FullName/* && 
							ffk.Table.FullName != table.FullName*/) { //注释这行条件为了增加 parent_id 的 obj 对象
							fk_Common = ffk;
							return true;
						}
						return false;
					});
					if (fks.Count == 0) return;
					ForeignKeyInfo fk = fks.Count > 1 ? fks.Find(delegate(ForeignKeyInfo ffk) {
						return string.Compare(table.Name + "_" + table.PrimaryKeys[0].Name, ffk.Columns[0].Name, true) == 0;
					}) : fks[0];
					if (fk == null) fk = fks[0];
					//if (fk.Table.FullName == table.FullName) return; //注释这行条件为了增加 parent_id 的 obj 对象
					List<ForeignKeyInfo> fk2 = t2.ForeignKeys.FindAll(delegate (ForeignKeyInfo ffk2) {
						return ffk2.Columns[0].IsPrimaryKey && ffk2 != fk;
					});
					// 1 -> 1
					ForeignKeyInfo fk1v1 = table.ForeignKeys.Find(delegate (ForeignKeyInfo ffk2) {
						return ffk2.ReferencedTable.FullName == t2.FullName
							&& ffk2.ReferencedColumns[0].IsPrimaryKey && ffk2.Columns[0].IsPrimaryKey; //这行条件为了增加 parent_id 的 obj 对象
					});
					if (fk1v1 != null) return;

					//t2.Columns
					string t2name = t2.Name;
					string tablename = table.Name;
					string addname = t2name;
					if (t2name.StartsWith(tablename + "_")) {
						addname = t2name.Substring(tablename.Length + 1);
					} else if (t2name.EndsWith("_" + tablename)) {
						addname = t2name.Remove(addname.Length - tablename.Length - 1);
					} else if (fk2.Count == 1 && t2name.EndsWith("_" + tablename)) {
						addname = t2name.Remove(t2name.Length - tablename.Length - 1);
					} else if (fk2.Count == 1 && t2name.EndsWith("_" + fk2[0].ReferencedTable.Name)) {
						addname = t2name;
					}
					string addname_schema = addname == t2.Name && t2.Owner != table.Owner ? t2.ClassName : addname;

					string parms1 = "";
					string parmsNoneType1 = "";
					string parms1_add = "";
					string parmsNoneType1_add = "";
					string parms2 = "";
					string parmsNoneType2 = "";
					string parms2_add = "";
					string parmsNoneType2_add = "";
					string parms3 = "";
					string parmsNoneType3 = "";
					string parms4 = "";
					string parmsNoneType4 = "";
					string parmsNoneType5 = "";
					string pkNamesNoneType = "";
					string updateDiySet = "";
					string add_or_flag = "Add";
					int ms = 0;
					//若中间表，两外键指向相同表，则选择 表名_主键名 此字段作为主参考字段
					string main_column = fk.Columns[0].Name;
					var pkName = fk.ReferencedColumns[0].Name;
					foreach (ColumnInfo columnInfo in t2.Columns) {
						bool is_addignore = columnInfo.IsPrimaryKey && columnInfo.CsType == "Guid?" ||
							 columnInfo.Name.ToLower() == "update_time" && columnInfo.CsType == "DateTime?" ||
							 columnInfo.Name.ToLower() == "create_time" && columnInfo.CsType == "DateTime?";
						if (string.Compare(columnInfo.Name, main_column, true) == 0) {
							parmsNoneType2 += string.Format("\r\n			{0} = this.{1}, ", UFString(columnInfo.Name), UFString(pkName));
							//if (!is_addignore) parmsNoneType2_add += string.Format("\r\n			{0} = this.{1}, ", UFString(columnInfo.Name), UFString(pkName));

							parmsNoneType4 += string.Format(GetCSTypeValue(columnInfo.Type), "this." + UFString(pkName)) + ", ";
							parmsNoneType5 += string.Format("\r\n			item.{0} = this.{1};", UFString(columnInfo.Name), UFString(pkName));
							if (columnInfo.IsPrimaryKey) pkNamesNoneType += string.Format(GetCSTypeValue(fk.ReferencedColumns[0].Type), "this." + UFString(pkName)) + ", ";
							continue;
						}
						if (columnInfo.IsPrimaryKey) pkNamesNoneType += string.Format(GetCSTypeValue(columnInfo.Type), UFString(columnInfo.Name)) + ", ";
						//UFString(columnInfo.Name) + ", ";
						else if (columnInfo.Name.ToLower() == "create_time" && columnInfo.CsType == "DateTime?") ;
						else updateDiySet += string.Format("\r\n\t\t\t\t.Set{0}({0})", UFString(columnInfo.Name));

						if (columnInfo.IsIdentity) {
							//parmsNoneType2 += "0, ";
							continue;
						}
						parms2 += columnInfo.CsType + " " + UFString(columnInfo.Name) + ", ";
						parmsNoneType2 += string.Format("\r\n			{0} = {0}, ", UFString(columnInfo.Name));
						if (!is_addignore) {
							parms2_add += columnInfo.CsType + " " + UFString(columnInfo.Name) + ", ";
							parmsNoneType2_add += string.Format("\r\n			{0} = {0}, ", UFString(columnInfo.Name));
						}

						ForeignKeyInfo fkk3 = t2.ForeignKeys.Find(delegate (ForeignKeyInfo fkk33) {
							return fkk33.Columns[0].Name == columnInfo.Name;
						});
						if (fkk3 == null) {
							parms1 += columnInfo.CsType + " " + UFString(columnInfo.Name) + ", ";
							parmsNoneType1 += UFString(columnInfo.Name) + ", ";
							if (!is_addignore) {
								parms1_add += columnInfo.CsType + " " + UFString(columnInfo.Name) + ", ";
								parmsNoneType1_add += UFString(columnInfo.Name) + ", ";
							}
						} else {
							string fkk3_ReferencedTable_ObjName = fkk3.ReferencedTable.Name;
							string endStr = "_" + fkk3.ReferencedTable.Name + "_" + fkk3.ReferencedColumns[0].Name;
							if (columnInfo.Name.EndsWith(endStr))
								fkk3_ReferencedTable_ObjName = columnInfo.Name.Remove(columnInfo.Name.Length - fkk3.ReferencedColumns[0].Name.Length - 1);

							fkk3_ReferencedTable_ObjName = UFString(fkk3_ReferencedTable_ObjName);
							parms1 += UFString(fkk3.ReferencedTable.ClassName) + "Info " + fkk3_ReferencedTable_ObjName + ", ";
							parmsNoneType1 += fkk3_ReferencedTable_ObjName + "." + UFString(fkk3.ReferencedColumns[0].Name) + ", ";
							if (!is_addignore) {
								parms1_add += UFString(fkk3.ReferencedTable.ClassName) + "Info " + fkk3_ReferencedTable_ObjName + ", ";
								parmsNoneType1_add += fkk3_ReferencedTable_ObjName + "." + UFString(fkk3.ReferencedColumns[0].Name) + ", ";
							}

							if (columnInfo.IsPrimaryKey) {
								parms3 += UFString(fkk3.ReferencedTable.ClassName) + "Info " + fkk3_ReferencedTable_ObjName + ", ";
								parmsNoneType3 += fkk3_ReferencedTable_ObjName + "." + UFString(fkk3.ReferencedColumns[0].Name) + ", ";
								parms4 += columnInfo.CsType + " " + UFString(columnInfo.Name) + ", ";
								parmsNoneType4 += string.Format(GetCSTypeValue(columnInfo.Type), UFString(columnInfo.Name)) + ", ";
							}
							//UFString(columnInfo.Name) + " ?? default(" + columnInfo.CsType.Replace("?", "") + "), ";
							if (add_or_flag != "Flag" && fk.Columns[0].IsPrimaryKey) //中间表关系键，必须为主键
								t2.Uniques.ForEach(delegate (List<ColumnInfo> cs) {
									if (cs.Count < 2) return;
									ms = 0;
									foreach (ColumnInfo c in cs) {
										if (t2.ForeignKeys.Find(delegate (ForeignKeyInfo ffkk2) {
											return ffkk2.Columns[0].Name == c.Name;
										}) != null) ms++;
									}
									if (ms == cs.Count) {
										add_or_flag = "Flag";
									}
								});
						}
					}
					if (parms1.Length > 0) parms1 = parms1.Remove(parms1.Length - 2);
					if (parmsNoneType1.Length > 0) parmsNoneType1 = parmsNoneType1.Remove(parmsNoneType1.Length - 2);
					if (parms1_add.Length > 0) parms1_add = parms1_add.Remove(parms1_add.Length - 2);
					if (parmsNoneType1_add.Length > 0) parmsNoneType1_add = parmsNoneType1_add.Remove(parmsNoneType1_add.Length - 2);

					if (parms2.Length > 0) parms2 = parms2.Remove(parms2.Length - 2);
					if (parmsNoneType2.Length > 0) parmsNoneType2 = parmsNoneType2.Remove(parmsNoneType2.Length - 2);
					if (parms2_add.Length > 0) parms2_add = parms2_add.Remove(parms2_add.Length - 2);
					if (parmsNoneType2_add.Length > 0) parmsNoneType2_add = parmsNoneType2_add.Remove(parmsNoneType2_add.Length - 2);

					if (parms3.Length > 0) parms3 = parms3.Remove(parms3.Length - 2);
					if (parmsNoneType3.Length > 0) parmsNoneType3 = parmsNoneType3.Remove(parmsNoneType3.Length - 2);
					if (parms4.Length > 0) parms4 = parms4.Remove(parms4.Length - 2);
					if (parmsNoneType4.Length > 0) parmsNoneType4 = parmsNoneType4.Remove(parmsNoneType4.Length - 2);
					if (pkNamesNoneType.Length > 0) pkNamesNoneType = pkNamesNoneType.Remove(pkNamesNoneType.Length - 2);

					if (add_or_flag == "Flag") {
						if (parms1 != parms2) {
							sb6.AppendFormat(@"
		public {0}Info Flag{1}({2}) => Flag{1}({3});", UFString(t2.ClassName), UFString(addname_schema), parms1, parmsNoneType1);
							sb16.AppendFormat(@"
		async public Task<{0}Info> Flag{1}Async({2}) => await Flag{1}Async({3});", UFString(t2.ClassName), UFString(addname_schema), parms1, parmsNoneType1);
						}
						sb6.AppendFormat(@"
		public {0}Info Flag{1}({2}) {{
			{0}Info item = BLL.{0}.GetItem({5});
			if (item == null) item = BLL.{0}.Insert(new {0}Info {{{3}}});{6}
			return item;
		}}
", UFString(t2.ClassName), UFString(addname_schema), parms2, parmsNoneType2.Replace("\t\t\t", "\t\t\t\t"), solutionName, pkNamesNoneType, updateDiySet.Length > 0 ? "\r\n\t\t\telse item.UpdateDiy" + updateDiySet + ".ExecuteNonQuery();" : string.Empty);
						sb16.AppendFormat(@"
		async public Task<{0}Info> Flag{1}Async({2}) {{
			{0}Info item = await BLL.{0}.GetItemAsync({5});
			if (item == null) item = await BLL.{0}.InsertAsync(new {0}Info {{{3}}});{6}
			return item;
		}}
", UFString(t2.ClassName), UFString(addname_schema), parms2, parmsNoneType2.Replace("\t\t\t", "\t\t\t\t"), solutionName, pkNamesNoneType, updateDiySet.Length > 0 ? "\r\n\t\t\telse await item.UpdateDiy" + updateDiySet + ".ExecuteNonQueryAsync();" : string.Empty);

					} else {
						//sb6.Append(addname + "," + t2.Name);
						if (parms1_add != parms2_add) {
							sb6.AppendFormat(@"
		public {0}Info Add{1}({2}) => Add{1}({3});", UFString(t2.ClassName), UFString(addname_schema), parms1_add, parmsNoneType1_add);
							sb16.AppendFormat(@"
		async public Task<{0}Info> Add{1}Async({2}) => await Add{1}Async({3});", UFString(t2.ClassName), UFString(addname_schema), parms1_add, parmsNoneType1_add);

						}
						sb6.AppendFormat(@"
		public {0}Info Add{1}({2}) => Add{1}(new {0}Info {{{3}}});
		public {0}Info Add{1}({0}Info item) {{{5}
			return BLL.{0}.Insert(item);
		}}
", UFString(t2.ClassName), UFString(addname_schema), parms2_add, parmsNoneType2_add, solutionName, parmsNoneType5);
						sb16.AppendFormat(@"
		async public Task<{0}Info> Add{1}Async({2}) => await Add{1}Async(new {0}Info {{{3}}});
		async public Task<{0}Info> Add{1}Async({0}Info item) {{{5}
			return await BLL.{0}.InsertAsync(item);
		}}
", UFString(t2.ClassName), UFString(addname_schema), parms2_add, parmsNoneType2_add, solutionName, parmsNoneType5);
					}

					if (add_or_flag == "Flag") {
						string deleteByUniqui = string.Empty;
						for (int deleteByUniqui_a = 0; deleteByUniqui_a < fk.Table.Uniques.Count; deleteByUniqui_a++)
							if (fk.Table.Uniques[deleteByUniqui_a].Count > 1 && fk.Table.Uniques[deleteByUniqui_a][0].IsPrimaryKey == false) {
								foreach (ColumnInfo deleteByuniquiCol in fk.Table.Uniques[deleteByUniqui_a])
									deleteByUniqui = deleteByUniqui + "And" + UFString(deleteByuniquiCol.Name);
								deleteByUniqui = "By" + deleteByUniqui.Substring(3);
								break;
							}
						sb6.AppendFormat(@"
		public {0}Info Unflag{1}({2}) => Unflag{1}({3});
		public {0}Info Unflag{1}({4}) => BLL.{0}.Delete{9}({5});
		public List<{0}Info> Unflag{1}ALL() => BLL.{0}.DeleteBy{8}(this.{7});
", UFString(t2.ClassName), UFString(addname_schema), parms3, parmsNoneType3, parms4, parmsNoneType4,
	solutionName, string.Format(GetCSTypeValue(fk.ReferencedColumns[0].Type), UFString(pkName)),
							UFString(fk.Columns[0].Name), deleteByUniqui);
						sb16.AppendFormat(@"
		async public Task<{0}Info> Unflag{1}Async({2}) => await Unflag{1}Async({3});
		async public Task<{0}Info> Unflag{1}Async({4}) => await BLL.{0}.Delete{9}Async({5});
		async public Task<List<{0}Info>> Unflag{1}ALLAsync() => await BLL.{0}.DeleteBy{8}Async(this.{7});
", UFString(t2.ClassName), UFString(addname_schema), parms3, parmsNoneType3, parms4, parmsNoneType4,
	solutionName, string.Format(GetCSTypeValue(fk.ReferencedColumns[0].Type), UFString(pkName)),
							UFString(fk.Columns[0].Name), deleteByUniqui);
						if (ms > 2) {

						} else {
							string civ = string.Format(GetCSTypeValue(fk.ReferencedColumns[0].Type), "_" + UFString(pkName));
							string f5 = t2name;
							//if (addname != f5) {
							string fk20_ReferencedTable_Name = fk2[0].ReferencedTable.Name;
							string fk_ReferencedTable_Name = fk.ReferencedTable.Name;
							if (f5.StartsWith(fk20_ReferencedTable_Name + "_"))
								f5 = f5.Substring(fk20_ReferencedTable_Name.Length + 1);
							else if (f5.EndsWith("_" + fk20_ReferencedTable_Name))
								f5 = f5.Remove(f5.Length - fk20_ReferencedTable_Name.Length - 1);
							else if (string.Compare(t2name, fk20_ReferencedTable_Name + "_" + fk_ReferencedTable_Name) != 0 &&
								string.Compare(t2name, fk_ReferencedTable_Name + "_" + fk20_ReferencedTable_Name) != 0)
								f5 = addname_schema;
							//}
							string objs_value = string.Format(@"
		private List<{0}Info> _obj_{1}s;
		public List<{0}Info> Obj_{1}s => _obj_{1}s ?? (_obj_{1}s = BLL.{0}.SelectBy{5}_{4}({3}).ToList());", UFString(fk2[0].ReferencedTable.ClassName), addname_schema, solutionName, civ, fk2[0].ReferencedTable.PrimaryKeys[0].Name, UFString(f5));
							//如果中间表字段 > 2，那么应该把其中间表也查询出来
							if (t2.Columns.Count > 2) {
								string _f6 = fk.Columns[0].Name;
								string _f7 = fk.ReferencedTable.PrimaryKeys[0].Name;
								string _f8 = fk2[0].Columns[0].Name;
								string _f9 = fk2[0].ReferencedTable.PrimaryKeys[0].CsType.Replace("?", "");

								if (fk.ReferencedTable.ClassName == fk2[0].ReferencedTable.ClassName &&
									string.Compare(main_column, fk.Columns[0].Name, true) != 0) {
									_f6 = fk2[0].Columns[0].Name;
									_f7 = fk2[0].ReferencedTable.PrimaryKeys[0].Name;
									_f8 = fk.Columns[0].Name;
									_f9 = fk2[0].Table.PrimaryKeys[0].CsType.Replace("?", "");
								}

								objs_value = string.Format(@"
		public {2}Info Obj_{3} {{ set; get; }}
		private List<{0}Info> _obj_{1}s;
		/// <summary>
		/// 遍历时，可通过 Obj_{3} 可获取中间表数据
		/// </summary>
		public List<{0}Info> Obj_{1}s => _obj_{1}s ?? (_obj_{1}s = BLL.{0}.Select.InnerJoin<BLL.{2}>(""b"", @""b.""""{6}"""" = a.""""{5}"""""").Where(@""b.""""{4}"""" = {{0}}"", {7}).ToList());", UFString(fk2[0].ReferencedTable.ClassName), addname_schema, UFString(t2.ClassName), t2.ClassName,
			_f6, _f7, _f8, civ.Replace(".Value", ""));
							}
							string objs_key = string.Format("Obj_{0}s", addname);
							if (dic_objs.ContainsKey(objs_key))
								dic_objs[objs_key] = objs_value;
							else
								dic_objs.Add(objs_key, objs_value);
						}
					} else {
						string f2 = fk.Columns[0].Name.CompareTo("parent_id") == 0 ? t2name : fk.Columns[0].Name.Replace(tablename + "_" + table.PrimaryKeys[0].Name, "") + t2name;
						if (fk.Columns[0].IsPrimaryKey && fk.Table.PrimaryKeys.Count == 1) { //1对1关系，不应该生成 obj_xxxs
							string obj_value = string.Format(@"
		private {0}Info _obj_{1};
		public {0}Info Obj_{1} {{
			get {{ return _obj_{1} ?? (_{4} == null ? null : (_obj_{1} = BLL.{0}.GetItem(_{5}))); }}
			internal set {{ _obj_{1} = value; }}
		}}", UFString(t2.ClassName), t2.ClassName, solutionName, UFString(fk.Columns[0].Name), UFString(fk.ReferencedColumns[0].Name), string.Format(GetCSTypeValue(fk.ReferencedColumns[0].Type), UFString(fk.ReferencedColumns[0].Name)));
							string objs_key = string.Format("Obj_{0}", f2);
							if (!dic_objs.ContainsKey(objs_key))
								dic_objs.Add(objs_key, obj_value);
						} else {
							string objs_value = string.Format(@"
		private List<{0}Info> _obj_{1}s;
		public List<{0}Info> Obj_{1}s => _obj_{1}s ?? (_obj_{1}s = BLL.{0}.SelectBy{3}(_{4}).Limit(500).ToList());", UFString(t2.ClassName), f2, solutionName, UFString(fk.Columns[0].Name), UFString(table.PrimaryKeys[0].Name));
							string objs_key = string.Format("Obj_{0}s", f2);
							if (!dic_objs.ContainsKey(objs_key))
								dic_objs.Add(objs_key, objs_value);
						}
					}
				});
				string[] dic_objs_values = new string[dic_objs.Count];
				dic_objs.Values.CopyTo(dic_objs_values, 0);
				sb9.Append(string.Join("", dic_objs_values));

				string[] innerjoinObjs_values = new string[innerjoinObjs.Count];
				innerjoinObjs.Values.CopyTo(innerjoinObjs_values, 0);
				sb9.Append(string.Join("", innerjoinObjs_values));

				string pkupdatediy = "";
				if (table.PrimaryKeys.Count > 0) {
					string newguid = "";
					foreach (ColumnInfo guidpk in table.PrimaryKeys)
						if (guidpk.CsType == "Guid?") newguid += string.Format(@"
			this.{0} = BLL.PSqlHelper.NewMongodbId();", UFString(guidpk.Name));

					if (table.Columns.Count > table.PrimaryKeys.Count || !string.IsNullOrEmpty(newguid)) {
						ColumnInfo colUpdateTime = table.Columns.Find(delegate (ColumnInfo fcc) { return fcc.Name.ToLower() == "update_time" && fcc.CsType == "DateTime?"; });
						ColumnInfo colCreateTime = table.Columns.Find(delegate (ColumnInfo fcc) { return fcc.Name.ToLower() == "create_time" && fcc.CsType == "DateTime?"; });
						sb6.Insert(0, string.Format(@"
		public {1}Info Save() {{{2}
			if (this.{4} != null) {{
				if (BLL.{1}.Update(this) == 0) return BLL.{1}.Insert(this);
				return this;
			}}{5}{3}
			return BLL.{1}.Insert(this);
		}}", solutionName, uClass_Name, colUpdateTime != null ? @"
			this." + UFString(colUpdateTime.Name) + " = DateTime.Now;" : "", colCreateTime != null ? @"
			this." + UFString(colCreateTime.Name) + " = DateTime.Now;" : "", pkCsParamNoType.Replace(", ", " != null && this."), newguid));
						sb16.Insert(0, string.Format(@"
		async public Task<{1}Info> SaveAsync() {{{2}
			if (this.{4} != null) {{
				if (await BLL.{1}.UpdateAsync(this) == 0) return await BLL.{1}.InsertAsync(this);
				return this;
			}}{5}{3}
			return await BLL.{1}.InsertAsync(this);
		}}", solutionName, uClass_Name, colUpdateTime != null ? @"
			this." + UFString(colUpdateTime.Name) + " = DateTime.Now;" : "", colCreateTime != null ? @"
			this." + UFString(colCreateTime.Name) + " = DateTime.Now;" : "", pkCsParamNoType.Replace(", ", " != null && this."), newguid));
					}
					string[] pkisnullfields = pkCsParamNoTypeByval.Split(new string[] { ", " }, StringSplitOptions.None);
					string pkisnull = "";
					foreach(string pkisnullfield in pkisnullfields) {
						if (pkisnullfield.EndsWith(".Value")) pkisnull += string.Format("_{0} == null || ", pkisnullfield.Replace(".Value", ""));
					}
					string pkisnullf3 = "";
					if (!string.IsNullOrEmpty(pkisnull)) pkisnullf3 = string.Format("{0} ? null : ", pkisnull.Substring(0, pkisnull.Length - 4));
					pkupdatediy = string.Format(@"
		public {0}.DAL.{1}.SqlUpdateBuild UpdateDiy => {3}BLL.{1}.UpdateDiy(new List<{1}Info> {{ this }});
", solutionName, uClass_Name, pkCsParamNoTypeByval.Replace(", ", ", _"), pkisnullf3);
				}

				sb1.AppendFormat(
	@"		#endregion

		public {0}Info() {{ }}", uClass_Name);

				sb1.AppendFormat(@"
{1}{2}
		#region 序列化，反序列化
		public string Stringify() => JsonConvert.SerializeObject(this{13});
		public static {0}Info Parse(string stringify) {{
			if (string.IsNullOrEmpty(stringify) || stringify == ""null"") return null;
			return JsonConvert.DeserializeObject<{0}Info>(stringify{13});
		}}
		#endregion

		#region override
		private static Lazy<Dictionary<string, bool>> __jsonIgnoreLazy = new Lazy<Dictionary<string, bool>>(() => {{
			FieldInfo field = typeof({0}Info).GetField(""JsonIgnore"");
			Dictionary<string, bool> ret = new Dictionary<string, bool>();
			if (field != null) string.Concat(field.GetValue(null)).Split(',').ToList().ForEach(f => {{
				if (!string.IsNullOrEmpty(f)) ret[f] = true;
			}});
			return ret;
		}});
		private static Dictionary<string, bool> __jsonIgnore => __jsonIgnoreLazy.Value;
		public override string ToString() => JsonConvert.SerializeObject(this.ToBson());
		public IDictionary ToBson(bool allField = false) {{
			IDictionary ht = new Hashtable();{10}
			return ht;
		}}
		{12}public object this[string key] {{
		{12}	get {{ return this.GetType().GetProperty(key).GetValue(this); }}
		{12}	set {{ this.GetType().GetProperty(key).SetValue(this, value); }}
		{12}}}
		#endregion

		#region properties
{4}{9}
		#endregion
{14}
		#region sync methods
{5}
		#endregion

		#region async methods
{11}
		#endregion
	}}
}}

", uClass_Name, "", "", sb5.ToString(), sb2.ToString(), sb6.ToString(), table.Columns.Count, sb7.ToString(), sb8.ToString(), sb9.ToString(), sb10.ToString(), sb16.ToString(),
	table.Columns.Find(delegate (ColumnInfo fccc) {
		return fccc.Name.ToLower() == "item";
	}) == null ? "" : "//", table.Columns.Find(delegate (ColumnInfo fccc2) {
		return fccc2.Type == NpgsqlDbType.Geometry;
	}) == null ? "" : ", new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All }", pkupdatediy);

				loc1.Add(new BuildInfo(string.Concat(CONST.corePath, solutionName, @".db\Model\", basicName, @"\", uClass_Name, "Info.cs"), Deflate.Compress(Is_System_ComponentModel ? sb1.ToString().Replace("using System.Reflection;", "using System.ComponentModel;\r\nusing System.Reflection;") : sb1.ToString())));
				clearSb();

				Model_Build_ExtensionMethods_cs.AppendFormat(@"
	public static string ToJson(this {0}Info item) => JsonConvert.SerializeObject(GetBson(new [] {{ item }}).First());
	public static string ToJson(this {0}Info[] items) => JsonConvert.SerializeObject(GetBson(items));
	public static string ToJson(this IEnumerable<{0}Info> items) => JsonConvert.SerializeObject(GetBson(items));
	public static IDictionary[] ToBson(this {0}Info[] items, Func<{0}Info, object> func = null) => GetBson(items, func);
	public static IDictionary[] ToBson(this IEnumerable<{0}Info> items, Func<{0}Info, object> func = null) => GetBson(items, func);", uClass_Name, solutionName);

				if (table.PrimaryKeys.Count > 0)
					Model_Build_ExtensionMethods_cs.AppendFormat(@"
	public static {1}.DAL.{0}.SqlUpdateBuild UpdateDiy(this List<{0}Info> items) => {1}.BLL.{0}.UpdateDiy(items);", uClass_Name, solutionName);
				Model_Build_ExtensionMethods_cs.AppendFormat(@"
");
				#endregion

				#region DAL *.cs

				#region use t-sql
				string sqlFields = "";
				string sqlDelete = string.Format("DELETE FROM {0} ", nTable_Name);
				string sqlUpdate = string.Format("UPDATE {0} SET ", nTable_Name);
				string sqlInsert = string.Format("INSERT INTO {0}(", nTable_Name);
				string insertField = string.Empty;
				string insertParms = string.Empty;
				string temp1 = string.Empty;
				string temp2 = string.Empty;
				string temp3 = string.Empty;
				string temp4 = string.Empty;
				foreach (ColumnInfo columnInfo in table.Columns) {
					if (columnInfo.IsIdentity == false) {
						temp1 += string.Format(@"""""{0}"""" = @{0}, ", columnInfo.Name);
						temp2 += string.Format(@"""""{0}"""", ", columnInfo.Name);
						temp3 += string.Format("@{0}, ", columnInfo.Name);
					}
					temp4 += string.Format(@"a.""""{0}"""", ", columnInfo.Name);
				}
				if (temp1.Length > 0) {
					temp1 = temp1.Substring(0, temp1.Length - 2);
					temp2 = temp2.Substring(0, temp2.Length - 2);
					temp3 = temp3.Substring(0, temp3.Length - 2);
				}
				temp4 = temp4.Substring(0, temp4.Length - 2);
				sqlFields = temp4;
				sqlDelete += "WHERE ";
				sqlUpdate += temp1 + string.Format(" WHERE {0}", pkSqlParam);
				sqlInsert += string.Format("{0}) VALUES({1})", temp2, temp3);
				insertField = temp2;
				insertParms = temp3;

				temp1 = "";
				temp2 = "";
				temp3 = "";
				temp4 = "";

				sb1.AppendFormat(
	@"using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Net;
using System.Net.NetworkInformation;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Npgsql;
using NpgsqlTypes;
using Npgsql.LegacyPostgis;
using {0}.Model;

namespace {0}.DAL {{

	public partial class {1} : IDAL {{
		#region transact-sql define
		public string Table {{ get {{ return TSQL.Table; }} }}
		public string Field {{ get {{ return TSQL.Field; }} }}
		public string Sort {{ get {{ return TSQL.Sort; }} }}
		internal class TSQL {{
			internal static readonly string Table = @""{3}"";
			internal static readonly string Field = @""{5}"";
			internal static readonly string Sort = @""{6}"";
			internal static readonly string Returning = @"" RETURNING "" + Field.Replace(@""a."""""", @"""""""");
			internal static readonly string Delete = @""DELETE FROM {3} WHERE "";
			internal static readonly string InsertField = @""{2}"";
			internal static readonly string InsertValues = @""{4}"";
			internal static readonly string InsertMultiFormat = @""INSERT INTO {3}("" + InsertField + "") VALUES{{0}}"" + Returning;
			internal static readonly string Insert = string.Format(InsertMultiFormat, $""({{InsertValues}})"");
		}}
		#endregion

		#region common call
		protected static NpgsqlParameter[] GetParameters({1}Info item) {{
			return new NpgsqlParameter[] {{
{7}
			}};
		}}", solutionName, uClass_Name, insertField, nTable_Name, insertParms, sqlFields, orderBy, AppendParameters(table, "				"));

				sb1.AppendFormat(@"
		public {0}Info GetItem(NpgsqlDataReader dr) {{
			int dataIndex = -1;
			return GetItem(dr, ref dataIndex) as {0}Info;
		}}
		public object GetItem(NpgsqlDataReader dr, ref int dataIndex) {{
			{0}Info item = new {0}Info();", uClass_Name);

                int getItemIndex = 0;
				foreach (ColumnInfo columnInfo in table.Columns) {
                    ++getItemIndex;
                    sb1.AppendFormat(@"
			if (!dr.IsDBNull(++dataIndex)) item.{0} = {1};", (columnInfo.CsType == "JToken" ? "_" : "") + UFString(columnInfo.Name), GetDataReaderMethod(columnInfo.Type, columnInfo.CsType));
					if (columnInfo.IsPrimaryKey)
						sb1.AppendFormat(@" if (item.{0} == null) {{ dataIndex += {1}; return null; }}", (columnInfo.CsType == "JToken" ? "_" : "") + UFString(columnInfo.Name), table.Columns.Count - getItemIndex);
				}

				sb1.AppendFormat(@"
			return item;
		}}
		private void CopyItemAllField({0}Info item, {0}Info newitem) {{{1}
		}}", uClass_Name, csItemAllFieldCopy);
				sb1.Append(sb4.ToString());
				sb1.AppendFormat(@"
		#endregion", uClass_Name, table.Columns.Count + 1);

				string dal_async_code = string.Format(@"
		async public Task<{0}Info> GetItemAsync(NpgsqlDataReader dr) {{
			var read = await GetItemAsync(dr, -1);
			return read.result as {0}Info;
		}}
		async public Task<(object result, int dataIndex)> GetItemAsync(NpgsqlDataReader dr, int dataIndex) {{
			{0}Info item = new {0}Info();", uClass_Name);
                getItemIndex = 0;
                foreach (ColumnInfo columnInfo in table.Columns) {
                    ++getItemIndex;
                    dal_async_code += string.Format(@"
			if (!await dr.IsDBNullAsync(++dataIndex)) item.{0} = {1};", (columnInfo.CsType == "JToken" ? "_" : "") + UFString(columnInfo.Name), GetDataReaderMethodAsync(columnInfo.Type, columnInfo.CsType));
					if (columnInfo.IsPrimaryKey)
						dal_async_code += string.Format(@" if (item.{0} == null) {{ dataIndex += {1}; return (null, dataIndex); }}", (columnInfo.CsType == "JToken" ? "_" : "") + UFString(columnInfo.Name), table.Columns.Count - getItemIndex);
				}

				dal_async_code += string.Format(@"
			return (item, dataIndex);
		}}", uClass_Name);

				Dictionary<string, bool> del_exists = new Dictionary<string, bool>();
				foreach (List<ColumnInfo> cs in table.Uniques) {
					string parms = string.Empty;
					string parmsBy = "By";
					string sqlParms = string.Empty;
					string sqlParmsA = string.Empty;
					string sqlParmsANoneType = string.Empty;
					int sqlParmsAIndex = 0;
					foreach (ColumnInfo columnInfo in cs) {
						parms += columnInfo.CsType.Replace("?", "") + " " + UFString(columnInfo.Name) + ", ";
						parmsBy += UFString(columnInfo.Name) + "And";
						sqlParms += @"""""" + columnInfo.Name + @""""" = @" + columnInfo.Name + " AND ";
						sqlParmsA += @"a.""""" + columnInfo.Name + @""""" = {" + sqlParmsAIndex++ + "} AND ";
						sqlParmsANoneType += UFString(columnInfo.Name) + ", ";
					}
					parms = parms.Substring(0, parms.Length - 2);
					parmsBy = parmsBy.Substring(0, parmsBy.Length - 3);
					sqlParms = sqlParms.Substring(0, sqlParms.Length - 5);
					sqlParmsA = sqlParmsA.Substring(0, sqlParmsA.Length - 5);
					sqlParmsANoneType = sqlParmsANoneType.Substring(0, sqlParmsANoneType.Length - 2);
					if (del_exists.ContainsKey(parms)) continue;
					del_exists.Add(parms, true);
					sb2.AppendFormat(@"
		public {0}Info Delete{3}({1}) {{
			{0}Info item = null;
			PSqlHelper.ExecuteReader(dr => {{ item = BLL.{0}.dal.GetItem(dr); }}, string.Concat(TSQL.Delete, @""{2}"", TSQL.Returning),
{4});
			return item;
		}}", uClass_Name, parms, sqlParms, cs[0].IsPrimaryKey ? string.Empty : parmsBy, AppendParameters(cs, "				"));
					dal_async_code += string.Format(@"
		async public Task<{0}Info> Delete{3}Async({1}) {{
			{0}Info item = null;
			await PSqlHelper.ExecuteReaderAsync(async dr => {{ item = await BLL.{0}.dal.GetItemAsync(dr); }}, string.Concat(TSQL.Delete, @""{2}"", TSQL.Returning),
{4});
			return item;
		}}", uClass_Name, parms, sqlParms, cs[0].IsPrimaryKey ? string.Empty : parmsBy, AppendParameters(cs, "				"));
				}
				table.ForeignKeys.ForEach(delegate (ForeignKeyInfo fkk) {
					string parms = string.Empty;
					string parmsBy = "By";
					string sqlParms = string.Empty;
					foreach (ColumnInfo columnInfo in fkk.Columns) {
						parms += columnInfo.CsType.Replace("?", "") + " " + UFString(columnInfo.Name) + ", ";
						parmsBy += UFString(columnInfo.Name) + "And";
						sqlParms += @"""""" + columnInfo.Name + @""""" = @" + columnInfo.Name + " AND ";
					}
					parms = parms.Substring(0, parms.Length - 2);
					parmsBy = parmsBy.Substring(0, parmsBy.Length - 3);
					sqlParms = sqlParms.Substring(0, sqlParms.Length - 5);
					if (del_exists.ContainsKey(parms)) return;
					del_exists.Add(parms, true);

					sb2.AppendFormat(@"
		public List<{0}Info> Delete{3}({1}) {{
			var items = new List<{0}Info>();
			PSqlHelper.ExecuteReader(dr => {{ items.Add(BLL.{0}.dal.GetItem(dr)); }}, string.Concat(TSQL.Delete, @""{2}"", TSQL.Returning),
{4});
			return items;
		}}", uClass_Name, parms, sqlParms, parmsBy, AppendParameters(fkk.Columns, "				"));
					dal_async_code += string.Format(@"
		async public Task<List<{0}Info>> Delete{3}Async({1}) {{
			var items = new List<{0}Info>();
			await PSqlHelper.ExecuteReaderAsync(async dr => {{ items.Add(await BLL.{0}.dal.GetItemAsync(dr)); }}, string.Concat(TSQL.Delete, @""{2}"", TSQL.Returning),
{4});
			return items;
		}}", uClass_Name, parms, sqlParms, parmsBy, AppendParameters(fkk.Columns, "				"));
				});

				if (table.PrimaryKeys.Count > 0) {
					#region 如果没有主键的处理UpdateBuild
					foreach (ColumnInfo col in table.Columns) {
						if (col.IsIdentity ||
							col.IsPrimaryKey && col.Type == NpgsqlDbType.Uuid ||
							table.PrimaryKeys.FindIndex(delegate (ColumnInfo pkf) { return pkf.Name == col.Name && pkf.Type == NpgsqlDbType.Uuid; }) != -1) continue;
						string arrParm = "";
						string arrUnde = "";
						string arrUndeSql = "";
						string arrType = col.CsType;
						for (int a = 0; a < col.Attndims; a++) {
							arrParm += ", int " + (char)('i' + a);
							arrUnde += ", " + (char)('i' + a);
							arrUndeSql += ", {" + (char)('i' + a) + "}";
						}
						if (col.Attndims > 0) {
							arrUnde = "[{" + arrUnde.Substring(2) + "}]";
							arrUndeSql = "[" + arrUndeSql.Substring(2) + "]";
							arrType = GetCSType(col.Type, 0, col.SqlType);
						}
						string lname = LFString(col.Name);
						string valueParm = AppendParameters(col, "");
						valueParm = valueParm.Remove(valueParm.LastIndexOf("Value = ") + 8);
						string valueParm2 = valueParm.Replace("\"" + col.Name + "\"", "$\"@" + col.Name + "_{_parameters.Count}\"");
						if (col.Attndims > 0) {
							sb5.AppendFormat(@"
			public SqlUpdateBuild Set{0}({2} value) {{
				if (_dataSource != null && _setAs.ContainsKey(""{0}"") == false) _setAs.Add(""{0}"", (olditem, newitem) => olditem.{0} = newitem.{0});
				return this.Set(@""""""{1}"""""", $""@{1}_{{_parameters.Count}}"", 
					{3}value }});
			}}
			public SqlUpdateBuild Set{0}Join({2} value) {{
				if (_dataSource != null && _setAs.ContainsKey(""{0}"") == false) _setAs.Add(""{0}"", (olditem, newitem) => olditem.{0} = newitem.{0});
				return this.Set(@""""""{1}"""""", $@""""""{1}"""" || @{1}_{{_parameters.Count}}"", 
					{3}value }});
			}}
			public SqlUpdateBuild Set{0}Remove({4} value) {{
				if (_dataSource != null && _setAs.ContainsKey(""{0}"") == false) _setAs.Add(""{0}"", (olditem, newitem) => olditem.{0} = newitem.{0});
				return this.Set(@""""""{1}"""""", $@""array_remove(""""{1}"""", @{1}_{{_parameters.Count}})"", 
					{5}value }});
			}}", UFString(col.Name), col.Name, col.CsType, valueParm2, arrType, valueParm2.Replace("NpgsqlDbType.Array | ", ""));
						}
						sb5.AppendFormat(@"
			public SqlUpdateBuild Set{0}({2} value{4}) {{
				if (_dataSource != null && _setAs.ContainsKey(""{0}"") == false) _setAs.Add(""{0}"", (olditem, newitem) => olditem.{0} = newitem.{0});
				return this.Set({6}@""""""{1}""""{5}"", $""@{1}_{{_parameters.Count}}"", 
					{3}value{7} }});
			}}", UFString(col.Name), col.Name, arrType, valueParm2.Replace("NpgsqlDbType.Array | ", ""), arrParm, arrUndeSql, string.IsNullOrEmpty(arrUndeSql) ? "" : "$", 
				col.Type == NpgsqlDbType.Json || col.Type == NpgsqlDbType.Jsonb ? "?.ToString()" : "");
						if (table.ForeignKeys.FindIndex(delegate (ForeignKeyInfo fkf) { return fkf.Columns.FindIndex(delegate (ColumnInfo fkfpkf) { return fkfpkf.Name == col.Name; }) != -1; }) == -1) {
							string fptype = "";
							if (col.Type == NpgsqlDbType.Smallint || col.Type == NpgsqlDbType.Integer || col.Type == NpgsqlDbType.Bigint ||
								col.Type == NpgsqlDbType.Numeric || col.Type == NpgsqlDbType.Real || col.Type == NpgsqlDbType.Double || col.Type == NpgsqlDbType.Money) {
								fptype = col.Attndims > 0 ? arrType : col.CsType.TrimEnd('?');
							}
							if ((col.Type == NpgsqlDbType.Integer || col.Type == NpgsqlDbType.Bigint) && (lname == "status" || lname.StartsWith("status_") || lname.EndsWith("_status"))) {
								fptype = "";
								sb5.AppendFormat(@"
			public SqlUpdateBuild Set{0}Flag(int _0_16{4}, bool isUnFlag = false) {{
				if (_dataSource != null && _setAs.ContainsKey(""{0}"") == false) _setAs.Add(""{0}"", (olditem, newitem) => olditem.{0} = newitem.{0});
				{2} tmp1 = ({2})Math.Pow(2, _0_16);
				return this.Set({7}@""""""{1}""""{5}"", $@""COALESCE(""""{1}""""{6},0) {{(isUnFlag ? '^' : '|')}} @{1}_{{_parameters.Count}}"", 
					{3}tmp1 }});
			}}
			public SqlUpdateBuild Set{0}UnFlag(int _0_16{4}) {{
				return this.Set{0}Flag(_0_16{8}, true);
			}}", UFString(col.Name), col.Name, arrType, valueParm2.Replace("NpgsqlDbType.Array | ", ""),
					arrParm, arrUndeSql, arrUndeSql, string.IsNullOrEmpty(arrUndeSql) ? "" : "$", col.Attndims > 0 ? " ," + arrUnde.Trim('[', ']') : "");
							}
							if (!string.IsNullOrEmpty(fptype)) {
								sb5.AppendFormat(@"
			public SqlUpdateBuild Set{0}Increment({2} value{4}) {{
				if (_dataSource != null && _setAs.ContainsKey(""{0}"") == false) _setAs.Add(""{0}"", (olditem, newitem) => olditem.{0} = newitem.{0});
				return this.Set({7}@""""""{1}""""{5}"", $@""COALESCE(""""{1}""""{6}, 0) + @{1}_{{_parameters.Count}}"", 
					{3}value }});
			}}", UFString(col.Name), col.Name, fptype, valueParm2.Replace("NpgsqlDbType.Array | ", ""),
					arrParm, arrUndeSql, arrUndeSql, string.IsNullOrEmpty(arrUndeSql) ? "" : "$", col.Attndims > 0 ? " ," + arrUnde.Trim('[', ']') : "");
							}
						}
						sb6.AppendFormat(@"
			if (ignore.ContainsKey(""{1}"") == false) sub.Set{0}(item.{0});", UFString(col.Name), col.Name);
					}

					string dal_insert_code = string.Format(@"
		public {0}Info Insert({0}Info item) {{
			{0}Info newitem = null;
			PSqlHelper.ExecuteReader(dr => {{ newitem = GetItem(dr); }}, TSQL.Insert, GetParameters(item));
			if (newitem == null) return null;
			this.CopyItemAllField(item, newitem);
			return item;
		}}
		public List<{0}Info> Insert(IEnumerable<{0}Info> items) {{
			var mp = InsertMakeParam(items);
			if (string.IsNullOrEmpty(mp.sql)) return new List<{0}Info>();
			List<{0}Info> newitems = new List<{0}Info>();
			PSqlHelper.ExecuteReader(dr => {{ newitems.Add(BLL.{0}.dal.GetItem(dr)); }}, mp.sql, mp.parms);
			return newitems;
		}}
		public (string sql, NpgsqlParameter[] parms) InsertMakeParam(IEnumerable<{0}Info> items) {{
			var itemsArr = items?.Where(a => a != null).ToArray();
			if (itemsArr == null || itemsArr.Any() == false) return (null, null);
			var values = """";
			var parms = new NpgsqlParameter[itemsArr.Length * {1}];
			for (var a = 0; a < itemsArr.Length; a++) {{
				var item = itemsArr[a];
				values += $"",({{TSQL.InsertValues.Replace("", "", a + "", "")}}{{a}})"";
				var tmparms = GetParameters(item);
				for (var b = 0; b < tmparms.Length; b++) {{
					tmparms[b].ParameterName += a;
					parms[a * {1} + b] = tmparms[b];
				}}
			}}
			return (string.Format(TSQL.InsertMultiFormat, values.Substring(1)), parms);
		}}", uClass_Name, insertParms.Split(new[] { ", " }, StringSplitOptions.None).Length);

					dal_async_code += string.Format(@"
		async public Task<{0}Info> InsertAsync({0}Info item) {{
			{0}Info newitem = null;
			await PSqlHelper.ExecuteReaderAsync(async dr => {{ newitem = await GetItemAsync(dr); }}, TSQL.Insert, GetParameters(item));
			if (newitem == null) return null;
			this.CopyItemAllField(item, newitem);
			return item;
		}}
		async public Task<List<{0}Info>> InsertAsync(IEnumerable<{0}Info> items) {{
			var mp = InsertMakeParam(items);
			if (string.IsNullOrEmpty(mp.sql)) return new List<{0}Info>();
			List<{0}Info> newitems = new List<{0}Info>();
			await PSqlHelper.ExecuteReaderAsync(async dr => {{ newitems.Add(await BLL.{0}.dal.GetItemAsync(dr)); }}, mp.sql, mp.parms);
			return newitems;
		}}", uClass_Name);

					string strdalpkwherein = "";
					foreach (ColumnInfo dalpkcol001 in table.PrimaryKeys) strdalpkwherein += string.Format(@"
						.Where(@""""""{0}"""" IN ({{0}})"", _dataSource.Select(a => a.{1}).Distinct())", dalpkcol001.Name, UFString(dalpkcol001.Name));
					if (!string.IsNullOrEmpty(strdalpkwherein)) strdalpkwherein = strdalpkwherein.Substring(strdalpkwherein.IndexOf("						") + 6);
					sb1.AppendFormat(@"
{1}

		public SqlUpdateBuild Update({0}Info item, string[] ignoreFields) {{
			var sub = new SqlUpdateBuild(new List<{0}Info> {{ item }}, false);
			var ignore = ignoreFields?.ToDictionary(a => a, StringComparer.CurrentCultureIgnoreCase) ?? new Dictionary<string, string>();{8}
			return sub;
		}}
		#region class SqlUpdateBuild
		public partial class SqlUpdateBuild {{
			protected List<{0}Info> _dataSource;
			protected bool _isRefershDataSource;
			protected Dictionary<string, {0}Info> _itemsDic;
			protected string _fields;
			protected string _where;
			protected List<NpgsqlParameter> _parameters = new List<NpgsqlParameter>();
			protected Dictionary<string, Action<{0}Info, {0}Info>> _setAs = new Dictionary<string, Action<{0}Info, {0}Info>>();
			public SqlUpdateBuild(List<{0}Info> dataSource, bool isRefershDataSource) {{
				_dataSource = dataSource;
				_isRefershDataSource = isRefershDataSource;
				_itemsDic = _dataSource == null ? null : _dataSource.ToDictionary(a => $""{{a.{12}}}"");
				if (_dataSource != null && _dataSource.Any())
					this{13};
			}}
			public SqlUpdateBuild() {{ }}
			public override string ToString() {{
				if (string.IsNullOrEmpty(_fields)) return string.Empty;
				if (string.IsNullOrEmpty(_where)) throw new Exception(""防止 {9}.DAL.{0}.SqlUpdateBuild 误修改，请必须设置 where 条件。"");
				return string.Concat(""UPDATE "", TSQL.Table, "" SET "", _fields.Substring(1), "" WHERE "", _where);
			}}
			public int ExecuteNonQuery() {{
				string sql = this.ToString();
				if (string.IsNullOrEmpty(sql)) return 0;
				if (_dataSource == null || _dataSource.Any() == false || _isRefershDataSource == false) {{
					var affrows = PSqlHelper.ExecuteNonQuery(sql, _parameters.ToArray());
					BLL.{0}.RemoveCache(_dataSource);
					return affrows;
				}}
				var newitems = new List<{0}Info>();
				PSqlHelper.ExecuteReader(dr => {{ newitems.Add(BLL.{0}.dal.GetItem(dr)); }}, sql + TSQL.Returning, _parameters.ToArray());
				BLL.{0}.RemoveCache(_dataSource.Concat(newitems));
				foreach (var newitem in newitems) {{
					if (_itemsDic.TryGetValue($""{{newitem.{14}}}"", out var olditem)) foreach (var a in _setAs.Values) a(olditem, newitem);
					else {{
						_dataSource.Add(newitem);
						_itemsDic.Add($""{{newitem.{14}}}"", newitem);
					}}
				}}
				return newitems.Count;
			}}
			async public Task<int> ExecuteNonQueryAsync() {{
				string sql = this.ToString();
				if (string.IsNullOrEmpty(sql)) return 0;
				if (_dataSource == null || _dataSource.Any() == false || _isRefershDataSource == false) {{
					var affrows = await PSqlHelper.ExecuteNonQueryAsync(sql, _parameters.ToArray());
					await BLL.{0}.RemoveCacheAsync(_dataSource);
					return affrows;
				}}
				var newitems = new List<{0}Info>();
				await PSqlHelper.ExecuteReaderAsync(async dr => {{ newitems.Add(await BLL.{0}.dal.GetItemAsync(dr)); }}, sql + TSQL.Returning, _parameters.ToArray());
				await BLL.{0}.RemoveCacheAsync(_dataSource);
				foreach (var newitem in newitems) {{
					if (_itemsDic.TryGetValue($""{{newitem.{14}}}"", out var olditem)) foreach (var a in _setAs.Values) a(olditem, newitem);
					else {{
						_dataSource.Add(newitem);
						_itemsDic.Add($""{{newitem.{14}}}"", newitem);
					}}
				}}
				return newitems.Count;
			}}
			public SqlUpdateBuild Where(string filterFormat, params object[] values) {{
				if (!string.IsNullOrEmpty(_where)) _where = string.Concat(_where, "" AND "");
				_where = string.Concat(_where, ""("", PSqlHelper.Addslashes(filterFormat, values), "")"");
				return this;
			}}
			public SqlUpdateBuild WhereExists<T>(SelectBuild<T> select) {{
				return this.Where($""EXISTS({{select.ToString(""1"")}})"");
			}}
			public SqlUpdateBuild WhereNotExists<T>(SelectBuild<T> select) {{
				return this.Where($""NOT EXISTS({{select.ToString(""1"")}})"");
			}}

			public SqlUpdateBuild Set(string field, string value, params NpgsqlParameter[] parms) {{
				if (value.IndexOf('\'') != -1) throw new Exception(""{9}.DAL.{0}.SqlUpdateBuild 可能存在注入漏洞，不允许传递 ' 给参数 value，若使用正常字符串，请使用参数化传递。"");
				_fields = string.Concat(_fields, "", "", field, "" = "", value);
				if (parms != null && parms.Length > 0) _parameters.AddRange(parms);
				return this;
			}}{6}
		}}
		#endregion
{10}
{2}
		#region async{11}
		#endregion
	}}
}}", uClass_Name, sb2.ToString(), sb3.ToString(), pkCsParam.Replace("?", ""), pkSqlParamFormat, pkCsParamNoType, sb5.ToString(),
	pkCsParamNoTypeByval.Replace(", ", ", item."), sb6.ToString(), solutionName, dal_insert_code, dal_async_code, pkCsParamNoType.Replace(", ", "}_{a."), strdalpkwherein, pkCsParamNoType.Replace(", ", "}_{newitem."));
					#endregion
				} else {
					sb1.AppendFormat(@"

		#region async{1}
		#endregion
	}}
}}", uClass_Name, dal_async_code);
				}
				#endregion

				loc1.Add(new BuildInfo(string.Concat(CONST.corePath, solutionName, @".db\DAL\", basicName, @"\", uClass_Name, ".cs"), Deflate.Compress(sb1.ToString())));
				clearSb();
				#endregion

				#region BLL *.cs
				sb1.AppendFormat(
	@"using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Net;
using System.Net.NetworkInformation;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using Npgsql;
using NpgsqlTypes;
using Npgsql.LegacyPostgis;
using {0}.Model;

namespace {0}.BLL {{

	public partial class {1} {{

		internal static readonly {0}.DAL.{1} dal = new {0}.DAL.{1}();
		internal static readonly int itemCacheTimeout;

		static {1}() {{
			if (!int.TryParse(PSqlHelper.CacheStrategy[""Timeout_{1}""], out itemCacheTimeout))
				int.TryParse(PSqlHelper.CacheStrategy[""Timeout""], out itemCacheTimeout);
		}}", solutionName, uClass_Name);

				Dictionary<string, bool> uniques_dic = new Dictionary<string, bool>();
				foreach (List<ColumnInfo> cs in table.Uniques) {
					string parms = string.Empty;
					foreach (ColumnInfo columnInfo in cs) {
						parms += columnInfo.CsType.Replace("?", "") + " " + UFString(columnInfo.Name) + ", ";
					}
					parms = parms.Substring(0, parms.Length - 2);
					if (uniques_dic.ContainsKey(parms)) continue;
					uniques_dic.Add(parms, true);
				}
				bool is_deleted_column = table.Columns.Find(delegate (ColumnInfo findIsDeleted) {
					return findIsDeleted.Name.ToLower() == "is_deleted" && findIsDeleted.CsType == "bool?";
				}) != null;
				string bll_async_code = "";
				Dictionary<string, bool> del_exists2 = new Dictionary<string, bool>();
				foreach (List<ColumnInfo> cs in table.Uniques) {
					string parms = string.Empty;
					string parmsNewItem = string.Empty;
					string parmsBy = "By";
					string parmsNoneType = string.Empty;
					string parmsNodeTypeUpdateCacheRemove = string.Empty;
					string cacheCond = string.Empty;
					string cacheRemoveCode = string.Empty;
					string whereCondi = string.Empty;
					foreach (ColumnInfo columnInfo in cs) {
						parms += columnInfo.CsType.Replace("?", "") + " " + UFString(columnInfo.Name) + ", ";
						parmsNewItem += UFString(columnInfo.Name) + " = " + UFString(columnInfo.Name) + ", ";
						parmsBy += UFString(columnInfo.Name) + "And";
						parmsNoneType += UFString(columnInfo.Name) + ", ";
						parmsNodeTypeUpdateCacheRemove += "item." + UFString(columnInfo.Name) + ", \"_,_\", ";
						cacheCond += UFString(columnInfo.Name) + " == null || ";
						whereCondi += string.Format(".Where{0}({1})", UFString(columnInfo.Name), 
							columnInfo.CsType.Contains("?") && !cs[0].IsPrimaryKey ? string.Concat("new ", columnInfo.CsType, "(", UFString(columnInfo.Name), ")") : UFString(columnInfo.Name));
					}
					parms = parms.Substring(0, parms.Length - 2);
					parmsNewItem = parmsNewItem.Substring(0, parmsNewItem.Length - 2);
					parmsBy = parmsBy.Substring(0, parmsBy.Length - 3);
					parmsNoneType = parmsNoneType.Substring(0, parmsNoneType.Length - 2);
					parmsNodeTypeUpdateCacheRemove = parmsNodeTypeUpdateCacheRemove.Substring(0, parmsNodeTypeUpdateCacheRemove.Length - 9);
					cacheCond = cacheCond.Substring(0, cacheCond.Length - 4);

					if (del_exists2.ContainsKey(parms)) continue;
					del_exists2.Add(parms, true);

					sb2.AppendFormat(@"
		public static {0}Info Delete{3}({1}) {{
			var item = dal.Delete{3}({2});
			if (itemCacheTimeout > 0) RemoveCache(item);
			return item;
		}}", uClass_Name, parms, parmsNoneType, cs[0].IsPrimaryKey ? string.Empty : parmsBy);
					/*
					if (uniques_dic.Count > 1)
						sb2.AppendFormat(@"
		public static int Delete{2}({0}) {{
			var affrows = dal.Delete{2}({1});
			if (itemCacheTimeout > 0) RemoveCache(GetItem{2}({1}));
			return affrows;
		}}", parms, parmsNoneType, cs[0].IsPrimaryKey ? string.Empty : parmsBy);
					else
						sb2.AppendFormat(@"
		public static int Delete{2}({0}) {{
			var affrows = dal.Delete{2}({1});
			if (itemCacheTimeout > 0) RemoveCache(new {3}Info {{ {4} }});
			return affrows;
		}}", parms, parmsNoneType, cs[0].IsPrimaryKey ? string.Empty : parmsBy, uClass_Name, parmsNewItem);
					*/
					bll_async_code += string.Format(@"
		async public static Task<{0}Info> Delete{3}Async({1}) {{
			var item = await dal.Delete{3}Async({2});
			if (itemCacheTimeout > 0) await RemoveCacheAsync(item);
			return item;
		}}", uClass_Name, parms, parmsNoneType, cs[0].IsPrimaryKey ? string.Empty : parmsBy);
					/*
					if (uniques_dic.Count > 1)
						bll_async_code += string.Format(@"
		async public static Task<int> Delete{2}Async({0}) {{
			var affrows = await dal.Delete{2}Async({1});
			if (itemCacheTimeout > 0) await RemoveCacheAsync(GetItem{2}({1}));
			return affrows;
		}}", parms, parmsNoneType, cs[0].IsPrimaryKey ? string.Empty : parmsBy);
					else
						bll_async_code += string.Format(@"
		async public static Task<int> Delete{2}Async({0}) {{
			var affrows = await dal.Delete{2}Async({1});
			if (itemCacheTimeout > 0) await RemoveCacheAsync(new {3}Info {{ {4} }});
			return affrows;
		}}", parms, parmsNoneType, cs[0].IsPrimaryKey ? string.Empty : parmsBy, uClass_Name, parmsNewItem);
					*/

					sb3.AppendFormat(@"
		public static {1}Info GetItem{2}({4}) => PSqlHelper.CacheShell(string.Concat(""{0}_BLL:{1}{2}:"", {3}), itemCacheTimeout, () => Select{7}.ToOne());", solutionName, uClass_Name, cs[0].IsPrimaryKey ? string.Empty : parmsBy, parmsNodeTypeUpdateCacheRemove.Replace("item.", ""),
		parms, parmsNoneType, cacheCond, whereCondi);

					bll_async_code += string.Format(@"
		async public static Task<{1}Info> GetItem{2}Async({4}) => await PSqlHelper.CacheShellAsync(string.Concat(""{0}_BLL:{1}{2}:"", {3}), itemCacheTimeout, () => Select{7}.ToOneAsync());", solutionName, uClass_Name, cs[0].IsPrimaryKey ? string.Empty : parmsBy, parmsNodeTypeUpdateCacheRemove.Replace("item.", ""),
		parms, parmsNoneType, cacheCond, whereCondi);

					sb4.AppendFormat(@"
				keys[keysIdx++] = string.Concat(""{0}_BLL:{1}{2}:"", {3});", solutionName, uClass_Name, cs[0].IsPrimaryKey ? string.Empty : parmsBy, parmsNodeTypeUpdateCacheRemove);
				}

				if (table.PrimaryKeys.Count > 0) {
					#region 如果没有主键的处理
					sb2.AppendFormat(@"|deleteby_fk|");

					var bllfields_ = "";
					foreach (var col33 in table.Columns) {
						string comment = _column_coments.ContainsKey(table.FullName) && _column_coments[table.FullName].ContainsKey(col33.Name) ? _column_coments[table.FullName][col33.Name] : col33.Name;
						string prototype_comment = comment == col33.Name ? @"
			" : string.Format(@"
			/// <summary>
			/// {0}
			/// </summary>
			", comment.Replace("\r\n", "\n").Replace("\n", "\r\n			/// "));

						bllfields_ += prototype_comment + UFString(col33.Name) + (bllfields_.Length == 0 ? " = 1, " : ", ");
					}
					if (bllfields_.Length > 0) bllfields_ = bllfields_.Substring(0, bllfields_.Length - 2);

					sb1.AppendFormat(@"

		#region delete, update, insert
{0}

		#region enum _
		public enum _ {{{1}
		}}
		#endregion
", sb2.ToString(), bllfields_);

					if (uniques_dic.Count > 1)
						sb1.AppendFormat(@"
		public static int Update({1}Info item, _ ignore1 = 0, _ ignore2 = 0, _ ignore3 = 0) => Update(item, new[] {{ ignore1, ignore2, ignore3 }});
		public static int Update({1}Info item, _[] ignore) => dal.Update(item, ignore?.Where(a => a > 0).Select(a => Enum.GetName(typeof(_), a)).ToArray()).ExecuteNonQuery();
		public static {0}.DAL.{1}.SqlUpdateBuild UpdateDiy({2}) => new {0}.DAL.{1}.SqlUpdateBuild(new List<{1}Info> {{ itemCacheTimeout > 0 ? new {1}Info {{ {4} }} : GetItem({3}) }}, false);
		public static {0}.DAL.{1}.SqlUpdateBuild UpdateDiy(List<{1}Info> dataSource) => new {0}.DAL.{1}.SqlUpdateBuild(dataSource, true);
		public static {0}.DAL.{1}.SqlUpdateBuild UpdateDiyDangerous => new {0}.DAL.{1}.SqlUpdateBuild();
", solutionName, uClass_Name, pkCsParam.Replace("?", ""), pkCsParamNoType, pkCsParamNoTypeFieldInit);
					else {
						var xxxxtempskdf = "";
						foreach(var xxxxtempskdfstr in pkCsParamNoType.Split(new string[] { ", " }, StringSplitOptions.None)) {
							xxxxtempskdf += xxxxtempskdfstr + " = " + xxxxtempskdfstr + ", ";
						}
						sb1.AppendFormat(@"
		public static int Update({1}Info item, _ ignore1 = 0, _ ignore2 = 0, _ ignore3 = 0) => Update(item, new[] {{ ignore1, ignore2, ignore3 }});
		public static int Update({1}Info item, _[] ignore) => dal.Update(item, ignore?.Where(a => a > 0).Select(a => Enum.GetName(typeof(_), a)).ToArray()).ExecuteNonQuery();
		public static {0}.DAL.{1}.SqlUpdateBuild UpdateDiy({2}) => new {0}.DAL.{1}.SqlUpdateBuild(new List<{1}Info> {{ new {1}Info {{ {4} }} }}, false);
		public static {0}.DAL.{1}.SqlUpdateBuild UpdateDiy(List<{1}Info> dataSource) => new {0}.DAL.{1}.SqlUpdateBuild(dataSource, true);
		public static {0}.DAL.{1}.SqlUpdateBuild UpdateDiyDangerous => new {0}.DAL.{1}.SqlUpdateBuild();
", solutionName, uClass_Name, pkCsParam.Replace("?", ""), pkCsParamNoType, xxxxtempskdf.Substring(0, xxxxtempskdf.Length - 2));
					}

					bll_async_code += string.Format(@"
		public static Task<int> UpdateAsync({1}Info item, _ ignore1 = 0, _ ignore2 = 0, _ ignore3 = 0) => UpdateAsync(item, new[] {{ ignore1, ignore2, ignore3 }});
		public static Task<int> UpdateAsync({1}Info item, _[] ignore) => dal.Update(item, ignore?.Where(a => a > 0).Select(a => Enum.GetName(typeof(_), a)).ToArray()).ExecuteNonQueryAsync();
", solutionName, uClass_Name);

					if (table.Columns.Count > 5)
						sb1.AppendFormat(@"
		/// <summary>
		/// 适用字段较少的表；避规后续改表风险，字段数较大请改用 {0}.Insert({0}Info item)
		/// </summary>
		[Obsolete]", uClass_Name);
					sb1.AppendFormat(@"
		public static {0}Info Insert({1}) {{
			return Insert(new {0}Info {{{2}}});
		}}", uClass_Name, CsParam3, CsParamNoType3);

					if (table.Columns.Count > 5)
						bll_async_code += string.Format(@"
		/// <summary>
		/// 适用字段较少的表；避规后续改表风险，字段数较大请改用 {0}.Insert({0}Info item)
		/// </summary>
		[Obsolete]", uClass_Name);
					bll_async_code += string.Format(@"
		public static Task<{0}Info> InsertAsync({1}) {{
			return InsertAsync(new {0}Info {{{2}}});
		}}", uClass_Name, CsParam3, CsParamNoType3);

					var redisRemove = sb4.ToString();
					string cspk2GuidSetValue = "";
					string cspk2GuidSetValuesss = "";
					foreach (ColumnInfo cspk2 in table.Columns) {
						if (cspk2.CsType == "Guid?" && cspk2.IsPrimaryKey) {
							cspk2GuidSetValue += string.Format("\r\n			if (item.{0} == null) item.{0} = PSqlHelper.NewMongodbId();", UFString(cspk2.Name));
							cspk2GuidSetValuesss += string.Format("\r\n			foreach (var item in items) if (item != null && item.{0} == null) item.{0} = PSqlHelper.NewMongodbId();", UFString(cspk2.Name));
						}
						if (cspk2.CsType == "DateTime?" && cspk2.Name.ToLower() == "create_time" ||
							cspk2.CsType == "DateTime?" && cspk2.Name.ToLower() == "update_time") {
							cspk2GuidSetValue += string.Format("\r\n			if (item.{0} == null) item.{0} = DateTime.Now;", UFString(cspk2.Name));
							cspk2GuidSetValuesss += string.Format("\r\n			foreach (var item in items) if (item != null && item.{0} == null) item.{0} = DateTime.Now;", UFString(cspk2.Name));
						}
						if (cspk2.CsType == "bool?" && cspk2.Name.ToLower() == "is_deleted") {
							cspk2GuidSetValue += string.Format("\r\n			if (item.{0} == null) item.{0} = false;", UFString(cspk2.Name));
							cspk2GuidSetValuesss += string.Format("\r\n			foreach (var item in items) if (item != null && item.{0} == null) item.{0} = false;", UFString(cspk2.Name));
						}
					}
					sb1.AppendFormat(@"
		public static {0}Info Insert({0}Info item) {{{3}
			item = dal.Insert(item);
			if (itemCacheTimeout > 0) RemoveCache(item);
			return item;
		}}
		public static List<{0}Info> Insert(IEnumerable<{0}Info> items) {{{4}
			var newitems = dal.Insert(items);
			if (itemCacheTimeout > 0) RemoveCache(newitems);
			return newitems;
		}}
		internal static void RemoveCache({0}Info item) => RemoveCache(item == null ? null : new [] {{ item }});
		internal static void RemoveCache(IEnumerable<{0}Info> items) {{
			if (itemCacheTimeout <= 0 || items == null || items.Any() == false) return;
			var keys = new string[items.Count() * {5}];
			var keysIdx = 0;
			foreach (var item in items) {{{2}
			}}
			if (PSqlHelper.Instance.CurrentThreadTransaction != null) PSqlHelper.Instance.PreRemove(keys);
			else PSqlHelper.CacheRemove(keys);
		}}
		#endregion
{1}
", uClass_Name, sb3.ToString(), redisRemove, cspk2GuidSetValue, cspk2GuidSetValuesss, table.Uniques.Count);
					bll_async_code += string.Format(@"
		async public static Task<{0}Info> InsertAsync({0}Info item) {{{3}
			item = await dal.InsertAsync(item);
			if (itemCacheTimeout > 0) await RemoveCacheAsync(item);
			return item;
		}}
		async public static Task<List<{0}Info>> InsertAsync(IEnumerable<{0}Info> items) {{{4}
			var newitems = await dal.InsertAsync(items);
			if (itemCacheTimeout > 0) await RemoveCacheAsync(newitems);
			return newitems;
		}}
		internal static Task RemoveCacheAsync({0}Info item) => RemoveCacheAsync(item == null ? null : new [] {{ item }});
		async internal static Task RemoveCacheAsync(IEnumerable<{0}Info> items) {{
			if (itemCacheTimeout <= 0 || items == null || items.Any() == false) return;
			var keys = new string[items.Count() * {5}];
			var keysIdx = 0;
			foreach (var item in items) {{{2}
			}}
			await PSqlHelper.CacheRemoveAsync(keys);
		}}
", uClass_Name, "", redisRemove, cspk2GuidSetValue, cspk2GuidSetValuesss, table.Uniques.Count);
					#endregion
				}

				sb1.AppendFormat(@"
		public static List<{0}Info> GetItems() => Select.ToList();", uClass_Name, solutionName);
				if (is_deleted_column)
					sb1.AppendFormat(@"
		public static SelectBuild SelectRaw => new SelectBuild(dal);
		/// <summary>
		/// 开启软删除功能，默认查询 is_deleted = false 的数据，查询所有使用 SelectRaw，软删除数据使用 Update is_deleted = true，物理删除数据使用 Delete 方法
		/// </summary>
		public static SelectBuild Select => SelectRaw.WhereIs_deleted(false);", uClass_Name, solutionName);
				else
					sb1.AppendFormat(@"
		public static SelectBuild Select => new SelectBuild(dal);", uClass_Name, solutionName);
				sb1.AppendFormat(@"
		public static SelectBuild SelectAs(string alias = ""a"") => Select.As(alias);", uClass_Name, solutionName);

				bll_async_code += string.Format(@"
		public static Task<List<{0}Info>> GetItemsAsync() => Select.ToListAsync();", uClass_Name, solutionName);

				Dictionary<string, bool> byItems = new Dictionary<string, bool>();
				foreach (ForeignKeyInfo fk in table.ForeignKeys) {
					string fkcsBy = string.Empty;
					string fkcsParms = string.Empty;
					string fkcsTypeParms = string.Empty;
					string fkcsFilter = string.Empty;
					int fkcsFilterIdx = 0;
					foreach (ColumnInfo c1 in fk.Columns) {
						fkcsBy += UFString(c1.Name) + "And";
						fkcsParms += UFString(c1.Name) + ", ";
						fkcsTypeParms += c1.CsType.Replace("?", "") + " " + UFString(c1.Name) + ", ";
						fkcsFilter += @"a.""""" + c1.Name + @""""" = {" + fkcsFilterIdx++ + "} and ";
					}
					fkcsBy = fkcsBy.Remove(fkcsBy.Length - 3);
					fkcsParms = fkcsParms.Remove(fkcsParms.Length - 2);
					fkcsTypeParms = fkcsTypeParms.Remove(fkcsTypeParms.Length - 2);
					fkcsFilter = fkcsFilter.Remove(fkcsFilter.Length - 5);
					if (byItems.ContainsKey(fkcsBy)) continue;
					byItems.Add(fkcsBy, true);

					if (!del_exists2.ContainsKey(fkcsTypeParms)) {
						sb5.AppendFormat(@"
		public static List<{0}Info> DeleteBy{3}({1}) {{
			var items = dal.DeleteBy{3}({2});
			if (itemCacheTimeout > 0) RemoveCache(items);
			return items;
		}}", uClass_Name, fkcsTypeParms, fkcsParms, fkcsBy);
						bll_async_code = string.Format(@"
		async public static Task<List<{0}Info>> DeleteBy{3}Async({1}) {{
			var items = await dal.DeleteBy{3}Async({2});
			if (itemCacheTimeout > 0) await RemoveCacheAsync(items);
			return items;
		}}", uClass_Name, fkcsTypeParms, fkcsParms, fkcsBy) + bll_async_code;
						del_exists2.Add(fkcsTypeParms, true);
					}
					if (fk.Columns.Count > 1) {
						sb1.AppendFormat(
		@"
		public static List<{0}Info> GetItemsBy{1}({2}) => Select.Where{1}({3}).ToList();
		public static List<{0}Info> GetItemsBy{1}({2}, int limit) => Select.Where{1}({3}).Limit(limit).ToList();
		public static SelectBuild SelectBy{1}({2}) => Select.Where{1}({3});", uClass_Name, fkcsBy, fkcsTypeParms, fkcsParms);
						bll_async_code += string.Format(
		@"
		public static Task<List<{0}Info>> GetItemsBy{1}Async({2}) => Select.Where{1}({3}).ToListAsync();
		public static Task<List<{0}Info>> GetItemsBy{1}Async({2}, int limit) => Select.Where{1}({3}).Limit(limit).ToListAsync();", uClass_Name, fkcsBy, fkcsTypeParms, fkcsParms);
						sb6.AppendFormat(@"
		public SelectBuild Where{1}({2}) => base.Where(@""{4}"", {3});", uClass_Name, fkcsBy, fkcsTypeParms, fkcsParms, fkcsFilter, solutionName);
					} else if (fk.Columns.Count == 1/* && fk.Columns[0].IsPrimaryKey == false*/) {
						string csType = fk.Columns[0].CsType;
						sb1.AppendFormat(
		@"
		public static List<{0}Info> GetItemsBy{1}(params {2}[] {1}) => Select.Where{1}({1}).ToList();
		public static List<{0}Info> GetItemsBy{1}({2}[] {1}, int limit) => Select.Where{1}({1}).Limit(limit).ToList();
		public static SelectBuild SelectBy{1}(params {2}[] {1}) => Select.Where{1}({1});", uClass_Name, fkcsBy, csType);
						bll_async_code += string.Format(
		@"
		public static Task<List<{0}Info>> GetItemsBy{1}Async(params {2}[] {1}) => Select.Where{1}({1}).ToListAsync();
		public static Task<List<{0}Info>> GetItemsBy{1}Async({2}[] {1}, int limit) => Select.Where{1}({1}).Limit(limit).ToListAsync();", uClass_Name, fkcsBy, csType);
						sb6.AppendFormat(@"
			public SelectBuild Where{1}(params {2}[] {1}) => this.Where1Or(@""a.""""{3}"""" = {{0}}"", {1});
			public SelectBuild Where{1}({4}.SelectBuild select, bool isNotIn = false) => this.Where($@""a.""""{3}"""" {{(isNotIn ? ""NOT IN"" : ""IN"")}} ({{select.ToString(@""""""{5}"""""")}})"");", uClass_Name, fkcsBy, csType, fk.Columns[0].Name, UFString(fk.ReferencedTable.ClassName), fk.ReferencedColumns[0].Name);
					}
				}
				// m -> n
				_tables.ForEach(delegate (TableInfo t2) {
					List<ForeignKeyInfo> fks = t2.ForeignKeys.FindAll(delegate (ForeignKeyInfo ffk) {
						if (ffk.ReferencedTable.FullName == table.FullName) {
							return true;
						}
						return false;
					});
					if (fks.Count == 0) return;
					ForeignKeyInfo fk = fks.Count > 1 ? fks.Find(delegate(ForeignKeyInfo ffk) {
						return string.Compare(table.Name + "_" + table.PrimaryKeys[0].Name, ffk.Columns[0].Name, true) == 0;
					}) : fks[0];
					if (fk == null) fk = fks[0];
					//if (fk.Table.FullName == table.FullName) return;
					List<ForeignKeyInfo> fk2 = t2.ForeignKeys.FindAll(delegate (ForeignKeyInfo ffk2) {
						return ffk2.Columns[0].IsPrimaryKey && ffk2 != fk;
					});
					if (fk2.Count != 1) return;
					if (fk.Columns[0].IsPrimaryKey == false) return; //中间表关系键，必须为主键

					//t2.Columns
					string t2name = t2.Name;
					string tablename = table.Name;
					string addname = t2name;
					if (t2name.StartsWith(tablename + "_")) {
						addname = t2name.Substring(tablename.Length + 1);
					} else if (t2name.EndsWith("_" + tablename)) {
						addname = t2name.Remove(addname.Length - tablename.Length - 1);
					} else if (fk2.Count == 1 && t2name.EndsWith("_" + tablename)) {
						addname = t2name.Remove(t2name.Length - tablename.Length - 1);
					} else if (fk2.Count == 1 && t2name.EndsWith("_" + fk2[0].ReferencedTable.Name)) {
						addname = t2name;
					}
					string addname_schema = addname == t2.Name && t2.Owner != table.Owner ? t2.ClassName : addname;

					string orgInfo = UFString(fk2[0].ReferencedTable.ClassName);
					string fkcsBy = UFString(addname_schema);
					if (byItems.ContainsKey(fkcsBy)) return;
					byItems.Add(fkcsBy, true);

					string civ = string.Format(GetCSTypeValue(fk2[0].ReferencedTable.PrimaryKeys[0].Type), UFString(fk2[0].ReferencedTable.PrimaryKeys[0].Name));
					sb1.AppendFormat(@"
		public static SelectBuild SelectBy{1}(params {2}Info[] {5}s) => Select.Where{1}({5}s);
		public static SelectBuild SelectBy{1}_{4}(params {3}[] {5}_ids) => Select.Where{1}_{4}({5}_ids);", uClass_Name, fkcsBy, orgInfo, fk2[0].ReferencedTable.PrimaryKeys[0].CsType.Replace("?", ""), table.PrimaryKeys[0].Name, LFString(orgInfo));

					string _f6 = fk.Columns[0].Name;
					string _f7 = fk.ReferencedTable.PrimaryKeys[0].Name;
					string _f8 = fk2[0].Columns[0].Name;
					string _f9 = fk2[0].ReferencedTable.PrimaryKeys[0].CsType.Replace("?", "");

					//若中间表，两外键指向相同表，则选择 表名_主键名 此字段作为主参考字段
					string main_column = fk.Columns[0].Name;
					if (fk.ReferencedTable.ClassName == fk2[0].ReferencedTable.ClassName &&
						string.Compare(main_column, fk.Columns[0].Name, true) == 0) {
						_f6 = fk2[0].Columns[0].Name;
						_f7 = fk2[0].ReferencedTable.PrimaryKeys[0].Name;
						_f8 = fk.Columns[0].Name;
						_f9 = fk2[0].Table.PrimaryKeys[0].CsType.Replace("?", "");
					}
					sb6.AppendFormat(@"
			public SelectBuild Where{1}(params {2}Info[] {10}s) => Where{1}({10}s?.ToArray(), null);
			public SelectBuild Where{1}_{7}(params {9}[] {10}_ids) => Where{1}_{7}({10}_ids?.ToArray(), null);
			public SelectBuild Where{1}({2}Info[] {10}s, Action<{5}.SelectBuild> subCondition) => Where{1}_{7}({10}s?.Where<{2}Info>(a => a != null).Select<{2}Info, {9}>(a => a.{3}).ToArray(), subCondition);
			public SelectBuild Where{1}_{7}({9}[] {10}_ids, Action<{5}.SelectBuild> subCondition) {{
				if ({10}_ids == null || {10}_ids.Length == 0) return this;
				{5}.SelectBuild subConditionSelect = {5}.Select.Where(string.Format(@""""""{6}"""" = a . """"{7}"""" AND """"{8}"""" IN ('{{0}}')"", string.Join(""','"", {10}_ids.Select(a => string.Concat(a).Replace(""'"", ""''"")))));
				subCondition?.Invoke(subConditionSelect);
				var subConditionSql = subConditionSelect.ToString(@""""""{6}"""""").Replace(""\"" a \r\nWHERE ("", ""\"" WHERE ("");
				if (subCondition != null) subConditionSql = subConditionSql.Replace(""a.\"""", ""\""{11}\"".\""{12}\"".\"""");
				return base.Where($""EXISTS({{subConditionSql}})"");
			}}", uClass_Name, fkcsBy, orgInfo, civ, string.Empty, UFString(t2.ClassName), _f6, _f7, _f8, _f9, LFString(orgInfo), t2.Owner, t2.Name);
				});

				table.Columns.ForEach(delegate (ColumnInfo col) {
					if (col.Attndims > 1) return;
					string csType = col.CsType;
					string lname = col.Name.ToLower();
					//if (col.IsPrimaryKey) return;
					//if (lname == "create_time" ||
					//	lname == "update_time") return;
					string fkcsBy = UFString(col.Name);
					if (byItems.ContainsKey(fkcsBy)) return;
					byItems.Add(fkcsBy, true);

					string comment = _column_coments.ContainsKey(table.FullName) && _column_coments[table.FullName].ContainsKey(col.Name) ? _column_coments[table.FullName][col.Name] : col.Name;
					string prototype_comment = comment == col.Name ? "" : string.Format(@"/// <summary>
			/// {0}，多个参数等于 OR 查询
			/// </summary>
			", comment.Replace("\r\n", "\n").Replace("\n", "\r\n			/// "));

					if (col.Attndims == 1) {
						csType = GetCSType(col.Type, 0, col.SqlType);
						if (col.Type == NpgsqlDbType.Enum) {
							sb6.AppendFormat(@"
			public SelectBuild Where{1}Any_IN(params {3}[] {1}s) => this.Where1Or(@""a.""""{4}"""" @> ARRAY[{{0}}::{5}]"", {1}s);
			public SelectBuild Where{1}Any({2} {1}1) => this.Where{1}Any_IN({1}1);
			public SelectBuild Where{1}Any({2} {1}1, {2} {1}2) => this.Where{1}Any_IN({1}1, {1}2);
			public SelectBuild Where{1}Any({2} {1}1, {2} {1}2, {2} {1}3) => this.Where{1}Any_IN({1}1, {1}2, {1}3);
			public SelectBuild Where{1}Any({2} {1}1, {2} {1}2, {2} {1}3, {2} {1}4) => this.Where{1}Any_IN({1}1, {1}2, {1}3, {1}4);
			public SelectBuild Where{1}Any({2} {1}1, {2} {1}2, {2} {1}3, {2} {1}4, {2} {1}5) => this.Where{1}Any_IN({1}1, {1}2, {1}3, {1}4, {1}5);", uClass_Name, fkcsBy, csType.Replace("?", ""), csType, col.Name, col.SqlType);
							return;
						}
						sb6.AppendFormat(@"
			public SelectBuild Where{1}Any(params {2}[] {1}) => {1} == null ? this.Where(@""a.""""{3}"""" IS NULL"") : this.Where1Or(@""a.""""{3}"""" @> ARRAY[{{0}}::{4}]"", {1});", uClass_Name, fkcsBy, csType.Replace("?", ""), col.Name, col.SqlType);
						return;
					}
					
					if (col.Type == NpgsqlDbType.Jsonb) {
						sb6.AppendFormat(@"
			/// <summary>
			/// {3}顶层是否包含JSON路径/值项，如：'{{""a"":1, ""b"":2}}'::jsonb @&gt; '{{""b"":2}}'::jsonb
			/// </summary>
			/// <param name=""{1}"">查找的json</param>
			/// <returns></returns>
			public SelectBuild Where{1}Contain(params JToken[] {1}) => {1} == null ? this.Where(@""a.""""{3}"""" IS NULL"") : this.Where1Or(@""a.""""{3}"""" @> {{0}}::jsonb"", {1}?.Select(a => a?.ToString()).Where(a => !string.IsNullOrEmpty(a)).ToArray());
			/// <summary>
			/// {3}顶层键值是否包含，如：'{{""a"":1, ""b"":2}}'::jsonb ? 'b'
			/// </summary>
			/// <param name=""key"">查找的key</param>
			/// <returns></returns>
			public SelectBuild Where{1}ContainKey(params string[] key) => this.Where1Or(@""a.""""{3}"""" ? {{0}}"", key?.Where(a => !string.IsNullOrEmpty(a)).ToArray() ?? new [] {{ """" }});
			/// <summary>
			/// {3}顶层键值是否同时包含，如：{{""a"":1, ""b"":2}}'::jsonb ?&amp; ARRAY['a', 'b']
			/// </summary>
			/// <param name=""keys"">查找的keys</param>
			/// <returns></returns>
			public SelectBuild Where{1}ContainKeys(params string[][] keys) => this.Where1Or(@""a.""""{3}"""" ?& ARRAY[{{0}}]"", keys?.Where(a => a != null).Select(a => a.Where(b => !string.IsNullOrEmpty(b))).ToArray() ?? new [] {{ new [] {{ """" }} }});
			/// <summary>
			/// {3}顶层键值是否任意包含一个，如：{{""a"":1, ""b"":2}}'::jsonb ?| ARRAY['a', 'b']
			/// </summary>
			/// <param name=""keys"">查找的keys</param>
			/// <returns></returns>
			public SelectBuild Where{1}ContainKeysAny(params string[][] keys) => this.Where1Or(@""a.""""{3}"""" ?| ARRAY[{{0}}]"", keys?.Where(a => a != null).Select(a => a.Where(b => !string.IsNullOrEmpty(b))).ToArray() ?? new [] {{ new [] {{ """" }} }});", uClass_Name, fkcsBy, csType.Replace("?", ""), col.Name, col.SqlType);
						return;
					}

					if (col.Type == NpgsqlDbType.Hstore) {
						sb6.AppendFormat(@"
			/// <summary>
			/// {3}是否包含字典(操作符：@&gt;)
			/// </summary>
			/// <param name=""{1}"">查找的字典</param>
			/// <returns></returns>
			public SelectBuild Where{1}Contain(params IDictionary[] {1}) {{
				if ({1} == null) return this.Where(@""a.""""{3}"""" IS NULL"");
				List<string[]> pgarrs = new List<string[]>();
				foreach (var dic in {1}) {{
					var dicKeys = new string[dic.Count];
					var dicVals = new string[dic.Count];
					dic.Keys.CopyTo(dicKeys, 0);
					dic.Values.CopyTo(dicVals, 0);
					var pgarr = new string[dic.Count * 2];
					for (var a = 0; a < dic.Count; a++) (pgarr[a * 2], pgarr[a * 2 + 1]) = (dicKeys[a], dicVals[a]);
					pgarrs.Add(pgarr);
				}}
				return this.Where1Or(@""a.""""{3}"""" @> hstore(ARRAY[{{0}}])"", pgarrs.ToArray());
			}}
			/// <summary>
			/// {3}键值是否包含(操作符：?)
			/// </summary>
			/// <param name=""key"">查找的key</param>
			/// <returns></returns>
			public SelectBuild Where{1}ContainKey(params string[] key) => this.Where1Or(@""a.""""{3}"""" ? {{0}}"", key?.ToArray() ?? new [] {{ """" }});
			/// <summary>
			/// {3}键值是否同时包含(操作符：?&amp;)
			/// </summary>
			/// <param name=""keys"">查找的keys</param>
			/// <returns></returns>
			public SelectBuild Where{1}ContainKeys(params string[][] keys) => this.Where1Or(@""a.""""{3}"""" ?& ARRAY[{{0}}]"", keys?.Where(a => a != null).Select(a => a.Where(b => !string.IsNullOrEmpty(b))).ToArray() ?? new [] {{ new [] {{ """" }} }});
			/// <summary>
			/// {3}键值是否任意包含一个(操作符：?|)
			/// </summary>
			/// <param name=""keys"">查找的keys</param>
			/// <returns></returns>
			public SelectBuild Where{1}ContainKeysAny(params string[][] keys) => this.Where1Or(@""a.""""{3}"""" ?| ARRAY[{{0}}]"", keys?.Where(a => a != null).Select(a => a.Where(b => !string.IsNullOrEmpty(b))).ToArray() ?? new [] {{ new [] {{ """" }} }});", uClass_Name, fkcsBy, csType.Replace("?", ""), col.Name, col.SqlType);
						return;
					}

					if (csType == "bool?" || csType == "Guid?") {
						sb6.AppendFormat(@"
			{4}public SelectBuild Where{1}(params {2}[] {1}) => this.Where1Or(@""a.""""{3}"""" = {{0}}"", {1});", uClass_Name, fkcsBy, col.IsPrimaryKey ? csType.Replace("?", "") : csType, col.Name, prototype_comment);
						return;
					}
					if (col.Type == NpgsqlDbType.Smallint || col.Type == NpgsqlDbType.Integer || col.Type == NpgsqlDbType.Bigint ||
						col.Type == NpgsqlDbType.Numeric || col.Type == NpgsqlDbType.Real || col.Type == NpgsqlDbType.Double || col.Type == NpgsqlDbType.Money) {
						sb6.AppendFormat(@"
			{4}public SelectBuild Where{1}(params {2}[] {1}) => this.Where1Or(@""a.""""{3}"""" = {{0}}"", {1});", uClass_Name, fkcsBy, col.IsPrimaryKey ? csType.Replace("?", "") : csType, col.Name, prototype_comment);
						sb6.AppendFormat(@"
			public SelectBuild Where{1}Range({2} begin) => base.Where(@""a.""""{3}"""" >= {{0}}"", begin);
			public SelectBuild Where{1}Range({2} begin, {2} end) => end == null ? this.Where{1}Range(begin) : base.Where(@""a.""""{3}"""" between {{0}} and {{1}}"", begin, end);", uClass_Name, fkcsBy, csType, col.Name);
						return;
					}
					if (col.Type == NpgsqlDbType.Timestamp || col.Type == NpgsqlDbType.TimestampTZ || col.Type == NpgsqlDbType.Date ||
						col.Type == NpgsqlDbType.Time || col.Type == NpgsqlDbType.TimeTZ || col.Type == NpgsqlDbType.Interval) {
						if (col.IsPrimaryKey)
							sb6.AppendFormat(@"
			{4}public SelectBuild Where{1}({2} {1}) => base.Where(@""a.""""{3}"""" = {{0}}"", {1});", uClass_Name, fkcsBy, csType, col.Name, prototype_comment);
						sb6.AppendFormat(@"
			public SelectBuild Where{1}Range({2} begin) => base.Where(@""a.""""{3}"""" >= {{0}}"", begin);
			public SelectBuild Where{1}Range({2} begin, {2} end) => end == null ? this.Where{1}Range(begin) : base.Where(@""a.""""{3}"""" between {{0}} and {{1}}"", begin, end);", uClass_Name, fkcsBy, csType, col.Name);
						return;
					}
					if ((col.Type == NpgsqlDbType.Integer || col.Type == NpgsqlDbType.Bigint) && (lname == "status" || lname.StartsWith("status_") || lname.EndsWith("_status"))) {
						sb6.AppendFormat(@"
			public SelectBuild Where{1}(params int[] _0_16) {{
				if (_0_16 == null || _0_16.Length == 0) return this;
				{2}[] copy = new {2}[_0_16.Length];
				for (int a = 0; a < _0_16.Length; a++) copy[a] = ({2})Math.Pow(2, _0_16[a]);
				return this.Where1Or(@""(a.""""{3}"""" & {{0}}) = {{0}}"", copy);
			}}", uClass_Name, fkcsBy, csType.Replace("?", ""), col.Name);
						return;
					}
					if (col.Type == NpgsqlDbType.Enum) {
						sb6.AppendFormat(@"
			public SelectBuild Where{1}_IN(params {3}[] {1}s) => this.Where1Or(@""a.""""{4}"""" = {{0}}"", {1}s);
			{5}public SelectBuild Where{1}({2} {1}1) => this.Where{1}_IN({1}1);
			public SelectBuild Where{1}({2} {1}1, {2} {1}2) => this.Where{1}_IN({1}1, {1}2);
			public SelectBuild Where{1}({2} {1}1, {2} {1}2, {2} {1}3) => this.Where{1}_IN({1}1, {1}2, {1}3);
			public SelectBuild Where{1}({2} {1}1, {2} {1}2, {2} {1}3, {2} {1}4) => this.Where{1}_IN({1}1, {1}2, {1}3, {1}4);
			public SelectBuild Where{1}({2} {1}1, {2} {1}2, {2} {1}3, {2} {1}4, {2} {1}5) => this.Where{1}_IN({1}1, {1}2, {1}3, {1}4, {1}5);", uClass_Name, fkcsBy, csType.Replace("?", ""), csType, col.Name, prototype_comment);
						return;
					}
					if (csType == "string") {
						if (col.Length > 0 && col.Length < 301)
							sb6.AppendFormat(@"
			{4}public SelectBuild Where{1}(params {2}[] {1}) => this.Where1Or(@""a.""""{3}"""" = {{0}}"", {1});
			public SelectBuild Where{1}Regex(string pattern, bool isNotMatch = false, bool ignoreCase = true) => this.Where($@""a.""""{3}"""" {{(isNotMatch ? (ignoreCase ? ""!~*"" : ""!~"") : (ignoreCase ? ""~*"" : ""~""))}} {{{{0}}}}"", pattern);", uClass_Name, fkcsBy, csType, col.Name, prototype_comment);
						sb6.AppendFormat(@"
			public SelectBuild Where{1}Like(string pattern, bool isNotLike = false, bool ignoreCase = true) => this.Where($@""a.""""{3}"""" {{(isNotLike ? (ignoreCase ? ""NOT ILIKE"" : ""NOT LIKE"") : (ignoreCase ? ""ILIKE"" : ""LIKE""))}} {{{{0}}}}"", pattern);", uClass_Name, fkcsBy, csType, col.Name);
						return;
					}
					if (csType == "NpgsqlPoint?") {
						sb6.AppendFormat(@"
			/// <summary>
			/// 查找地理位置多少米范围内的记录，距离由近到远排序
			/// </summary>
			/// <param name=""point"">经纬度</param>
			/// <param name=""meter"">米(=0时无限制)</param>
			/// <returns></returns>
			public SelectBuild Where{1}ST_dwithin(NpgsqlPoint point, double meter = 0) => this.Where(meter > 0, @""st_dwithin({{0}}::geometry::geography, a.""""{3}""""::geometry::geography, {{1}})"", new NpgsqlParameter {{ NpgsqlDbType = NpgsqlDbType.Point, Value = point }}, meter)
				.OrderBy(@""{{0}} <-> a.""""{3}"""""", new NpgsqlParameter {{ NpgsqlDbType = NpgsqlDbType.Point, Value = point }});", uClass_Name, fkcsBy, csType.Replace("?", ""), col.Name);
						return;
					}
					if (csType == "PostgisGeometry") {
			//			sb6.AppendFormat(@"
			///// <summary>
			///// 查找地理位置多少米范围内的记录，距离由近到远排序
			///// </summary>
			///// <param name=""point"">经纬度</param>
			///// <param name=""meter"">米</param>
			///// <returns></returns>
			//public SelectBuild Where{1}ST_dwithin(PostgisPoint point, double meter) {{
			//	if (point.SRID == 0) point.SRID = 4326;
			//	return this.Where(@""st_dwithin({{0}}::geography, a.""""{3}""""::geography, {{1}})"", new NpgsqlParameter {{ Value = point }}, meter)
			//		.OrderBy(@""st_distance({{0}}::geography, a.""""{3}""""::geography)"", new NpgsqlParameter {{ Value = point }});
			//}}", uClass_Name, fkcsBy, csType.Replace("?", ""), col.Name);
						return;
					}
				});

				sb1.AppendFormat(@"

		#region async{3}
		#endregion

		public partial class SelectBuild : SelectBuild<{0}Info, SelectBuild> {{{2}
			public SelectBuild(IDAL dal) : base(dal, PSqlHelper.Instance) {{ }}
		}}
	}}
}}", uClass_Name, solutionName, sb6.ToString(), bll_async_code);

				loc1.Add(new BuildInfo(string.Concat(CONST.corePath, solutionName, @".db\BLL\", basicName, @"\", uClass_Name, ".cs"), Deflate.Compress(sb1.ToString().Replace("|deleteby_fk|", sb5.ToString()))));
				clearSb();
				#endregion

				if (table.PrimaryKeys.Count == 0) continue;

				#region admin
				if (isMakeAdmin) {

					#region common define
					string pkNames = string.Empty;
					string pkUrlQuerys = string.Empty;
					string pkHiddens = string.Empty;
					for (int a = 0; a < table.PrimaryKeys.Count; a++) {
						ColumnInfo col88 = table.PrimaryKeys[a];
						pkNames += UFString(col88.Name) + ",";
						pkUrlQuerys += string.Format(@"{0}=@item.{0}&", UFString(col88.Name));
						pkHiddens += string.Format(@"@item.{0},", UFString(col88.Name));
					}
					if (pkNames.Length > 0) pkNames = pkNames.Remove(pkNames.Length - 1);
					if (pkUrlQuerys.Length > 0) pkUrlQuerys = pkUrlQuerys.Remove(pkUrlQuerys.Length - 1);
					if (pkHiddens.Length > 0) pkHiddens = pkHiddens.Remove(pkHiddens.Length - 1);

					ForeignKeyInfo ttfk = table.ForeignKeys.Find(delegate (ForeignKeyInfo fkk) {
						return fkk.ReferencedTable != null && fkk.ReferencedTable.FullName == table.FullName;
					});
					#endregion

					#region wwwroot_sitemap
					wwwroot_sitemap += string.Format(@"
			<li><a href=""/{0}/""><i class=""fa fa-circle-o""></i>{0}</a></li>", uClass_Name);
					#endregion

					#region init_sysdir
					admin_controllers_syscontroller_init_sysdir.Add(string.Format(@"

			dir2 = Sysdir.Insert(dir1.Id, DateTime.Now, ""{0}"", {1}, ""/{0}/"");
			dir3 = Sysdir.Insert(dir2.Id, DateTime.Now, ""列表"", 1, ""/{0}/"");
			dir3 = Sysdir.Insert(dir2.Id, DateTime.Now, ""添加"", 2, ""/{0}/add"");
			dir3 = Sysdir.Insert(dir2.Id, DateTime.Now, ""编辑"", 3, ""/{0}/edit"");
			dir3 = Sysdir.Insert(dir2.Id, DateTime.Now, ""删除"", 4, ""/{0}/del"");", nClass_Name, admin_controllers_syscontroller_init_sysdir.Count + 1));
					#endregion

					#region Controller.cs
					string str_listTh = "";
					string str_listTd = "";
					string str_listTh1 = "";
					string str_listTd1 = "";
					string str_controller_list_join = "";
					byte str_controller_list_join_alias = 97;
					string str_listCms2FilterFK = "";
					string str_listCms2FilterFK_fkitems = "";
					string keyLikes = string.Empty;
					string getListParamQuery = "";
					bool ttfk_flag = false;
					string str_addhtml_mn = "";
					string str_controller_insert_mn = "";
					string str_controller_update_mn = "";
					string str_fk_getlist = "";
					string str_addjs_mn_initUI = "";
					foreach (ColumnInfo col in table.Columns) {
						List<ColumnInfo> us = table.Uniques.Find(delegate (List<ColumnInfo> cs) {
							return cs.Find(delegate (ColumnInfo col88) {
								return col88.Name == col.Name;
							}) != null;
						});
						if (us == null) us = new List<ColumnInfo>();
						List<ForeignKeyInfo> fks_comb = table.ForeignKeys.FindAll(delegate (ForeignKeyInfo fk2) {
							return fk2.Columns.Count == 1 && fk2.Columns[0].Name == col.Name;
						});

						string csType = col.CsType;
						string csUName = UFString(col.Name);
						string comment = _column_coments.ContainsKey(table.FullName) && _column_coments[table.FullName].ContainsKey(col.Name) ? _column_coments[table.FullName][col.Name] : col.Name;
						if (csType == "string") {
							keyLikes += "a." + col.Name + " ilike {0} or ";
						}
						List<ForeignKeyInfo> fks = table.ForeignKeys.FindAll(delegate (ForeignKeyInfo fk88) {
							return fk88.Columns.Find(delegate (ColumnInfo col88) {
								return col88.Name == col.Name;
							}) != null;
						});

						//外键
						ForeignKeyInfo fk = null;
						string FK_uEntry_Name = string.Empty;
						string tableNamefe3 = string.Empty;
						string memberName = string.Empty;
						string strName = string.Empty;
						if (fks.Count > 0) {
							fk = fks[0];
							FK_uEntry_Name = fk.ReferencedTable != null ? GetCSName(fk.ReferencedTable.Name) :
								GetCSName(TableInfo.GetEntryName(fk.ReferencedTableName));
							tableNamefe3 = fk.ReferencedTable != null ? fk.ReferencedTable.Name : FK_uEntry_Name;
							memberName = fk.Columns[0].Name.IndexOf(tableNamefe3) == -1 ? tableNamefe3 :
								(fk.Columns[0].Name.Substring(0, fk.Columns[0].Name.IndexOf(tableNamefe3)) + tableNamefe3);
							if (fk.Columns[0].Name.IndexOf(tableNamefe3) == 0 && fk.ReferencedTable != null) memberName = fk.ReferencedTable.ClassName;

							ColumnInfo strNameCol = null;
							if (fk.ReferencedTable != null) {
								strNameCol = fk.ReferencedTable.Columns.Find(delegate (ColumnInfo col88) {
									return col88.Name.ToLower().IndexOf("name") != -1 || col88.Name.ToLower().IndexOf("title") != -1;
								});
								if (strNameCol == null) strNameCol = fk.ReferencedTable.Columns.Find(delegate (ColumnInfo col88) {
									return col88.CsType == "string" && col88.Length > 0 && col88.Length < 300;
								});
							}
							strName = strNameCol != null ? "." + UFString(strNameCol.Name) : string.Empty;
						}
						string Obj_name = string.Concat("Obj_", memberName, strName);

						if (!col.IsIdentity && fks.Count == 1) {
							ForeignKeyInfo fkcb = fks[0];
							string FK_uClass_Name = fkcb.ReferencedTable != null ? UFString(fkcb.ReferencedTable.ClassName) :
								UFString(TableInfo.GetClassName(fkcb.ReferencedTableName));

							getListParamQuery += string.Format(@"[FromQuery] {0}[] {1}, ", csType, csUName);
							sb3.AppendFormat(@"
			if ({0}.Length > 0) select.Where{0}({0});", csUName);
						} else if (!col.IsIdentity && us.Count == 1 || col.IsPrimaryKey && table.PrimaryKeys.Count == 1) {
							//主键或唯一键，非自动增值
						}

						//前端js或者模板
						if (!col.IsIdentity && fks.Count == 1 && fks[0].Table.FullName != fks[0].ReferencedTable.FullName) {
							str_listTh += string.Format(@"<th scope=""col"">{0}</th>
						", comment);
							str_listTd += string.Format(@"<td>[@item.{0}] @item.Obj_{1}{2}</td>
								", csUName, memberName, string.IsNullOrEmpty(strName) ? "" : ("?" + strName));
				//			str_controller_list_join += string.Format(@"
				//.LeftJoin<{0}>(""{3}"", ""{3}.{1} = a.{2}"")", UFString(fks[0].ReferencedTable.ClassName), fks[0].ReferencedColumns[0].Name, fks[0].Columns[0].Name, (char)++str_controller_list_join_alias);
							str_controller_list_join += string.Format(@"
				.LeftJoin(a => a.Obj_{0}.{1} == a.{2})", fks[0].ReferencedTable.ClassName, UFString(fks[0].ReferencedColumns[0].Name), UFString(fks[0].Columns[0].Name), (char)++str_controller_list_join_alias);
							if (str_listCms2FilterFK_fkitems.Contains("	var fk_" + LFString(fks[0].ReferencedTable.ClassName) + "s = ") == false)
								str_listCms2FilterFK_fkitems += string.Format(@"
	var fk_{1}s = {2}{0}.Select.ToList();", UFString(fks[0].ReferencedTable.ClassName), LFString(fks[0].ReferencedTable.ClassName), UFString(fks[0].ReferencedTable.ClassName) == "User" ? solutionName + ".BLL." : "");
							str_listCms2FilterFK += string.Format(@"
			{{ name: '{0}', field: '{4}', text: @Html.Json(fk_{1}s.Select(a => a.{2})), value: @Html.Json(fk_{1}s.Select(a => a.{3})) }},",
				UFString(fks[0].ReferencedTable.ClassName), LFString(fks[0].ReferencedTable.ClassName),
				string.IsNullOrEmpty(strName) ? "ToString()" : strName.TrimStart('.'), UFString(fks[0].ReferencedColumns[0].Name), UFString(fks[0].Columns[0].Name));
						} else if (csType == "string" && !ttfk_flag) {
							ttfk_flag = true;
							string t1 = string.Format(@"<th scope=""col"">{0}</th>
						", comment);
							string t2 = string.Format(@"<td>@item.{0}</td>
								", csUName);
							str_listTh1 += t1;
							str_listTd1 += t2;
							if (ttfk == null || ttfk.Columns[0].Name.ToLower() != "parent_id") {
								str_listTh += t1;
								str_listTd += t2;
							}
						} else if (col.Attndims > 0 || col.Type == NpgsqlDbType.Composite) {
							str_listTh += string.Format(@"<th scope=""col"">{0}</th>
						", comment);
							str_listTd += string.Format(@"<td>@JsonConvert.SerializeObject(item.{0})</td>
								", csUName);
						} else {
							str_listTh += string.Format(@"<th scope=""col"">{0}</th>
						", comment);
							str_listTd += string.Format(@"<td>@item.{0}</td>
								", csUName);
						}
					}
					if (keyLikes.Length > 0) {
						keyLikes = keyLikes.Remove(keyLikes.Length - 4);
						getListParamQuery = "[FromQuery] string key, " + getListParamQuery;
						sb2.AppendFormat(@"
				.Where(!string.IsNullOrEmpty(key), ""{0}"", string.Concat(""%"", key, ""%""))", keyLikes);
					}

					string itemSetValuePK = "";
					string itemSetValuePKInsert = "";
					string itemSetValueNotPK = "";
					string itemCsParamInsertForm = "";
					string itemCsParamUpdateForm = "";
					table.Columns.ForEach(delegate (ColumnInfo col88) {
						string csLName = LFString(col88.Name);
						string csUName = UFString(col88.Name);
						string csType = col88.CsType;

						if (col88.IsPrimaryKey) {
							//				itemSetValuePK += string.Format(@"
							//item.{0} = {0};", csUName);
							if (col88.IsIdentity) ;
							else if (csType == "Guid?") {
								itemSetValuePKInsert += string.Format(@"
			item.{0} = BLL.PSqlHelper.NewMongodbId();", csUName);
							} else {
								itemSetValuePKInsert += string.Format(@"
			item.{0} = {0};", csUName);
								itemCsParamInsertForm += string.Format(", [FromForm] {0} {1}", csType, csUName);
							}
						} else if (col88.IsIdentity) {
						} else if ((csLName == "img" || csLName.StartsWith("img_") || csLName.EndsWith("_img") ||
							csLName == "path" || csLName.StartsWith("path_") || csLName.EndsWith("_path")) && (col88.Type == NpgsqlDbType.Varchar || col88.Type == NpgsqlDbType.Char)) {
							//图片字段
							itemCsParamInsertForm += string.Format(", [FromForm] {0} {1}, [FromForm] IFormFile {1}_file", csType, csUName);
							itemCsParamUpdateForm += string.Format(", [FromForm] {0} {1}, [FromForm] IFormFile {1}_file", csType, csUName);
							itemSetValuePKInsert += string.Format(@"
			if ({1}_file != null) {{
				item.{1} = $""/upload/{{Guid.NewGuid().ToString()}}.png"";
				using (FileStream fs = new FileStream(System.IO.Path.Combine(AppContext.BaseDirectory, item.{1}), FileMode.Create)) {1}_file.CopyTo(fs);
			}} else
				item.{1} = {1};", "", csUName);
							itemSetValuePK += string.Format(@"
			if (!string.IsNullOrEmpty(item.{1}) && (item.{1} != {1} || {1}_file != null)) {{
				string path = System.IO.Path.Combine(AppContext.BaseDirectory, item.{1});
				if (System.IO.File.Exists(path)) System.IO.File.Delete(path);
			}}
			if ({1}_file != null) {{
				item.{1} = $""/upload/{{Guid.NewGuid().ToString()}}.png"";
				using (FileStream fs = new FileStream(System.IO.Path.Combine(AppContext.BaseDirectory, item.{1}), FileMode.Create)) {1}_file.CopyTo(fs);
			}} else
				item.{1} = {1};", "", csUName);
						} else {
							string colvalue = "";
							if (csType == "DateTime?" && (
	   string.Compare(csLName, "create_time", true) == 0 ||
	   string.Compare(csLName, "update_time", true) == 0
   )) {
								colvalue = "DateTime.Now";
							} else {
								string csType2 = csType;
								if (csType2 == "bool?") csType2 = "bool";
								itemCsParamInsertForm += string.Format(", [FromForm] {0} {1}", csType2, csUName);
								itemCsParamUpdateForm += string.Format(", [FromForm] {0} {1}", csType2, csUName);
								colvalue = csUName;
							}
							itemSetValueNotPK += string.Format(@"
			item.{0} = {1};", csUName, colvalue);
						}
					});
					if (itemCsParamInsertForm.Length > 0) itemCsParamInsertForm = itemCsParamInsertForm.Substring(2);

					// m -> n
					_tables.ForEach(delegate (TableInfo t2) {
						ForeignKeyInfo fk = t2.ForeignKeys.Find(delegate (ForeignKeyInfo ffk) {
							if (ffk.ReferencedTable.FullName == table.FullName) {
								return true;
							}
							return false;
						});
						if (fk == null) return;
						if (fk.Table.FullName == table.FullName) return;
						List<ForeignKeyInfo> fk2 = t2.ForeignKeys.FindAll(delegate (ForeignKeyInfo ffk2) {
							return ffk2 != fk;
						});
						if (fk2.Count != 1) return;
						if (fk.Columns[0].IsPrimaryKey == false) return; //中间表关系键，必须为主键
						if (t2.Columns.Count != 2) return; //mn表若不是两个字段，则不处理

						//t2.Columns
						string t2name = t2.Name;
						string tablename = table.Name;
						string addname = t2name;
						if (t2name.StartsWith(tablename + "_")) {
							addname = t2name.Substring(tablename.Length + 1);
						} else if (t2name.EndsWith("_" + tablename)) {
							addname = t2name.Remove(addname.Length - tablename.Length - 1);
						} else if (fk2.Count == 1 && t2name.EndsWith("_" + tablename)) {
							addname = t2name.Remove(t2name.Length - tablename.Length - 1);
						} else if (fk2.Count == 1 && t2name.EndsWith("_" + fk2[0].ReferencedTable.Name)) {
							addname = t2name;
						}

						ColumnInfo strNameCol = fk2[0].ReferencedTable.Columns.Find(delegate (ColumnInfo col88) {
							return col88.Name.ToLower().IndexOf("name") != -1 || col88.Name.ToLower().IndexOf("title") != -1;
						});
						if (strNameCol == null) strNameCol = fk2[0].ReferencedTable.Columns.Find(delegate (ColumnInfo col88) {
							return col88.CsType == "string" && col88.Length > 0 && col88.Length < 300;
						});
						if (strNameCol == null) strNameCol = fk2[0].ReferencedTable.PrimaryKeys[0];
						string strName = UFString(strNameCol.Name);

						getListParamQuery += string.Format(@"[FromQuery] {0}[] {1}_{2}, ", fk2[0].ReferencedTable.PrimaryKeys[0].CsType.Replace("?", ""), UFString(addname), table.PrimaryKeys[0].Name);
						sb3.AppendFormat(@"
			if ({0}_{1}.Length > 0) select.Where{0}_{1}({0}_{1});", UFString(addname), table.PrimaryKeys[0].Name);
						if (str_listCms2FilterFK_fkitems.Contains("	var fk_" + LFString(fk2[0].ReferencedTable.ClassName) + "s = ") == false)
							str_listCms2FilterFK_fkitems += string.Format(@"
	var fk_{1}s = {2}{0}.Select.ToList();", UFString(fk2[0].ReferencedTable.ClassName), LFString(fk2[0].ReferencedTable.ClassName), UFString(fk2[0].ReferencedTable.ClassName) == "User" ? solutionName + ".BLL." : "");
						str_listCms2FilterFK += string.Format(@"
			{{ name: '{0}', field: '{4}', text: @Html.Json(fk_{1}s.Select(a => a.{2})), value: @Html.Json(fk_{1}s.Select(a => a.{3})) }},",
			UFString(fk2[0].ReferencedTable.ClassName), LFString(fk2[0].ReferencedTable.ClassName),
			string.IsNullOrEmpty(strName) ? "ToString()" : strName.TrimStart('.'), UFString(fk2[0].ReferencedColumns[0].Name), UFString(fk2[0].Columns[0].Name));
						//add.html 标签关联
						itemCsParamInsertForm += string.Format(", [FromForm] {0}[] mn_{1}", fk2[0].ReferencedColumns[0].CsType.Replace("?", ""), UFString(addname));
						itemCsParamUpdateForm += string.Format(", [FromForm] {0}[] mn_{1}", fk2[0].ReferencedColumns[0].CsType.Replace("?", ""), UFString(addname));
						str_controller_insert_mn += string.Format(@"
			//关联 {1}
			foreach ({0} mn_{1}_in in mn_{1})
				item.Flag{1}(mn_{1}_in);", fk2[0].ReferencedColumns[0].CsType.Replace("?", ""), UFString(addname));
						str_controller_update_mn += string.Format(@"
			//关联 {1}
			if (mn_{1}.Length == 0) {{
				item.Unflag{1}ALL();
			}} else {{
				List<{0}> mn_{1}_list = mn_{1}.ToList();
				foreach (var Obj_{2} in item.Obj_{2}s) {{
					int idx = mn_{1}_list.FindIndex(a => a == Obj_{2}.Id);
					if (idx == -1) item.Unflag{1}(Obj_{2}.Id);
					else mn_{1}_list.RemoveAt(idx);
				}}
				mn_{1}_list.ForEach(a => item.Flag{1}(a));
			}}", fk2[0].ReferencedColumns[0].CsType.Replace("?", ""), UFString(addname), LFString(addname));
						str_addhtml_mn += string.Format(@"
						<tr>
							<td>{1}</td>
							<td>
								<select name=""mn_{2}"" data-placeholder=""Select a {3}"" class=""form-control select2"" multiple>
									@foreach ({0}Info fk in fk_{1}s) {{ <option value=""@fk.{4}"">@fk.{5}</option> }}
								</select>
							</td>
						</tr>", UFString(fk2[0].ReferencedTable.ClassName), LFString(fk2[0].ReferencedTable.ClassName),
							UFString(addname), LFString(addname), UFString(fk2[0].ReferencedColumns[0].Name), strName);
						if (str_fk_getlist.Contains("	var fk_" + LFString(fk2[0].ReferencedTable.ClassName) + "s") == false)
							str_fk_getlist += string.Format(@"
	var fk_{1}s = {2}{0}.Select.ToList();", UFString(fk2[0].ReferencedTable.ClassName), LFString(fk2[0].ReferencedTable.ClassName), UFString(fk2[0].ReferencedTable.ClassName) == "User" ? solutionName + ".BLL." : "");
						str_addjs_mn_initUI += string.Format(@"
			item.mn_{0} = @Html.Json(item.Obj_{2}s);
			for (var a = 0; a < item.mn_{0}.length; a++) $(form.mn_{0}).find('option[value=""{{0}}""]'.format(item.mn_{0}[a].{1})).attr('selected', 'selected');", UFString(addname), UFString(fk2[0].ReferencedColumns[0].Name), LFString(addname));
					});

					string str_mvcdel = string.Format(@"
		async public Task<APIReturn> _Del([FromForm] {2}[] id) {{
			var dels = new List<object>();
			foreach ({2} id2 in id)
				dels.Add(await {3}{1}.DeleteAsync(id2));
			if (dels.Count > 0) return APIReturn.成功.SetMessage($""删除成功，影响行数：{{dels.Count}}"").SetData(""dels"", dels);
			return APIReturn.失败;
		}}", solutionName, uClass_Name, table.PrimaryKeys[0].CsType.Replace("?", ""), uClass_Name == "User" ? "BLL." : "");
					if (table.PrimaryKeys.Count > 1) {
						string pkParses = "";
						int pk_idx = 0;
						foreach (ColumnInfo pk in table.PrimaryKeys) {
							pkParses += ", " + string.Format(GetStringifyParse(pk.Type, pk.CsType.TrimEnd('?')).Replace(".Replace(StringifySplit, \"|\")", ""), "vs[" + pk_idx++ + "]");
						}
						pkParses = pkParses.Substring(2);
						str_mvcdel = string.Format(@"
		async public Task<APIReturn> _Del([FromForm] string[] id) {{
			var dels = new List<object>();
			foreach (string id2 in id) {{
				string[] vs = id2.Split(',');
				dels.Add(await {3}{1}.DeleteAsync({2}));
			}}
			if (dels.Count > 0) return APIReturn.成功.SetMessage($""删除成功，影响行数：{{dels.Count}}"").SetData(""dels"", dels);
			return APIReturn.失败;
		}}", solutionName, uClass_Name, pkParses, uClass_Name == "User" ? "BLL." : "");
					}

					sb1.AppendFormat(CONST.Module_Admin_Controller, solutionName, uClass_Name, nClass_Name, pkMvcRoute,
						"[FromQuery] " + pkCsParam.Replace("?", "").Replace(", ", ", [FromQuery] "), pkCsParamNoType, itemSetValuePK, itemSetValueNotPK,
						sb2.ToString(), sb3.ToString(), itemCsParamInsertForm, itemCsParamUpdateForm, getListParamQuery, itemSetValuePKInsert,
						str_controller_list_join, "",
						str_controller_insert_mn, str_controller_update_mn, str_mvcdel, uClass_Name == "User" ? "BLL." : "");

					loc1.Add(new BuildInfo(string.Concat(CONST.moduleAdminPath, @"\Controllers\", uClass_Name, @"Controller.cs"), Deflate.Compress(sb1.ToString())));
					clearSb();
					#endregion

					if (ttfk == null || ttfk.Columns[0].Name.ToLower() != "parent_id") {
						#region wwwroot/xxx/index.html
						foreach (ColumnInfo col in table.Columns) {
							List<ForeignKeyInfo> ffks = new List<ForeignKeyInfo>();
							foreach (TableInfo fti in _tables) {
								ffks.AddRange(fti.ForeignKeys.FindAll(delegate (ForeignKeyInfo ffk) {
									if (ffk.ReferencedTable != null && ffk.ReferencedTable.FullName == table.FullName) {
										return ffk.ReferencedColumns.Find(delegate (ColumnInfo col88) {
											return col88.Name == col.Name;
										}) != null;
									}
									return false;
								}));
							}
							foreach (ForeignKeyInfo ffk in ffks) {
								string FFK_uClass_Name = UFString(ffk.Table.ClassName);
								string FFK_nClass_Name = UFString(ffk.Table.ClassName);

								string urlQuerys = string.Empty;
								ffk.Columns.ForEach(delegate (ColumnInfo col88) {
									string FFK_csUName = UFString(col.Name);
									urlQuerys += string.Format("{0}=@item.{1}&", UFString(col88.Name), FFK_csUName);
								});
								if (urlQuerys.Length > 0) urlQuerys = urlQuerys.Remove(urlQuerys.Length - 1);

								str_listTh += string.Format(@"<th scope=""col"">&nbsp;</th>
						");
								str_listTd += string.Format(@"<td><a href=""../{0}/?{1}"">{0}</a></td>
							", FFK_nClass_Name, urlQuerys);
							}
						}
						sb1.AppendFormat(@"@{{ 
	Layout = """";
}}

<div class=""box"">
	<div class=""box-header with-border"">
		<h3 id=""box-title"" class=""box-title""></h3>
		<span class=""form-group mr15""></span><a href=""./add"" data-toggle=""modal"" class=""btn btn-success pull-right"">添加</a>
	</div>
	<div class=""box-body"">
		<div class=""table-responsive"">
			<form id=""form_search"">
				<div id=""div_filter""></div>
			</form>
			<form id=""form_list"" action=""./del"" method=""post"">
				@Html.AntiForgeryToken()
				<input type=""hidden"" name=""__callback"" value=""del_callback""/>
				<table id=""GridView1"" cellspacing=""0"" rules=""all"" border=""1"" style=""border-collapse:collapse;"" class=""table table-bordered table-hover"">
					<tr>
						<th scope=""col"" style=""width:2%;""><input type=""checkbox"" onclick=""$('#GridView1 tbody tr').each(function (idx, el) {{ var chk = $(el).find('td:first input[type=\'checkbox\']')[0]; if (chk) chk.checked = !chk.checked; }});"" /></th>
						{3}<th scope=""col"" style=""width:5%;"">&nbsp;</th>
					</tr>
					<tbody>
						@foreach({0}Info item in ViewBag.items) {{
							<tr>
								<td><input type=""checkbox"" id=""id"" name=""id"" value=""{2}"" /></td>
								{4}<td><a href=""./edit?{1}"">修改</a></td>
							</tr>
						}}
					</tbody>
				</table>
			</form>
			<a id=""btn_delete_sel"" href=""#"" class=""btn btn-danger pull-right"">删除选中项</a>
			<div id=""kkpager""></div>
		</div>
	</div>
</div>

@{{{6}
}}
<script type=""text/javascript"">
	(function () {{
		top.del_callback = function(rt) {{
			if (rt.success) return top.mainViewNav.goto('./?' + new Date().getTime());
			alert(rt.message);
		}};

		var qs = _clone(top.mainViewNav.query);
		var page = cint(qs.page, 1);
		delete qs.page;
		$('#kkpager').html(cms2Pager(@ViewBag.count, page, 20, qs, 'page'));
		var fqs = _clone(top.mainViewNav.query);
		delete fqs.page;
		var fsc = [{5}
			null
		];
		fsc.pop();
		cms2Filter(fsc, fqs);
		top.mainViewInit();
	}})();
</script>
", uClass_Name, pkUrlQuerys, pkHiddens, str_listTh, str_listTd, str_listCms2FilterFK, str_listCms2FilterFK_fkitems);
						loc1.Add(new BuildInfo(string.Concat(CONST.moduleAdminPath, @"Views\", uClass_Name, @"\List.cshtml"), Deflate.Compress(sb1.ToString())));
						clearSb();
						#endregion
					} else {
						#region wwwroot/xxx/index.html(递归关系)
						sb1.AppendFormat(@"@{{ 
	Layout = """";
}}

<div class=""box"">
	<div class=""box-header with-border"">
		<h3 id=""box-title"" class=""box-title""></h3>
		<span class=""form-group mr15""></span><a href=""./add"" data-toggle=""modal"" class=""btn btn-success pull-right"">添加</a>
	</div>
	<div class=""box-body"">
		<div class=""table-responsive"">
			<form id=""form_list"" action=""./del"" method=""post"">
				@Html.AntiForgeryToken()
				<input type=""hidden"" name=""__callback"" value=""del_callback""/>
				<table id=""GridView1"" cellspacing=""0"" rules=""all"" border=""1"" style=""border-collapse:collapse;"" class=""table table-bordered table-hover"">
					<tr>
						{8}{6}<th scope=""col"" style=""width:5%;"">&nbsp;</th>
						<th scope=""col"" style=""width:5%;"">删除</th>
					</tr>
					<tbody>
						@foreach({0}Info item in ViewBag.items) {{
							<tr data-tt-id=""@item.{1}"" data-tt-parent-id=""@item.{2}"">
								{9}{7}<td><a href=""./edit?{4}"">修改</a></td>
								<td><input id=""id"" name=""id"" type=""checkbox"" value=""{5}"" /></td>
							</tr>
						}}
					</tbody>
				</table>
			</form>
		</div>
	</div>
</div>

<div>
	<font color=""red"">*</font> 删除父项时，请先删除其所有子项。
	<a id=""btn_delete_sel"" href=""#"" class=""btn btn-danger pull-right"">删除选中项</a>
</div>

<script type=""text/javascript"">
	(function() {{
		top.del_callback = function(rt) {{
			if (rt.success) return top.mainViewNav.goto('./?' + new Date().getTime());
			alert(rt.message);
		}};

		$('table#GridView1').treetable({{ expandable: true }});
		$('table#GridView1').treetable('expandAll');
		top.mainViewInit();
	}})();
</script>", uClass_Name, UFString(table.PrimaryKeys[0].Name), UFString(ttfk.Columns[0].Name), "",
	pkUrlQuerys.Replace("a.", ""), pkHiddens.Replace("a.", ""), str_listTh.Replace("a.", ""), str_listTd.Replace("a.", ""), str_listTh1.Replace("a.", ""), str_listTd1.Replace("a.", ""));
						loc1.Add(new BuildInfo(string.Concat(CONST.moduleAdminPath, @"Views\", uClass_Name, @"\List.cshtml"), Deflate.Compress(sb1.ToString())));
						clearSb();
						#endregion
					}

					#region wwwroot/xxx/add.html
					foreach (ColumnInfo col in table.Columns) {
						string csType = col.CsType;
						string csUName = UFString(col.Name);
						string lname = col.Name.ToLower();
						string comment = _column_coments.ContainsKey(table.FullName) && _column_coments[table.FullName].ContainsKey(col.Name) ? _column_coments[table.FullName][col.Name] : col.Name;
						string rfvEmpty = string.Empty;
						List<ColumnInfo> us = table.Uniques.Find(delegate (List<ColumnInfo> cs) {
							return cs.Find(delegate (ColumnInfo col88) {
								return col88.Name == col.Name;
							}) != null;
						});
						if (us == null) us = new List<ColumnInfo>();
						List<ForeignKeyInfo> fks_comb = table.ForeignKeys.FindAll(delegate (ForeignKeyInfo fk) {
							return fk.Columns.Count == 1 && fk.Columns[0].Name == col.Name;
						});

						if (csType == "bool?") {
							sb4.AppendFormat(@"
						<tr>
							<td>{1}</td>
							<td id=""{0}_td""><input name=""{0}"" type=""checkbox"" value=""true"" /></td>
						</tr>", csUName, comment);
						} else if (csType == "DateTime?" && (
							string.Compare(lname, "create_time", true) == 0 ||
							string.Compare(lname, "update_time", true) == 0
							)) {
							sb14.AppendFormat(@"
							<tr>
								<td>{1}</td>
								<td><input name=""{0}"" type=""text"" readonly class=""datepicker"" style=""width:20%;background-color:#ddd;"" /></td>
							</tr>", csUName, comment);
						} else if (col.IsPrimaryKey && col.IsIdentity) {
							//主键自动增值
							sb4.AppendFormat(@"
						@if (item != null) {{
							<tr>
								<td>{1}</td>
								<td><input name=""{0}"" type=""text"" readonly class=""datepicker"" style=""width:20%;background-color:#ddd;"" /></td>
							</tr>
						}}", csUName, comment);
						} else if (col.IsPrimaryKey && csType == "Guid?") {
							//uuid主键
							sb4.AppendFormat(@"
						@if (item != null) {{
							<tr>
								<td>{1}</td>
								<td><input name=""{0}"" type=""text"" readonly class=""datepicker"" style=""width:60%;background-color:#ddd;"" /></td>
							</tr>
						}}", csUName, comment);
						} else if (fks_comb.Count == 1) {
							//外键下拉框
							ForeignKeyInfo fkcb = fks_comb[0];
							string FK_uClass_Name = fkcb.ReferencedTable != null ? UFString(fkcb.ReferencedTable.ClassName) :
								UFString(TableInfo.GetClassName(fkcb.ReferencedTableName));
							ForeignKeyInfo fkrr = fkcb.ReferencedTable != null ?
										fkcb.ReferencedTable.ForeignKeys.Find(delegate (ForeignKeyInfo fkkk) {
											return fkkk.ReferencedTable != null && fkcb.ReferencedTable.FullName == fkkk.ReferencedTable.FullName;
										}) : null;
							bool isParentSelect = fkcb.ReferencedTable != null && fkrr != null;
							string FK_Column = fkcb.ReferencedTable != null ?
										UFString(fkcb.ReferencedColumns[0].Name) : UFString(fkcb.ReferencedColumnNames[0]);

							ColumnInfo strCol = fkcb.ReferencedTable.Columns.Find(delegate (ColumnInfo col99) {
								return col99.Name.ToLower().IndexOf("name") != -1 || col99.Name.ToLower().IndexOf("title") != -1;
							});
							if (strCol == null) strCol = fkcb.ReferencedTable.Columns.Find(delegate (ColumnInfo col99) {
								return col99.CsType == "string" && col99.Length > 0 && col99.Length < 300;
							});
							string FK_Column_Text = fkcb.ReferencedTable != null && strCol != null ? UFString(strCol.Name)
								 : FK_Column;

							if (isParentSelect) {
								sb4.AppendFormat(@"
						<tr>
							<td>{1}</td>
							<td id=""{0}_td""></td>
						</tr>", csUName, comment);
								sb5.AppendFormat(@"
		$('#{3}_td').html(yieldTreeSelect(yieldTreeArray(@Html.Json(fk_{0}s), null, '{1}', '{2}'), '{{#{4}}}', '{1}')).find('select').attr('name', '{3}');",
			FK_uClass_Name, UFString(fkcb.ReferencedColumns[0].Name), UFString(fkrr.Columns[0].Name), csUName, FK_Column_Text);
							} else {
								sb4.AppendFormat(@"
						<tr>
							<td>{1}</td>
							<td>
								<select name=""{0}"">
									<option value="""">------ 请选择 ------</option>
									@foreach (var fk in fk_{4}s) {{ <option value=""@fk.{2}"">@fk.{3}</option> }}
								</select>
							</td>
						</tr>", csUName, comment, UFString(fkcb.ReferencedColumns[0].Name), FK_Column_Text, FK_uClass_Name);
							}
							if (str_fk_getlist.Contains("	var fk_" + FK_uClass_Name + "s") == false)
								str_fk_getlist += string.Format(@"
	var fk_{0}s = {1}{0}.Select.ToList();", FK_uClass_Name, FK_uClass_Name == "User" ? solutionName +  ".BLL." : "");
						} else if ((col.Type == NpgsqlDbType.Integer || col.Type == NpgsqlDbType.Bigint) && (lname == "status" || lname.StartsWith("status_") || lname.EndsWith("_status"))) {
							//加载 multi 多状态字段
							sb4.AppendFormat(@"
						<tr>
							<td>{1}</td>
							<td><input name=""{0}"" type=""hidden"" multi_status=""状态1,状态2,状态3,状态4,状态5"" /></td>
						</tr>", csUName, comment);
						} else if (col.Attndims == 0 && (col.Type == NpgsqlDbType.Smallint || col.Type == NpgsqlDbType.Integer || col.Type == NpgsqlDbType.Bigint)) {
							sb4.AppendFormat(@"
						<tr>
							<td>{1}</td>
							<td><input name=""{0}"" type=""text"" class=""form-control"" data-inputmask=""'mask': '9', 'repeat': 6, 'greedy': false"" data-mask style=""width:200px;"" /></td>
						</tr>", csUName, comment);
						} else if (col.Attndims == 0 && (col.Type == NpgsqlDbType.Numeric || col.Type == NpgsqlDbType.Real || col.Type == NpgsqlDbType.Double || col.Type == NpgsqlDbType.Money)) {
							sb4.AppendFormat(@"
						<tr>
							<td>{1}</td>
							<td>
								<div class=""input-group"" style=""width:200px;"">
									<span class=""input-group-addon"">￥</span>
									<input name=""{0}"" type=""text"" class=""form-control"" data-inputmask=""'mask': '9', 'repeat': 10, 'greedy': false"" data-mask />
									<span class=""input-group-addon"">.00</span>
								</div>
							</td>
						</tr>", csUName, comment);
						} else if (col.Type == NpgsqlDbType.Timestamp || col.Type == NpgsqlDbType.TimestampTZ) {
							//日期
							sb4.AppendFormat(@"
						<tr>
							<td>{1}</td>
							<td><input name=""{0}"" type=""text"" class=""datepicker"" /></td>
						</tr>", csUName, comment);
						} else if (col.Type == NpgsqlDbType.Date) {
							//日期控件
							sb4.AppendFormat(@"
						<tr>
							<td>{1}</td>
							<td>
								<div class=""input-group date"" style=""width:200px;"">
									<div class=""input-group-addon""><i class=""fa fa-calendar""></i></div>
									<input name=""{0}"" type=""text"" data-provide=""datepicker"" class=""form-control pull-right"" readonly />
								</div>
							</td>
						</tr>", csUName, comment);
						} else if ((lname == "img" || lname.StartsWith("img_") || lname.EndsWith("_img") ||
							lname == "path" || lname.StartsWith("path_") || lname.EndsWith("_path")) && (col.Type == NpgsqlDbType.Varchar || col.Type == NpgsqlDbType.Char)) {
							//图片字段
							sb4.AppendFormat(@"
						<tr>
							<td>{1}</td>
							<td>
								<input name=""{0}"" type=""text"" class=""datepicker"" style=""width:60%;"" />
								<input name=""{0}_file"" type=""file"">
							</td>
						</tr>", csUName, comment);
						} else if (col.Type == NpgsqlDbType.Text) {
							//加载百度编辑器
							sb4.AppendFormat(@"
						<tr>
							<td>{1}</td>
							<td><textarea name=""{0}"" style=""width:100%;height:100px;"" editor=""ueditor""></textarea></td>
						</tr>", csUName, comment);
						} else if (col.Type == NpgsqlDbType.Enum) {
							sb4.AppendFormat(@"
						<tr>
							<td>{1}</td>
							<td>
								<select name=""{0}""{3}
									@foreach (object eo in Enum.GetValues(typeof({2}))) {{ <option value=""@eo"">@eo</option> }}
								</select>
							</td>
						</tr>", csUName, comment, GetCSType(col.Type, 0, col.SqlType).Replace("?", ""), col.Attndims > 0 ? string.Format(@" data-placeholder=""Select a {0}"" class=""form-control select2"" multiple>", comment) : @"><option value="""">------ 请选择 ------</option>");
							if (col.Attndims > 0)
								str_addjs_mn_initUI += string.Format(@"
			if (item.{0}) for (var a = 0; a < item.{0}.length; a++) $(form.{0}).find('option[value=""{{0}}""]'.format(item.{0}[a])).attr('selected', 'selected');", csUName);
						} else {
							sb4.AppendFormat(@"
						<tr>
							<td>{1}</td>
							<td><input name=""{0}"" type=""text"" class=""datepicker"" style=""width:60%;"" /></td>
						</tr>", csUName, comment);
						}
					}
					sb4.Append(str_addhtml_mn);
					if (sb14.ToString().Length > 0) {
						sb14.Insert(0, @"
						@if (item != null) {");
						sb14.Append(@"
						}");
					}

					sb1.AppendFormat(@"@{{
	Layout = """";
	{0}Info item = ViewBag.item;{3}
}}

<div class=""box"">
	<div class=""box-header with-border"">
		<h3 class=""box-title"" id=""box-title""></h3>
	</div>
	<div class=""box-body"">
		<div class=""table-responsive"">
			<form id=""form_add"" method=""post"">
				@Html.AntiForgeryToken()
				<input type=""hidden"" name=""__callback"" value=""edit_callback"" />
				<div>
					<table cellspacing=""0"" rules=""all"" class=""table table-bordered table-hover"" border=""1"" style=""border-collapse:collapse;"">{1}{5}
						<tr>
							<td width=""8%"">&nbsp</td>
							<td><input type=""submit"" value=""@(item == null ? ""添加"" : ""更新"")"" />&nbsp;<input type=""button"" value=""取消"" /></td>
						</tr>
					</table>
				</div>
			</form>

		</div>
	</div>
</div>

<script type=""text/javascript"">
	(function () {{
		top.edit_callback = function (rt) {{
			if (rt.success) return top.mainViewNav.goto('./?' + new Date().getTime());
			alert(rt.message);
		}};
{2}
		var form = $('#form_add')[0];
		var item = null;
		@if (item != null) {{
			<text>
			item = @Html.Json(item);
			fillForm(form, item);{4}
			</text>
		}}
		top.mainViewInit();
	}})();
</script>", uClass_Name, sb4.ToString(), sb5.ToString(), str_fk_getlist, str_addjs_mn_initUI, sb14.ToString());
					loc1.Add(new BuildInfo(string.Concat(CONST.moduleAdminPath, @"Views\", uClass_Name, @"\Edit.cshtml"), Deflate.Compress(sb1.ToString())));
					clearSb();
					#endregion
				}
				#endregion
			}

			#region BLL ItemCache.cs
			sb1.AppendFormat(CONST.BLL_Build_ItemCache_cs, solutionName);
			//loc1.Add(new BuildInfo(string.Concat(CONST.corePath, solutionName, @".db\BLL\", basicName, @"\ItemCache.cs"), Deflate.Compress(sb1.ToString())));
			clearSb();
			#endregion
			#region Model ExtensionMethods.cs 扩展方法
			sb1.AppendFormat(CONST.Model_Build__ExtensionMethods_cs, solutionName, Model_Build_ExtensionMethods_cs.ToString());
			loc1.Add(new BuildInfo(string.Concat(CONST.corePath, solutionName, @".db\Model\", basicName, @"\_ExtensionMethods.cs"), Deflate.Compress(sb1.ToString())));
			clearSb();
			#endregion
			#region DBUtility/PSqlHelper.cs
			sb1.AppendFormat(CONST.DAL_DBUtility_PSqlHelper_cs, solutionName, connectionStringName, PSqlHelperMapTypeGlobally);
			loc1.Add(new BuildInfo(string.Concat(CONST.corePath, solutionName, @".db\DAL\DBUtility\PSqlHelper.cs"), Deflate.Compress(sb1.ToString())));
			clearSb();
			#endregion

			if (isSolution) {
				#region db.csproj
				sb1.AppendFormat(CONST.Db_csproj, solutionName);
				loc1.Add(new BuildInfo(string.Concat(CONST.corePath, solutionName, @".db\", solutionName, ".db.csproj"), Deflate.Compress(sb1.ToString())));
				clearSb();
				#endregion

				#region Module/Test
				#region TestController.cs
				sb1.AppendFormat(CONST.Module_Test_Controller, solutionName, "Test");
				loc1.Add(new BuildInfo(string.Concat(CONST.corePath, @"Module\Test\Controllers\TestController.cs"), Deflate.Compress(sb1.ToString())));
				clearSb();
				#endregion
				#region Init.cs
				sb1.AppendFormat(CONST.Module_Test_Init_cs, solutionName, "Test");
				loc1.Add(new BuildInfo(string.Concat(CONST.corePath, @"Module\Test\Init.cs"), Deflate.Compress(sb1.ToString())));
				clearSb();
				#endregion
				#region appsettings.json
				loc1.Add(new BuildInfo(string.Concat(CONST.corePath, @"Module\Test\appsettings.json"), Deflate.Compress("{\r\n}")));
				clearSb();
				#endregion

				#region Views\_ViewStart.cshtml
				sb1.AppendFormat(@"@{{
	Layout = ""_Layout"";
}}", solutionName);
				loc1.Add(new BuildInfo(string.Concat(CONST.corePath, @"Module\Test\Views\_ViewStart.cshtml"), Deflate.Compress(sb1.ToString())));
				clearSb();
				#endregion
				#region Views\_ViewImports.cshtml
				sb1.AppendFormat(@"@using Newtonsoft.Json;
@using {0}.BLL;
@using {0}.Model;

@addTagHelper *, Microsoft.AspNetCore.Mvc.TagHelpers
", solutionName);
				loc1.Add(new BuildInfo(string.Concat(CONST.corePath, @"Module\Test\Views\_ViewImports.cshtml"), Deflate.Compress(sb1.ToString())));
				clearSb();
				#endregion
				#region Views\Shared\_Layout.cshtml
				sb1.AppendFormat(@"<!DOCTYPE html>
<html>
<head>
	<meta charset=""utf-8"">
	<title>@ViewBag.title</title>
	<link rel=""stylesheet"" href=""//cdn.bootcss.com/semantic-ui/2.1.8/semantic.min.css"">
	<link rel=""stylesheet"" href=""/css/style.css"">
	<script src=""//cdn.bootcss.com/jquery/1.11.3/jquery.min.js""></script>
	<script src=""//cdn.bootcss.com/semantic-ui/2.1.8/semantic.min.js""></script>
</head>
<body>

	@RenderBody()

</body>
</html>", solutionName);
				loc1.Add(new BuildInfo(string.Concat(CONST.corePath, @"Module\Test\Views\Shared\_Layout.cshtml"), Deflate.Compress(sb1.ToString())));
				clearSb();
				#endregion
				#region Test.csproj
				sb1.AppendFormat(CONST.Module_csproj, "Test");
				loc1.Add(new BuildInfo(string.Concat(CONST.corePath, @"Module\Test\Test.csproj"), Deflate.Compress(sb1.ToString())));
				clearSb();
				#endregion
				#endregion

				#region .gitattributes
				sb1.Append(Server.Properties.Resources._gitattributes);
				loc1.Add(new BuildInfo(string.Concat(CONST.corePath, @"..\.gitattributes"), Deflate.Compress(sb1.ToString())));
				clearSb();
				#endregion
				#region .gitignore
				sb1.Append(Server.Properties.Resources._gitignore);
				loc1.Add(new BuildInfo(string.Concat(CONST.corePath, @"..\.gitignore"), Deflate.Compress(sb1.ToString())));
				clearSb();
				#endregion
				#region build.bat
				sb1.Append(Server.Properties.Resources._build_bat);
				loc1.Add(new BuildInfo(string.Concat(CONST.corePath, @"..\build.bat"), Deflate.Compress(sb1.ToString())));
				clearSb();
				#endregion
				#region readme.md
				loc1.Add(new BuildInfo(string.Concat(CONST.corePath, @"..\readme.md"), Deflate.Compress(string.Format(@"# {0}
.net core模块化开发框架

本项目由 [【dotnetGen_postgresql】](https://github.com/2881099/dotnetGen_postgresql) 工具生成

## Module

	所有业务接口约定在 Module 划分并行开发，互不依赖

	Module/Admin
	生成的后台管理模块，http://localhost:5001/module/Admin 可访问

	Module/Test
	生成的测试模块

## WebHost

	WebHost 编译的时候，会将 Module/* 编译结果复制到当前目录
	WebHost 只当做主引擎运行时按需加载相应的 Module
	WebHost 依赖 npm ，请安装 node，并在目录执行 npm install
	WebHost 依赖 gulp-cli，请执行全局安装 npm install --global gulp-cli
	运行步骤：
    1、打开 vs 右击 Module 目录全部编译；
    2、cd WebHost && npm install && dotnet build && dotnet run

## Infrastructure

	Module 里面每个子模块的依赖所需

#### xx.db

	包含一切数据库操作的封装
	xx.Model(实体映射)
	xx.BLL(静态方法封装)
	xx.DAL(数据访问)
	生成名特征取数据库名首字母大写(如: 表 test 对应 xx.Model.TestInfo、xx.BLL.Test、xx.DAL.Test)

	数据库设计命名习惯：所有命名(username, stats_click)、外键字段(user_id)
	仅支持主键作为外键，不支持组合字段，不支持唯一键作为外键
	修改数据库后，双击“./GenPg只更新db.bat”可快速覆盖，所有类都使用 partial，方便扩展亦不会被二次生成覆盖

# 数据库相关方法

## 添加记录

```csharp
// 如有 create_time 字段并且类型为日期，内部会初始化
TestInfo newitem1 = Test.Insert(Title: ""添加的标题"", Content: ""这是一段添加的内容"");
TestInfo newitem2 = Test.Insert(new TestInfo {{ Title = ""添加的标题"", Content = ""这是一段添加的内容"" }});
```

## 添加记录(批量)

```csharp
List<TestInfo> newitems1 = Test.Insert(new [] {{
	new TestInfo {{ Title = ""添加的标题1"", Content = ""这是一段添加的内容1"" }},
	new TestInfo {{ Title = ""添加的标题2"", Content = ""这是一段添加的内容2"" }}
}});
```

## 更新记录

```csharp
// 更新 id = 1 所有字段
Test.Update(new TestInfo {{ Id: 1, Title = ""添加的标题"", Content = ""这是一段添加的内容"", Clicks = 1 }});
// 更新 id = 1 指定字段
Test.UpdateDiy(1).SetTitle(""修改后的标题"").SetContent(""修改后的内容"").SetClicks(1).ExecuteNonQuery();
// update 表名 set clicks = clicks + 1 where id = 1
Test.UpdateDiy(1).SetClicksIncrement(1).ExecuteNonQuery();
// 使用实体层修改
new TestInfo {{ Id = 1 }}.UpdateDiy.SetClicksIncrement(1).ExecuteNonQuery();
```

## 更新记录(批量)

```csharp
//先查找 clicks 在 0 - 100 的记录
List<TestInfo> newitems1 = Test.Select.WhereClicksRange(0, 100).ToList();
// update 表名 set clicks = clicks + 1 where id in (newitems1所有id)
newitems1.UpdateDiy().SetClicksIncrement(1).ExecuteNonQuery();
```

> 警告：批量更新的方法，在事务中使用会导致死锁

## 删除记录

```csharp
// 删除 id = 1 的记录
Test.Delete(1);
```

## 按主键/唯一键获取单条记录

> appsettings可配置缓存时间，以上所有增、改、删都会删除缓存保障同步

```csharp
//按主键获取
UserInfo user1 = User.GetItem(1);
//按唯一键
UserInfo user2 = User.GetItemByUsername(""2881099@qq.com"");
// 返回 null 或 UserInfo
```

## 查询(核心)

```csharp
//BLL.表名.Select 是一个链式查询对象，几乎支持所有查询，包括 group by、inner join等等，最终 ToList ToOne Aggregate 执行 sql
List<UserInfo> users1 = User.Select.WhereUsername(""2881099@qq.com"").WherePassword(""******"").WhereStatus(正常).ToList();
//返回 new List<UserInfo>() 或 有元素的 List，永不返回 null

//返回指定列，返回List<元组>
var users2 = User.Select.WhereStatus(正常).Aggregate<(int id, string title)>(""id,title"");

//多表查询，只返回 a 表字段
var users3 = User.Select.Where(a => a.Obj_user_group.Id == a.Group_id).ToList();

//join查询，返回 a, b 表字段 ，b 表结果填充至 a.Obj_user_group 对象，类似 ef.Include
var users4 = User.Select.InnerJoin(a => a.Obj_user_group.Id == a.Group_id).ToList();

//分组查询
var users5 = User.Select.GroupBy(""group_id"").Aggregate<(int groupId, int count)>(""group_id, count(1)"");

//等等...
```

## 事务

```csharp
//错误会回滚，事务内支持所有生成的同步方法（不支持生成对应的Async方法）
var user = User.GetItem(1);
PSqlHelper.Transaction(() => {{
	if (user.UpdateDiy.SetAmountIncrement(-num).Where(""amount > {{0}}"", num).ExecuteNonQuery() <= 0)
		throw new Exception(""余额不足"");

	var order = user.AddOrder(Amount: 1, Count: num, Count_off: num);
}});
```

## 缓存

1、根据主键、唯一键缓存

BLL GetItem、GetItemBy唯一键，使用了默认缓存策略180秒，用来缓存一条记录，db 层自动维护缓存同步，例如：

```csharp
//只有第一次查询了数据库，后面99次读取redis的缓存值
UserInfo u;
for (var a = 0; a < 100; a++)
	u = User.GetItemByUsername(""2881099@qq.com"");

//执行类似以下的数据变动方法，会删除redis对应的缓存
u.UpdateDiy.SetLogin_time(DateTime.Now).ExecuteNonQuery();
```

2、缓存一个查询结果

BLL Select.ToList(10, ""cache_key"")，将查询结果缓存10秒，需要手工删除redis对应的键

## 读写分离

内置实现读和写分离，一个【主库】多个【从库】，【从库】的查询策略为随机方式。

若某【从库】发生故障，将切换到其他可用【从库】，若已全部不可用则使用【主库】查询。

出现故障【从库】被隔离起来间隔性的检查可用状态，以待恢复。

```csharp
Topic.Select.WhereId(1).ToOne(); //读【从库】（默认）
Topic.Select.Master().WhereId(1).ToOne(); //读【主库】
```

# 生成规则

## 不会生成

* 没有主键，不会生成 增、改、删 方法

## 特别规则

* 字段类型 point，会生成
	> 表.Select.Where字段MbrContains(查找地理位置多少米范围内的记录，距离由近到远排序)
* 字段类型 string 相关并且长度 <= 300，会生成
	> 表.Select.Where字段Like
* 字段类型 数组，会生成
	> 表.Select.Where字段Any、表.UpdateDiy(1).Set字段Join
* 字段类型 jsonb，会生成
	> 表.Select.Where字段Contain

	> 表.Select.Where字段ContainKey

	> 表.Select.Where字段ContainKeys

	> 表.Select.Where字段ContainKeysAny
* 字段类型 hstore，会生成
	> 表.Select.Where字段Contain

	> 表.Select.Where字段ContainKey

	> 表.Select.Where字段ContainKeys

	> 表.Select.Where字段ContainKeysAny
* 100%的数据类型被支持
", solutionName))));
				clearSb();
				#endregion
				
				#region GenPg只更新db.bat
				loc1.Add(new BuildInfo(string.Concat(CONST.corePath, @"..\GenPg只更新db.bat"), Deflate.Compress(string.Format(@"
GenPg {0}:{1} -U {2} -P {3} -D {4} -N {5}", _client.Server, _client.Port, _client.Username, _client.Password, _client.Database, solutionName))));
				clearSb();
				#endregion
			}

			if (isMakeAdmin) {
				#region WebHost
				#region Extensions/StarupExtensions.cs
				sb1.AppendFormat(CONST.WebHost_Extensions_StarupExtensions_cs, solutionName);
				loc1.Add(new BuildInfo(string.Concat(CONST.webHostPath, @"\Extensions\StarupExtensions.cs"), Deflate.Compress(sb1.ToString())));
				clearSb();
				#endregion
				#region Extensions/SwaggerExtensions.cs
				sb1.AppendFormat(CONST.WebHost_Extensions_SwaggerExtensions_cs, solutionName);
				loc1.Add(new BuildInfo(string.Concat(CONST.webHostPath, @"\Extensions\SwaggerExtensions.cs"), Deflate.Compress(sb1.ToString())));
				clearSb();
				#endregion
				#region .gitignore
				sb1.Append(Server.Properties.Resources.WebHost_gitignore);
				loc1.Add(new BuildInfo(string.Concat(CONST.webHostPath, @".gitignore"), Deflate.Compress(sb1.ToString())));
				clearSb();
				#endregion
				#region appsettings.json
				sb1.AppendFormat(CONST.WebHost_appsettings_json, solutionName);
				loc1.Add(new BuildInfo(string.Concat(CONST.webHostPath, @"appsettings.json"), Deflate.Compress(sb1.ToString())));
				clearSb();
				#endregion
				#region gulpfile.js
				sb1.Append(Server.Properties.Resources.WebHost_gulpfile_js);
				loc1.Add(new BuildInfo(string.Concat(CONST.webHostPath, @"gulpfile.js"), Deflate.Compress(sb1.ToString())));
				clearSb();
				#endregion
				#region nlog.config
				sb1.AppendFormat(CONST.WebHost_nlog_config, solutionName);
				loc1.Add(new BuildInfo(string.Concat(CONST.webHostPath, @"nlog.config"), Deflate.Compress(sb1.ToString())));
				clearSb();
				#endregion
				#region package.json
				sb1.Append(Server.Properties.Resources.WebHost_package_json);
				loc1.Add(new BuildInfo(string.Concat(CONST.webHostPath, @"package.json"), Deflate.Compress(sb1.ToString())));
				clearSb();
				#endregion
				#region Program.cs
				sb1.AppendFormat(CONST.WebHost_Program_cs, solutionName);
				loc1.Add(new BuildInfo(string.Concat(CONST.webHostPath, @"Program.cs"), Deflate.Compress(sb1.ToString())));
				clearSb();
				#endregion
				#region Startup.cs
				sb1.AppendFormat(CONST.WebHost_Startup_cs, solutionName);
				loc1.Add(new BuildInfo(string.Concat(CONST.webHostPath, @"Startup.cs"), Deflate.Compress(sb1.ToString())));
				clearSb();
				#endregion
				#region web.config
				sb1.Append(Server.Properties.Resources.WebHost_web_config);
				loc1.Add(new BuildInfo(string.Concat(CONST.webHostPath, @"web.config"), Deflate.Compress(sb1.ToString())));
				clearSb();
				#endregion
				#region WebHost.csproj
				sb1.AppendFormat(CONST.WebHost_csproj, solutionName);
				loc1.Add(new BuildInfo(string.Concat(CONST.webHostPath, @"WebHost.csproj"), Deflate.Compress(sb1.ToString())));
				clearSb();
				#endregion
				#endregion

				#region Module/Admin
				#region SysController.cs
				sb1.AppendFormat(CONST.Module_Admin_Controllers_SysController, solutionName, string.Join(string.Empty, admin_controllers_syscontroller_init_sysdir.ToArray()));
				loc1.Add(new BuildInfo(string.Concat(CONST.moduleAdminPath, @"Controllers\SysController.cs"), Deflate.Compress(sb1.ToString())));
				clearSb();
				#endregion
				#region LoginController.cs
				sb1.AppendFormat(CONST.Module_Admin_Controllers_LoginController, solutionName);
				loc1.Add(new BuildInfo(string.Concat(CONST.moduleAdminPath, @"Controllers\LoginController.cs"), Deflate.Compress(sb1.ToString())));
				clearSb();
				#endregion
				#region Views\Admin\Login\Index.cshtml
				sb1.AppendFormat(CONST.Module_Admin_Views_Login_Index_cshtml, solutionName);
				loc1.Add(new BuildInfo(string.Concat(CONST.moduleAdminPath, @"Views\Login\Index.cshtml"), Deflate.Compress(sb1.ToString())));
				clearSb();
				#endregion
				#region wwwroot\index.html
				sb1.AppendFormat(CONST.Module_Admin_wwwroot_index_html, solutionName, wwwroot_sitemap);
				loc1.Add(new BuildInfo(string.Concat(CONST.moduleAdminPath, @"wwwroot\index.html"), Deflate.Compress(sb1.ToString())));
				clearSb();
				#endregion
				#region Init.cs
				sb1.AppendFormat(CONST.Module_Test_Init_cs, solutionName, "Admin");
				loc1.Add(new BuildInfo(string.Concat(CONST.moduleAdminPath, @"Init.cs"), Deflate.Compress(sb1.ToString())));
				clearSb();
				#endregion
				#region appsettings.json
				loc1.Add(new BuildInfo(string.Concat(CONST.moduleAdminPath, @"appsettings.json"), Deflate.Compress("{\r\n}")));
				clearSb();
				#endregion

				#region Views\_ViewStart.cshtml
				sb1.AppendFormat(@"@{{
	Layout = ""_Layout"";
}}", solutionName);
				loc1.Add(new BuildInfo(string.Concat(CONST.moduleAdminPath, @"Views\_ViewStart.cshtml"), Deflate.Compress(sb1.ToString())));
				clearSb();
				#endregion
				#region Views\_ViewImports.cshtml
				sb1.AppendFormat(@"@using Newtonsoft.Json;
@using {0}.BLL;
@using {0}.Model;

@addTagHelper *, Microsoft.AspNetCore.Mvc.TagHelpers
", solutionName);
				loc1.Add(new BuildInfo(string.Concat(CONST.moduleAdminPath, @"Views\_ViewImports.cshtml"), Deflate.Compress(sb1.ToString())));
				clearSb();
				#endregion
				#region Views\Shared\_Layout.cshtml
				sb1.AppendFormat(@"<!DOCTYPE html>
<html>
<head>
	<meta charset=""utf-8"">
	<title>@ViewBag.title</title>
	<link rel=""stylesheet"" href=""//cdn.bootcss.com/semantic-ui/2.1.8/semantic.min.css"">
	<link rel=""stylesheet"" href=""/css/style.css"">
	<script src=""//cdn.bootcss.com/jquery/1.11.3/jquery.min.js""></script>
	<script src=""//cdn.bootcss.com/semantic-ui/2.1.8/semantic.min.js""></script>
</head>
<body>

	@RenderBody()

</body>
</html>", solutionName);
				loc1.Add(new BuildInfo(string.Concat(CONST.moduleAdminPath, @"Views\Shared\_Layout.cshtml"), Deflate.Compress(sb1.ToString())));
				clearSb();
				#endregion
				#region Admin.csproj
				sb1.AppendFormat(CONST.Module_csproj, "Admin");
				loc1.Add(new BuildInfo(string.Concat(CONST.moduleAdminPath, @"Admin.csproj"), Deflate.Compress(sb1.ToString())));
				clearSb();
				#endregion
				#endregion
			}
			if (isDownloadRes) {
				loc1.Add(new BuildInfo(string.Concat(CONST.corePath, @"..\htm.zip"), Server.Properties.Resources.htm_zip));
			}

			GC.Collect();
			return loc1;
		}
	}
}
