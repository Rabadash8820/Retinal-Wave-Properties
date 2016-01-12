using NHibernate;
using NUnit.Framework;

using System.Collections.Generic;

using MeaData;

namespace MeaDataTest {

    [TestFixture]
    public class AgeUnitFixture : BaseTestFixture {

        [Test]
        public void CanCrudOnAgeUnits() {
            using (ITransaction trans = _sess.BeginTransaction()) {
                // Assert that there are already some Entities in the database
                int count1 = _sess.QueryOver<AgeUnit>().RowCount();
                Assert.Greater(count1, 1);

                // Create an Entity
                AgeUnit entity = createTransient();
                _sess.Save(entity);
                int count2 = _sess.QueryOver<AgeUnit>().RowCount();
                Assert.AreEqual(count1 + 1, count2);

                // Update the Entity
                entity.Name = "Not jiga watts";
                _sess.Update(entity);

                // Delete the Entity
                _sess.Delete(entity);
                int count3 = _sess.QueryOver<AgeUnit>().RowCount();
                Assert.AreEqual(count1, count3);

                trans.Commit();
            }
        }
        private AgeUnit createTransient() {
            // Define the transient Entity instance
            AgeUnit entity = new AgeUnit() {
                Name = "Jiga watts",
            };

            return entity;
        }

        [Test]
        public void CanCloneAgeUnit() {
            // Define the original Entity and its clone (both transient)
            AgeUnit orig = createTransient();
            AgeUnit clone = orig.Clone() as AgeUnit;

            // Assert that the Entities have the same values...
            Assert.AreEqual(orig.Name, clone.Name);

            // ...but are not the same instance
            Assert.AreNotSame(orig, clone);
        }

    }

}
