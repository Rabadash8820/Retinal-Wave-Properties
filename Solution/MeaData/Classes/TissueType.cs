using System;
using System.Collections.Generic;

namespace MeaData {

    public class TissueType : Entity {
        // VARIABLES
        private ISet<Tissue> _tissues;
        private ISet<TissueType> _children;

        // CONSTRUCTORS
        public TissueType() {
            this.Construct();
        }
        public TissueType(Guid g) : base(g) {
            this.Construct();
        }

        // PROPERTIES
        public virtual string Name { get; set; }
        public virtual TissueType Parent { get; set; }
        public virtual string Comments { get; set; }
        public virtual ISet<Tissue> Tissues {
            get { return _tissues; }
        }
        public virtual ISet<TissueType> Children {
            get { return _children; }
        }

        // FUNCTIONS
        private void Construct() {
            _tissues = new HashSet<Tissue>();
            _children = new HashSet<TissueType>();
        }
        public override object Clone() {
            return TissueType.Clone(this, new EntityMap());
        }
        internal static TissueType Clone(TissueType t, EntityMap map) {
            // If this object is already a key in the map, then set the clone equal to its associated value
            TissueType clone = null;
            if (map.Contains(t))
                clone = map.GetEntity<TissueType>(t);

            // Otherwise, create its clone and add them as a key/value pair
            else {
                clone = Activator.CreateInstance(t.GetType()) as TissueType;
                map.Add(t, clone);

                clone.Name = t.Name;
                clone.Comments = t.Comments;
                foreach (Tissue tp in t.Tissues)
                    clone.Tissues.Add(Tissue.Clone(tp, map));
                foreach (TissueType ch in t.Children)
                    clone.Children.Add(TissueType.Clone(ch, map));
            }

            // Clone any remaining object members of the object, and return the clone
            clone.Parent = map.GetEntity<TissueType>(TissueType.Clone(t.Parent, map));
            return clone;
        }
    }

}