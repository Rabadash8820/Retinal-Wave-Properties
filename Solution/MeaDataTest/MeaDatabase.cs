using System;
using System.Reflection;
using System.Data.Common;
using System.Collections.Generic;

using NUnit.Framework;
using NHibernate;
using NC = NHibernate.Cfg;
using MySql.Data.MySqlClient;

using MeaData;

namespace MeaDataTest {

    [SetUpFixture]
    class MeaDatabase {
        
        private ISessionFactory _sf = null;

        public MeaDatabase() { }
        public ISession OpenSession() {
            return _sf.OpenSession();
        }

        [SetUp]
        public void Build() {
            // Create the connection string for this MySQL database
            string connStr = "Server=localhost;Port=3306;CharSet=utf8;User id=root;Pwd=mysqlShundra8820";
            MySqlConnectionStringBuilder connStrBuilder = new MySqlConnectionStringBuilder(connStr);
            connStrBuilder.Database = "meadata";

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
            config.AddAssembly(typeof(Entity).Assembly);

            // Create a SessionFactory with this Configuration
            _sf = config.BuildSessionFactory();
        }

    }

}
