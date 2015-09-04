using NHibernate;
using NHibernate.Event;
using NHibernate.Exceptions;
using NHibernate.Event.Default;
using NC = NHibernate.Cfg;

using MeaData;
using MEACruncher.Exceptions;
using P = MEACruncher.Properties;

using System;
using System.IO;
using System.Text;
using System.Linq;
using System.Reflection;
using System.Data.Common;
using System.Windows.Forms;
using System.Collections;
using System.Collections.Generic;

using MySql.Data.MySqlClient;

namespace MEACruncher {

    public class DbWrapper {
        // VARIABLES
        private Assembly _assembly;
        private ISessionFactory _sf;
        private ISession _sess;

        // CONSTRUCTORS
        public DbWrapper() { }
        public DbWrapper(Assembly a, string dbName, string version, string importSql) {
            this.Configure(a, dbName, version, importSql);
        }

        // METHODS
        public void Configure(Assembly a, string dbName, string version, string importSql) {
            _assembly = a;

            // Make sure an actual database name and SQL script file were provided
            if (dbName == null || importSql == null)
                throw new ArgumentException("No database name provided");
            if (importSql == null)
                throw new ArgumentException("SQL to import the database schema was not name provided");

            // If this DbWrapper is already configured, then just return            
            bool alreadyConfigured = (_sf != null);
            if (alreadyConfigured)
                return;

            // If not, then make the NHibernate connection, first importing the provided SQL file if necessary
            try {
                connectExistingDb(dbName, version);
            }
            catch (MySqlException) {
                importMySqlDb(dbName, importSql);
                connectExistingDb(dbName, version);
            }
            catch (IncorrectDbVersionException) {
                updateExistingDb(dbName, importSql);
                connectExistingDb(dbName, version);
            }
        }
        public ISession OpenSession() {
            if (_sf == null)
                throw new NullReferenceException("SessionFactory has not been defined.");

            return _sf.OpenSession();
        }

        // HELPER FUNCTIONS
        private void connectExistingDb(string dbName, string curVersion) {
            // Create the connection string for this MySQL database
            string connStr = P.Resources.MySqlConnectionString;
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
            config.AddAssembly(_assembly);

            // Create a SessionFactory with this Configuration
            _sf = config.BuildSessionFactory();

            // If this existing MeaData database is not of the correct version, then throw an exception
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

            // If the db doesnt even have a version table, then also throw an exception
            catch (GenericADOException e) {
                IncorrectDbVersionException ex = new IncorrectDbVersionException(
                    String.Format("The database's version should be {0} but could not be determined", curVersion),
                    "",
                    curVersion,
                    e);
                throw ex;
            }
        }
        private void importMySqlDb(string dbName, string importSql) {
            // Create the connection string for this MySQL database
            string connStr = P.Resources.MySqlConnectionString;
            MySqlConnectionStringBuilder connStrBuilder = new MySqlConnectionStringBuilder(connStr);

            // Create a new database with the provided name
            using (MySqlConnection db = new MySqlConnection(connStrBuilder.ConnectionString)) {
                string sqlStr = "CREATE DATABASE " + dbName;
                using (MySqlCommand createQuery = new MySqlCommand(sqlStr, db)) {
                    db.Open();
                    createQuery.ExecuteNonQuery();
                    db.Close();
                }
            }

            // Import the database schema/data from the provided script
            connStrBuilder.Database = dbName;
            using (MySqlConnection db = new MySqlConnection(connStrBuilder.ConnectionString)) {
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
        private void updateExistingDb(string dbName, string importSql) {
            // Create the connection string for this MySQL database
            string connStr = P.Resources.MySqlConnectionString;
            MySqlConnectionStringBuilder connStrBuilder = new MySqlConnectionStringBuilder(connStr);

            // Remove the old database with the provided name
            using (MySqlConnection db = new MySqlConnection(connStrBuilder.ConnectionString)) {
                string dropSql = "DROP DATABASE " + dbName;
                string createSql = "CREATE DATABASE " + dbName;
                using (MySqlCommand cmd = new MySqlCommand(dropSql, db)) {
                    db.Open();
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = createSql;
                    cmd.ExecuteNonQuery();
                    db.Close();
                }
            }

            // Import the database schema/data from the provided script
            connStrBuilder.Database = dbName;
            using (MySqlConnection db = new MySqlConnection(connStrBuilder.ConnectionString)) {
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