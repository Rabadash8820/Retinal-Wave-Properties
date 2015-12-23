using NHibernate;
using NUnit.Framework;

using MeaData;

namespace MeaDataTest {

    [TestFixture]
    public class RecordingFixture : BaseTestFixture {

        [Test]
        public void CanCrudOnRecordings() {
            // Create an Entity
            Recording entity;
            using (ITransaction trans = _db.BeginTransaction()) {
                entity = new Recording() {
                    Number = 1,
                    MeaColumns = 8,
                    MeaRows = 8,
                    Comments = "A nonexistent test recording"
                };
                _db.Save(entity);
                trans.Commit();
            }

            // Assert that it was stored in the database
            int count = _db.QueryOver<Recording>().RowCount();
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
            count = _db.QueryOver<Recording>().RowCount();
            Assert.AreEqual(0, count);
        }

        [Test]
        public void CanCloneRecording() {
            // Define the original Entity and its clone
            Recording orig = new Recording() {
                MeaColumns = 8,
                MeaRows = 8,
                Number = 1,
                Comments = "This is a derp recording for testing."
            };
            Recording clone = orig.Clone() as Recording;

            // Assert that the Entities have the same values but are different references
            Assert.AreEqual(orig.MeaColumns, clone.MeaColumns);
            Assert.AreEqual(orig.MeaRows, clone.MeaRows);
            Assert.AreEqual(orig.Number, clone.Number);
            Assert.AreEqual(orig.Comments, clone.Comments);
            Assert.AreNotSame(orig, clone);

            // Persist both Entities and assert that they get different Guids
            cloneAsserts(orig, clone);
        }

    }

}
