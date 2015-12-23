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
            // Select the Entity
            TissueType forebrain = _db.QueryOver<TissueType>()
                                      .WhereRestrictionOn(tt => tt.Name).IsLike("%Prosencephalon%")
                                      .SingleOrDefault();
            Assert.NotNull(forebrain);

            // Select its children
            Assert.Greater(forebrain.Children.Count, 1);
        }

        [Test]
        public void CanGetTissueTypeParent() {
            // Select the Entity
            TissueType forebrain = _db.QueryOver<TissueType>()
                                      .WhereRestrictionOn(tt => tt.Name).IsLike("%Prosencephalon%")
                                      .SingleOrDefault();
            Assert.NotNull(forebrain);

            // Select its parent
            Assert.NotNull(forebrain.Parent);
        }

        [Test]
        public void CanGetTopLevelTissueTypes() {
            // Select top-level Entities from the database (ones with no parent)
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

        [Test]
        public void CanCloneTissueType() {
            // Select an Entity and clone it
            TissueType forebrain = _db.QueryOver<TissueType>()
                                      .WhereRestrictionOn(tt => tt.Name).IsLike("%Prosencephalon%")
                                      .SingleOrDefault();
            TissueType clone = forebrain.Clone() as TissueType;

            // Assert that the Entities have the same values...
            Assert.AreEqual(forebrain.Name, clone.Name);
            Assert.AreEqual(forebrain.Comments, clone.Comments);
            Assert.AreEqual(forebrain.Children.Count, clone.Children.Count);
            Assert.NotNull(clone.Parent);
            Assert.AreNotSame(forebrain.Parent, clone.Parent);

            // ...but are different references
            Assert.AreNotSame(forebrain, clone);

            // Assert that the clone gets a different Guid when persisted
            cloneAsserts(forebrain, clone);
        }
    }

}
