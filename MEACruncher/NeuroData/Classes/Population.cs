using System;
using System.Collections.Generic;

namespace MeaData {

    public class Population : Entity {
        // VARIABLES
        private ISet<TissuePreparation> _tissuePreparations;
        private ISet<ProjectPopulation> _projectPopulations;

        // CONSTRUCTORS
        public Population() {
            this.Construct();
        }
        public Population(Guid g) : base(g) {
            this.Construct();
        }

        // PROPERTIES
        public virtual Tissue Tissue { get; set; }
        public virtual Condition Condition { get; set; }
        public virtual Strain Strain { get; set; }
        public virtual double Age { get; set; }
        public virtual AgeUnit AgeUnit { get; set; }
        public virtual string Comments { get; set; }
        public virtual ISet<TissuePreparation> TissuePreparations {
            get { return _tissuePreparations; }
        }
        public virtual ISet<ProjectPopulation> ProjectPopulations {
            get { return _projectPopulations; }
        }

        // FUNCTIONS
        private void Construct(){
            _tissuePreparations = new HashSet<TissuePreparation>();
            _projectPopulations = new HashSet<ProjectPopulation>();
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
                foreach (TissuePreparation tp in p.TissuePreparations)
                    clone.TissuePreparations.Add(TissuePreparation.Clone(tp, map));
                foreach (ProjectPopulation pp in p.ProjectPopulations)
                    clone.ProjectPopulations.Add(ProjectPopulation.Clone(pp, map));
            }

            // Clone any remaining object members of the object, and return the clone
            clone.Tissue = map.GetEntity<Tissue>(p.Tissue);
            clone.Condition = map.GetEntity<Condition>(p.Condition);
            clone.Strain = map.GetEntity<Strain>(p.Strain);
            clone.AgeUnit = map.GetEntity<AgeUnit>(p.AgeUnit);
            return clone;
        }
    }

}