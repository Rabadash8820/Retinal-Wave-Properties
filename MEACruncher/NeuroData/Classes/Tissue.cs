using System;
using System.Collections.Generic;

namespace Neuro {

    public class Tissue : Entity {
        // VARIABLES
        private ISet<TissuePreparation> _tissuePreparations;
        private ISet<Tissue> _children;

        // CONSTRUCTORS
        public Tissue() {
            this.Construct();
        }
        public Tissue(Guid g) : base(g) {
            this.Construct();
        }

        // PROPERTIES
        public virtual string Description { get; set; }
        public virtual Tissue Parent { get; set; }
        public virtual string Comments { get; set; }
        public virtual ISet<TissuePreparation> TissuePreparations {
            get { return _tissuePreparations; }
        }
        public virtual ISet<Tissue> Children {
            get { return _children; }
        }

        // FUNCTIONS
        private void Construct() {
            _tissuePreparations = new HashSet<TissuePreparation>();
            _children = new HashSet<Tissue>();
        }
        public override object Clone() {
            return Tissue.Clone(this, new EntityMap());
        }
        internal static Tissue Clone(Tissue t, EntityMap map) {
            // If this object is already a key in the map, then set the clone equal to its associated value
            Tissue clone = null;
            if (map.Contains(t))
                clone = map.GetEntity<Tissue>(t);

            // Otherwise, create its clone and add them as a key/value pair
            else {
                clone = Activator.CreateInstance(t.GetType()) as Tissue;
                map.Add(t, clone);

                clone.Description = t.Description;
                clone.Comments = t.Comments;
                foreach (TissuePreparation tp in t.TissuePreparations)
                    clone.TissuePreparations.Add(TissuePreparation.Clone(tp, map));
                foreach (Tissue ch in t.Children)
                    clone.Children.Add(Tissue.Clone(ch, map));
            }

            // Clone any remaining object members of the object, and return the clone
            clone.Parent = map.GetEntity<Tissue>(Tissue.Clone(t.Parent, map));
            return clone;
        }
    }

}