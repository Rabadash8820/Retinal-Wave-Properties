using System;

using NHibernate;
using NUnit.Framework;

using MeaData;

namespace MeaDataTest {

    [TestFixture]
    public class RecordingTest : BaseTest {

        [Test]
        public void CanCreateRecording() {
            using (ITransaction trans = _db.BeginTransaction()) {
                Recording r = new Recording() {
                    Number = 1,
                    MeaColumns = 8,
                    MeaRows = 8,
                    Comments = "A nonexistent test recording"
                };
                _db.Save(r);
                trans.Commit();
            }
        }

    }

}
