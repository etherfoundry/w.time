using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data.SqlServerCe;
using w_time.data.helpers;
using w_time.data;

namespace w_time.Systems.ApplicationSetup
{
    class DataEnvironmentSetup
    {
        string FullAppDataPath = string.Empty;
        string FullTimeDBPath = string.Empty;

        public void Initialize()
        {
            CreateApplicationDataFolder();
            CreateBaseDatabase();
        }

        void CreateBaseDatabase()
        {
            SQLDB sql = SQLDB.Instance;
            if (!sql.CheckDatabaseExists())
            {
                sql.CreateDatabase();
            }
        }

        void CreateApplicationDataFolder()
        {
            InitializeAppDataPath();
            if (!Directory.Exists(FullAppDataPath))
            {
                Directory.CreateDirectory(FullAppDataPath);
            }
        }

        private void InitializeAppDataPath()
        {
            if (FullAppDataPath == string.Empty || FullTimeDBPath == string.Empty)
            {
                FullAppDataPath = EnvLibrary.GetAppDataPath();
                FullTimeDBPath = EnvLibrary.GetDBPath();
            }
        }
    }
}
