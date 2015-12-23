using System.Collections.Generic;

using NUnit.Framework;
using NHibernate;
using NC = NHibernate.Cfg;
using MySql.Data.MySqlClient;

using MeaData;
using MeaDataTest.Properties;

namespace MeaDataTest {

    public class BaseTestFixture {
        // HIDDEN FIELDS
        protected ISession _db;
        private static ISessionFactory _sf;

        // CONSTRUCTORS
        public BaseTestFixture() {
            _sf = BuildSessionFactory();
            _db = _sf.OpenSession();
        }

        // INTERFACE FUNCTIONS
        public static ISessionFactory BuildSessionFactory() {
            bool alreadyBuilt = (_sf != null);
            if (alreadyBuilt) return _sf;

            // Create a new database with the provided name
            string connStr = "Server=localhost;Port=3306;CharSet=utf8;User id=root;Pwd=mysqlShundra8820";
            using (MySqlConnection db = new MySqlConnection(connStr)) {
                string sqlStr = "CREATE DATABASE meadata_test";
                using (MySqlCommand createQuery = new MySqlCommand(sqlStr, db)) {
                    db.Open();
                    createQuery.ExecuteNonQuery();
                    db.Close();
                }
            }

            // Import the test database schema/data
            connStr += ";Database=meadata_test";
            using (MySqlConnection db = new MySqlConnection(connStr)) {
                using (MySqlCommand cmd = new MySqlCommand()) {
                    using (MySqlBackup backup = new MySqlBackup(cmd)) {
                        cmd.Connection = db;
                        db.Open();
                        backup.ImportFromString(Resources.MeaDataSql);
                        db.Close();
                    }
                }
            }

            // Define the NHibernate configuration properties for the MySQL database
            Dictionary<string, string> props = new Dictionary<string, string>();
            props[NC.Environment.ConnectionProvider] = @"NHibernate.Connection.DriverConnectionProvider";
            props[NC.Environment.Dialect] = @"NHibernate.Dialect.MySQL5Dialect";    // Note the 5
            props[NC.Environment.ConnectionDriver] = @"NHibernate.Driver.MySqlDataDriver";
            props[NC.Environment.BatchSize] = "50";
            props[NC.Environment.ConnectionString] = connStr;
            props[NC.Environment.ShowSql] = @"true";

            // Create an NHibernate Configuration with the above properties
            NC.Configuration config = new NC.Configuration();
            config.SetProperties(props);
            config.AddAssembly(typeof(Entity).Assembly);

            // Create a SessionFactory with this Configuration
            ISessionFactory sf = config.BuildSessionFactory();
            return sf;
        }

        // HELPER FUNCTIONS
        protected void cloneAsserts(Entity original, Entity clone) {
            // Persist both Entities and assert that they get different Guids
            using (ITransaction trans = _db.BeginTransaction()) {
                _db.Save(clone);
                Assert.AreNotEqual(original.Guid, clone.Guid);
                _db.Delete(clone);

                trans.Commit();
            }
        }
    }

}
