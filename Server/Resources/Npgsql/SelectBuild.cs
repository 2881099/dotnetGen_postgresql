using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Npgsql {
	public partial interface IDAL {
		string Table { get; }
		string Field { get; }
		string Sort { get; }
		object GetItem(NpgsqlDataReader dr, ref int index);
		Task<(object result, int dataIndex)> GetItemAsync(NpgsqlDataReader dr, int index);
	}
	public class SelectBuild<TReturnInfo, TLinket> : SelectBuild<TReturnInfo> where TLinket : SelectBuild<TReturnInfo> {
		protected TLinket Where1Or(string filterFormat, Array values) {
			if (values == null) values = new object[] { null };
			if (values.Length == 0) return this as TLinket;
			if (values.Length == 1) return base.Where(filterFormat, values.GetValue(0)) as TLinket;
			string filter = string.Empty;
			for (int a = 0; a < values.Length; a++) filter = string.Concat(filter, " OR ", string.Format(filterFormat, "{" + a + "}"));
			object[] parms = new object[values.Length];
			values.CopyTo(parms, 0);
			return base.Where(filter.Substring(4), parms) as TLinket;
		}
		public new TLinket Count(out long count) => base.Count(out count) as TLinket;
		public new TLinket Where(string filter, params object[] parms) => base.Where(true, filter, parms) as TLinket;
		public new TLinket Where(bool isadd, string filter, params object[] parms) => base.Where(isadd, filter, parms) as TLinket;
		public TLinket WhereExists<T>(SelectBuild<T> select, bool isNotExists = false) => this.Where((isNotExists ? "NOT " : "") + $"EXISTS({select.ToString("1")})") as TLinket;
		public new TLinket GroupBy(string groupby) => base.GroupBy(groupby) as TLinket;
		public new TLinket Having(string filter, params object[] parms) => base.Having(true, filter, parms) as TLinket;
		public new TLinket Having(bool isadd, string filter, params object[] parms) => base.Having(isadd, filter, parms) as TLinket;
		public new TLinket Sort(string orderby, params object[] parms) => base.Sort(orderby, parms) as TLinket;
		public new TLinket OrderBy(string orderby, params object[] parms) => base.Sort(orderby, parms) as TLinket;
		/// <summary>
		/// 窗口函数原型：@field OVER(PARTITION BY @partitionBy ORDER BY @orderby)
		/// </summary>
		/// <param name="field">如：rank()、avg(xx)、sum(xxx)等聚合函数，传null会清除链式累积的over</param>
		/// <param name="partitionBy">如：表字段 xxx</param>
		/// <param name="orderby">如：表字段 xxx DESC</param>
		/// <returns></returns>
		public new TLinket Over(string field, string partitionBy, string orderby) => base.Over(field, partitionBy, orderby) as TLinket;
		/// <summary>
		/// pgsql特性：只保留在给定表达式上计算相等的行集合中的第一行
		/// </summary>
		/// <param name="fields">expression [, ...]</param>
		/// <param name="orderby">DISTINCT ON表达式必须匹配最左边的 ORDER BY表达式</param>
		/// <returns></returns>
		public new TLinket DistinctOn(string fields, string orderby = null) => base.DistinctOn(fields, orderby) as TLinket;
		public new TLinket From<TBLL>() => base.From<TBLL>() as TLinket;
		public new TLinket From<TBLL>(string alias) => base.From<TBLL>(alias) as TLinket;
		public new TLinket As(string alias) => base.As(alias) as TLinket;
		public new TLinket InnerJoin<TBLL>(string alias, string on) => base.InnerJoin<TBLL>(alias, on) as TLinket;
		public new TLinket LeftJoin<TBLL>(string alias, string on) => base.LeftJoin<TBLL>(alias, on) as TLinket;
		public new TLinket RightJoin<TBLL>(string alias, string on) => base.RightJoin<TBLL>(alias, on) as TLinket;
		public new TLinket Skip(int skip) => base.Skip(skip) as TLinket;
		public new TLinket Limit(int limit) => base.Limit(limit) as TLinket;
		public new TLinket Take(int limit) => base.Limit(limit) as TLinket;
		public new TLinket Page(int pageIndex, int pageSize) => base.Page(pageIndex, pageSize) as TLinket;
		public SelectBuild(IDAL dal, Executer exec) : base(dal, exec) { }
	}
	public partial class SelectBuild<TReturnInfo> {
		protected int _limit, _skip;
		protected string _orderby, _field, _table, _join, _where, _groupby, _having, _distinctOnFields, _distinctOnOrderby, _overField, _overWindow;
		protected List<NpgsqlParameter> _params = new List<NpgsqlParameter>();
		protected List<IDAL> _dals = new List<IDAL>();
		protected Executer _exec;
		public List<TReturnInfo> ToList(int expireSeconds, string cacheKey = null) {
			string sql = null;
			string[] objNames = new string[_dals.Count - 1];
			for (int b = 1; b < _dals.Count; b++) {
				string name = _dals[b].GetType().Name;
				objNames[b - 1] = string.Concat("Obj_", name[0].ToString().ToLower(), name.Substring(1));
			}
			if (string.IsNullOrEmpty(cacheKey)) {
				sql = this.ToString();
				cacheKey = sql.Substring(sql.IndexOf(" \r\nFROM ") + 8);
			}
			List<object> cacheList = expireSeconds > 0 ? new List<object>() : null;
			return CSRedis.QuickHelperBase.Cache(cacheKey, expireSeconds, () => {
				List<TReturnInfo> ret = new List<TReturnInfo>();
				if (string.IsNullOrEmpty(sql)) sql = this.ToString();
				_exec.ExecuteReader(dr => {
					int dataIndex = -1;
					if (!string.IsNullOrEmpty(_distinctOnFields)) ++dataIndex;
					TReturnInfo info = (TReturnInfo) _dals[0].GetItem(dr, ref dataIndex);
					Type type = info.GetType();
					ret.Add(info);
					if (cacheList != null) cacheList.Add(type.GetMethod("Stringify").Invoke(info, null));
					for (int b = 0; b < objNames.Length; b++) {
						object obj = _dals[b + 1].GetItem(dr, ref dataIndex);
						PropertyInfo prop = type.GetProperty(objNames[b]);
						if (prop == null) throw new Exception(string.Concat(type.FullName, " 没有定义属性 ", objNames[b]));
						if (obj != null) prop.SetValue(info, obj, null);
						if (cacheList != null) cacheList.Add(obj?.GetType().GetMethod("Stringify").Invoke(obj, null));
					}
					int dataCount = dr.FieldCount;
					object[] overValue = new object[dataCount - dataIndex - 1];
					for (var a = 0; a < overValue.Length; a++) overValue[a] = dr.IsDBNull(++dataIndex) ? null : dr.GetValue(dataIndex);
					if (overValue.Length > 0) type.GetProperty("OverValue")?.SetValue(info, overValue, null);
				}, CommandType.Text, sql, _params.ToArray());

				return ret;
			}, list => JsonConvert.SerializeObject(cacheList), cacheValue => ToListDeserialize(cacheKey, objNames));
		}
		private List<TReturnInfo> ToListDeserialize(string cacheValue, string[] objNames) {
			List<TReturnInfo> ret = new List<TReturnInfo>();
			MethodInfo[] parses = new MethodInfo[_dals.Count];
			for (int b = 0; b < _dals.Count; b++) {
				string modelTypeName = string.Concat(_dals[b].GetType().FullName.Replace(".DAL.", ".Model."), "Info");
				parses[b] = this.GetType().GetTypeInfo().Assembly.GetType(modelTypeName).GetMethod("Parse", new Type[] { typeof(string) });
			}
			string[] vs = JsonConvert.DeserializeObject<string[]>(cacheValue);
			for (int a = 0, skip = objNames.Length + 1; a < vs.Length; a += skip) {
				TReturnInfo info = (TReturnInfo) parses[0].Invoke(null, new object[] { vs[a] });
				if (info == null) continue;
				Type type = info.GetType();
				for (int b = 1; b < parses.Length; b++) {
					object item = parses[b].Invoke(null, new object[] { vs[a + b] });
					if (item == null) continue;
					PropertyInfo prop = type.GetProperty(objNames[b - 1]);
					if (prop != null) prop.SetValue(info, item, null);
				}
				ret.Add(info);
			}
			return ret;
		}
		public List<TReturnInfo> ToList() {
			return this.ToList(0);
		}
		public TReturnInfo ToOne() {
			List<TReturnInfo> ret = this.Limit(1).ToList();
			return ret.Count > 0 ? ret[0] : default(TReturnInfo);
		}
		public override string ToString() => this.ToString(null);
		public string ToString(string field) {
			if (string.IsNullOrEmpty(_orderby) && _skip > 0) this.Sort(_dals[0].Sort);
			string limit = string.Concat(_limit > 0 ? string.Format(" \r\nlimit {0}", _limit) : string.Empty, _skip > 0 ? string.Format(" \r\noffset {0}", _skip) : string.Empty);
			string where = string.IsNullOrEmpty(_where) ? string.Empty : string.Concat(" \r\nWHERE ", _where.Substring(5));
			string sql = string.Concat("SELECT ",
				string.IsNullOrEmpty(_distinctOnFields) ? string.Empty : $"DISTINCT ON ({_distinctOnFields}) null as dgsbdo639, {_field}",
				field ?? _field, _overField, _table, _join, _overWindow, where,
				string.IsNullOrEmpty(_distinctOnOrderby) ? _orderby : string.Concat(" \r\nORDER BY ", _distinctOnOrderby, ", ", _orderby.Substring(12)),
				limit);
			return sql;
		}
		/// <summary>
		/// 查询指定字段，返回元组或单值
		/// </summary>
		/// <typeparam name="T">元组或单值，如：.Aggregate&lt;(int id, string name)&gt;("id,title")，或 .Aggregate&lt;int&gt;("id")</typeparam>
		/// <param name="field">返回的字段，用逗号分隔，如：id,name</param>
		/// <returns></returns>
		public List<T> Aggregate<T>(string fields, params object[] parms) {
			string limit = string.Concat(_limit > 0 ? string.Format(" \r\nlimit {0}", _limit) : string.Empty, _skip > 0 ? string.Format(" \r\noffset {0}", _skip) : string.Empty);
			string where = string.IsNullOrEmpty(_where) ? string.Empty : string.Concat(" \r\nWHERE ", _where.Substring(5));
			string having = string.IsNullOrEmpty(_groupby) ||
							string.IsNullOrEmpty(_having) ? string.Empty : string.Concat(" \r\nHAVING ", _having.Substring(5));
			string sql = string.Concat("SELECT ",
				string.IsNullOrEmpty(_distinctOnFields) ? string.Empty : $"DISTINCT ON ({_distinctOnFields}) null as dgsbdo639, {_field}",
				this.ParseCondi(fields, parms), _overField, _table, _join, _overWindow, where, _groupby, having,
				string.IsNullOrEmpty(_distinctOnOrderby) ? _orderby : string.Concat(" \r\nORDER BY ", _distinctOnOrderby, ", ", _orderby.Substring(12)),
				limit);

			List<T> ret = new List<T>();
			Type type = typeof(T);

			_exec.ExecuteReader(dr => {
				int dataIndex = -1;
				if (!string.IsNullOrEmpty(_distinctOnFields)) ++dataIndex;
				var read = this.AggregateReadTuple(type, dr, ref dataIndex);
				ret.Add(read == null ? default(T) : (T) read);
			}, CommandType.Text, sql, _params.ToArray());
			return ret;
		}
		public T AggregateScalar<T>(string field, params object[] parms) {
			var items = this.Aggregate<T>(field, parms);
			return items.Count > 0 ? items[0] : default(T);
		}
		protected object AggregateReadTuple(Type type, NpgsqlDataReader dr, ref int dataIndex) {
			bool isTuple = type.Namespace == "System" && type.Name.StartsWith("ValueTuple`");
			if (isTuple) {
				FieldInfo[] fs = type.GetFields();
				Type[] types = new Type[fs.Length];
				object[] parms = new object[fs.Length];
				for (int a = 0; a < fs.Length; a++) {
					types[a] = fs[a].FieldType;
					parms[a] = this.AggregateReadTuple(types[a], dr, ref dataIndex);
				}
				ConstructorInfo constructor = type.GetConstructor(types);
				return constructor.Invoke(parms);
			}
			return dr.IsDBNull(++dataIndex) ? null : dr.GetValue(dataIndex);
		}
		public long Count() {
			return this.AggregateScalar<long>("count(1)");
		}
		protected SelectBuild<TReturnInfo> Count(out long count) {
			count = this.Count();
			return this;
		}
		public static SelectBuild<TReturnInfo> From(IDAL dal, Executer exec) {
			return new SelectBuild<TReturnInfo>(dal, exec);
		}
		int _fields_count = 0;
		string _mainAlias = "a";
		protected SelectBuild(IDAL dal, Executer exec) {
			_dals.Add(dal);
			_field = dal.Field;
			_table = string.Concat(" \r\nFROM ", dal.Table, " ", _mainAlias);
			_exec = exec;
		}
		protected SelectBuild<TReturnInfo> From<TBLL>() {
			return this.From<TBLL>(string.Empty);
		}
		protected SelectBuild<TReturnInfo> From<TBLL>(string alias) {
			IDAL dal = this.ConvertTBLL<TBLL>();
			_table = string.Concat(_table, ", ", dal.Table, " ", alias);
			return this;
		}
		protected SelectBuild<TReturnInfo> As(string alias) {
			string table = string.Concat(" \r\nFROM ", _dals.FirstOrDefault()?.Table, " ", _mainAlias);
			if (_table.StartsWith(table)) _table = string.Concat(table, _mainAlias = alias, _table.Substring(table.Length));
			return this;
		}
		protected IDAL ConvertTBLL<TBLL>() {
			string dalTypeName = typeof(TBLL).FullName.Replace(".BLL.", ".DAL.");
			IDAL dal = this.GetType().GetTypeInfo().Assembly.CreateInstance(dalTypeName) as IDAL;
			if (dal == null) throw new Exception(string.Concat("找不到类型 ", dalTypeName));
			return dal;
		}
		protected SelectBuild<TReturnInfo> Join<TBLL>(string alias, string on, string joinType) {
			IDAL dal = this.ConvertTBLL<TBLL>();
			_dals.Add(dal);
			string fields2 = dal.Field.Replace("a.", string.Concat(alias, "."));
			string[] names = fields2.Split(new string[] { ", " }, StringSplitOptions.None);
			for (int a = 0; a < names.Length; a++) {
				string ast = string.Concat(" as", ++_fields_count);
				names[a] = string.Concat(names[a], ast);
			}
			_field = string.Concat(_field, ", \r\n", string.Join(", ", names));
			_join = string.Concat(_join, " \r\n", joinType, " ", dal.Table, " ", alias, " ON ", on);
			return this;
		}
		protected SelectBuild<TReturnInfo> Where(string filter, params object[] parms) {
			return this.Where(true, filter, parms);
		}
		protected SelectBuild<TReturnInfo> Where(bool isadd, string filter, params object[] parms) {
			if (isadd) _where = string.Concat(_where, " AND (", this.ParseCondi(filter, parms), ")");
			return this;
		}
		protected string ParseCondi(string filter, params object[] parms) {
			if (string.IsNullOrEmpty(filter)) filter = "";
			//将参数 = null 转换成 IS NULL
			if (parms != null && parms.Length > 0) {
				for (int a = 0; a < parms.Length; a++)
					if (parms[a] == null)
						filter = Regex.Replace(filter, @"\s+=\s+\{" + a + @"\}", " IS {" + a + "}");
					else if (parms[a] is NpgsqlParameter) {
						var param = parms[a] as NpgsqlParameter;
						param.ParameterName = $"ParseCondiParam{_params.Count}";
						_params.Add(param);
						filter = filter.Replace($"{{{a}}}", $"@{param.ParameterName}");
					}
			}
			return Executer.Addslashes(filter, parms);
		}
		protected SelectBuild<TReturnInfo> GroupBy(string groupby) {
			_groupby = groupby;
			if (string.IsNullOrEmpty(_groupby)) return this;
			_groupby = string.Concat(" \r\nGROUP BY ", _groupby);
			return this;
		}
		protected SelectBuild<TReturnInfo> Having(string filter, params object[] parms) {
			return this.Having(true, filter, parms);
		}
		protected SelectBuild<TReturnInfo> Having(bool isadd, string filter, params object[] parms) {
			if (string.IsNullOrEmpty(_groupby)) return this;
			if (isadd) _having = string.Concat(_having, " AND (", this.ParseCondi(filter, parms), ")");
			return this;
		}
		protected SelectBuild<TReturnInfo> Sort(string orderby, params object[] parms) {
			if (string.IsNullOrEmpty(orderby)) _orderby = null;
			else {
				if (string.IsNullOrEmpty(_orderby)) _orderby = string.Concat(" \r\nORDER BY ", this.ParseCondi(orderby, parms));
				else _orderby = string.Concat(_orderby, ", ", this.ParseCondi(orderby, parms));
			}
			return this;
		}
		protected SelectBuild<TReturnInfo> OrderBy(string orderby, params object[] parms) {
			return this.Sort(orderby, parms);
		}
		protected SelectBuild<TReturnInfo> Over(string field, string partitionBy, string orderby) {
			if (string.IsNullOrEmpty(field)) {
				_overField = _overWindow = string.Empty;
				return this;
			}
			int dgsboverwd = _overWindow?.Length ?? 0;
			string win = $" \r\nWINDOW dgsboverwd{dgsboverwd} as (";
			if (!string.IsNullOrEmpty(partitionBy)) win = $"{win}PARTITION BY {partitionBy}";
			if (!string.IsNullOrEmpty(orderby)) win = $"{win} ORDER BY {orderby}";
			_overWindow = string.Concat(_overWindow, win, ")");
			_overField = $", {field} OVER dgsboverwd{dgsboverwd}";
			return this;
		}
		protected SelectBuild<TReturnInfo> DistinctOn(string fields, string orderby = null) {
			if (string.IsNullOrEmpty(fields)) return this;
			if (string.IsNullOrEmpty(orderby)) orderby = fields;
			_distinctOnFields = fields;
			_distinctOnOrderby = orderby;
			return this;
		}
		protected SelectBuild<TReturnInfo> InnerJoin<TBLL>(string alias, string on) {
			return this.Join<TBLL>(alias, on, "INNER JOIN");
		}
		protected SelectBuild<TReturnInfo> LeftJoin<TBLL>(string alias, string on) {
			return this.Join<TBLL>(alias, on, "LEFT JOIN");
		}
		protected SelectBuild<TReturnInfo> RightJoin<TBLL>(string alias, string on) {
			return this.Join<TBLL>(alias, on, "RIGHT JOIN");
		}
		protected SelectBuild<TReturnInfo> Skip(int skip) {
			_skip = skip;
			return this;
		}
		protected SelectBuild<TReturnInfo> Limit(int limit) {
			_limit = limit;
			return this;
		}
		protected SelectBuild<TReturnInfo> Take(int limit) {
			return this.Limit(limit);
		}
		protected SelectBuild<TReturnInfo> Page(int pageIndex, int pageSize) {
			return this.Skip(Math.Max(0, pageIndex - 1) * pageSize).Limit(pageSize);
		}
	}
}