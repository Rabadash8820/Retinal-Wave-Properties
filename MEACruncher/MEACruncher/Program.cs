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
#if DEBUG
            MessageBox.Show(
                "Make sure you uncommented lines in the NewEntity and ViewEntities base forms!",
                Application.ProductName,
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button1);
#endif

            // Establish connections with Access databases
            DbManager.ConnectTo(Database.MeaData, Settings.Default.mysqlDbName, P.Resources.meadata);

            // Open the main form
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }

}