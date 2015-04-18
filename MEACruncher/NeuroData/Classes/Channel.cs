using System;
using System.Collections.Generic;

namespace Neuro {

    public class Channel : Entity {
        // VARIABLES
        private ISet<Spike> _spikes;
        private ISet<Burst> _bursts;

        // CONSTRUCTORS
        public Channel() {
            this.Construct();
        }
        public Channel(Guid g) : base(g) {
            this.Construct();
        }

        // PROPERTIES
        public virtual Recording Recording { get; set; }
        public virtual string Description { get; set; }
        public virtual int Row { get; set; }
        public virtual int Column { get; set; }
        public virtual ISet<Spike> Spikes {
            get { return _spikes; }
        }
        public virtual ISet<Burst> Bursts {
            get { return _bursts; }
        }

        // FUNCTIONS
        private void Construct() {
            _spikes = new HashSet<Spike>();
            _bursts = new HashSet<Burst>();
        }
        public override object Clone() {
            return Channel.Clone(this, new EntityMap());
        }
        internal static Channel Clone(Channel ch, EntityMap map) {
            // If this object is already a key in the map, then set the clone equal to its associated value
            Channel clone = null;
            if (map.Contains(ch))
                clone = map.GetEntity<Channel>(ch);

            // Otherwise, create its clone and add them as a key/value pair
            else {
                clone = Activator.CreateInstance(ch.GetType()) as Channel;
                map.Add(ch, clone);

                clone.Description = ch.Description;
                clone.Row = ch.Row;
                clone.Column = ch.Column;
                foreach (Spike s in ch.Spikes)
                    clone.Spikes.Add(Spike.Clone(s, map));
                foreach (Burst b in ch.Bursts)
                    clone.Bursts.Add(Burst.Clone(b, map));
            }

            // Clone any remaining object members of the object, and return the clone
            clone.Recording = map.GetEntity<Recording>(Recording.Clone(ch.Recording, map));
            return clone;
        }
    }

}