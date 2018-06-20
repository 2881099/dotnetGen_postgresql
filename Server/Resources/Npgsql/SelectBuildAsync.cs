using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Threading.Tasks;

namespace Npgsql {
	partial class SelectBuild<TReturnInfo> {
		async public Task<List<TReturnInfo>> ToListAsync(int expireSeconds, string cacheKey = null) {
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
			return await CSRedis.QuickHelperBase.CacheAsync(cacheKey, expireSeconds, async () => {
				List<TReturnInfo> ret = new List<TReturnInfo>();
				if (string.IsNullOrEmpty(sql)) sql = this.ToString();
				await _exec.ExecuteReaderAsync(async dr => {
					int dataIndex = -1;
					if (!string.IsNullOrEmpty(_distinctOnFields)) ++dataIndex;
					var read = await _dals[0].GetItemAsync(dr, dataIndex);
					TReturnInfo info = (TReturnInfo) read.result;
					dataIndex = read.dataIndex;
					Type type = info.GetType();
					ret.Add(info);
					if (cacheList != null) cacheList.Add(type.GetMethod("Stringify").Invoke(info, null));
					for (int b = 0; b < objNames.Length; b++) {
						var read2 = await _dals[b + 1].GetItemAsync(dr, dataIndex);
						object obj = read2.result;
						dataIndex = read2.dataIndex;
						PropertyInfo prop = type.GetProperty(objNames[b]);
						if (prop == null) throw new Exception(string.Concat(type.FullName, " 没有定义属性 ", objNames[b]));
						if (obj == null) prop.SetValue(info, obj, null);
						if (cacheList != null) cacheList.Add(obj?.GetType().GetMethod("Stringify").Invoke(obj, null));
					}
					int dataCount = dr.FieldCount;
					object[] overValue = new object[dataCount - dataIndex - 1];
					for (var a = 0; a < overValue.Length; a++) overValue[a] = await dr.IsDBNullAsync(++dataIndex) ? null : await dr.GetFieldValueAsync<object>(dataIndex);
					if (overValue.Length > 0) type.GetProperty("OverValue")?.SetValue(info, overValue, null);
				}, CommandType.Text, sql, _params.ToArray());
				return ret;
			}, list => JsonConvert.SerializeObject(cacheList), cacheValue => ToListDeserialize(cacheKey, objNames));
		}
		async public Task<List<TReturnInfo>> ToListAsync() {
			return await this.ToListAsync(0);
		}
		async public Task<TReturnInfo> ToOneAsync() {
			List<TReturnInfo> ret = await this.Limit(1).ToListAsync();
			return ret.Count > 0 ? ret[0] : default(TReturnInfo);
		}
		/// <summary>
		/// 查询指定字段，返回元组或单值
		/// </summary>
		/// <typeparam name="T">元组或单值，如：.Aggregate&lt;(int id, string name)&gt;("id,title")，或 .Aggregate&lt;int&gt;("id")</typeparam>
		/// <param name="field">返回的字段，用逗号分隔，如：id,name</param>
		/// <returns></returns>
		async public Task<List<T>> AggregateAsync<T>(string fields, params object[] parms) {
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

			await _exec.ExecuteReaderAsync(async dr => {
				int dataIndex = -1;
				if (!string.IsNullOrEmpty(_distinctOnFields)) ++dataIndex;
				var read = await this.AggregateReadTupleAsync(type, dr, dataIndex);
				ret.Add(read.result == null ? default(T) : (T)read.result);
				dataIndex = read.dataIndex;
			}, CommandType.Text, sql, _params.ToArray());
			return ret;
		}
		async public Task<T> AggregateScalarAsync<T>(string field, params object[] parms) {
			var items = await this.AggregateAsync<T>(field, parms);
			return items.Count > 0 ? items[0] : default(T);
		}
		async private Task<(object result, int dataIndex)> AggregateReadTupleAsync(Type type, NpgsqlDataReader dr, int dataIndex) {
			bool isTuple = type.Namespace == "System" && type.Name.StartsWith("ValueTuple`");
			if (isTuple) {
				FieldInfo[] fs = type.GetFields();
				Type[] types = new Type[fs.Length];
				object[] parms = new object[fs.Length];
				for (int a = 0; a < fs.Length; a++) {
					types[a] = fs[a].FieldType;
					var read = await this.AggregateReadTupleAsync(types[a], dr, dataIndex);
					parms[a] = read.result;
					dataIndex = read.dataIndex;
				}
				ConstructorInfo constructor = type.GetConstructor(types);
				return (constructor.Invoke(parms), dataIndex);
			}
			return (await dr.IsDBNullAsync(++dataIndex) ? null : await dr.GetFieldValueAsync<object>(dataIndex), dataIndex);
		}
		async public Task<long> CountAsync() {
			return await this.AggregateScalarAsync<long>("count(1)");
		}
	}
}