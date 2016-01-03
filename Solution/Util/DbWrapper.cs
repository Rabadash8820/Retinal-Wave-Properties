using NHibernate;
using NHibernate.Exceptions;
using NC = NHibernate.Cfg;

using MeaData;
using Util.Exceptions;
using Util.Properties;

using System;
using System.Reflection;
using System.Collections.Generic;

using MySql.Data.MySqlClient;

namespace Util {

    public class DbWrapper {
        // HIDDEN FIELDS
        private Assembly _assembly;
        private ISessionFactory _sf;

        // CONSTRUCTORS
        public DbWrapper() { }
        public DbWrapper(Assembly a, string dbName, string version, string importSql) {
            Configure(a, dbName, version, importSql);
        }

        // INTERFACE FUNCTIONS
        public void Configure(Assembly a, string dbName, string version, string importSql) {
            // If this DbWrapper is already configured, then just return            
            bool alreadyConfigured = (_sf != null);
            if (alreadyConfigured)
                return;

            _assembly = a;

            // Make sure an actual database name and SQL script file were provided
            if (dbName == null || importSql == null)
                throw new ArgumentException("No database name provided", nameof(dbName));
            if (importSql == null)
                throw new ArgumentException("SQL to import the database schema was not name provided", nameof(importSql));

            // Make the NHibernate connection, first importing the provided SQL file if necessary
            try {
                connectExistingDb(dbName, version);
            }
            catch (Exception e) when (e is MySqlException || e is IncorrectDbVersionException){
                // Create a new database with the provided name (replacing the old one if necessary)
                string connStr = Resources.MySqlConnectionString;
                MySqlConnectionStringBuilder connStrBuilder = new MySqlConnectionStringBuilder(connStr);
                bool dropFirst = (e is IncorrectDbVersionException);
                if (dropFirst)
                    dropDb(dbName, connStrBuilder.ConnectionString);
                createDb(dbName, connStrBuilder.ConnectionString);

                // Import the database schema/data with the provided SQL statements
                connStrBuilder.Database = dbName;
                importDb(importSql, connStrBuilder.ConnectionString);

                // Connect to this new database
                connectExistingDb(dbName, version);
            }
        }
        public ISession OpenSession() {
            if (_sf == null)
                throw new NullReferenceException($"{nameof(DbWrapper)} has not yet been configured.");

            return _sf.OpenSession();
        }

        // HELPER FUNCTIONS
        private void connectExistingDb(string dbName, string curVersion) {
            // Create the connection string for this MySQL database
            string connStr = Resources.MySqlConnectionString;
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
            props[NC.Environment.ShowSql] = @"true";
#endif

            // Create an NHibernate Configuration with the above properties
            NC.Configuration config = new NC.Configuration();
            config.SetProperties(props);
            config.AddAssembly(_assembly);

            // Create a SessionFactory with this Configuration and
            // verify that the opened database has the correct version
            _sf = config.BuildSessionFactory();
            checkDbVersion(curVersion);
        }
        private void checkDbVersion(string curVersion) {
            // If this existing database is not of the correct version, then throw an exception
            try {
                using (ISession sess = _sf.OpenSession()) {
                    DbVersion v = sess.QueryOver<DbVersion>().SingleOrDefault();
                    if (v.Version != curVersion) {
                        IncorrectDbVersionException ex = new IncorrectDbVersionException(
                            String.Format("The database's version should be {0} but is {1}", curVersion, v.Version),
                            v.Version,
                            curVersion);
                        throw ex;
                    }
                }
            }

            // If the db doesnt even have a version table, then throw a similar exception
            catch (GenericADOException e) {
                IncorrectDbVersionException ex = new IncorrectDbVersionException(
                    String.Format("The database's version should be {0} but could not be determined", curVersion),
                    "",
                    curVersion,
                    e);
                throw ex;
            }
        }
        private void dropDb(string dbName, string connectionStr) {
            // Create a new database with the provided name
            using (MySqlConnection db = new MySqlConnection(connectionStr)) {
                string dropSql = $"DROP DATABASE {dbName}";
                using (MySqlCommand createQuery = new MySqlCommand(dropSql, db)) {
                    db.Open();
                    createQuery.ExecuteNonQuery();
                    db.Close();
                }
            }
        }
        private void createDb(string dbName, string connectionStr) {
            // Create a new database with the provided name
            using (MySqlConnection db = new MySqlConnection(connectionStr)) {
                string createSql = $"CREATE DATABASE {dbName}";
                using (MySqlCommand createQuery = new MySqlCommand(createSql, db)) {
                    db.Open();
                    createQuery.ExecuteNonQuery();
                    db.Close();
                }
            }
        }
        private static void importDb(string importSql, string connectionStr) {
            using (MySqlConnection db = new MySqlConnection(connectionStr)) {
                using (MySqlCommand cmd = new MySqlCommand()) {
                    using (MySqlBackup backup = new MySqlBackup(cmd)) {
                        cmd.Connection = db;
                        db.Open();
                        backup.ImportFromString(importSql);
                        db.Close();
                    }
                }
            }
        }
        
    }

}
