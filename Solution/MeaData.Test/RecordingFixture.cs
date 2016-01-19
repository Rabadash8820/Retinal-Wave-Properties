using NHibernate;
using NUnit.Framework;

using MeaData;

namespace MeaDataTest {

    [TestFixture]
    public class RecordingFixture : BaseTestFixture {

        [Test]
        public void CanCrudOnRecordings() {
            using (ITransaction trans = _sess.BeginTransaction()) {
                int count1 = 0;

                // Create an Entity
                Recording entity = createTransient();
                _sess.Save(entity);
                int count2 = _sess.QueryOver<Recording>().RowCount();
                Assert.AreEqual(count1 + 1, count2);

                // Update the Entity
                entity.Comments = "An updated comment";
                _sess.Update(entity);

                // Delete the Entity
                _sess.Delete(entity);
                int count3 = _sess.QueryOver<Recording>().RowCount();
                Assert.AreEqual(count1, count3);

                trans.Commit();
            }
        }
        private Recording createTransient() {
            // Define the transient Entity instance
            Recording entity = new Recording() {
                Number = 1,
                Comments = "A nonexistent test recording"
            };

            return entity;
        }

        [Test]
        public void CanGetRecordingCollections() {
            using (ITransaction trans = _sess.BeginTransaction()) {
                // Create the main Entity
                Recording entity = createTransient();
                RecordingFile elem1 = new RecordingFile();
                Channel elem2 = new Channel();
                Condition elem3 = new Condition();
                entity.Files.Add(elem1);
                entity.Channels.Add(elem2);
                entity.Conditions.Add(elem3);
                _sess.Save(entity);

                // Assert that associated Entities are added to db with the Entity (when mapped as such)
                int insCount1 = _sess.QueryOver<RecordingFile>().RowCount();
                int insCount2 = _sess.QueryOver<Channel>().RowCount();
                int insCount3 = _sess.QueryOver<Condition>().RowCount();
                Assert.AreEqual(1, insCount1);
                Assert.AreEqual(1, insCount2);
                Assert.AreEqual(1, insCount3);

                // Assert that Entities are removed from db with the Entity (when mapped as such)
                _sess.Delete(entity);
                int delCount1 = _sess.QueryOver<RecordingFile>().RowCount();
                int delCount2 = _sess.QueryOver<Channel>().RowCount();
                int delCount3 = _sess.QueryOver<Condition>().RowCount();
                Assert.AreEqual(0, delCount1);
                Assert.AreEqual(0, delCount2);
                Assert.AreEqual(1, delCount3);
                _sess.Delete(elem3);

                trans.Commit();
            }
        }

        [Test]
        public void CanCloneRecording() {
            // Define the original Entity and its clone (both transient)
            Recording orig = createTransient();
            Recording clone = orig.Clone() as Recording;

            // Assert that the Entities have the same values but are different references
            Assert.AreEqual(orig.Mea, clone.Mea);
            Assert.AreEqual(orig.Number, clone.Number);
            Assert.AreEqual(orig.Comments, clone.Comments);

            // ...but are not the same instance
            Assert.AreNotSame(orig, clone);
        }

    }

}
