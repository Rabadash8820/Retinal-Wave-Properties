using System;
using System.Windows.Forms;
using MEACruncher.Properties;

namespace MEACruncher {

    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            // Establish connections with Access databases
            DbManager.ConnectTo(Database.MeaData, Resources.DbName, Resources.DbScriptName);

            // Open the main form
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }

}