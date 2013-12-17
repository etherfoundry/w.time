using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace w_time.data
{
    class Migration
    {
        const string MIGRATION_TABLE = "Migration";
        /// <summary>
        /// Checks the current
        /// </summary>
        /// <returns></returns>
        public int CheckMigrationLevel()
        {
            int result = 0;
            CreateMigrationTableIfNotExists();
            DAL dal = new DAL();
            result = (int)dal.ExecuteScalarQuery("SELECT MAX(VersionNumber) FROM Migration");
            return result;
        }

        private bool CheckMigrationTableExists()
        {
            DAL dal = new DAL();
            return dal.CheckTableExists(MIGRATION_TABLE);
        }

        private void CreateMigrationTableIfNotExists()
        {
            DAL dal = new DAL();
            if (!CheckMigrationTableExists())
            {
                // We'll want a better way to do this, but its the only table that cannot be created with migrations
                dal.ExecuteRawQuery("CREATE TABLE [Migration] ([VersionNumber] int NOT NULL, [Name] nvarchar(300) NOT NULL, [ApplyTime] datetime NOT NULL)");
                dal.ExecuteRawQuery("ALTER TABLE [Migration] ADD CONSTRAINT [PK_Migration] PRIMARY KEY ([VersionNumber]);");
            }
        }
    }
}
