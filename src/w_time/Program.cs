using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using w_time.Systems.ApplicationSetup;
using w_time.data;

namespace w_time
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Initialize database environment if its not present
            DataEnvironmentSetup DataSetup = new DataEnvironmentSetup();
            DataSetup.Initialize();

            // Check and run migrations if necessary
            Migration migration = new Migration();
            migration.CheckMigrationLevel();

            Application.Run(new Form1());
        }
    }
}
