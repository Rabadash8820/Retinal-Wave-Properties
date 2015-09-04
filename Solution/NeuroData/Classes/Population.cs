using System;
using System.Collections.Generic;

namespace MeaData {

    public class Population : Entity {
        // VARIABLES
        private ISet<Tissue> _tissues;
        private ISet<Project> _projects;

        // CONSTRUCTORS
        public Population() {
            this.Construct();
        }
        public Population(Guid g) : base(g) {
            this.Construct();
        }

        // PROPERTIES
        public virtual TissueType TissueType { get; set; }
        public virtual Strain Strain { get; set; }
        public virtual double Age { get; set; }
        public virtual AgeUnit AgeUnit { get; set; }
        public virtual Condition Condition { get; set; }
        public virtual string Comments { get; set; }
        public virtual ISet<Tissue> Tissues {
            get { return _tissues; }
        }
        public virtual ISet<Project> Projects {
            get { return _projects; }
        }

        // FUNCTIONS
        private void Construct(){
            _tissues = new HashSet<Tissue>();
            _projects = new HashSet<Project>();
        }
        public override object Clone() {
            return Population.Clone(this, new EntityMap());
        }
        internal static Population Clone(Population p, EntityMap map) {
            // If this object is already a key in the map, then set the clone equal to its associated value
            Population clone = null;
            if (map.Contains(p))
                clone = map.GetEntity<Population>(p);

            // Otherwise, create its clone and add them as a key/value pair
            else {
                clone = Activator.CreateInstance(p.GetType()) as Population;
                map.Add(p, clone);

                clone.Age = p.Age;
                clone.Comments = p.Comments;
                foreach (Tissue t in p.Tissues)
                    clone.Tissues.Add(Tissue.Clone(t, map));
                foreach (Project proj in p.Projects)
                    clone.Projects.Add(Project.Clone(proj, map));
            }

            // Clone any remaining object members of the object, and return the clone
            clone.TissueType = map.GetEntity<TissueType>(TissueType.Clone(p.TissueType, map));
            clone.Strain = map.GetEntity<Strain>(Strain.Clone(p.Strain, map));
            clone.AgeUnit = map.GetEntity<AgeUnit>(AgeUnit.Clone(p.AgeUnit, map));
            clone.Condition = map.GetEntity<Condition>(Condition.Clone(p.Condition, map));
            return clone;
        }
    }

}