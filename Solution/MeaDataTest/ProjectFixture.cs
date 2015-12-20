using NHibernate;
using NUnit.Framework;

using MeaData;

namespace MeaDataTest {

    [TestFixture]
    public class ProjectFixture : BaseTestFixture {

        [Test]
        public void CanCrudOnProjects() {
            // Create an Entity
            Project entity;
            using (ITransaction trans = _db.BeginTransaction()) {
                entity = new Project() {
                    Name = "Test Project",
                    DateStarted = System.DateTime.Today,
                    Comments = "A test project for testing"
                };
                _db.Save(entity);
                trans.Commit();
            }

            // Assert that it was stored in the database
            int count = _db.QueryOver<Project>().RowCount();
            Assert.AreEqual(1, count);

            // Update the Entity
            using (ITransaction trans = _db.BeginTransaction()) {
                entity.Comments = "An updated comment";
                _db.Update(entity);
                trans.Commit();
            }

            // Delete the Entity
            using (ITransaction trans = _db.BeginTransaction()) {
                _db.Delete(entity);
                trans.Commit();
            }

            // Assert that there are no more of this Entity in the database
            count = _db.QueryOver<Project>().RowCount();
            Assert.AreEqual(0, count);
        }

    }

}
