using System;
using System.Collections.Generic;

namespace Neuro {

    public class NervousSystemRegion : Entity {
        // VARIABLES
        private ISet<TissuePreparation> _tissuePreparations;

        // CONSTRUCTORS
        public NervousSystemRegion() {
            this.Construct();
        }
        public NervousSystemRegion(Guid g) : base(g) {
            this.Construct();
        }

        // PROPERTIES
        public virtual string Description { get; set; }
        public virtual NervousSystemRegion Parent { get; set; }
        public virtual string Comments { get; set; }
        public virtual ISet<TissuePreparation> TissuePreparations {
            get { return _tissuePreparations; }
        }

        // FUNCTIONS
        private void Construct() {
            _tissuePreparations = new HashSet<TissuePreparation>();
        }
        public override object Clone() {
            return NervousSystemRegion.Clone(this, new EntityMap());
        }
        internal static NervousSystemRegion Clone(NervousSystemRegion nsr, EntityMap map) {
            // If this object is already a key in the map, then set the clone equal to its associated value
            NervousSystemRegion clone = null;
            if (map.Contains(nsr))
                clone = map.GetEntity<NervousSystemRegion>(nsr);

            // Otherwise, create its clone and add them as a key/value pair
            else {
                clone = Activator.CreateInstance(nsr.GetType()) as NervousSystemRegion;
                map.Add(nsr, clone);

                clone.Description = nsr.Description;
                clone.Comments = nsr.Comments;
                foreach (TissuePreparation tp in nsr.TissuePreparations)
                    clone.TissuePreparations.Add(TissuePreparation.Clone(tp, map));
            }

            // Clone any remaining object members of the object, and return the clone
            clone.Parent = map.GetEntity<NervousSystemRegion>(NervousSystemRegion.Clone(nsr.Parent, map));
            return clone;
        }
    }

}