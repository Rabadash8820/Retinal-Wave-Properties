using NHibernate;
using NUnit.Framework;

using System.Collections.Generic;

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

        [Test]
        public void CanGetTopLevelTissueTypes() {
            // Select top-level TissueTypes from the database (ones with no parent)
            IList<TissueType> entities = _db.QueryOver<TissueType>()
                                            .Where(tt => tt.Parent == null)
                                            .OrderBy(tt => tt.Name).Asc
                                            .List();
            Assert.Greater(entities.Count, 0);

            // Assert that each one has children but no parents
            foreach (TissueType tt in entities) {
                Assert.Null(tt.Parent);
                Assert.Greater(tt.Children.Count, 0);
            }
        }
    }

}
