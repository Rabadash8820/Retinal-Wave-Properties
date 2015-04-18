using System;
using System.Collections.Generic;

namespace Neuro {

    public class Recording : Entity {
        // VARIABLES
        private ISet<Channel> _channels;
        private ISet<ProjectRecording> _projectRecordings;

        // CONSTRUCTORS
        public Recording() {
            this.Construct();
        }
        public Recording(Guid g) : base(g) {
            this.Construct();
        }

        // PROPERTIES
        public virtual string FilePath { get; set; }
        public virtual TissueCondition TissueCondition { get; set; }
        public virtual int Number { get; set; }
        public virtual int MeaRows { get; set; }
        public virtual int MeaColumns { get; set; }
        public virtual string Comments { get; set; }
        public virtual ISet<Channel> Channels {
            get { return _channels; }
        }
        public virtual ISet<ProjectRecording> ProjectRecordings {
            get { return _projectRecordings; }
        }

        // FUNCTIONS
        private void Construct() {
            _channels = new HashSet<Channel>();
            _projectRecordings = new HashSet<ProjectRecording>();
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

                clone.FilePath = r.FilePath;
                clone.Number = r.Number;
                clone.MeaRows = r.MeaRows;
                clone.MeaColumns = r.MeaColumns;
                clone.Comments = r.Comments;
                foreach (Channel ch in r.Channels)
                    clone.Channels.Add(Channel.Clone(ch, map));
                foreach (ProjectRecording pr in r.ProjectRecordings)
                    clone.ProjectRecordings.Add(ProjectRecording.Clone(pr, map));
            }

            // Clone any remaining object members of the object, and return the clone
            clone.TissueCondition = map.GetEntity<TissueCondition>(r.TissueCondition); 
            return clone;
        }
    }

}