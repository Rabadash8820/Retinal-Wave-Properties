using System;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;

using NHibernate;
using NHibernate.Transform;

using MeaData;
using MEACruncher.Forms;
using Util;
using U = Util.Properties;

namespace MEACruncher {

    static class Program {
        public static DbWrapper MeaDataDb;
        public static IList<TissueType> TissueTypes;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            // Establish connections with MySQL databases
            MeaDataDb = new DbWrapper(
                typeof(Entity).Assembly,
                Properties.Resources.MeaDataDbName,
                U.Resources.MeaDataDbVersion,
                U.Resources.MeaDataSql);

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
    }

}