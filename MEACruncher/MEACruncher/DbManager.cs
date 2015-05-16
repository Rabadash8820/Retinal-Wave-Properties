using NHibernate;
using NHibernate.Event;
using NHibernate.Event.Default;
using NC = NHibernate.Cfg;
using MeaData;
using MEACruncher.Properties;
using System;
using System.IO;
using System.Text;
using System.Reflection;
using System.Data.Common;
using System.Windows.Forms;
using System.Collections;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace MEACruncher {

    public class DbManager {
        // VARIABLES
        private Assembly _assembly;
        private Stack<object> _stack;
        private ISessionFactory _sf;
        private ISession _sess;

        // CONSTRUCTORS
        public DbManager(Assembly a) {
            _assembly = a;
            _stack = new Stack<object>();
        }

        // EVENT LISTENERS
        private class DeleteListener : IDeleteEventListener {
            public void OnDelete(DeleteEvent e) {
                int derp;
            }
            public void OnDelete(DeleteEvent e, ISet<object> transientEntities) {
                int derp;
            }
        }
        private class RefreshListener : IRefreshEventListener {
            public void OnRefresh(RefreshEvent e) {
                int derp;
            }
            public void OnRefresh(RefreshEvent e, IDictionary refreshedAlready) {
                int derp;
            }
        }
        private class CollectionListener : IInitializeCollectionEventListener {
            public void OnInitializeCollection(InitializeCollectionEvent e) {
                int derp;
            }
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
                if (_sess != null)
                    return _sess;

                if (_sf != null)
                    return _sess = _sf.OpenSession();

                throw new NullReferenceException("SessionFactory has been defined.");
            }
        }
        public void Push(object obj) {
            // Push the object onto this database's stack if...
            if (obj == null ||                                      // The object is non-null
                _assembly != obj.GetType().Assembly ||    // This database deals with persistence objects of this type
                _stack.Contains(obj))                               // It's not already in the database
                return;
            _stack.Push(obj);
        }
        public object Pop() {
            // Pop the next object off this database's stack if...
            if (_stack.Count == 0)    // The stack is non-empty
                return null;
            return _stack.Pop();
        }

        // HELPER FUNCTIONS
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

            // Define event listeners
            IPostLoadEventListener[] loadListeners = new IPostLoadEventListener[] { new PostLoadListener(), new DefaultPostLoadEventListener() };
            IDeleteEventListener[] deleteListeners = new IDeleteEventListener[] { new DeleteListener(), new DefaultDeleteEventListener() };
            IRefreshEventListener[] refreshListeners = new IRefreshEventListener[] { new RefreshListener(), new DefaultRefreshEventListener() };
            IInitializeCollectionEventListener[] collectionListeners = new IInitializeCollectionEventListener[] { new CollectionListener(), new DefaultInitializeCollectionEventListener() };
            IReplicateEventListener[] replicateListeners = new IReplicateEventListener[] { new ReplicateListener(), new DefaultReplicateEventListener() };

            // Create an NHibernate Configuration with the above properties
            NC.Configuration config = new NC.Configuration();
            config.EventListeners.DeleteEventListeners = deleteListeners;
            config.EventListeners.RefreshEventListeners = refreshListeners;
            config.EventListeners.InitializeCollectionEventListeners = collectionListeners;
            config.EventListeners.ReplicateEventListeners = replicateListeners;
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