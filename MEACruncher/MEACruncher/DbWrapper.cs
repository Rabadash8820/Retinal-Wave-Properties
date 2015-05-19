﻿using NHibernate;
using NHibernate.Event;
using NHibernate.Event.Default;
using NC = NHibernate.Cfg;
using MeaData;
using MEACruncher.Properties;
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
        public DbWrapper(Assembly a) {
            this.initialize(a);
        }

        // METHODS
        public void Configure(string dbName, string sqlPath) {
            // Make sure an actual database name and SQL script file were provided
            if (dbName == null || sqlPath == null)
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
                importMySqlDb(dbName, sqlPath);
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
            config.AddAssembly(this._assembly);

            // Create a SessionFactory with this Configuration
            _sf = config.BuildSessionFactory();
        }
        private void importMySqlDb(string dbName, string sqlPath) {
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