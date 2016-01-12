using NUnit.Framework;
using NHibernate;

using Util;
using U = Util.Properties;
using MeaData;
using MeaDataTest.Properties;

namespace MeaDataTest {

    public class BaseTestFixture {
        // HIDDEN FIELDS
        protected ISession _sess;

        // CONSTRUCTORS
        public BaseTestFixture() {
            DbWrapper dbw = new DbWrapper(
                typeof(Entity).Assembly,
                Resources.TestDbName,
                U.Resources.MeaDataDbVersion,
                U.Resources.MeaData);
            _sess = dbw.OpenSession();
        }

        // HELPER FUNCTIONS

    }

}
