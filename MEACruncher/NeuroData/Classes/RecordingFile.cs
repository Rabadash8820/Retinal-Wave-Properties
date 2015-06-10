using System;
using System.Collections.Generic;

namespace MeaData {

    public class RecordingFile : Entity {
        // CONSTRUCTORS
        public RecordingFile() {
            this.Construct();
        }
        public RecordingFile(Guid g) : base(g) {
            this.Construct();
        }

        // PROPERTIES
        public virtual Recording Recording { get; set; }
        public virtual int Number { get; set; }
        public virtual string FileDir { get; set; }

        // FUNCTIONS
        private void Construct() { }
        public override object Clone() {
            return RecordingFile.Clone(this, new EntityMap());
        }
        internal static RecordingFile Clone(RecordingFile rf, EntityMap map) {
            // If this object is already a key in the map, then set the clone equal to its associated value
            RecordingFile clone = null;
            if (map.Contains(rf))
                clone = map.GetEntity<RecordingFile>(rf);

            // Otherwise, create its clone and add them as a key/value pair
            else {
                clone = Activator.CreateInstance(rf.GetType()) as RecordingFile;
                map.Add(rf, clone);

                clone.Number = rf.Number;
                clone.FileDir = rf.FileDir;
            }

            // Clone any remaining object members of the object, and return the clone
            clone.Recording = map.GetEntity<Recording>(Recording.Clone(rf.Recording, map));
            return clone;
        }
    }

}