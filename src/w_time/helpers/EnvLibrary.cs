using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace w_time.data.helpers
{
    class EnvLibrary
    {
        const string APPDATA_DIR = "w_time";
        const string TIMEDB_FILE = "time.sdf";

        public static string GetAppDataPath()
        {
            string AppDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            return Path.Combine(AppDataPath, APPDATA_DIR);
        }

        public static string GetDBPath()
        {
            return Path.Combine(GetAppDataPath(), TIMEDB_FILE);
        }
    }
}
