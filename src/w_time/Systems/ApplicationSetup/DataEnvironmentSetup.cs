using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data.SqlServerCe;

namespace w_time.Systems.ApplicationSetup
{
    class DataEnvironmentSetup
    {
        const string APPDATA_DIR = "w_time";
        const string TIMEDB_FILE = "time.sdf";
        string FullAppDataPath = string.Empty;
        string FullTimeDBPath = string.Empty;

        public void Initialize()
        {
            CreateApplicationDataFolder();
            CreateBaseDatabase();
        }

        void CreateBaseDatabase()
        {
            InitializeAppDataPath();
            if (!File.Exists(FullTimeDBPath))
            {
                string connStr = "DataSource=" + FullTimeDBPath;
                using(SqlCeEngine engine = new SqlCeEngine(connStr))
                {
                    engine.CreateDatabase();
                }
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
                string AppDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                FullAppDataPath = Path.Combine(AppDataPath, APPDATA_DIR);
                FullTimeDBPath = Path.Combine(FullAppDataPath, TIMEDB_FILE);
            }
        }
    }
}
