using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Model;
using System.Collections;

namespace Server {

	internal partial class CodeBuild {
		protected NpgsqlDbType GetDBType(string strType, string typtype) {
			if (typtype == "c") return NpgsqlDbType.Composite;
			if (typtype == "e") return NpgsqlDbType.Enum;
			switch (strType.ToLower().TrimStart('_')) {
				case "int2": return NpgsqlDbType.Smallint;
				case "int4": return NpgsqlDbType.Integer;
				case "int8": return NpgsqlDbType.Bigint;
				case "numeric": return NpgsqlDbType.Numeric;
				case "float4": return NpgsqlDbType.Real;
				case "float8": return NpgsqlDbType.Double;
				case "money": return NpgsqlDbType.Money;

				case "bpchar": return NpgsqlDbType.Char;
				case "varchar": return NpgsqlDbType.Varchar;
				case "text": return NpgsqlDbType.Text;

				case "timestamp": return NpgsqlDbType.Timestamp;
				case "timestamptz": return NpgsqlDbType.TimestampTZ;
				case "date": return NpgsqlDbType.Date;
				case "time": return NpgsqlDbType.Time;
				case "timetz": return NpgsqlDbType.TimeTZ;
				case "interval": return NpgsqlDbType.Interval;

				case "bool": return NpgsqlDbType.Boolean;
				case "bytea": return NpgsqlDbType.Bytea;
				case "bit": return NpgsqlDbType.Bit;
				case "varbit": return NpgsqlDbType.Varbit;

				case "point": return NpgsqlDbType.Point;
				case "line": return NpgsqlDbType.Line;
				case "lseg": return NpgsqlDbType.LSeg;
				case "box": return NpgsqlDbType.Box;
				case "path": return NpgsqlDbType.Path;
				case "polygon": return NpgsqlDbType.Polygon;
				case "circle": return NpgsqlDbType.Circle;

				case "cidr": return NpgsqlDbType.Cidr;
				case "inet": return NpgsqlDbType.Inet;
				case "macaddr": return NpgsqlDbType.MacAddr;

				case "json": return NpgsqlDbType.Json;
				case "jsonb": return NpgsqlDbType.Jsonb;
				case "uuid": return NpgsqlDbType.Uuid;

				case "int4range": return NpgsqlDbType.IntegerRange;
				case "int8range": return NpgsqlDbType.BigintRange;
				case "numrange": return NpgsqlDbType.NumericRange;
				case "tsrange": return NpgsqlDbType.TimestampRange;
				case "tstzrange": return NpgsqlDbType.TimestampTZRange;
				case "daterange": return NpgsqlDbType.DateRange;

				case "hstore": return NpgsqlDbType.Hstore;
				case "geometry": return NpgsqlDbType.Geometry;
				default: return NpgsqlDbType.Unknown;
			}
		}

		protected string GetCSTypeValue(NpgsqlDbType type) {
			switch (type) {
				case NpgsqlDbType.Smallint: 
				case NpgsqlDbType.Integer: 
				case NpgsqlDbType.Bigint: 
				case NpgsqlDbType.Numeric:
				case NpgsqlDbType.Real:
				case NpgsqlDbType.Double:
				case NpgsqlDbType.Money: return "{0}.Value";

				case NpgsqlDbType.Char:
				case NpgsqlDbType.Varchar:
				case NpgsqlDbType.Text: return "{0}";

				case NpgsqlDbType.Timestamp:
				case NpgsqlDbType.TimestampTZ:
				case NpgsqlDbType.Date:
				case NpgsqlDbType.Time:
				case NpgsqlDbType.TimeTZ:
				case NpgsqlDbType.Interval: return "{0}.Value";

				case NpgsqlDbType.Boolean: return "{0}.Value";
				case NpgsqlDbType.Bytea: return "{0}";
				case NpgsqlDbType.Bit:
				case NpgsqlDbType.Varbit: return "{0}";

				case NpgsqlDbType.Point:
				case NpgsqlDbType.Line:
				case NpgsqlDbType.LSeg:
				case NpgsqlDbType.Box: return "{0}.Value";
				case NpgsqlDbType.Path: return "{0}";
				case NpgsqlDbType.Polygon: return "{0}";
				case NpgsqlDbType.Circle: return "{0}.Value";

				case NpgsqlDbType.Cidr:
				case NpgsqlDbType.Inet:
				case NpgsqlDbType.MacAddr: return "{0}.Value";

				case NpgsqlDbType.Json:
				case NpgsqlDbType.Jsonb: return "{0}";
				case NpgsqlDbType.Uuid: return "{0}.Value";

				case NpgsqlDbType.IntegerRange:
				case NpgsqlDbType.BigintRange: 
				case NpgsqlDbType.NumericRange: 
				case NpgsqlDbType.TimestampRange: 
				case NpgsqlDbType.TimestampTZRange:
				case NpgsqlDbType.DateRange: return "{0}.Value";

				case NpgsqlDbType.Hstore: return "{0}";
				case NpgsqlDbType.Geometry: return "{0}";
				case NpgsqlDbType.Composite:
				case NpgsqlDbType.Enum: return "{0}.Value";
				default: return "";
			}
		}
		protected string GetCSType(NpgsqlDbType type, int attndims, string enumType) {
			if (enumType == "hstore") enumType = "Dictionary<string, string>";
			string arr = "";
			for (int a = 1; a < attndims; a++) arr = arr + ",";
			if (attndims > 0) arr = "[" + arr + "]";
			arr = "{0}" + arr;
			switch (type) {
				case NpgsqlDbType.Smallint: return string.Format(arr, "short" + (attndims > 0 ? "" : "?"));
				case NpgsqlDbType.Integer: return string.Format(arr, "int" + (attndims > 0 ? "" : "?"));
				case NpgsqlDbType.Bigint: return string.Format(arr, "long" + (attndims > 0 ? "" : "?"));
				case NpgsqlDbType.Numeric: return string.Format(arr, "decimal" + (attndims > 0 ? "" : "?"));
				case NpgsqlDbType.Real: return string.Format(arr, "float" + (attndims > 0 ? "" : "?"));
				case NpgsqlDbType.Double: return string.Format(arr, "double" + (attndims > 0 ? "" : "?"));
				case NpgsqlDbType.Money: return string.Format(arr, "decimal" + (attndims > 0 ? "" : "?"));

				case NpgsqlDbType.Char:
				case NpgsqlDbType.Varchar:
				case NpgsqlDbType.Text: return string.Format(arr, "string");

				case NpgsqlDbType.Timestamp:
				case NpgsqlDbType.TimestampTZ:
				case NpgsqlDbType.Date: return string.Format(arr, "DateTime" + (attndims > 0 ? "" : "?"));
				case NpgsqlDbType.Time:
				case NpgsqlDbType.TimeTZ:
				case NpgsqlDbType.Interval: return string.Format(arr, "TimeSpan" + (attndims > 0 ? "" : "?"));

				case NpgsqlDbType.Boolean: return string.Format(arr, "bool" + (attndims > 0 ? "" : "?"));
				case NpgsqlDbType.Bytea: return string.Format(arr, "byte[]");
				case NpgsqlDbType.Bit:
				case NpgsqlDbType.Varbit: return string.Format(arr, "BitArray");

				case NpgsqlDbType.Point: return string.Format(arr, "NpgsqlPoint" + (attndims > 0 ? "" : "?"));
				case NpgsqlDbType.Line: return string.Format(arr, "NpgsqlLine" + (attndims > 0 ? "" : "?"));
				case NpgsqlDbType.LSeg: return string.Format(arr, "NpgsqlLSeg" + (attndims > 0 ? "" : "?"));
				case NpgsqlDbType.Box: return string.Format(arr, "NpgsqlBox" + (attndims > 0 ? "" : "?"));
				case NpgsqlDbType.Path: return string.Format(arr, "NpgsqlPath" + (attndims > 0 ? "" : "?"));
				case NpgsqlDbType.Polygon: return string.Format(arr, "NpgsqlPolygon" + (attndims > 0 ? "" : "?"));
				case NpgsqlDbType.Circle: return string.Format(arr, "NpgsqlCircle" + (attndims > 0 ? "" : "?"));

				case NpgsqlDbType.Cidr: return string.Format(arr, "(IPAddress Address, int Subnet)" + (attndims > 0 ? "" : "?"));
				case NpgsqlDbType.Inet: return string.Format(arr, "IPAddress");
				case NpgsqlDbType.MacAddr: return string.Format(arr, "PhysicalAddress");

				case NpgsqlDbType.Json:
				case NpgsqlDbType.Jsonb: return string.Format(arr, "JToken");
				case NpgsqlDbType.Uuid: return string.Format(arr, "Guid" + (attndims > 0 ? "" : "?"));

				case NpgsqlDbType.IntegerRange: return string.Format(arr, "NpgsqlRange<int>" + (attndims > 0 ? "" : "?"));
				case NpgsqlDbType.BigintRange: return string.Format(arr, "NpgsqlRange<long>" + (attndims > 0 ? "" : "?"));
				case NpgsqlDbType.NumericRange: return string.Format(arr, "NpgsqlRange<decimal>" + (attndims > 0 ? "" : "?"));
				case NpgsqlDbType.TimestampRange:
				case NpgsqlDbType.TimestampTZRange:
				case NpgsqlDbType.DateRange: return string.Format(arr, "NpgsqlRange<DateTime>" + (attndims > 0 ? "" : "?"));

				case NpgsqlDbType.Hstore: return string.Format(arr, enumType);
				case NpgsqlDbType.Geometry: return string.Format(arr, "PostgisGeometry");
				case NpgsqlDbType.Composite: 
				case NpgsqlDbType.Enum: return string.Format(arr, enumType + (attndims > 0 ? "" : "?"));
				default: return "object";
			}
		}

		protected string GetDataReaderMethod(NpgsqlDbType type, string csType) {
			if (csType == "byte[]") return "dr.GetFieldValue<byte[]>(dataIndex)";
			if (csType.EndsWith("]")) return "dr.GetFieldValue<object>(dataIndex) as " + csType.Replace("?", "");
			switch (type) {
				case NpgsqlDbType.Smallint: return "dr.GetFieldValue<short>(dataIndex)";
				case NpgsqlDbType.Integer: return "dr.GetFieldValue<int>(dataIndex)";
				case NpgsqlDbType.Bigint: return "dr.GetFieldValue<long>(dataIndex)";
				case NpgsqlDbType.Numeric: return "dr.GetFieldValue<decimal>(dataIndex)";
				case NpgsqlDbType.Real: return "dr.GetFieldValue<float>(dataIndex)";
				case NpgsqlDbType.Double: return "dr.GetFieldValue<double>(dataIndex)";
				case NpgsqlDbType.Money: return "dr.GetFieldValue<decimal>(dataIndex)";

				case NpgsqlDbType.Char:
				case NpgsqlDbType.Varchar:
				case NpgsqlDbType.Text: return "dr.GetFieldValue<string>(dataIndex)";

				case NpgsqlDbType.Timestamp:
				case NpgsqlDbType.TimestampTZ: return "dr.GetFieldValue<NpgsqlDateTime>(dataIndex).ToDateTime()";
				case NpgsqlDbType.Date: return "(DateTime)dr.GetFieldValue<NpgsqlDate>(dataIndex)";
				case NpgsqlDbType.Time:
				case NpgsqlDbType.TimeTZ: return "dr.GetFieldValue<TimeSpan>(dataIndex)";
				case NpgsqlDbType.Interval: return "dr.GetFieldValue<NpgsqlTimeSpan>(dataIndex).Time";

				case NpgsqlDbType.Boolean: return "dr.GetFieldValue<bool>(dataIndex)";
				case NpgsqlDbType.Bytea: return "dr.GetFieldValue<byte[]>(dataIndex)";
				case NpgsqlDbType.Bit:
				case NpgsqlDbType.Varbit: return "dr.GetFieldValue<BitArray>(dataIndex)";

				case NpgsqlDbType.Point: return "dr.GetFieldValue<NpgsqlPoint>(dataIndex)";
				case NpgsqlDbType.Line: return "dr.GetFieldValue<NpgsqlLine>(dataIndex)";
				case NpgsqlDbType.LSeg: return "dr.GetFieldValue<NpgsqlLSeg>(dataIndex)";
				case NpgsqlDbType.Box: return "dr.GetFieldValue<NpgsqlBox>(dataIndex)";
				case NpgsqlDbType.Path: return "dr.GetFieldValue<NpgsqlPath>(dataIndex)";
				case NpgsqlDbType.Polygon: return "dr.GetFieldValue<NpgsqlPolygon>(dataIndex)";
				case NpgsqlDbType.Circle: return "dr.GetFieldValue<NpgsqlCircle>(dataIndex)";

				case NpgsqlDbType.Cidr: return "dr.GetFieldValue<(IPAddress, int)>(dataIndex)";
				case NpgsqlDbType.Inet: return "dr.GetFieldValue<IPAddress>(dataIndex)";
				case NpgsqlDbType.MacAddr: return "dr.GetFieldValue<PhysicalAddress>(dataIndex)";

				case NpgsqlDbType.Json:
				case NpgsqlDbType.Jsonb: return "dr.GetFieldValue<string>(dataIndex)";
				case NpgsqlDbType.Uuid: return "dr.GetFieldValue<Guid>(dataIndex)";

				case NpgsqlDbType.IntegerRange: return "dr.GetFieldValue<NpgsqlRange<int>>(dataIndex)";
				case NpgsqlDbType.BigintRange: return "dr.GetFieldValue<NpgsqlRange<long>>(dataIndex)";
				case NpgsqlDbType.NumericRange: return "dr.GetFieldValue<NpgsqlRange<decimal>>(dataIndex)";
				case NpgsqlDbType.TimestampRange:
				case NpgsqlDbType.TimestampTZRange: 
				case NpgsqlDbType.DateRange: return "dr.GetFieldValue<NpgsqlRange<DateTime>>(dataIndex)";

				case NpgsqlDbType.Hstore: return "dr.GetFieldValue<Dictionary<string, string>>(dataIndex)";
				case NpgsqlDbType.Geometry: return "dr.GetFieldValue<PostgisGeometry>(dataIndex)";
				case NpgsqlDbType.Enum:
				case NpgsqlDbType.Composite: return "dr.GetFieldValue<" + csType.Replace("?", "") + ">(dataIndex)";
				default: return "dr.GetFieldValue<object>(dataIndex)";
			}
		}

		protected string GetDataReaderMethodAsync(NpgsqlDbType type, string csType) {
			if (csType == "byte[]") return "await dr.GetFieldValueAsync<byte[]>(dataIndex)";
			if (csType.EndsWith("]")) return "await dr.GetFieldValueAsync<object>(dataIndex) as " + csType.Replace("?", "");
			switch (type) {
				case NpgsqlDbType.Smallint: return "await dr.GetFieldValueAsync<short>(dataIndex)";
				case NpgsqlDbType.Integer: return "await dr.GetFieldValueAsync<int>(dataIndex)";
				case NpgsqlDbType.Bigint: return "await dr.GetFieldValueAsync<long>(dataIndex)";
				case NpgsqlDbType.Numeric: return "await dr.GetFieldValueAsync<decimal>(dataIndex)";
				case NpgsqlDbType.Real: return "await dr.GetFieldValueAsync<float>(dataIndex)";
				case NpgsqlDbType.Double: return "await dr.GetFieldValueAsync<double>(dataIndex)";
				case NpgsqlDbType.Money: return "await dr.GetFieldValueAsync<decimal>(dataIndex)";

				case NpgsqlDbType.Char:
				case NpgsqlDbType.Varchar:
				case NpgsqlDbType.Text: return "await dr.GetFieldValueAsync<string>(dataIndex)";

				case NpgsqlDbType.Timestamp:
				case NpgsqlDbType.TimestampTZ: return "(await dr.GetFieldValueAsync<NpgsqlDateTime>(dataIndex)).ToDateTime()";
				case NpgsqlDbType.Date: return "(DateTime)(await dr.GetFieldValueAsync<NpgsqlDate>(dataIndex))";
				case NpgsqlDbType.Time:
				case NpgsqlDbType.TimeTZ: return "await dr.GetFieldValueAsync<TimeSpan>(dataIndex)";
				case NpgsqlDbType.Interval: return "(await dr.GetFieldValueAsync<NpgsqlTimeSpan>(dataIndex)).Time";

				case NpgsqlDbType.Boolean: return "await dr.GetFieldValueAsync<bool>(dataIndex)";
				case NpgsqlDbType.Bytea: return "await dr.GetFieldValueAsync<byte[]>(dataIndex)";
				case NpgsqlDbType.Bit:
				case NpgsqlDbType.Varbit: return "await dr.GetFieldValueAsync<BitArray>(dataIndex)";

				case NpgsqlDbType.Point: return "await dr.GetFieldValueAsync<NpgsqlPoint>(dataIndex)";
				case NpgsqlDbType.Line: return "await dr.GetFieldValueAsync<NpgsqlLine>(dataIndex)";
				case NpgsqlDbType.LSeg: return "await dr.GetFieldValueAsync<NpgsqlLSeg>(dataIndex)";
				case NpgsqlDbType.Box: return "await dr.GetFieldValueAsync<NpgsqlBox>(dataIndex)";
				case NpgsqlDbType.Path: return "await dr.GetFieldValueAsync<NpgsqlPath>(dataIndex)";
				case NpgsqlDbType.Polygon: return "await dr.GetFieldValueAsync<NpgsqlPolygon>(dataIndex)";
				case NpgsqlDbType.Circle: return "await dr.GetFieldValueAsync<NpgsqlCircle>(dataIndex)";

				case NpgsqlDbType.Cidr: return "await dr.GetFieldValueAsync<(IPAddress, int)>(dataIndex)";
				case NpgsqlDbType.Inet: return "await dr.GetFieldValueAsync<IPAddress>(dataIndex)";
				case NpgsqlDbType.MacAddr: return "await dr.GetFieldValueAsync<PhysicalAddress>(dataIndex)";

				case NpgsqlDbType.Json:
				case NpgsqlDbType.Jsonb: return "await dr.GetFieldValueAsync<string>(dataIndex)";
				case NpgsqlDbType.Uuid: return "await dr.GetFieldValueAsync<Guid>(dataIndex)";

				case NpgsqlDbType.IntegerRange: return "await dr.GetFieldValueAsync<NpgsqlRange<int>>(dataIndex)";
				case NpgsqlDbType.BigintRange: return "await dr.GetFieldValueAsync<NpgsqlRange<long>>(dataIndex)";
				case NpgsqlDbType.NumericRange: return "await dr.GetFieldValueAsync<NpgsqlRange<decimal>>(dataIndex)";
				case NpgsqlDbType.TimestampRange:
				case NpgsqlDbType.TimestampTZRange:
				case NpgsqlDbType.DateRange: return "await dr.GetFieldValueAsync<NpgsqlRange<DateTime>>(dataIndex)";

				case NpgsqlDbType.Hstore: return "await dr.GetFieldValueAsync<Dictionary<string, string>>(dataIndex)";
				case NpgsqlDbType.Geometry: return "await dr.GetFieldValueAsync<PostgisGeometry>(dataIndex)";
				case NpgsqlDbType.Enum:
				case NpgsqlDbType.Composite: return "await dr.GetFieldValueAsync<" + csType.Replace("?", "") + ">(dataIndex)";
				default: return "await dr.GetFieldValueAsync<object>(dataIndex)";
			}
		}
		protected string GetObjectConvertToCsTypeMethod(NpgsqlDbType type, string csType) {
			if (csType == "byte[]" || csType.EndsWith("]")) return "{0} as " + csType;
			switch (type) {
				case NpgsqlDbType.Smallint: return "(short){0}";
				case NpgsqlDbType.Integer: return "(int){0}";
				case NpgsqlDbType.Bigint: return "(long){0}";
				case NpgsqlDbType.Numeric: return "(decimal){0}";
				case NpgsqlDbType.Real: return "(float){0}";
				case NpgsqlDbType.Double: return "(double){0}";
				case NpgsqlDbType.Money: return "(decimal){0}";

				case NpgsqlDbType.Char:
				case NpgsqlDbType.Varchar:
				case NpgsqlDbType.Text: return "(string){0}";

				case NpgsqlDbType.Timestamp:
				case NpgsqlDbType.TimestampTZ:
				case NpgsqlDbType.Date: return "(DateTime){0}";
				case NpgsqlDbType.Time:
				case NpgsqlDbType.TimeTZ: return "(TimeSpan){0}";
				case NpgsqlDbType.Interval: return "(TimeSpan){0}";

				case NpgsqlDbType.Boolean: return "(bool){0}";
				case NpgsqlDbType.Bytea: return "{0} as byte[]";
				case NpgsqlDbType.Bit:
				case NpgsqlDbType.Varbit: return "{0} as BitArray";

				case NpgsqlDbType.Point: return "(NpgsqlPoint){0}";
				case NpgsqlDbType.Line: return "(NpgsqlLine){0}";
				case NpgsqlDbType.LSeg: return "(NpgsqlLSeg){0}";
				case NpgsqlDbType.Box: return "(NpgsqlBox){0}";
				case NpgsqlDbType.Path: return "(NpgsqlPath){0}";
				case NpgsqlDbType.Polygon: return "(NpgsqlPolygon){0}";
				case NpgsqlDbType.Circle: return "(NpgsqlCircle){0}";

				case NpgsqlDbType.Cidr: return "((IPAddress, int)){0}";
				case NpgsqlDbType.Inet: return "(IPAddress){0}";
				case NpgsqlDbType.MacAddr: return "{0} as PhysicalAddress";

				case NpgsqlDbType.Json:
				case NpgsqlDbType.Jsonb: return "{0} as JToken";
				case NpgsqlDbType.Uuid: return "(Guid){0}";

				case NpgsqlDbType.IntegerRange: return "(NpgsqlRange<int>){0}";
				case NpgsqlDbType.BigintRange: return "(NpgsqlRange<long>){0}";
				case NpgsqlDbType.NumericRange: return "(NpgsqlRange<decimal>){0}";
				case NpgsqlDbType.TimestampRange:
				case NpgsqlDbType.TimestampTZRange:
				case NpgsqlDbType.DateRange: return "(NpgsqlRange<DateTime>){0}";

				case NpgsqlDbType.Hstore: return "{0} as Dictionary<string, string>";
				case NpgsqlDbType.Geometry: return "{0} as PostgisGeometry";
				case NpgsqlDbType.Enum:
				case NpgsqlDbType.Composite: return "(" + csType + "){0}";
				default: return "{0}";
			}
		}

		protected string GetToStringFieldConcat(ColumnInfo columnInfo, string csType) {
			switch (columnInfo.Type) {
				case NpgsqlDbType.Smallint:
				case NpgsqlDbType.Integer:
				case NpgsqlDbType.Bigint:
				case NpgsqlDbType.Numeric:
				case NpgsqlDbType.Real:
				case NpgsqlDbType.Double:
				case NpgsqlDbType.Money: return string.Format("{0} == null ? \"null\" : {0}.ToString()", UFString(columnInfo.Name));

				case NpgsqlDbType.Char:
				case NpgsqlDbType.Varchar:
				case NpgsqlDbType.Text: return string.Format("{0} == null ? \"null\" : string.Format(\"'{{0}}'\", {0}.Replace(\"\\\\\", \"\\\\\\\\\").Replace(\"\\r\\n\", \"\\\\r\\\\n\").Replace(\"'\", \"\\\\'\"))", UFString(columnInfo.Name));

				case NpgsqlDbType.Timestamp:
				case NpgsqlDbType.TimestampTZ:
				case NpgsqlDbType.Date: return string.Format("{0} == null ? \"null\" : {0}.Value.Subtract(new DateTime(1970, 1, 1)).TotalMilliseconds.ToString()", UFString(columnInfo.Name));
				case NpgsqlDbType.Time:
				case NpgsqlDbType.TimeTZ:
				case NpgsqlDbType.Interval: return string.Format("{0} == null ? \"null\" : {0}.Value.TotalMilliseconds.ToString()", UFString(columnInfo.Name));

				case NpgsqlDbType.Boolean: return string.Format("{0} == null ? \"null\" : ({0} == true ? \"true\" : \"false\")", UFString(columnInfo.Name));
				case NpgsqlDbType.Bytea: return string.Format("{0} == null ? \"null\" : Convert.ToBase64String({0})", UFString(columnInfo.Name));
				case NpgsqlDbType.Bit:
				case NpgsqlDbType.Varbit: return string.Format("{0} == null ? \"null\" : string.Format(\"'{{0}}'\", {0}.To1010())", UFString(columnInfo.Name));

				case NpgsqlDbType.Point:
				case NpgsqlDbType.Line:
				case NpgsqlDbType.LSeg:
				case NpgsqlDbType.Box:
				case NpgsqlDbType.Path:
				case NpgsqlDbType.Polygon:
				case NpgsqlDbType.Circle:

				case NpgsqlDbType.Cidr:
				case NpgsqlDbType.Inet:
				case NpgsqlDbType.MacAddr: return string.Format("{0} == null ? \"null\" : {0}.ToString()", UFString(columnInfo.Name));

				case NpgsqlDbType.Json:
				case NpgsqlDbType.Jsonb:
				case NpgsqlDbType.Uuid: return string.Format("{0} == null ? \"null\" : {0}.ToString()", UFString(columnInfo.Name));

				case NpgsqlDbType.IntegerRange:
				case NpgsqlDbType.BigintRange:
				case NpgsqlDbType.NumericRange:
				case NpgsqlDbType.TimestampRange:
				case NpgsqlDbType.TimestampTZRange:
				case NpgsqlDbType.DateRange: return string.Format("{0} == null ? \"null\" : {0}.ToString()", UFString(columnInfo.Name));

				case NpgsqlDbType.Hstore:
				case NpgsqlDbType.Geometry:
				case NpgsqlDbType.Enum:
				case NpgsqlDbType.Composite:
				default: return string.Format("{0} == null ? \"null\" : {0}.ToString()", UFString(columnInfo.Name));
			}
		}

		protected string GetToStringStringify(ColumnInfo columnInfo)
        {
            switch (columnInfo.Type)
            {
				case NpgsqlDbType.Smallint:
				case NpgsqlDbType.Integer:
				case NpgsqlDbType.Bigint:
				case NpgsqlDbType.Numeric:
				case NpgsqlDbType.Real:
				case NpgsqlDbType.Double:
				case NpgsqlDbType.Money: return "_" + UFString(columnInfo.Name) + " == null ? \"null\" : _" + UFString(columnInfo.Name) + ".ToString()";

				case NpgsqlDbType.Char:
				case NpgsqlDbType.Varchar:
				case NpgsqlDbType.Text: return "_" + UFString(columnInfo.Name) + " == null ? \"null\" : _" + UFString(columnInfo.Name) + ".Replace(\"|\", StringifySplit)";

				case NpgsqlDbType.Timestamp:
				case NpgsqlDbType.TimestampTZ:
				case NpgsqlDbType.Date:
				case NpgsqlDbType.Time:
				case NpgsqlDbType.TimeTZ:
				case NpgsqlDbType.Interval: return "_" + UFString(columnInfo.Name) + " == null ? \"null\" : _" + UFString(columnInfo.Name) + ".Value.Ticks.ToString()";

				case NpgsqlDbType.Boolean: return "_" + UFString(columnInfo.Name) + " == null ? \"null\" : (_" + UFString(columnInfo.Name) + " == true ? \"1\" : \"0\")";
				case NpgsqlDbType.Bytea: return "_" + UFString(columnInfo.Name) + " == null ? \"null\" : Convert.ToBase64String(_" + UFString(columnInfo.Name) + ")";
				case NpgsqlDbType.Bit:
				case NpgsqlDbType.Varbit: return string.Format("{0} == null ? \"null\" : {0}.To1010()", UFString(columnInfo.Name));

				case NpgsqlDbType.Point:
				case NpgsqlDbType.Line:
				case NpgsqlDbType.LSeg:
				case NpgsqlDbType.Box:
				case NpgsqlDbType.Path:
				case NpgsqlDbType.Polygon:
				case NpgsqlDbType.Circle:

				case NpgsqlDbType.Cidr:
				case NpgsqlDbType.Inet:
				case NpgsqlDbType.MacAddr: return string.Format("{0} == null ? \"null\" : {0}.ToString()", UFString(columnInfo.Name));

				case NpgsqlDbType.Json:
				case NpgsqlDbType.Jsonb:
				case NpgsqlDbType.Uuid: return string.Format("{0} == null ? \"null\" : {0}.ToString()", UFString(columnInfo.Name));

				case NpgsqlDbType.IntegerRange:
				case NpgsqlDbType.BigintRange:
				case NpgsqlDbType.NumericRange:
				case NpgsqlDbType.TimestampRange:
				case NpgsqlDbType.TimestampTZRange:
				case NpgsqlDbType.DateRange: return string.Format("{0} == null ? \"null\" : {0}.ToString()", UFString(columnInfo.Name));

				case NpgsqlDbType.Hstore:
				case NpgsqlDbType.Geometry:
				case NpgsqlDbType.Enum:
				case NpgsqlDbType.Composite:
				default: return "_" + UFString(columnInfo.Name) + " == null ? \"null\" : _" + UFString(columnInfo.Name) + ".ToString().Replace(\"|\", StringifySplit)";
			}
        }
        protected string GetStringifyParse(NpgsqlDbType type, string enumType)
        {
			switch (type)
            {
				case NpgsqlDbType.Smallint: return "short.Parse({0})";
				case NpgsqlDbType.Integer: return "int.Parse({0})";
				case NpgsqlDbType.Bigint: return "long.Parse({0})";
				case NpgsqlDbType.Numeric: return "decimal.Parse({0})";
				case NpgsqlDbType.Real: return "float.Parse({0})";
				case NpgsqlDbType.Double: return "double.Parse({0})";
				case NpgsqlDbType.Money: return "decimal.Parse({0})";

				case NpgsqlDbType.Char:
				case NpgsqlDbType.Varchar:
				case NpgsqlDbType.Text: return "{0}.Replace(StringifySplit, \"|\")";

				case NpgsqlDbType.Timestamp:
				case NpgsqlDbType.TimestampTZ:
				case NpgsqlDbType.Date: return "new DateTime(long.Parse({0}))";
				case NpgsqlDbType.Time:
				case NpgsqlDbType.TimeTZ:
				case NpgsqlDbType.Interval: return "new TimeSpan(long.Parse({0}))";

				case NpgsqlDbType.Boolean: return "{0} == \"1\"";
				case NpgsqlDbType.Bytea: return "Convert.FromBase64String({0})";
				case NpgsqlDbType.Bit:
				case NpgsqlDbType.Varbit: return "PSqlHelper.Parse1010({0})";

				case NpgsqlDbType.Point: return "NpgsqlPoint.Parse({0})";
				case NpgsqlDbType.Line: return "NpgsqlLine.Parse({0})";
				case NpgsqlDbType.LSeg: return "NpgsqlLSeg.Parse({0})";
				case NpgsqlDbType.Box: return "NpgsqlBox.Parse({0})";
				case NpgsqlDbType.Path: return "NpgsqlPath.Parse({0})";
				case NpgsqlDbType.Polygon: return "NpgsqlPolygon.Parse({0})";
				case NpgsqlDbType.Circle: return "NpgsqlCircle.Parse({0})";

				case NpgsqlDbType.Cidr: return "(IPAddress, int)({0})";
				case NpgsqlDbType.Inet: return "IPAddress.Parse({0})";
				case NpgsqlDbType.MacAddr: return "PhysicalAddress.Parse({0})";

				case NpgsqlDbType.Json:
				case NpgsqlDbType.Jsonb: return "JToken.Parse({0})";
				case NpgsqlDbType.Uuid: return "Guid.Parse({0})";

				case NpgsqlDbType.IntegerRange: return "PSqlHelper.ParseNpgsqlRange<int>({0})";
				case NpgsqlDbType.BigintRange: return "PSqlHelper.ParseNpgsqlRange<long>({0})";
				case NpgsqlDbType.NumericRange: return "PSqlHelper.ParseNpgsqlRange<decimal>({0})";
				case NpgsqlDbType.TimestampRange:
				case NpgsqlDbType.TimestampTZRange:
				case NpgsqlDbType.DateRange: return "PSqlHelper.ParseNpgsqlRange<DateTime>({0})";

				case NpgsqlDbType.Enum: return "(" + enumType + ")int.Parse({0})";
				case NpgsqlDbType.Composite: return enumType + ".Parse({0})";
				default: return "{0}.Replace(StringifySplit, \"|\")";
            }
        }

		protected string AppendParameter(ColumnInfo col, string value, string place) {
			if (col == null) return "";
			string type = "";
			string type2 = "";
			if (col.Attndims > 0) type += " | NpgsqlDbType.Array";

			switch (col.Type) {
				case NpgsqlDbType.Smallint:
				case NpgsqlDbType.Integer:
				case NpgsqlDbType.Bigint:
				case NpgsqlDbType.Numeric:
				case NpgsqlDbType.Real:
				case NpgsqlDbType.Double:
				case NpgsqlDbType.Money:

				case NpgsqlDbType.Char:
				case NpgsqlDbType.Varchar:
				case NpgsqlDbType.Text:

				case NpgsqlDbType.Timestamp:
				case NpgsqlDbType.TimestampTZ:
				case NpgsqlDbType.Date:
				case NpgsqlDbType.Time:
				case NpgsqlDbType.TimeTZ:
				case NpgsqlDbType.Interval:

				case NpgsqlDbType.Boolean:
				case NpgsqlDbType.Bytea:
				case NpgsqlDbType.Bit:
				case NpgsqlDbType.Varbit:

				case NpgsqlDbType.Point:
				case NpgsqlDbType.Line:
				case NpgsqlDbType.LSeg:
				case NpgsqlDbType.Box:
				case NpgsqlDbType.Path:
				case NpgsqlDbType.Polygon:
				case NpgsqlDbType.Circle:

				case NpgsqlDbType.Cidr:
				case NpgsqlDbType.Inet:
				case NpgsqlDbType.MacAddr:

				case NpgsqlDbType.Uuid: type += " | NpgsqlDbType." + col.Type.ToString(); break;
				case NpgsqlDbType.Json:
				case NpgsqlDbType.Jsonb: type += " | NpgsqlDbType." + col.Type.ToString(); type2 = "?.ToString()"; break;

				case NpgsqlDbType.IntegerRange: type += " | NpgsqlDbType.Range | NpgsqlDbType.Integer"; break;
				case NpgsqlDbType.BigintRange: type += " | NpgsqlDbType.Range | NpgsqlDbType.Bigint"; break;
				case NpgsqlDbType.NumericRange: type += " | NpgsqlDbType.Range | NpgsqlDbType.Numeric"; break;
				case NpgsqlDbType.TimestampRange: type += " | NpgsqlDbType.Range | NpgsqlDbType.Timestamp"; break;
				case NpgsqlDbType.TimestampTZRange: type += " | NpgsqlDbType.Range | NpgsqlDbType.TimestampTZ"; break;
				case NpgsqlDbType.DateRange: type += " | NpgsqlDbType.Range | NpgsqlDbType.Date"; break;

				case NpgsqlDbType.Enum:
				case NpgsqlDbType.Composite:
					string DataTypeName = "";
					dic_globalnpgtypes.TryGetValue(col.SqlType, out DataTypeName);
					return place + string.Format("new NpgsqlParameter {{ ParameterName = \"{0}\", DataTypeName = \"{1}\", Value = {2} }}, \r\n",
				col.Name, DataTypeName + (col.Attndims > 0 ? "[]" : ""), value + UFString(col.Name));
					//break;

				case NpgsqlDbType.Hstore:
				case NpgsqlDbType.Geometry:
				default: type += " | NpgsqlDbType." + col.Type.ToString(); break;
			}
			string returnValue = place + string.Format("new NpgsqlParameter(\"{0}\", {1}, {2}) {{ Value = {3}{4} }}, \r\n",
				col.Name, type.Substring(3), col.Length, value + UFString(col.Name), type2);

			return returnValue;
		}
		protected string AppendParameters(List<ColumnInfo> columnInfos, string value, string place) {
			string returnValue = "";

			foreach (ColumnInfo columnInfo in columnInfos) {
				returnValue += AppendParameter(columnInfo, value, place);
			}
			return returnValue == "" ? "" : returnValue.Substring(0, returnValue.Length - 4);
		}
		protected string AppendParameters(List<ColumnInfo> columnInfos, string place) {
			return AppendParameters(columnInfos, "", place);
		}
		protected string AppendParameters(TableInfo table, string place) {
			return AppendParameters(table.Columns, "item.", place);
		}
		protected string AppendParameters(ColumnInfo columnInfo, string place) {
			string returnValue = AppendParameter(columnInfo, "", place);
			return returnValue == "" ? "" : returnValue.Substring(0, returnValue.Length - 4);
		}

		protected string UFString(string text) {
			if (text.Length <= 1) return text.ToUpper();
			else return text.Substring(0, 1).ToUpper() + text.Substring(1, text.Length - 1);
		}

		protected string LFString(string text) {
			if (text.Length <= 1) return text.ToLower();
			else return text.Substring(0, 1).ToLower() + text.Substring(1, text.Length - 1);
		}

		protected string GetCSName(string name) {
			name = Regex.Replace(name.TrimStart('@'), @"[^\w]", "_");
			return char.IsLetter(name, 0) ? name : string.Concat("_", name);
		}

		protected void FindForeignKeyTables(List<TableInfo> tables, TableInfo table, List<ForeignKeyInfo> finds) {
			foreach(var t in tables) {
				foreach (var fk in t.ForeignKeys) {
					if (fk.ReferencedTable.FullName == table.FullName) {
						finds.Add(fk);
					}
				}
			}
		}
	}
}
