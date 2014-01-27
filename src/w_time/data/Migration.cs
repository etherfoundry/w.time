using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace w_time.data
{
    class Migration
    {
        const string MIGRATION_TABLE = "Migration";

        public List<int> GetAppliedMigrationList()
        {
            CreateMigrationTableIfNotExists();
            DAL dal = new DAL();
            return dal.ExecuteListQuery<int>("SELECT VersionNumber FROM Migration", "VersionNumber");
        }

        public void RunMigrations()
        {
            // Get our available migration classes
            List<Type> MigrationTypes = System.Reflection.Assembly.GetExecutingAssembly().GetTypes()
                                .Where(type => type.IsSubclassOf(typeof(BaseMigration))).ToList();

            // Turn them into migration instances; we need to so we can check the version
            List<BaseMigration> AvailableMigrations = new List<BaseMigration>();
            MigrationTypes.ForEach((Type MigrationType) =>
            {
                AvailableMigrations.Add((BaseMigration)Activator.CreateInstance(MigrationType));
            });

            // Get a list of migrations that have already been applied
            List<int> appliedMigrations = this.GetAppliedMigrationList();

            var unappliedMigrations = from avm in AvailableMigrations
                    where !appliedMigrations.Contains(avm.version)
                    orderby avm.version ascending
                    select avm;

            foreach (BaseMigration mig in unappliedMigrations)
            {
                bool migrationSuccessful = false;
                string errorMessage = string.Empty;

                try
                {
                    migrationSuccessful = mig.up();
                }
                catch (Exception ex)
                {
                    errorMessage = ex.Message + "\r\n" + ex.StackTrace;
                }

                if (!migrationSuccessful)
                {
                    // Something went wrong with the last migration..
                    // [insert error logging system here]
                    ErrorLogger.Log("Migration " + mig.name + " failed to run... Stopping migrations! The error message was: \r\n" + errorMessage);
                    break;
                }
                else
                {
                }
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
