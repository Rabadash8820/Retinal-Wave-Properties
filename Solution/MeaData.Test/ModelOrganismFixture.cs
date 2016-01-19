using NHibernate;
using NUnit.Framework;

using System.Collections.Generic;

using MeaData;

namespace MeaDataTest {

    [TestFixture]
    public class ModelOrganismFixture : BaseTestFixture {

        [Test]
        public void CanCrudOnModelOrganisms() {
            using (ITransaction trans = _sess.BeginTransaction()) {
                // Assert that there are already some Entities in the database
                int count1 = _sess.QueryOver<ModelOrganism>().RowCount();
                Assert.Greater(count1, 1);

                // Create an Entity
                ModelOrganism entity = createTransient();
                _sess.Save(entity);
                int count2 = _sess.QueryOver<ModelOrganism>().RowCount();
                Assert.AreEqual(count1 + 1, count2);

                // Update the Entity
                entity.Comments = "An updated comment";
                _sess.Update(entity);

                // Delete the Entity
                _sess.Delete(entity);
                int count3 = _sess.QueryOver<ModelOrganism>().RowCount();
                Assert.AreEqual(count1, count3);

                trans.Commit();
            }
        }
        private ModelOrganism createTransient() {
            // Define the transient Entity instance
            ModelOrganism entity = new ModelOrganism() {
                ScientificName = "Herpicus derpii",
                CommonName = "The common derp",
                Category = "Derp animals",
                Comments = "A made-up, derp-like organism"
            };

            return entity;
        }

        [Test]
        public void CanGetModelOrganismCollections() {
            using (ITransaction trans = _sess.BeginTransaction()) {
                // Create the main Entity
                ModelOrganism entity = createTransient();
                Strain elem1 = new Strain();
                entity.Strains.Add(elem1);
                _sess.Save(entity);

                // Assert that associated Entities are added to db with the Entity (when mapped as such)
                int insCount1 = _sess.QueryOver<Strain>().RowCount();
                Assert.AreEqual(1, insCount1);

                // Assert that Entities are removed from db with the Entity (when mapped as such)
                _sess.Delete(entity);
                int delCount1 = _sess.QueryOver<Strain>().RowCount();
                Assert.AreEqual(0, delCount1);

                trans.Commit();
            }
        }

        [Test]
        public void CanCloneModelOrganism() {
            // Define the original Entity and its clone (both transient)
            ModelOrganism orig = createTransient();
            ModelOrganism clone = orig.Clone() as ModelOrganism;

            // Assert that the Entities have the same values...
            Assert.AreEqual(orig.ScientificName, clone.ScientificName);
            Assert.AreEqual(orig.CommonName, clone.CommonName);
            Assert.AreEqual(orig.Category, clone.Category);
            Assert.AreEqual(orig.Comments, clone.Comments);

            // ...but are not the same instance
            Assert.AreNotSame(orig, clone);
        }

    }

}
