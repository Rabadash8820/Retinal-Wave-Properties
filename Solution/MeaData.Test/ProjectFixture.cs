using NHibernate;
using NUnit.Framework;

using System.Collections.Generic;

using MeaData;

namespace MeaDataTest {

    [TestFixture]
    public class ProjectFixture : BaseTestFixture {

        [Test]
        public void CanCrudOnProjects() {
            using (ITransaction trans = _sess.BeginTransaction()) {
                int count1 = 0;

                // Create an Entity
                Project entity = createTransient();
                _sess.Save(entity);
                int count2 = _sess.QueryOver<Project>().RowCount();
                Assert.AreEqual(count1 + 1, count2);

                // Update the Entity
                entity.Comments = "An updated comment";
                _sess.Update(entity);

                // Delete the Entity
                _sess.Delete(entity);
                int count3 = _sess.QueryOver<Project>().RowCount();
                Assert.AreEqual(count1, count3);

                trans.Commit();
            }
        }
        private Project createTransient() {
            // Define the transient Entity instance
            Project entity = new Project() {
                Name = "Test Project",
                DateStarted = System.DateTime.Today,
                Comments = "A test project for testing"
            };

            return entity;
        }

        [Test]
        [Ignore("This test only succeeds if Projects have a child collection of Populations")]
        public void CanGetProjectCollections() {
            using (ITransaction trans = _sess.BeginTransaction()) {
                // Create the main Entity
                Project entity = createTransient();
                Population elem1 = new Population();
                //entity.Populations.Add(elem1);
                _sess.Save(entity);

                // Assert that associated Entities are added to db with the Entity (when mapped as such)
                int insCount1 = _sess.QueryOver<Population>().RowCount();
                Assert.AreEqual(1, insCount1);

                // Assert that Entities are removed from db with the Entity (when mapped as such)
                _sess.Delete(entity);
                int delCount1 = _sess.QueryOver<Population>().RowCount();
                Assert.AreEqual(1, delCount1);
                _sess.Delete(elem1);

                trans.Commit();
            }
        }

        [Test]
        public void CanCloneProject() {
            // Define the original Entity and its clone (both transient)
            Project orig = createTransient();
            Project clone = orig.Clone() as Project;
            
            // Assert that the Entities have the same values but are different references
            Assert.AreEqual(orig.Name, clone.Name);
            Assert.AreEqual(orig.DateStarted, clone.DateStarted);
            Assert.AreEqual(orig.Comments, clone.Comments);

            // ...but are not the same instance
            Assert.AreNotSame(orig, clone);
        }

    }

}
