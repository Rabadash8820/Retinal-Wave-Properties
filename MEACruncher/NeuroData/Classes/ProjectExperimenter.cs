using System;
using System.Collections.Generic;

namespace MeaData {

    public class ProjectExperimenter : Entity {
        // CONSTRUCTORS
        public ProjectExperimenter() {
            this.Construct();
        }
        public ProjectExperimenter(Guid g) : base(g) {
            this.Construct();
        }

        // PROPERTIES
        public virtual Project Project { get; set; }
        public virtual Experimenter Experimenter { get; set; }
        public virtual DateTime StartDate { get; set; }
        public virtual DateTime EndDate { get; set; }
        public virtual bool IsManager { get; set; }

        // FUNCTIONS
        private void Construct() { }
        public override object Clone() {
            return ProjectExperimenter.Clone(this, new EntityMap());
        }
        internal static ProjectExperimenter Clone(ProjectExperimenter pe, EntityMap map) {
            // If this object is already a key in the map, then set the clone equal to its associated value
            ProjectExperimenter clone = null;
            if (map.Contains(pe))
                clone = map.GetEntity<ProjectExperimenter>(pe);

            // Otherwise, create its clone and add them as a key/value pair
            else {
                clone = Activator.CreateInstance(pe.GetType()) as ProjectExperimenter;
                map.Add(pe, clone);

                clone.StartDate = pe.StartDate;
                clone.EndDate = pe.EndDate;
                clone.IsManager = pe.IsManager;
            }

            // Clone any remaining object members of the object, and return the clone
            clone.Project = map.GetEntity<Project>(pe.Project);
            clone.Experimenter = map.GetEntity<Experimenter>(pe.Experimenter);
            return clone;
        }
    }

}