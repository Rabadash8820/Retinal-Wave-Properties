using NHibernate;
using NUnit.Framework;

namespace MeaDataTest {

    public class BaseTest {

        protected ISession _db;

        public BaseTest() {            
            _db = (new MeaDatabase()).OpenSession();
        }

    }

}
