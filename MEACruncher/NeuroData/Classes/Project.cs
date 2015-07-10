using System;
using System.Collections.Generic;

namespace MeaData {

    public class Project : Entity {
        // VARIABLES
        private ISet<Population> _populations;

        // CONSTRUCTORS
        public Project() {
            this.Construct();
        }
        public Project(Guid g) : base(g) {
            this.Construct();
        }

        // PROPERTIES
        public virtual string Name { get; set; }
        public virtual DateTime DateStarted { get; set; }
        public virtual string Comments { get; set; }
        public virtual ISet<Population> Populations {
            get { return _populations; }
        }

        // FUNCTIONS
        private void Construct() {
            _populations = new HashSet<Population>();
        }
        public override object Clone() {
            return Project.Clone(this, new EntityMap());
        }
        internal static Project Clone(Project p, EntityMap map) {
            // If this object is already a key in the map, then set the clone equal to its associated value
            Project clone = null;
            if (map.Contains(p))
                clone = map.GetEntity<Project>(p);
                
            // Otherwise, create its clone and add them as a key/value pair
            else {
                clone = Activator.CreateInstance(p.GetType()) as Project;
                map.Add(p, clone);

                clone.Name = p.Name;
                clone.DateStarted = p.DateStarted;
                clone.Comments = p.Comments;
                foreach (Population pop in p.Populations)
                    clone.Populations.Add(Population.Clone(pop, map));
            }

            // Clone any remaining object members of the object, and return the clone
            return clone;
        }
    }

}