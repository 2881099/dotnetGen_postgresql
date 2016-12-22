using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Npgsql;
using NpgsqlTypes;

namespace Newtonsoft.Json {
	public class NpgsqlTypesConverter : JsonConverter {
		private static readonly Type typeof_BitArray = typeof(BitArray);

		private static readonly Type typeof_NpgsqlPoint = typeof(NpgsqlPoint);
		private static readonly Type typeof_NpgsqlLine = typeof(NpgsqlLine);
		private static readonly Type typeof_NpgsqlLSeg = typeof(NpgsqlLSeg);
		private static readonly Type typeof_NpgsqlBox = typeof(NpgsqlBox);
		private static readonly Type typeof_NpgsqlPath = typeof(NpgsqlPath);
		private static readonly Type typeof_NpgsqlPolygon = typeof(NpgsqlPolygon);
		private static readonly Type typeof_NpgsqlCircle = typeof(NpgsqlCircle);

		private static readonly Type typeof_NpgsqlInet = typeof(NpgsqlInet);
		private static readonly Type typeof_IPAddress = typeof(IPAddress);
		private static readonly Type typeof_PhysicalAddress = typeof(PhysicalAddress);

		private static readonly Type typeof_String = typeof(string);

		private static readonly Type typeof_NpgsqlRange_int = typeof(NpgsqlRange<int>);
		private static readonly Type typeof_NpgsqlRange_long = typeof(NpgsqlRange<long>);
		private static readonly Type typeof_NpgsqlRange_decimal = typeof(NpgsqlRange<decimal>);
		private static readonly Type typeof_NpgsqlRange_DateTime = typeof(NpgsqlRange<DateTime>);
		public override bool CanConvert(Type objectType) {
			Type ctype = objectType.IsArray ? objectType.GetElementType() : objectType;

			if (ctype == typeof_BitArray) return true;

			if (ctype == typeof_NpgsqlPoint) return true;
			if (ctype == typeof_NpgsqlLine) return true;
			if (ctype == typeof_NpgsqlLSeg) return true;
			if (ctype == typeof_NpgsqlBox) return true;
			if (ctype == typeof_NpgsqlPath) return true;
			if (ctype == typeof_NpgsqlPolygon) return true;
			if (ctype == typeof_NpgsqlCircle) return true;

			if (ctype == typeof_NpgsqlInet) return true;
			if (ctype == typeof_IPAddress) return true;
			if (ctype == typeof_PhysicalAddress) return true;

			if (ctype == typeof_NpgsqlRange_int) return true;
			if (ctype == typeof_NpgsqlRange_long) return true;
			if (ctype == typeof_NpgsqlRange_decimal) return true;
			if (ctype == typeof_NpgsqlRange_DateTime) return true;

			return false;
		}
		private object YieldJToken(Type ctype, JToken jt, int rank) {
			if (rank == 0) {
				if (ctype == typeof_BitArray) return Executer.Parse1010(jt.ToString());

				if (ctype == typeof_NpgsqlPoint) return NpgsqlPoint.Parse(jt.ToString());
				if (ctype == typeof_NpgsqlLine) return NpgsqlLine.Parse(jt.ToString());
				if (ctype == typeof_NpgsqlLSeg) return NpgsqlLSeg.Parse(jt.ToString());
				if (ctype == typeof_NpgsqlBox) return NpgsqlBox.Parse(jt.ToString());
				if (ctype == typeof_NpgsqlPath) return NpgsqlPath.Parse(jt.ToString());
				if (ctype == typeof_NpgsqlPolygon) return NpgsqlPolygon.Parse(jt.ToString());
				if (ctype == typeof_NpgsqlCircle) return NpgsqlCircle.Parse(jt.ToString());

				if (ctype == typeof_NpgsqlInet) return new NpgsqlInet(jt.ToString());
				if (ctype == typeof_IPAddress) return new NpgsqlInet(jt.ToString());
				if (ctype == typeof_PhysicalAddress) return PhysicalAddress.Parse(jt.ToString());

				if (ctype == typeof_NpgsqlRange_int) return Executer.ParseNpgsqlRange<int>(jt.ToString());
				if (ctype == typeof_NpgsqlRange_long) return Executer.ParseNpgsqlRange<long>(jt.ToString());
				if (ctype == typeof_NpgsqlRange_decimal) return Executer.ParseNpgsqlRange<decimal>(jt.ToString());
				if (ctype == typeof_NpgsqlRange_DateTime) return Executer.ParseNpgsqlRange<DateTime>(jt.ToString());

				return null;
			}
			return jt.Select<JToken, object>(a => YieldJToken(ctype, a, rank - 1));
		}
		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) {
			int rank = objectType.IsArray ? objectType.GetArrayRank() : 0;
			Type ctype = objectType.IsArray ? objectType.GetElementType() : objectType;

			return YieldJToken(ctype, JToken.Load(reader), rank);
		}
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {
			Type objectType = value.GetType();
			if (objectType.IsArray) {
				int rank = objectType.GetArrayRank();
				int[] indices = new int[rank];
				GetJObject(value as Array, indices, 0).WriteTo(writer);
			} else
				GetJObject(value).WriteTo(writer);
		}
		public static JToken GetJObject(object value) {
			if (value is BitArray) return JToken.FromObject((value as BitArray).To1010());
			return JToken.FromObject(value.ToString());
		}
		public static JToken GetJObject(Array value, int[] indices, int idx) {
			if (idx == indices.Length) {
				return GetJObject(value.GetValue(indices));
			}
			JArray ja = new JArray();
			if (indices.Length == 1) {
				foreach(object a in value)
					ja.Add(GetJObject(a));
				return ja;
			}
			int lb = value.GetLowerBound(idx);
			int ub = value.GetUpperBound(idx);
			for (int b = lb; b <= ub; b++) {
				indices[idx] = b;
				ja.Add(GetJObject(value, indices, idx + 1));
			}
			return ja;
		}
	}
}