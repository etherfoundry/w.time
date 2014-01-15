using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace w_time.data.schema
{
    abstract class Column
    {
        public enum DataType
        {
            bigint,
            integer,
            smallint,
            tinyint,
            bit,
            numeric,
            money,
            @float,
            real,
            datetime,
            nchar,
            nvarchar,
            ntext,
            binary,
            varbinary,
            image,
            uniqueidentifier
        }

        protected DataType _Type;
        public bool IsIdentity = false;
        public bool IsNullable = false;
        public string @Default = null;
        public bool IsUnique = false;
        public bool IsPrimaryKey = false;
        public int? IdentitySeed;
        public int? IdentityIncrement;
        public string ReferencesTable = null;
        public string ReferencesColumn = null;
        public string Name;

        public DataType Type
        {
            get
            {
                return this._Type;
            }
        }

        public string toColumnDefinition()
        {
            StringBuilder definitionSQL = new StringBuilder();

            definitionSQL.AppendFormat("[{0}] {1} ", this.Name, this.GetColumnTypeString());

            if (this.IsIdentity)
            {
                int seed = 1, increment = 1;
                if (this.IdentityIncrement != null) increment = (int)this.IdentityIncrement;
                if (this.IdentitySeed != null) seed = (int)this.IdentitySeed;

                definitionSQL.AppendFormat("IDENTITY({0},{1}) ", seed, increment);
            }

            if(this.Default != null)
            {
                definitionSQL.AppendFormat("DEFAULT \"{0}\" ", this.Default);
            }

            if (this.IsPrimaryKey)
            {
                definitionSQL.Append("PRIMARY KEY ");
            }

            if (this.ReferencesTable != null && this.ReferencesColumn != null)
            {
                definitionSQL.AppendFormat("REFERENCES {0}({1})", this.ReferencesTable, this.ReferencesColumn);
            }

            return definitionSQL.ToString();
        }

        protected string GetColumnTypeString()
        {
            return this.GetBaseColumnTypeString() + this.GetColumnTypeString();
        }

        protected  string GetBaseColumnTypeString()
        {
            return this._Type.ToString();
        }

        protected virtual string GetColumnTypeSize()
        {
            return string.Empty;
        }
    }
}
