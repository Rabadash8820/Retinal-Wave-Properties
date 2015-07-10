using System;
using System.Collections.Generic;

namespace MeaData {

    public class Strain : Entity {
        // VARIABLES
        private ISet<TissuePreparation> _tissuePreparations;

        // CONSTRUCTORS
        public Strain() {
            this.Construct();
        }
        public Strain(Guid g) : base(g) {
            this.Construct();
        }

        // PROPERTIES
        public virtual ModelOrganism Organism { get; set; }
        public virtual string Name { get; set; }
        public virtual string Breeder { get; set; }
        public virtual string Comments { get; set; }
        public virtual ISet<TissuePreparation> TissuePreparations {
            get { return _tissuePreparations; }
        }

        // FUNCTIONS
        private void Construct() {
            _tissuePreparations = new HashSet<TissuePreparation>();
        }
        public override object Clone() {
            return Strain.Clone(this, new EntityMap());
        }
        internal static Strain Clone(Strain s, EntityMap map) {
            // If this object is already a key in the map, then set the clone equal to its associated value
            Strain clone = null;
            if (map.Contains(s))
                clone = map.GetEntity<Strain>(s);

            // Otherwise, create its clone and add them as a key/value pair
            else {
                clone = Activator.CreateInstance(s.GetType()) as Strain;
                map.Add(s, clone);
                
                clone.Name = s.Name;
                clone.Breeder = s.Breeder;
                clone.Comments = s.Comments;
                foreach (TissuePreparation tp in s.TissuePreparations)
                    clone.TissuePreparations.Add(TissuePreparation.Clone(tp, map));
            }

            // Clone any remaining object members of the object, and return the clone
            clone.Organism = map.GetEntity<ModelOrganism>(ModelOrganism.Clone(s.Organism, map));
            return clone;
        }
    }

}