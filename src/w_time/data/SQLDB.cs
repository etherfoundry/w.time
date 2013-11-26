using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data.SqlServerCe;
using w_time.data.helpers;

namespace w_time.data
{
    // Singleton SQLCE connection
    class SQLDB
    {
        private static readonly SQLDB _instance = new SQLDB();
        private static SqlCeConnection connection;

        private SQLDB()
        {
            connection = new SqlCeConnection(GetConnectionString());
        }

        public static SQLDB Instance
        {
            get
            {
                return _instance;
            }
        }

        public bool CheckDatabaseExists()
        {
            return File.Exists(EnvLibrary.GetDBPath());
        }

        public string GetConnectionString()
        {
            return "DataSource=" + EnvLibrary.GetDBPath();
        }

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
