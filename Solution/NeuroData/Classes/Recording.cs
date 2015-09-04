using System;
using System.Collections.Generic;

namespace MeaData {

    public class Recording : Entity {
        // VARIABLES
        private ISet<RecordingFile> _files;
        private ISet<Channel> _channels;

        // CONSTRUCTORS
        public Recording() {
            this.Construct();
        }
        public Recording(Guid g) : base(g) {
            this.Construct();
        }

        // PROPERTIES
        public virtual Tissue Tissue { get; set; }
        public virtual Condition Condition { get; set; }
        public virtual int Number { get; set; }
        public virtual int MeaRows { get; set; }
        public virtual int MeaColumns { get; set; }
        public virtual string Comments { get; set; }
        public virtual ISet<RecordingFile> Files {
            get { return _files; }
        }
        public virtual ISet<Channel> Channels {
            get { return _channels; }
        }

        // FUNCTIONS
        private void Construct() {
            _files = new HashSet<RecordingFile>();
            _channels = new HashSet<Channel>();
        }
        public override object Clone() {
            return Recording.Clone(this, new EntityMap());
        }
        internal static Recording Clone(Recording r, EntityMap map) {
            // If this object is already a key in the map, then set the clone equal to its associated value
            Recording clone = null;
            if (map.Contains(r))
                clone = map.GetEntity<Recording>(r);

            // Otherwise, create its clone and add them as a key/value pair
            else {
                clone = Activator.CreateInstance(r.GetType()) as Recording;
                map.Add(r, clone);

                clone.Number = r.Number;
                clone.MeaRows = r.MeaRows;
                clone.MeaColumns = r.MeaColumns;
                clone.Comments = r.Comments;
                foreach (RecordingFile rf in r.Files)
                    clone.Files.Add(RecordingFile.Clone(rf, map));
                foreach (Channel ch in r.Channels)
                    clone.Channels.Add(Channel.Clone(ch, map));
            }

            // Clone any remaining object members of the object, and return the clone
            clone.Tissue = map.GetEntity<Tissue>(r.Tissue);
            clone.Condition = map.GetEntity<Condition>(r.Condition);
            return clone;
        }
    }

}