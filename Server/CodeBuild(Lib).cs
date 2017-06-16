using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Model;
using System.Collections;

namespace Server {

	internal partial class CodeBuild {
		protected static NpgsqlDbType GetDBType(string strType, string typtype) {
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

				case "hstore":return NpgsqlDbType.Hstore;
				default: return NpgsqlDbType.Unknown;
			}
		}

		protected static string GetCSTypeValue(NpgsqlDbType type) {
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
				case NpgsqlDbType.Composite:
				case NpgsqlDbType.Enum: return "{0}.Value";
				default: return "";
			}
		}
		protected static string GetCSType(NpgsqlDbType type, int attndims, string enumType) {
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

				case NpgsqlDbType.Cidr: return string.Format(arr, "NpgsqlInet" + (attndims > 0 ? "" : "?"));
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
				case NpgsqlDbType.Composite: 
				case NpgsqlDbType.Enum: return string.Format(arr, enumType + (attndims > 0 ? "" : "?"));
				default: return "object";
			}
		}

		protected static string GetDataReaderMethod(NpgsqlDbType type, string csType) {
			if (csType == "byte[]" || csType.EndsWith("]")) return "dr.GetValue(index) as " + csType.Replace("?", "");
			switch (type) {
				case NpgsqlDbType.Smallint: return "dr.GetInt16(index)";
				case NpgsqlDbType.Integer: return "dr.GetInt32(index)";
				case NpgsqlDbType.Bigint: return "dr.GetInt64(index)";
				case NpgsqlDbType.Numeric: return "dr.GetDecimal(index)";
				case NpgsqlDbType.Real: return "dr.GetFloat(index)";
				case NpgsqlDbType.Double: return "dr.GetDouble(index)";
				case NpgsqlDbType.Money: return "dr.GetDecimal(index)";

				case NpgsqlDbType.Char:
				case NpgsqlDbType.Varchar:
				case NpgsqlDbType.Text: return "dr.GetString(index)";

				case NpgsqlDbType.Timestamp:
				case NpgsqlDbType.TimestampTZ: return "dr.GetTimeStamp(index).DateTime";
				case NpgsqlDbType.Date: return "(DateTime)dr.GetDate(index)";
				case NpgsqlDbType.Time:
				case NpgsqlDbType.TimeTZ: return "dr.GetTimeSpan(index)";
				case NpgsqlDbType.Interval: return "dr.GetInterval(index).Time";

				case NpgsqlDbType.Boolean: return "dr.GetBoolean(index)";
				case NpgsqlDbType.Bytea: return "dr.GetFieldValue<byte[]>(index)";
				case NpgsqlDbType.Bit:
				case NpgsqlDbType.Varbit: return "dr.GetFieldValue<BitArray>(index)";

				case NpgsqlDbType.Point: return "dr.GetFieldValue<NpgsqlPoint>(index)";
				case NpgsqlDbType.Line: return "dr.GetFieldValue<NpgsqlLine>(index)";
				case NpgsqlDbType.LSeg: return "dr.GetFieldValue<NpgsqlLSeg>(index)";
				case NpgsqlDbType.Box: return "dr.GetFieldValue<NpgsqlBox>(index)";
				case NpgsqlDbType.Path: return "dr.GetFieldValue<NpgsqlPath>(index)";
				case NpgsqlDbType.Polygon: return "dr.GetFieldValue<NpgsqlPolygon>(index)";
				case NpgsqlDbType.Circle: return "dr.GetFieldValue<NpgsqlCircle>(index)";

				case NpgsqlDbType.Cidr: return "dr.GetFieldValue<NpgsqlInet>(index)";
				case NpgsqlDbType.Inet: return "dr.GetFieldValue<IPAddress>(index)";
				case NpgsqlDbType.MacAddr: return "dr.GetFieldValue<PhysicalAddress>(index)";

				case NpgsqlDbType.Json:
				case NpgsqlDbType.Jsonb: return "dr.GetString(index)";
				case NpgsqlDbType.Uuid: return "dr.GetGuid(index)";

				case NpgsqlDbType.IntegerRange: return "dr.GetFieldValue<NpgsqlRange<int>>(index)";
				case NpgsqlDbType.BigintRange: return "dr.GetFieldValue<NpgsqlRange<long>>(index)";
				case NpgsqlDbType.NumericRange: return "dr.GetFieldValue<NpgsqlRange<decimal>>(index)";
				case NpgsqlDbType.TimestampRange:
				case NpgsqlDbType.TimestampTZRange: 
				case NpgsqlDbType.DateRange: return "dr.GetFieldValue<NpgsqlRange<DateTime>>(index)";

				case NpgsqlDbType.Hstore: return "dr.GetValue(index) as Dictionary<string, string>";
				case NpgsqlDbType.Enum:
				case NpgsqlDbType.Composite: return "dr.GetFieldValue<" + csType.Replace("?", "") + ">(index)";
				default: return "dr.GetValue(index)";
			}
		}

		protected static string GetObjectConvertToCsTypeMethod(NpgsqlDbType type, string csType) {
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

				case NpgsqlDbType.Cidr: return "(NpgsqlInet){0}";
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
				case NpgsqlDbType.Enum:
				case NpgsqlDbType.Composite: return "(" + csType + "){0}";
				default: return "{0}";
			}
		}

		protected static string GetToStringFieldConcat(ColumnInfo columnInfo, string csType) {
			switch (columnInfo.Type) {
				case NpgsqlDbType.Smallint:
				case NpgsqlDbType.Integer:
				case NpgsqlDbType.Bigint:
				case NpgsqlDbType.Numeric:
				case NpgsqlDbType.Real:
				case NpgsqlDbType.Double:
				case NpgsqlDbType.Money: return string.Format("{0} == null ? \"null\" : {0}.ToString()", CodeBuild.UFString(columnInfo.Name));

				case NpgsqlDbType.Char:
				case NpgsqlDbType.Varchar:
				case NpgsqlDbType.Text: return string.Format("{0} == null ? \"null\" : string.Format(\"'{{0}}'\", {0}.Replace(\"\\\\\", \"\\\\\\\\\").Replace(\"\\r\\n\", \"\\\\r\\\\n\").Replace(\"'\", \"\\\\'\"))", CodeBuild.UFString(columnInfo.Name));

				case NpgsqlDbType.Timestamp:
				case NpgsqlDbType.TimestampTZ:
				case NpgsqlDbType.Date: return string.Format("{0} == null ? \"null\" : {0}.Value.Subtract(new DateTime(1970, 1, 1)).TotalMilliseconds.ToString()", CodeBuild.UFString(columnInfo.Name));
				case NpgsqlDbType.Time:
				case NpgsqlDbType.TimeTZ:
				case NpgsqlDbType.Interval: return string.Format("{0} == null ? \"null\" : {0}.Value.TotalMilliseconds.ToString()", CodeBuild.UFString(columnInfo.Name));

				case NpgsqlDbType.Boolean: return string.Format("{0} == null ? \"null\" : ({0} == true ? \"true\" : \"false\")", CodeBuild.UFString(columnInfo.Name));
				case NpgsqlDbType.Bytea: return string.Format("{0} == null ? \"null\" : Convert.ToBase64String({0})", CodeBuild.UFString(columnInfo.Name));
				case NpgsqlDbType.Bit:
				case NpgsqlDbType.Varbit: return string.Format("{0} == null ? \"null\" : string.Format(\"'{{0}}'\", {0}.To1010())", CodeBuild.UFString(columnInfo.Name));

				case NpgsqlDbType.Point:
				case NpgsqlDbType.Line:
				case NpgsqlDbType.LSeg:
				case NpgsqlDbType.Box:
				case NpgsqlDbType.Path:
				case NpgsqlDbType.Polygon:
				case NpgsqlDbType.Circle:

				case NpgsqlDbType.Cidr:
				case NpgsqlDbType.Inet:
				case NpgsqlDbType.MacAddr: return string.Format("{0} == null ? \"null\" : {0}.ToString()", CodeBuild.UFString(columnInfo.Name));

				case NpgsqlDbType.Json:
				case NpgsqlDbType.Jsonb:
				case NpgsqlDbType.Uuid: return string.Format("{0} == null ? \"null\" : {0}.ToString()", CodeBuild.UFString(columnInfo.Name));

				case NpgsqlDbType.IntegerRange:
				case NpgsqlDbType.BigintRange:
				case NpgsqlDbType.NumericRange:
				case NpgsqlDbType.TimestampRange:
				case NpgsqlDbType.TimestampTZRange:
				case NpgsqlDbType.DateRange: return string.Format("{0} == null ? \"null\" : {0}.ToString()", CodeBuild.UFString(columnInfo.Name));

				case NpgsqlDbType.Hstore:
				case NpgsqlDbType.Enum:
				case NpgsqlDbType.Composite:
				default: return string.Format("{0} == null ? \"null\" : {0}.ToString()", CodeBuild.UFString(columnInfo.Name));
			}
		}

		protected static string GetToStringStringify(ColumnInfo columnInfo)
        {
            switch (columnInfo.Type)
            {
				case NpgsqlDbType.Smallint:
				case NpgsqlDbType.Integer:
				case NpgsqlDbType.Bigint:
				case NpgsqlDbType.Numeric:
				case NpgsqlDbType.Real:
				case NpgsqlDbType.Double:
				case NpgsqlDbType.Money: return "_" + CodeBuild.UFString(columnInfo.Name) + " == null ? \"null\" : _" + CodeBuild.UFString(columnInfo.Name) + ".ToString()";

				case NpgsqlDbType.Char:
				case NpgsqlDbType.Varchar:
				case NpgsqlDbType.Text: return "_" + CodeBuild.UFString(columnInfo.Name) + " == null ? \"null\" : _" + CodeBuild.UFString(columnInfo.Name) + ".Replace(\"|\", StringifySplit)";

				case NpgsqlDbType.Timestamp:
				case NpgsqlDbType.TimestampTZ:
				case NpgsqlDbType.Date:
				case NpgsqlDbType.Time:
				case NpgsqlDbType.TimeTZ:
				case NpgsqlDbType.Interval: return "_" + CodeBuild.UFString(columnInfo.Name) + " == null ? \"null\" : _" + CodeBuild.UFString(columnInfo.Name) + ".Value.Ticks.ToString()";

				case NpgsqlDbType.Boolean: return "_" + CodeBuild.UFString(columnInfo.Name) + " == null ? \"null\" : (_" + CodeBuild.UFString(columnInfo.Name) + " == true ? \"1\" : \"0\")";
				case NpgsqlDbType.Bytea: return "_" + CodeBuild.UFString(columnInfo.Name) + " == null ? \"null\" : Convert.ToBase64String(_" + CodeBuild.UFString(columnInfo.Name) + ")";
				case NpgsqlDbType.Bit:
				case NpgsqlDbType.Varbit: return string.Format("{0} == null ? \"null\" : {0}.To1010()", CodeBuild.UFString(columnInfo.Name));

				case NpgsqlDbType.Point:
				case NpgsqlDbType.Line:
				case NpgsqlDbType.LSeg:
				case NpgsqlDbType.Box:
				case NpgsqlDbType.Path:
				case NpgsqlDbType.Polygon:
				case NpgsqlDbType.Circle:

				case NpgsqlDbType.Cidr:
				case NpgsqlDbType.Inet:
				case NpgsqlDbType.MacAddr: return string.Format("{0} == null ? \"null\" : {0}.ToString()", CodeBuild.UFString(columnInfo.Name));

				case NpgsqlDbType.Json:
				case NpgsqlDbType.Jsonb:
				case NpgsqlDbType.Uuid: return string.Format("{0} == null ? \"null\" : {0}.ToString()", CodeBuild.UFString(columnInfo.Name));

				case NpgsqlDbType.IntegerRange:
				case NpgsqlDbType.BigintRange:
				case NpgsqlDbType.NumericRange:
				case NpgsqlDbType.TimestampRange:
				case NpgsqlDbType.TimestampTZRange:
				case NpgsqlDbType.DateRange: return string.Format("{0} == null ? \"null\" : {0}.ToString()", CodeBuild.UFString(columnInfo.Name));

				case NpgsqlDbType.Hstore:
				case NpgsqlDbType.Enum:
				case NpgsqlDbType.Composite:
				default: return "_" + CodeBuild.UFString(columnInfo.Name) + " == null ? \"null\" : _" + CodeBuild.UFString(columnInfo.Name) + ".ToString().Replace(\"|\", StringifySplit)";
			}
        }
        protected static string GetStringifyParse(NpgsqlDbType type, string enumType)
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

				case NpgsqlDbType.Cidr: return "new NpgsqlInet({0})";
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

		protected static string AppendParameter(ColumnInfo col, string value, string place) {
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

				case NpgsqlDbType.Json:
				case NpgsqlDbType.Jsonb:
				case NpgsqlDbType.Uuid: type += " | NpgsqlDbType." + col.Type.ToString();break;

				case NpgsqlDbType.IntegerRange: type += " | NpgsqlDbType.Range | NpgsqlDbType.Integer"; break;
				case NpgsqlDbType.BigintRange: type += " | NpgsqlDbType.Range | NpgsqlDbType.Bigint"; break;
				case NpgsqlDbType.NumericRange: type += " | NpgsqlDbType.Range | NpgsqlDbType.Numeric"; break;
				case NpgsqlDbType.TimestampRange: type += " | NpgsqlDbType.Range | NpgsqlDbType.Timestamp"; break;
				case NpgsqlDbType.TimestampTZRange: type += " | NpgsqlDbType.Range | NpgsqlDbType.TimestampTZ"; break;
				case NpgsqlDbType.DateRange: type += " | NpgsqlDbType.Range | NpgsqlDbType.Date"; break;

				case NpgsqlDbType.Enum:
				case NpgsqlDbType.Composite: type += " | NpgsqlDbType." + col.Type.ToString(); type2 = "SpecificType = typeof(" + Regex.Replace(col.CsType.Replace("?", ""), @"\[\,*\]", "") + "), "; break;
				default: type += " | NpgsqlDbType." + col.Type.ToString(); break;
			}
			string returnValue = place + string.Format("new NpgsqlParameter(\"{0}\", {1}, {2}) {{ {4}Value = {3} }}, \r\n",
				col.Name, type.Substring(3), col.Length, value + CodeBuild.UFString(col.Name), type2);

			return returnValue;
		}
		protected static string AppendParameters(List<ColumnInfo> columnInfos, string value, string place) {
			string returnValue = "";

			foreach (ColumnInfo columnInfo in columnInfos) {
				returnValue += AppendParameter(columnInfo, value, place);
			}
			return returnValue == "" ? "" : returnValue.Substring(0, returnValue.Length - 4);
		}
		protected static string AppendParameters(List<ColumnInfo> columnInfos, string place) {
			return AppendParameters(columnInfos, "", place);
		}
		protected static string AppendParameters(TableInfo table, string place) {
			return AppendParameters(table.Columns, "item.", place);
		}
		protected static string AppendParameters(ColumnInfo columnInfo, string place) {
			string returnValue = AppendParameter(columnInfo, "", place);
			return returnValue == "" ? "" : returnValue.Substring(0, returnValue.Length - 4);
		}

		protected static string UFString(string text) {
			if (text.Length <= 1) return text.ToUpper();
			else return text.Substring(0, 1).ToUpper() + text.Substring(1, text.Length - 1);
		}

		protected static string LFString(string text) {
			if (text.Length <= 1) return text.ToLower();
			else return text.Substring(0, 1).ToLower() + text.Substring(1, text.Length - 1);
		}

		protected static string GetCSName(string name) {
			name = Regex.Replace(name.TrimStart('@'), @"[^\w]", "_");
			return char.IsLetter(name, 0) ? name : string.Concat("_", name);
		}
	}
}
