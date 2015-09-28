using System;
using System.Windows.Forms;

using MeaData;
using MEACruncher.Forms;
using P = MEACruncher.Properties;
using Util;

namespace MEACruncher {

    static class Program {
        public static DbWrapper MeaDataDb;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            // Establish connections with MySQL databases
            MeaDataDb = new DbWrapper(
                typeof(Entity).Assembly,
                P.Resources.MeaDataDbName,
                P.Resources.MeaDataDbVersion,
                P.Resources.MeaDataSql);

            System.Collections.Generic.List<int> intList = new System.Collections.Generic.List<int>();
            System.ComponentModel.BindingList<int> intBindList = new System.ComponentModel.BindingList<int>(intList);
            BindingSource bs = new BindingSource(intList, null);
            bool canSort = bs.SupportsSorting;

            // Open the main form
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }

}