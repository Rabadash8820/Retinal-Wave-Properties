using System;
using System.Collections.Generic;

namespace Neuro {

    public class Burst : Entity {
        // VARIABLES
        private ISet<Spike> _spikes;

        // CONSTRUCTORS
        public Burst() {
            this.Construct();
        }
        public Burst(Guid g) : base(g) {
            this.Construct();
        }

        // PROPERTIES
        public virtual Channel Channel { get; set; }
        public virtual int Number { get; set; }
        public virtual double StartTimestamp { get; set; }
        public virtual double EndTimestamp { get; set; }
        public virtual bool IsWaveAssociated { get; set; }
        public virtual ISet<Spike> Spikes { get; set; }

        // FUNCTIONS
        private void Construct() {
            _spikes = new HashSet<Spike>();
        }
        public override object Clone() {
            return Burst.Clone(this, new EntityMap());
        }
        internal static Burst Clone(Burst b, EntityMap map) {
            // If this object is already a key in the map, then set the clone equal to its associated value
            Burst clone = null;
            if (map.Contains(b))
                clone = map.GetEntity<Burst>(b);

            // Otherwise, create its clone and add them as a key/value pair
            else {
                clone = Activator.CreateInstance(b.GetType()) as Burst;
                map.Add(b, clone);

                clone.Number = b.Number;
                clone.StartTimestamp = b.StartTimestamp;
                clone.EndTimestamp = b.EndTimestamp;
                clone.IsWaveAssociated = b.IsWaveAssociated;
                foreach (Spike s in b.Spikes)
                    clone.Spikes.Add(Spike.Clone(s, map));
            }

            // Clone any remaining object members of the object, and return the clone
            clone.Channel = map.GetEntity<Channel>(Channel.Clone(b.Channel, map));
            return clone;
        }
    }

}