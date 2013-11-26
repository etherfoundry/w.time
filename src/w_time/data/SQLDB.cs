using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data.SqlServerCe;
using w_time.data.helpers;

namespace w_time.data
{
    /// <summary>
    /// Singleton SQLCE connection
    /// </summary>
    class SQLDB
    {
        private static readonly SQLDB _instance = new SQLDB();
        private static SqlCeConnection connection;

        private SQLDB()
        {
            connection = new SqlCeConnection(GetConnectionString());
        }

        /// <summary>
        /// Singleton instance of SQLCE management object (including connection)
        /// </summary>
        public static SQLDB Instance
        {
            get
            {
                return _instance;
            }
        }

        /// <summary>
        /// Checks if a file exists where the SQLCE DB is expected to be
        /// </summary>
        /// <returns></returns>
        public bool CheckDatabaseExists()
        {
            return File.Exists(EnvLibrary.GetDBPath());
        }

        /// <summary>
        /// Gets the (currently static) SQLCE connection string
        /// </summary>
        /// <returns>Connection String</returns>
        private string GetConnectionString()
        {
            return "DataSource=" + EnvLibrary.GetDBPath();
        }

        /// <summary>
        /// Creates an empty SQLCE database if it does not exist
        /// </summary>
        public void CreateDatabase()
        {
            if (!CheckDatabaseExists())
            {
                using (SqlCeEngine engine = new SqlCeEngine(GetConnectionString()))
                {
                    engine.CreateDatabase();
                }
            }
            else
            {
                throw new DatabaseExistsException();
            }
        }
    }
}
