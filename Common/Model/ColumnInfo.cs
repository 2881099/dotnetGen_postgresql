using System;
using System.Collections.Generic;
using System.Text;

namespace Model {

	[Serializable]
	public class ColumnInfo {

		private string _name;
		private NpgsqlDbType _type;
		private long _length;
		private string _sqlType;
		private string _csType;
		private DataSort _orderby;
		private bool _isNullable;
		private bool _isIdentity;
		private bool _isClustered;
		private bool _isPrimaryKey;
		private int _attndims;
		private int _attnum;

		public ColumnInfo() { }
		public ColumnInfo(string name, NpgsqlDbType type, long length, string sqlType, string csType, DataSort orderby, bool isNullable, bool isIdentity, bool isClustered, bool isPrimaryKey, int attndims, int attnum) {
			_name = name;
			_type = type;
			_length = length;
			_sqlType = sqlType;
			_csType = csType;
			_orderby = orderby;
			_isNullable = isNullable;
			_isIdentity = isIdentity;
			_isClustered = isClustered;
			_isPrimaryKey = isPrimaryKey;
			_attndims = attndims;
			_attnum = attnum;
	}

		public string Name {
			get { return _name; }
			set { _name = value; }
		}
		public NpgsqlDbType Type {
			get { return _type; }
			set { _type = value; }
		}
		public long Length {
			get { return _length; }
			set { _length = value; }
		}
		public string SqlType {
			get { return _sqlType; }
			set { _sqlType = value; }
		}
		public string CsType {
			get { return _csType; }
			set { _csType = value; }
		}
		public DataSort Orderby {
			get { return _orderby; }
			set { _orderby = value; }
		}
		public bool IsNullable {
			get { return _isNullable; }
			set { _isNullable = value; }
		}
		public bool IsIdentity {
			get { return _isIdentity; }
			set { _isIdentity = value; }
		}
		public bool IsClustered {
			get { return _isClustered; }
			set { _isClustered = value; }
		}
		public bool IsPrimaryKey {
			get { return _isPrimaryKey; }
			set { _isPrimaryKey = value; }
		}
		public int Attndims {
			get { return _attndims; }
			set { _attndims = value; }
		}
		public int Attnum {
			get { return _attnum; }
			set { _attnum = value; }
		}
	}
}
