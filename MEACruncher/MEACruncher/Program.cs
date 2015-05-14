using System;
using System.Windows.Forms;
using MEACruncher.Properties;
using P = MEACruncher.Properties;
using MEACruncher.Forms;

namespace MEACruncher {

    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            // Establish connections with Access databases
            DbManager.ConnectTo(Database.MeaData, Settings.Default.mysqlDbName, P.Resources.meadata);

            // Open the main form
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }

}