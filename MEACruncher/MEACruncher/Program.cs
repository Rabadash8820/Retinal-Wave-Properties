using System;
using MeaData;
using System.Windows.Forms;
using P = MEACruncher.Properties;
using MEACruncher.Forms;

namespace MEACruncher {

    static class Program {
        public static DbWrapper MeaDataDb;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            // Establish connections with MySQL databases
            MeaDataDb = new DbWrapper(typeof(Entity).Assembly);
            MeaDataDb.Configure(P.Settings.Default.MysqlDbName, P.Resources.meadata);

            // Open the main form
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }

}