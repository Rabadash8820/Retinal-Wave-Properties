using NHibernate;
using NC = NHibernate.Cfg;
using MeaData;
using MEACruncher.Properties;
using System;
using System.IO;
using System.Text;
using System.Reflection;
using System.Data.Common;
using System.Windows.Forms;
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
        public static void ConnectTo(Database db, string dbName, string sqlPath) {
            // Initialize this static class, if necessary
            if (!_initialized)
                initialize();

            // Make sure an actual database name and SQL script file were provided
            if (dbName == null || sqlPath == null)
                return;

            // If this database is already connected, then just return
            bool alreadyConnected = _sessionFactories.ContainsKey(db);
            if (alreadyConnected)
                return;

            // If not, then make the NHibernate connection, first importing the provided SQL file if necessary
            try {
                connectExistingDb(db, dbName);
            }
            catch (MySqlException) {
                importMysqlDb(dbName, sqlPath);
                connectExistingDb(db, dbName);
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
        private static void connectExistingDb(Database db, string dbName) {
            // Create the connection string for this MySQL database
            string connStr = Settings.Default.MysqlDbConnectionString;
            MySqlConnectionStringBuilder connStrBuilder = new MySqlConnectionStringBuilder(connStr);
            connStrBuilder.Database = dbName;

            // Define the NHibernate configuration properties for the MySQL database
            Dictionary<string, string> props = new Dictionary<string, string>();
            props[NC.Environment.ConnectionProvider] = @"NHibernate.Connection.DriverConnectionProvider";
            props[NC.Environment.Dialect] = @"NHibernate.Dialect.MySQL5Dialect";    // Note the 5
            props[NC.Environment.ConnectionDriver] = @"NHibernate.Driver.MySqlDataDriver";
            props[NC.Environment.BatchSize] = "50";
            props[NC.Environment.ConnectionString] = connStrBuilder.ConnectionString;
#if DEBUG
            props[NHibernate.Cfg.Environment.ShowSql] = @"true";
#endif

            // Create an NHibernate Configuration with the above properties
            NC.Configuration config = new NC.Configuration();
            config.SetProperties(props);
            config.AddAssembly(_assemblies[db]);

            // Create a SessionFactory with this Configuration and store it in the private Dictionary
            ISessionFactory sf = config.BuildSessionFactory();
            _sessionFactories.Add(db, sf);
        }
        private static void importMysqlDb(string dbName, string sqlPath) {
            // Create the connection string for this MySQL database
            string connStr = Settings.Default.MysqlDbConnectionString;
            MySqlConnectionStringBuilder connStrBuilder = new MySqlConnectionStringBuilder(connStr);
            
            // Create a new database with the provided name
            using (MySqlConnection db = new MySqlConnection(connStrBuilder.ConnectionString)) {
                db.Open();
                MySqlCommand createQuery = new MySqlCommand(
                    "CREATE DATABASE " + dbName,
                    db
                );
                createQuery.ExecuteNonQuery();
            }

            // Import the database schema/data from the provided script
            connStrBuilder.Database = dbName;
            using (MySqlConnection db = new MySqlConnection(connStrBuilder.ConnectionString)) {
                db.Open();
                MySqlScript script = new MySqlScript(db, File.ReadAllText(sqlPath));
                script.Execute();
            }
        }


    }

}