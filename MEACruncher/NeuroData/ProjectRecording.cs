using System;
using System.Collections.Generic;

namespace Neuro {

    public class ProjectRecording : Entity {
        // CONSTRUCTORS
        public ProjectRecording() {
            this.Construct();
        }
        public ProjectRecording(Guid g) : base(g) {
            this.Construct();
        }

        // PROPERTIES
        public virtual Project Project { get; set; }
        public virtual Recording Recording { get; set; }
        public virtual bool IsOriginal { get; set; }

        // FUNCTIONS
        private void Construct() { }
        public override object Clone() {
            return ProjectRecording.Clone(this, new EntityMap());
        }
        internal static ProjectRecording Clone(ProjectRecording pr, EntityMap map) {
            // If this object is already a key in the map, then set the clone equal to its associated value
            ProjectRecording clone = null;
            if (map.Contains(pr))
                clone = map.GetEntity<ProjectRecording>(pr);

            // Otherwise, create its clone and add them as a key/value pair
            else {
                clone = Activator.CreateInstance(pr.GetType()) as ProjectRecording;
                map.Add(pr, clone);

                clone.IsOriginal = pr.IsOriginal;
            }

            // Clone any remaining object members of the object, and return the clone
            clone.Project = map.GetEntity<Project>(pr.Project);
            clone.Recording = map.GetEntity<Recording>(pr.Recording);
            return clone;
        }
    }

}