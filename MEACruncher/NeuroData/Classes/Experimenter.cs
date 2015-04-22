using System;
using System.Collections.Generic;

namespace Neuro {

    public class Experimenter : Entity {
        // VARIABLES
        private ISet<TissuePreparation> _tissuePreparations;
        private ISet<ProjectExperimenter> _projectExperimenters;
        private ISet<Affiliation> _affiliations;

        // CONSTRUCTORS
        public Experimenter() {
            this.Construct();
        }
        public Experimenter(Guid g) : base(g) {
            this.Construct();
        }

        // PROPERTIES
        public virtual string FullName { get; set; }
        public virtual string WorkEmail { get; set; }
        public virtual string WorkPhone { get; set; }
        public virtual string Comments { get; set; }
        public virtual ISet<TissuePreparation> TissuePreparations {
            get { return _tissuePreparations; }
        }
        public virtual ISet<ProjectExperimenter> ProjectExperimenters {
            get { return _projectExperimenters; }
        }
        public virtual ISet<Affiliation> Affiliations {
            get { return _affiliations; }
        }

        // FUNCTIONS
        private void Construct() {
            _tissuePreparations = new HashSet<TissuePreparation>();
            _projectExperimenters = new HashSet<ProjectExperimenter>();
            _affiliations = new HashSet<Affiliation>();
        }
        public override object Clone() {
            return Experimenter.Clone(this, new EntityMap());
        }
        internal static Experimenter Clone(Experimenter e, EntityMap map) {
            // If this object is already a key in the map, then set the clone equal to its associated value
            Experimenter clone = null;
            if (map.Contains(e))
                clone = map.GetEntity<Experimenter>(e);

            // Otherwise, create its clone and add them as a key/value pair
            else {
                clone = Activator.CreateInstance(e.GetType()) as Experimenter;
                map.Add(e, clone);

                clone.FullName = e.FullName;
                clone.WorkEmail = e.WorkEmail;
                clone.WorkPhone = e.WorkPhone;
                clone.Comments = e.Comments;
                foreach (TissuePreparation tp in e.TissuePreparations)
                    clone.TissuePreparations.Add(TissuePreparation.Clone(tp, map));
                foreach (ProjectExperimenter pe in e.ProjectExperimenters)
                    clone.ProjectExperimenters.Add(ProjectExperimenter.Clone(pe, map));
                foreach (Affiliation a in e.Affiliations)
                    clone.Affiliations.Add(Affiliation.Clone(a, map));
            }

            // Clone any remaining object members of the object, and return the clone
            return clone;
        }
    }

}