using NHibernate;
using NHibernate.Cfg;
using MeaData;
using System;
using System.Reflection;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

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
        public static void ConnectTo(Database db, string dbName) {
            // Initialize this static class, if necessary
            if (!_initialized)
                initialize();

            // Make sure an actual database file was provided
            if (dbName == null)
                return;

            // If this database is already connected, then just return
            bool alreadyConnected = _sessionFactories.ContainsKey(db);
            if (alreadyConnected)
                return;

            // If not, then connect to it if it exists, or create it first
            try {
                connectToExisting(db, dbName);
            }
            catch (MySqlException) {
                connectToNew(db, dbName);
            }
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
        private static void connectToExisting(Database db, string dbName) {
            // Define the NHibernate configuration properties for the MySQL database
            Dictionary<string, string> props = new Dictionary<string, string>();
            props[NHibernate.Cfg.Environment.ConnectionProvider] = @"NHibernate.Connection.DriverConnectionProvider";
            props[NHibernate.Cfg.Environment.Dialect] = @"NHibernate.Dialect.MySQL5Dialect";    // Note the 5
            props[NHibernate.Cfg.Environment.ConnectionDriver] = @"NHibernate.Driver.MySqlDataDriver";
            props[NHibernate.Cfg.Environment.BatchSize] = "50";
            props[NHibernate.Cfg.Environment.ConnectionString] =
                @"Server=localhost;" +
                "Port=3306;" +
                "Database=" + dbName + ";" +
                "Uid=root;" +
                "Pwd=mysqlShundra8820;" +
                "CharSet=utf8;";
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
        private static void connectToNew(Database db, string dbName) {
            // Define the NHibernate configuration properties for the MySQL database
            Dictionary<string, string> props = new Dictionary<string, string>();
            props[NHibernate.Cfg.Environment.ConnectionProvider] = @"NHibernate.Connection.DriverConnectionProvider";
            props[NHibernate.Cfg.Environment.Dialect] = @"NHibernate.Dialect.MySQL5Dialect";    // Note the 5
            props[NHibernate.Cfg.Environment.ConnectionDriver] = @"NHibernate.Driver.MySqlDataDriver";
            props[NHibernate.Cfg.Environment.BatchSize] = "50";
            props[NHibernate.Cfg.Environment.ConnectionString] =
                @"Server=localhost;" +
                "Port=3306;" +
                "Database=" + dbName + ";" +
                "Uid=root;" +
                "Pwd=mysqlShundra8820;" +
                "CharSet=utf8;";
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


    }

}