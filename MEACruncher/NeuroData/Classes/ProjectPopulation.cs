using System;
using System.Collections.Generic;

namespace MeaData {

    public class ProjectPopulation : Entity {
        // CONSTRUCTORS
        public ProjectPopulation() {
            this.Construct();
        }
        public ProjectPopulation(Guid g) : base(g) {
            this.Construct();
        }

        // PROPERTIES
        public virtual Project Project { get; set; }
        public virtual Population Population { get; set; }
        public virtual bool IsOriginal { get; set; }

        // FUNCTIONS
        private void Construct() { }
        public override object Clone() {
            return ProjectPopulation.Clone(this, new EntityMap());
        }
        internal static ProjectPopulation Clone(ProjectPopulation pp, EntityMap map) {
            // If this object is already a key in the map, then set the clone equal to its associated value
            ProjectPopulation clone = null;
            if (map.Contains(pp))
                clone = map.GetEntity<ProjectPopulation>(pp);

            // Otherwise, create its clone and add them as a key/value pair
            else {
                clone = Activator.CreateInstance(pp.GetType()) as ProjectPopulation;
                map.Add(pp, clone);

                clone.IsOriginal = pp.IsOriginal;
            }

            // Clone any remaining object members of the object, and return the clone
            clone.Project = map.GetEntity<Project>(pp.Project);
            clone.Population = map.GetEntity<Population>(pp.Population);
            return clone;
        }
    }

}