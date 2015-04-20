using NHibernate;
using NHibernate.Cfg;
using Neuro;
using System;
using System.Reflection;
using System.Collections.Generic;

namespace MEACruncher {

    public enum Database {
        MeaData,
    }

    public static class DbManager {
        // VARIABLES
        private static Dictionary<Database, Assembly> _assemblies;
        private static Dictionary<Database, ISessionFactory> _sessionFactories;
        private static bool _initialized;

        // INTERFACE FUNCTIONS
        public static ISessionFactory SessionFactory(Database db) {
            // Initialize this static class, if necessary
            if (!_initialized)
                initialize();

            // Try to get the SessionFactory associated with this database enum
            try {
                return _sessionFactories[db];
            }
            catch (KeyNotFoundException) {
                throw;
            }
        }
        public static ISession StartSessionWith(Database db) {
            // Initialize this static class, if necessary
            if (!_initialized)
                initialize();

            // Open a new NHibernate session with the associated database
            try {
                return _sessionFactories[db].OpenSession();
            }
            catch (KeyNotFoundException) {
                throw;
            }
        }
        public static void ConnectTo(Database db, string filePath) {
            // Initialize this static class, if necessary
            if (!_initialized)
                initialize();

            // Make sure an actual database file was provided
            if (filePath == null)
                return;

            // If this database was already connected to then just return
            if (_sessionFactories.ContainsKey(db))
                return;

            // Define the NHibernate configuration properties for an Access database
            Dictionary<string, string> props = new Dictionary<string, string>();
            props[NHibernate.Cfg.Environment.ConnectionProvider] = @"NHibernate.Connection.DriverConnectionProvider";
            props[NHibernate.Cfg.Environment.Dialect] = @"NHibernate.JetDriver.JetDialect, NHibernate.JetDriver";
            props[NHibernate.Cfg.Environment.ConnectionDriver] = @"NHibernate.JetDriver.JetDriver, NHibernate.JetDriver";
            props[NHibernate.Cfg.Environment.BatchSize] = "50";
            props[NHibernate.Cfg.Environment.ConnectionString] = String.Format(
                @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0}", filePath);
#if DEBUG
                props[NHibernate.Cfg.Environment.ShowSql] = @"true";
#endif

            // Create an NHibernate Configuration with the above properties
            Configuration config = new Configuration();
            config.SetProperties(props);
            config.AddAssembly(_assemblies[db]);

            // Create a SessionFactory with this Configuration and store it in the private Dictionary
            ISessionFactory sf = config.BuildSessionFactory();
            _sessionFactories.Add(db, sf);
        }

        // HELPER FUNCTIONS
        private static void initialize(){
            // Associate Database enums with their respective Assemblies
            _sessionFactories = new Dictionary<Database, ISessionFactory>();
            _assemblies = new Dictionary<Database, Assembly>(){
                { Database.MeaData, typeof(Project).Assembly },
            };

            // Set the initialized flag to true
            _initialized = true;
        }

    }

}