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

        /// <summary>
        /// Returns a column result set as a list of the specified type (via cast, omitting NULLs)
        /// </summary>
        /// <typeparam name="T">Cast to this return type</typeparam>
        /// <param name="query">Query to execute</param>
        /// <param name="columnName">Column (name) to return</param>
        /// <returns></returns>
        public List<T> ExecuteListQuery<T>(string query, string columnName)
        {
            using (SqlCeCommand cmd = this.GetConnection().CreateCommand())
            {
                List<T> result = new List<T>();
                cmd.CommandText = query;
                SqlCeResultSet rs = cmd.ExecuteResultSet(ResultSetOptions.None);
                int ordinal = rs.GetOrdinal(columnName);

                while (rs.Read())
                {
                    if (!rs.IsDBNull(ordinal))
                    {
                        result.Add((T)rs.GetValue(ordinal));
                    }
                }
                
                return result;
            }
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
