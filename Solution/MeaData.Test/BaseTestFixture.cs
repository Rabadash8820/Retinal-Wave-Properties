using NHibernate;

using MeaData;
using MeaData.Util;
using U = MeaData.Util.Properties;
using T = MeaData.Test.Properties;

namespace MeaDataTest {

    public class BaseTestFixture {
        // HIDDEN FIELDS
        protected ISession _sess;

        // CONSTRUCTORS
        public BaseTestFixture() {
            DbWrapper dbw = new DbWrapper(
                typeof(Entity).Assembly,
                T.Resources.TestDbName,
                U.Resources.MeaDataDbVersion,
                U.Resources.MeaData);
            _sess = dbw.OpenSession();
        }

        // HELPER FUNCTIONS

    }

}
