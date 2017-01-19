using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Text.RegularExpressions;
using Model;

namespace Server {

	internal partial class CodeBuild : IDisposable {
		private ClientInfo _client;
		private AcceptSocket _socket;
		private List<TableInfo> _tables;
		private Dictionary<string, Dictionary<string, string>> _column_coments = new Dictionary<string, Dictionary<string, string>>();

		public CodeBuild(ClientInfo client, AcceptSocket socket) {
			_client = client;
			_socket = socket;
		}

		private DataSet GetDataSet(string commandText) {
			SocketMessager messager = new SocketMessager("ExecuteDataSet", commandText);
			_socket.Write(messager, delegate(object sender, ServerSocketReceiveEventArgs e) {
				messager = e.Messager;
			});
			return messager.Arg as DataSet;
		}
		private int ExecuteNonQuery(string commandText) {
			SocketMessager messager = new SocketMessager("ExecuteNonQuery", commandText);
			_socket.Write(messager, delegate(object sender, ServerSocketReceiveEventArgs e) {
				messager = e.Messager;
			});
			int val;
			int.TryParse(string.Concat(messager.Arg), out val);
			return val;
		}

		public List<DatabaseInfo> GetDatabases() {
			Logger.remotor.Info("GetDatabases: " + _client.Server + "," + _client.Username + "," + _client.Password);

			List<DatabaseInfo> loc1 = null;

			DataSet ds = this.GetDataSet(@"select datname from pg_database where datname not in ('template1', 'template0')");
			if (ds == null) return loc1;

			loc1 = new List<DatabaseInfo>();
			foreach (DataRow row in ds.Tables[0].Rows) {
				loc1.Add(new DatabaseInfo(string.Concat(row[0])));
			}
			return loc1;
		}

		public List<TableInfo> GetTablesByDatabase(string database) {
			_client.Database = database;
			Logger.remotor.Info("GetTablesByDatabase: " + _client.Server + "," + _client.Username + "," + _client.Password + "," + _client.Database);

			List<TableInfo> loc1 = _tables = null;
			Dictionary<string, TableInfo> loc2 = new Dictionary<string, TableInfo>();
			Dictionary<string, Dictionary<string, ColumnInfo>> loc3 = new Dictionary<string, Dictionary<string, ColumnInfo>>();

			DataSet ds = this.GetDataSet(string.Format(@"
select
b.nspname || '.' || a.tablename,
a.schemaname,
a.tablename ,
'T'
from pg_tables a
inner join pg_namespace b on b.nspname = a.schemaname
where a.schemaname not in ('pg_catalog', 'information_schema')

union all

select
b.nspname || '.' || a.relname,
b.nspname,
a.relname,
'V'
from pg_class a
inner join pg_namespace b on b.oid = a.relnamespace
where b.nspname not in ('pg_catalog', 'information_schema') and a.relkind in ('m','v')
"));
			if (ds == null) return loc1;

			List<string> loc6 = new List<string>();
			List<string> loc66 = new List<string>();
			foreach (DataRow row in ds.Tables[0].Rows) {
				string table_id = string.Concat(row[0]);
				string owner = string.Concat(row[1]);
				string table = string.Concat(row[2]);
				string type = string.Concat(row[3]);
				loc2.Add(table_id, new TableInfo(table_id, owner, table, type));
				loc3.Add(table_id, new Dictionary<string, ColumnInfo>());
				switch (type) {
					case "V":
					case "T":
						loc6.Add(table_id.Replace("'", "''"));
						break;
					case "P":
						loc66.Add(table_id.Replace("'", "''"));
						break;
				}
			}
			if (loc6.Count == 0) return loc1;
			string loc8 = "'" + string.Join("','", loc6.ToArray()) + "'";
			string loc88 = "'" + string.Join("','", loc66.ToArray()) + "'";

			ds = this.GetDataSet(string.Format(@"
select
ns.nspname || '.' || c.relname as id, 
a.attname,
t.typname,
case when a.atttypmod > 0 and a.atttypmod < 32767 then a.atttypmod - 4 else a.attlen end len,
case when t.typelem = 0 then t.typname else t2.typname end,
case when a.attnotnull then 0 else 1 end as is_nullable,
e.adsrc as is_identity,
--case when e.adsrc = 'nextval(''' || case when ns.nspname = 'public' then '' else ns.nspname || '.' end || c.relname || '_' || a.attname || '_seq''::regclass)' then 1 else 0 end as is_identity,
d.description as comment,
a.attndims,
case when t.typelem = 0 then t.typtype else t2.typtype end,
ns2.nspname,
a.attnum
from pg_class c
inner join pg_attribute a on a.attnum > 0 and a.attrelid = c.oid
inner join pg_type t on t.oid = a.atttypid
left join pg_type t2 on t2.oid = t.typelem
left join pg_description d on d.objoid = a.attrelid and d.objsubid = a.attnum
left join pg_attrdef e on e.adrelid = a.attrelid and e.adnum = a.attnum
inner join pg_namespace ns on ns.oid = c.relnamespace
inner join pg_namespace ns2 on ns2.oid = t.typnamespace
where ns.nspname || '.' || c.relname in ({0})
", loc8));
			if (ds == null) return loc1;

			foreach (DataRow row in ds.Tables[0].Rows) {
				string table_id = string.Concat(row[0]);
				string column = string.Concat(row[1]);
				string type = string.Concat(row[2]);
				long max_length = long.Parse(string.Concat(row[3]));
				string sqlType = string.Concat(row[4]);
				bool is_nullable = string.Concat(row[5]) == "1";
				//bool is_identity = string.Concat(row[6]) == "1";
				bool is_identity = string.Concat(row[6]).StartsWith(@"nextval('") && string.Concat(row[6]).EndsWith(@"_seq'::regclass)");
				string comment = string.Concat(row[7]);
				if (string.IsNullOrEmpty(comment)) comment = column;
				int attndims = int.Parse(string.Concat(row[8]));
				string typtype = string.Concat(row[9]);
				string owner = string.Concat(row[10]);
				int attnum = int.Parse(string.Concat(row[11]));
				switch (sqlType) {
					case "bool": case "name": case "bit": case "varbit": case "bpchar": case "varchar": case "bytea": case "text": case "uuid": break;
					default: max_length *= 8; break;
				}
				if (max_length <= 0) max_length = -1;
				if (type.StartsWith("_")) {
					type = type.Substring(1);
					if (attndims == 0) attndims++;
				}
				if (sqlType.StartsWith("_")) sqlType = sqlType.Substring(1);
				NpgsqlDbType dbtype = CodeBuild.GetDBType(type, typtype);
				string csType2 =
						dbtype == NpgsqlDbType.Composite ? UFString((owner == "public" ? sqlType : (owner + "_" + sqlType)) + "TYPE") :
						dbtype == NpgsqlDbType.Enum ? UFString((owner == "public" ? sqlType : (owner + "_" + sqlType)) + "ENUM") : sqlType;
				loc3[table_id].Add(column, new ColumnInfo(
					column, dbtype, max_length, csType2, CodeBuild.GetCSType(dbtype, attndims, csType2),
					DataSort.ASC, is_nullable, is_identity, false, false, attndims, attnum));
				if (!_column_coments.ContainsKey(table_id)) _column_coments.Add(table_id, new Dictionary<string, string>());
				if (!_column_coments[table_id].ContainsKey(column)) _column_coments[table_id].Add(column, comment);
				else _column_coments[table_id][column] = comment;
			}

			ds = this.GetDataSet(string.Format(@"
select
ns.nspname || '.' || d.relname as table_id, 
c.attname,
ns.nspname || '/' || d.relname || '/' || b.relname as index_id,
case when a.indisunique then 1 else 0 end IsUnique,
case when a.indisprimary then 1 else 0 end IsPrimary,
case when a.indisclustered then 0 else 1 end IsClustered,
0 IsDesc,
a.indkey,
c.attnum
from pg_index a
inner join pg_class b on b.oid = a.indexrelid
inner join pg_attribute c on c.attnum > 0 and c.attrelid = b.oid
inner join pg_namespace ns on ns.oid = b.relnamespace
inner join pg_class d on d.oid = a.indrelid
where ns.nspname || '.' || d.relname in ({0})
", loc8));
			if (ds == null) return loc1;

			Dictionary<string, Dictionary<string, List<ColumnInfo>>> indexColumns = new Dictionary<string, Dictionary<string, List<ColumnInfo>>>();
			Dictionary<string, Dictionary<string, List<ColumnInfo>>> uniqueColumns = new Dictionary<string, Dictionary<string, List<ColumnInfo>>>();
			foreach (DataRow row in ds.Tables[0].Rows) {
				string table_id = string.Concat(row[0]);
				string column = string.Concat(row[1]);
				string index_id = string.Concat(row[2]);
				bool is_unique = string.Concat(row[3]) == "1";
				bool is_primary_key = string.Concat(row[4]) == "1";
				bool is_clustered = string.Concat(row[5]) == "1";
				int is_desc = int.Parse(string.Concat(row[6]));
				string[] inkey = string.Concat(row[7]).Split(' ');
				int attnum = int.Parse(string.Concat(row[8]));
				attnum = int.Parse(inkey[attnum - 1]);
				foreach(string tc in loc3[table_id].Keys) {
					if (loc3[table_id][tc].Attnum == attnum) {
						column = tc;
						break;
					}
				}
				ColumnInfo loc9 = loc3[table_id][column];
				if (loc9.IsClustered == false && is_clustered) loc9.IsClustered = is_clustered;
				if (loc9.IsPrimaryKey == false && is_primary_key) loc9.IsPrimaryKey = is_primary_key;
				if (loc9.Orderby == DataSort.NONE) loc9.Orderby = (DataSort)is_desc;

				Dictionary<string, List<ColumnInfo>> loc10 = null;
				List<ColumnInfo> loc11 = null;
				if (!indexColumns.TryGetValue(table_id, out loc10)) {
					indexColumns.Add(table_id, loc10 = new Dictionary<string, List<ColumnInfo>>());
				}
				if (!loc10.TryGetValue(index_id, out loc11)) {
					loc10.Add(index_id, loc11 = new List<ColumnInfo>());
				}
				loc11.Add(loc9);
				if (is_unique) {
					if (!uniqueColumns.TryGetValue(table_id, out loc10)) {
						uniqueColumns.Add(table_id, loc10 = new Dictionary<string, List<ColumnInfo>>());
					}
					if (!loc10.TryGetValue(index_id, out loc11)) {
						loc10.Add(index_id, loc11 = new List<ColumnInfo>());
					}
					loc11.Add(loc9);
				}
			}
			foreach (string table_id in indexColumns.Keys) {
				foreach (List<ColumnInfo> columns in indexColumns[table_id].Values) {
					loc2[table_id].Indexes.Add(columns);
				}
			}
			foreach (string table_id in uniqueColumns.Keys) {
				foreach (List<ColumnInfo> columns in uniqueColumns[table_id].Values) {
					columns.Sort(delegate(ColumnInfo c1, ColumnInfo c2) {
						return c1.Name.CompareTo(c2.Name);
					});
					loc2[table_id].Uniques.Add(columns);
				}
			}
			ds = this.GetDataSet(string.Format(@"
select
ns.nspname || '.' || b.relname as table_id, 
array(select attname from pg_attribute where attrelid = a.conrelid and attnum = any(a.conkey)) as column_name,
a.connamespace || '/' || a.conname as FKId,
ns2.nspname || '.' || c.relname as ref_table_id, 
1 as IsForeignKey,
array(select attname from pg_attribute where attrelid = a.confrelid and attnum = any(a.confkey)) as ref_column,
null ref_sln,
null ref_table
from  pg_constraint a
inner join pg_class b on b.oid = a.conrelid
inner join pg_class c on c.oid = a.confrelid
inner join pg_namespace ns on ns.oid = b.relnamespace
inner join pg_namespace ns2 on ns2.oid = c.relnamespace
where ns.nspname || '.' || b.relname in ({0})
", loc8));
			if (ds == null) return loc1;

			Dictionary<string, Dictionary<string, ForeignKeyInfo>> fkColumns = new Dictionary<string, Dictionary<string, ForeignKeyInfo>>();
			foreach (DataRow row in ds.Tables[0].Rows) {
				string table_id = string.Concat(row[0]);
				string[] column = row[1] as string[];
				string fk_id = string.Concat(row[2]);
				string ref_table_id = string.Concat(row[3]);
				bool is_foreign_key = string.Concat(row[4]) == "1";
				string[] referenced_column = row[5] as string[];
				string referenced_db = string.Concat(row[6]);
				string referenced_table = string.Concat(row[7]);
				TableInfo loc10 = null;
				ColumnInfo loc11 = null;
				bool isThisSln = !string.IsNullOrEmpty(ref_table_id);

				if (isThisSln) {
					if (loc2.ContainsKey(ref_table_id) == false) continue;
					loc10 = loc2[ref_table_id];
					loc11 = loc3[ref_table_id][referenced_column[0]];
				} else {

				}
				Dictionary<string, ForeignKeyInfo> loc12 = null;
				ForeignKeyInfo loc13 = null;
				if (!fkColumns.TryGetValue(table_id, out loc12)) {
					fkColumns.Add(table_id, loc12 = new Dictionary<string, ForeignKeyInfo>());
				}
				if (!loc12.TryGetValue(fk_id, out loc13)) {
					if (isThisSln) {
						loc13 = new ForeignKeyInfo(loc2[table_id], loc10);
					} else {
						loc13 = new ForeignKeyInfo(referenced_db, referenced_table, is_foreign_key);
					}
					loc12.Add(fk_id, loc13);
				}
				for (int a = 0; a < column.Length; a++) {
					loc13.Columns.Add(loc3[table_id][column[a]]);

					if (isThisSln)
						loc13.ReferencedColumns.Add(loc3[ref_table_id][referenced_column[a]]);
					else
						loc13.ReferencedColumnNames.Add(referenced_column[a]);
				}
			}
			foreach (string table_id in fkColumns.Keys) {
				foreach (ForeignKeyInfo fk in fkColumns[table_id].Values) {
					loc2[table_id].ForeignKeys.Add(fk);
				}
			}

			foreach (string table_id in loc3.Keys) {
				foreach (ColumnInfo loc5 in loc3[table_id].Values) {
					loc2[table_id].Columns.Add(loc5);
					if (loc5.IsIdentity) {
						loc2[table_id].Identitys.Add(loc5);
					}
					if (loc5.IsClustered) {
						loc2[table_id].Clustereds.Add(loc5);
					}
					if (loc5.IsPrimaryKey) {
						loc2[table_id].PrimaryKeys.Add(loc5);
					}
				}
			}
			loc1 = _tables = new List<TableInfo>();
			foreach (TableInfo loc4 in loc2.Values) {
				if (loc4.PrimaryKeys.Count == 0 && loc4.Uniques.Count > 0) {
					foreach (ColumnInfo loc5 in loc4.Uniques[0]) {
						loc5.IsPrimaryKey = true;
						loc4.PrimaryKeys.Add(loc5);
					}
				}
				this.Sort(loc4);
				loc1.Add(loc4);
			}
			loc1.Sort(delegate (TableInfo t1, TableInfo t2) {
				return t1.FullName.CompareTo(t2.FullName);
			});

			loc2.Clear();
			loc3.Clear();
			return loc1;
		}

		protected virtual void Sort(TableInfo table) {
			table.PrimaryKeys.Sort(delegate (ColumnInfo c1, ColumnInfo c2) {
				return c1.Name.CompareTo(c2.Name);
			});
			table.Columns.Sort(delegate(ColumnInfo c1, ColumnInfo c2) {
				int compare = c2.IsPrimaryKey.CompareTo(c1.IsPrimaryKey);
				if (compare == 0) {
					bool b1 = table.ForeignKeys.Find(delegate(ForeignKeyInfo fk) {
						return fk.Columns.Find(delegate(ColumnInfo c3) {
							return c3.Name == c1.Name;
						}) != null;
					}) != null;
					bool b2 = table.ForeignKeys.Find(delegate(ForeignKeyInfo fk) {
						return fk.Columns.Find(delegate(ColumnInfo c3) {
							return c3.Name == c2.Name;
						}) != null;
					}) != null;
					compare = b2.CompareTo(b1);
				}
				if (compare == 0) compare = c1.Name.CompareTo(c2.Name);
				return compare;
			});
		}

		#region IDisposable ≥…‘±

		public void Dispose() {
			if (_tables != null) {
				_tables.Clear();
			}
		}

		#endregion
	}
}
