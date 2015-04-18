using System;
using System.Collections.Generic;

namespace Neuro {

    public class ModelOrganism : Entity {
        // VARIABLES
        private ISet<Strain> _strains;

        // CONSTRUCTORS
        public ModelOrganism() {
            this.Construct();
        }
        public ModelOrganism(Guid g) : base(g) {
            this.Construct();
        }

        // PROPERTIES
        public virtual string ScientificName { get; set; }
        public virtual string CommonName { get; set; }
        public virtual string Comments { get; set; }
        public virtual ISet<Strain> Strains {
            get { return _strains; }
        }

        // FUNCTIONS
        private void Construct() {
            _strains = new HashSet<Strain>();
        }
        public override object Clone() {
            return ModelOrganism.Clone(this, new EntityMap());
        }
        internal static ModelOrganism Clone(ModelOrganism mo, EntityMap map) {
            // If this object is already a key in the map, then set the clone equal to its associated value
            ModelOrganism clone = null;
            if (map.Contains(mo))
                clone = map.GetEntity<ModelOrganism>(mo);

            // Otherwise, create its clone and add them as a key/value pair
            else {
                clone = Activator.CreateInstance(mo.GetType()) as ModelOrganism;
                map.Add(mo, clone);

                clone.ScientificName = mo.ScientificName;
                clone.CommonName = mo.CommonName;
                clone.Comments = mo.Comments;
                foreach (Strain s in mo.Strains)
                    clone.Strains.Add(Strain.Clone(s, map));
            }

            // Clone any remaining object members of the object, and return the clone
            return clone;
        }
    }

}