using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlServerCe;

namespace w_time.data
{
    class DAL
    {
        public bool CheckTableExists(string tableName)
        {
            int resultCount = 0;
            using(SqlCeCommand cmd = this.GetConnection().CreateCommand())
            {
                cmd.CommandText = "SELECT COUNT(*) AS TblCount FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = @tablename";
                cmd.Parameters.AddWithValue("@tablename", tableName);
                resultCount = (int)cmd.ExecuteScalar();
            }
            return resultCount > 0;
        }

        public object ExecuteScalarQuery(string query)
        {
            object result = 0;
            using (SqlCeCommand cmd = this.GetConnection().CreateCommand())
            {
                cmd.CommandText = query;
                result = cmd.ExecuteScalar();
            }
            return result;
        }

        public int ExecuteRawQuery(string query)
        {
            int resultCount = 0;
            using (SqlCeCommand cmd = this.GetConnection().CreateCommand())
            {
                cmd.CommandText = query;
                resultCount = cmd.ExecuteNonQuery();
            }
            return resultCount;
        }

        private SqlCeConnection GetConnection()
        {
            SQLDB.Instance.OpenConnection();
            return SQLDB.Instance.connection;
        }
    }
}
