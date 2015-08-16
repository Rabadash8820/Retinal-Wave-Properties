using System;

namespace MeaData {

    public class AgeUnit : Entity {
        // CONSTRUCTORS
        public AgeUnit() {
            this.Construct();
        }
        public AgeUnit(Guid g) : base(g) {
            this.Construct();
        }

        // PROPERTIES
        public virtual string Description { get; set; }

        // FUNCTIONS
        private void Construct() { }
        public override object Clone() {
            return AgeUnit.Clone(this, new EntityMap());
        }
        internal static AgeUnit Clone(AgeUnit au, EntityMap map) {
            // If this object is already a key in the map, then set the clone equal to its associated value
            AgeUnit clone = null;
            if (map.Contains(au))
                clone = map.GetEntity<AgeUnit>(au);

            // Otherwise, create its clone and add them as a key/value pair
            else {
                clone = Activator.CreateInstance(au.GetType()) as AgeUnit;
                map.Add(au, clone);

                clone.Description = au.Description;
            }

            // Clone any remaining object members of the object, and return the clone
            return clone;
        }
    }

}