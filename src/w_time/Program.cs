using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using w_time.Systems.ApplicationSetup;

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

            DataEnvironmentSetup DataSetup = new DataEnvironmentSetup();
            DataSetup.Initialize();

            Application.Run(new Form1());
        }
    }
}
