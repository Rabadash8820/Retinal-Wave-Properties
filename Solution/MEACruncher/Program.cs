using System;
using System.Windows.Forms;
using System.Collections.Generic;

using NHibernate;
using NHibernate.Transform;

using MeaData;
using M = MEACruncher.Properties;
using MEACruncher.Forms;
using MeaData.Util;
using U = MeaData.Util.Properties;
using CommParse;


namespace MEACruncher {

    static class Program {
        public static DbWrapper MeaDataDb;
        public static IList<TissueType> TissueTypes;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args) {
            parseCommandLine(args);

            // Establish connections with MySQL databases
            MeaDataDb = new DbWrapper(
                typeof(Entity).Assembly,
                M.Resources.MeaDataDbName,
                U.Resources.MeaDataDbVersion,
                U.Resources.MeaData);

            // Cache some data
            using (ISession sess = MeaDataDb.OpenSession()) {
                TissueTypes = sess.QueryOver<TissueType>()
                                  .OrderBy(tt => tt.Name).Asc
                                  .Fetch(tt => tt.Children).Eager
                                  .TransformUsing(Transformers.DistinctRootEntity)
                                  .List();
            }

            // Open the main form
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }

        private static void parseCommandLine(string[] args) {
            // Parse command line arguments
            CommLineItemCollection<FlagType, ArgType> items = CommLineItemCollectionBuilder.Get();
            items.Parse(args);

            // Show some dialogs and output to the console in response
            string msg = "";
            if (items.IsHelpSet)
                msg += " help";
            if (items.IsFlagSet(FlagType.Disp1))
                msg += " 1";
            if (items.IsFlagSet(FlagType.Disp2))
                msg += " 2";
            if (items.IsFlagSet(FlagType.Disp3))
                msg += " 3";
            if (items.IsFlagSet(FlagType.DispA))
                msg += " A";
            if (items.IsFlagSet(FlagType.DispB))
                msg += " B";
            if (items.IsFlagSet(FlagType.DispC))
                msg += " C";
            log($"Here's some {msg}!\n{items[ArgType.FileName].Name}: {items[ArgType.FileName].Value}\n{items[ArgType.VersionStr].Name}: {items[ArgType.VersionStr].Value}");
        }
        private static void log(string msg) {
            MessageBox.Show(msg, Application.ProductName);
            Console.WriteLine(msg);
        }
    }

}