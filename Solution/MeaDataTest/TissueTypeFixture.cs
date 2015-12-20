using NHibernate;
using NUnit.Framework;

using MeaData;

namespace MeaDataTest {

    [TestFixture]
    public class TissueTypeFixture : BaseTestFixture {

        [Test]
        public void CanReadTissueTypes() {
            // Assert that TissueTypes can be read from the database
            int count = _db.QueryOver<TissueType>().RowCount();
            Assert.Greater(count, 1);
        }

        [Test]
        public void CanGetTissueTypeChildren() {
            // Select the Forebrain tissue type
            TissueType forebrain = _db.QueryOver<TissueType>()
                                      .WhereRestrictionOn(tt => tt.Name).IsLike("%Prosencephalon%")
                                      .SingleOrDefault();
            Assert.NotNull(forebrain);

            // Select its children
            Assert.Greater(forebrain.Children.Count, 1);
        }

        [Test]
        public void CanGetTissueTypeParent() {
            // Select the Forebrain tissue type
            TissueType forebrain = _db.QueryOver<TissueType>()
                                      .WhereRestrictionOn(tt => tt.Name).IsLike("%Prosencephalon%")
                                      .SingleOrDefault();
            Assert.NotNull(forebrain);

            // Select its parent
            Assert.NotNull(forebrain.Parent);
        }
    }

}
