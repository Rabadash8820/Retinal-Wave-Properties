using System;
using System.Collections.Generic;

namespace Neuro {

    public class Condition : Entity {
        // VARIABLES
        private ISet<TissueCondition> _tissueConditions;

        // CONSTRUCTORS
        public Condition() {
            this.Construct();
        }
        public Condition(Guid g) : base(g) {
            this.Construct();
        }

        // PROPERTIES
        public virtual string Description { get; set; }
        public virtual ISet<TissueCondition> TissueConditions {
            get { return _tissueConditions; }
    }

        // FUNCTIONS
        private void Construct() {
            _tissueConditions = new HashSet<TissueCondition>();
        }
        public override object Clone() {
            return Condition.Clone(this, new EntityMap());
        }
        internal static Condition Clone(Condition c, EntityMap map) {
            // If this object is already a key in the map, then set the clone equal to its associated value
            Condition clone = null;
            if (map.Contains(c))
                clone = map.GetEntity<Condition>(c);

            // Otherwise, create its clone and add them as a key/value pair
            else {
                clone = Activator.CreateInstance(c.GetType()) as Condition;
                map.Add(c, clone);

                clone.Description = c.Description;
                foreach (TissueCondition tc in c.TissueConditions)
                    clone.TissueConditions.Add(TissueCondition.Clone(tc, map));
            }

            // Clone any remaining object members of the object, and return the clone
            return clone;
        }
    }

}