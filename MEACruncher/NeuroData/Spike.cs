using System;
using System.Collections.Generic;

namespace Neuro {

    public class Spike : Entity {
        // CONSTRUCTORS
        public Spike() {
            this.Construct();
        }
        public Spike(Guid g) : base(g) {
            this.Construct();
        }

        // PROPERTIES
        public virtual Channel Channel { get; set; }
        public virtual int Number { get; set; }
        public virtual double Timestamp { get; set; }
        public virtual Burst Burst{ get; set; }

        // FUNCTIONS
        private void Construct() { }
        public override object Clone() {
            return Spike.Clone(this, new EntityMap());
        }
        internal static Spike Clone(Spike s, EntityMap map) {
            // If this object is already a key in the map, then set the clone equal to its associated value
            Spike clone = null;
            if (map.Contains(s))
                clone = map.GetEntity<Spike>(s);

            // Otherwise, create its clone and add them as a key/value pair
            else {
                clone = Activator.CreateInstance(s.GetType()) as Spike;
                map.Add(s, clone);

                clone.Number = s.Number;
                clone.Timestamp = s.Timestamp;
            }

            // Clone any remaining object members of the object, and return the clone
            clone.Channel = map.GetEntity<Channel>(Channel.Clone(s.Channel, map));
            clone.Burst = map.GetEntity<Burst>(Burst.Clone(s.Burst, map));
            return clone;
        }
    }

}