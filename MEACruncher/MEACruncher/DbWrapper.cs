﻿using NHibernate;
using NHibernate.Event;
using NHibernate.Exceptions;
using NHibernate.Event.Default;
using NC = NHibernate.Cfg;
using MeaData;
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

    public class IncorrectDbVersionException : DbException {
        public IncorrectDbVersionException() : base() { }
        public IncorrectDbVersionException(string message, Exception innerException) : base(message, innerException) { }
    }

    public class DbWrapper {
        // VARIABLES
        private Assembly _assembly;
        private ISessionFactory _sf;
        private ISession _sess;

        // CONSTRUCTORS
        public DbWrapper(Assembly a) {
            this.initialize(a);
        }
        public DbWrapper(Assembly a, string dbName, string importSql) {
            this.initialize(a);
            this.Configure(dbName, importSql);
        }

        // METHODS
        public void Configure(string dbName, string importSql) {
            // Make sure an actual database name and SQL script file were provided
            if (dbName == null || importSql == null)
                return;

            // If this database is already connected, then just return
            bool alreadyConnected = (_sf != null);
            if (alreadyConnected)
                return;

            // If not, then make the NHibernate connection, first importing the provided SQL file if necessary
            try {
                connectExistingDb(dbName);
            }
            catch (MySqlException) {
                importMySqlDb(dbName, importSql);
                connectExistingDb(dbName);
            }
            catch (IncorrectDbVersionException) {
                updateExistingDb(dbName, importSql);
                connectExistingDb(dbName);
            }
        }
        public ISession Session {
            get {
                if (_sess != null && _sess.IsOpen)
                    return _sess;

                if (_sf != null)
                    return _sess = _sf.OpenSession();

                throw new NullReferenceException("SessionFactory has been defined.");
            }
        }

        // HELPER FUNCTIONS
        private void initialize(Assembly a) {
            _assembly = a;
        }
        private void connectExistingDb(string dbName) {
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
            config.AddAssembly(this._assembly);

            // Create a SessionFactory with this Configuration
            _sf = config.BuildSessionFactory();

            // If this existing MeaData database is not of the correct version, then throw an exception
            try {
                using (ISession sess = _sf.OpenSession()) {
                    int count = sess.QueryOver<DbVersion>()
                                    .Where(v => v.Version == P.Resources.MeaDataDbVersion)
                                    .RowCount();
                    if (count != 1)
                        throw new IncorrectDbVersionException();
                }
            }

            // If the db doesnt even have a version table, then also throw an exception
            catch (GenericADOException e) {
                IncorrectDbVersionException odve = new IncorrectDbVersionException("", e);
                throw odve;
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