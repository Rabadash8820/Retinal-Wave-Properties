using NUnit.Framework;
using MySql.Data.MySqlClient;

using MeaDataTest.Properties;

namespace MeaDataTest {

    [SetUpFixture]
    class TearDownFixture {

        [TearDown]
        public static void DropDb() {
            // Remove the test database
            string connStr = "Server=localhost;Port=3306;CharSet=utf8;User id=root;Pwd=mysqlShundra8820";
            using (MySqlConnection db = new MySqlConnection(connStr)) {
                string dropSql = $"DROP DATABASE {Resources.TestDbName}";
                using (MySqlCommand cmd = new MySqlCommand(dropSql, db)) {
                    db.Open();
                    cmd.ExecuteNonQuery();
                    db.Close();
                }
            }
        }

    }

}
