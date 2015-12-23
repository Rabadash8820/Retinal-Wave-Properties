using NHibernate;
using NUnit.Framework;

using System.Collections.Generic;

using MeaData;

namespace MeaDataTest {

    [TestFixture]
    public class ProjectFixture : BaseTestFixture {

        [Test]
        public void CanCrudOnProjects() {
            using (ITransaction trans = _db.BeginTransaction()) {
                // Create an Entity
                Project entity = new Project() {
                    Name = "Test Project",
                    DateStarted = System.DateTime.Today,
                    Comments = "A test project for testing"
                };
                _db.Save(entity);

                // Assert that it was stored in the database
                int count = _db.QueryOver<Project>().RowCount();
                Assert.AreEqual(1, count);

                // Update the Entity
                entity.Comments = "An updated comment";
                _db.Update(entity);

                // Delete the Entity
                _db.Delete(entity);

                // Assert that there are no more of this Entity in the database
                count = _db.QueryOver<Project>().RowCount();
                Assert.AreEqual(0, count);

                trans.Commit();
            }
        }

        [Test]
        public void CanGetProjectPopulations() {
            using (ITransaction trans = _db.BeginTransaction()) {
                // Create an Entity
                Project entity = new Project() {
                    Name = "Test Project",
                    DateStarted = System.DateTime.Today,
                    Comments = "A test project for testing"
                };
                entity.Populations.Add(new Population());
                _db.Save(entity);

                // Assert that it has no children (but property can still be fetched)
                int count = _db.Load<Project>(entity.Guid).Populations.Count;
                Assert.AreEqual(1, count);

                trans.Commit();
            }
        }

        [Test]
        public void CanCloneProject() {
            // Define the original Entity and its clone
            Project orig = new Project() {
                Name = "Derp Project",
                DateStarted = System.DateTime.Today,
                Comments = "This is a derp project for testing."
            };
            Project clone = orig.Clone() as Project;
            
            // Assert that the Entities have the same values but are different references
            Assert.AreEqual(orig.Name, clone.Name);
            Assert.AreEqual(orig.DateStarted, clone.DateStarted);
            Assert.AreEqual(orig.Comments, clone.Comments);
            Assert.AreNotSame(orig, clone);

            // Persist both Entities and assert that they get different Guids
            cloneAsserts(orig, clone);
        }

    }

}
