using System;
using System.Collections.Generic;

namespace Neuro {

    public class Genotype : Entity {
        // VARIABLES
        private ISet<Strain> _strains;

        // CONSTRUCTORS
        public Genotype() {
            this.Construct();
        }
        public Genotype(Guid g) : base(g) {
            this.Construct();
        }

        // PROPERTIES
        public virtual string Description { get; set; }
        public virtual ISet<Strain> Strains {
            get { return _strains; }
        }

        // FUNCTIONS
        private void Construct() {
            _strains = new HashSet<Strain>();
        }
        public override object Clone() {
            return Genotype.Clone(this, new EntityMap());
        }
        internal static Genotype Clone(Genotype g, EntityMap map) {
            // If this object is already a key in the map, then set the clone equal to its associated value
            Genotype clone = null;
            if (map.Contains(g))
                clone = map.GetEntity<Genotype>(g);

            // Otherwise, create its clone and add them as a key/value pair
            else {
                clone = Activator.CreateInstance(g.GetType()) as Genotype;
                map.Add(g, clone);

                clone.Description = g.Description;
                foreach (Strain s in g.Strains)
                    clone.Strains.Add(Strain.Clone(s, map));
            }

            // Clone any remaining object members of the object, and return the clone
            return clone;
        }
    }

}