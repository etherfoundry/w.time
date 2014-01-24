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
            object queryResult = dal.ExecuteScalarQuery("SELECT MAX(VersionNumber) AS VersionNumber FROM Migration");
            if (queryResult != null && !(queryResult is DBNull))
            {
                result = (int)queryResult;
            }
            return result;
        }

        public void GetMigrations()
        {
            List<Type> MigrationTypes = System.Reflection.Assembly.GetExecutingAssembly().GetTypes()
                                .Where(type => type.IsSubclassOf(typeof(BaseMigration))).ToList();

            foreach (Type MigrationType in MigrationTypes)
            {
                BaseMigration migration = (BaseMigration)Activator.CreateInstance(MigrationType);
                migration.up();
            }
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
