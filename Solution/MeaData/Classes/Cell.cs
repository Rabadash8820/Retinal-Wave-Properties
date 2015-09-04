using System;
using System.Collections.Generic;

namespace MeaData {

    public class Cell : Entity {
        // VARIABLES
        private ISet<Spike> _spikes;
        private ISet<Burst> _bursts;
        private ISet<Flag> _flags;

        // CONSTRUCTORS
        public Cell() {
            this.Construct();
        }
        public Cell(Guid g) : base(g) {
            this.Construct();
        }

        // PROPERTIES
        public virtual Channel Channel { get; set; }
        public virtual string Identifier { get; set; }
        public virtual ISet<Spike> Spikes {
            get { return _spikes; }
        }
        public virtual ISet<Burst> Bursts {
            get { return _bursts; }
        }
        public virtual ISet<Flag> Flags {
            get { return _flags; }
        }

        // FUNCTIONS
        private void Construct() {
            _spikes = new HashSet<Spike>();
            _bursts = new HashSet<Burst>();
            _flags = new HashSet<Flag>();
        }
        public override object Clone() {
            return Cell.Clone(this, new EntityMap());
        }
        internal static Cell Clone(Cell c, EntityMap map) {
            // If this object is already a key in the map, then set the clone equal to its associated value
            Cell clone = null;
            if (map.Contains(c))
                clone = map.GetEntity<Cell>(c);

            // Otherwise, create its clone and add them as a key/value pair
            else {
                clone = Activator.CreateInstance(c.GetType()) as Cell;
                map.Add(c, clone);

                clone.Identifier = c.Identifier;
                foreach (Spike s in c.Spikes)
                    clone.Spikes.Add(Spike.Clone(s, map));
                foreach (Burst b in c.Bursts)
                    clone.Bursts.Add(Burst.Clone(b, map));
                foreach (Flag f in c.Flags)
                    clone.Flags.Add(Flag.Clone(f, map));
            }

            // Clone any remaining object members of the object, and return the clone
            clone.Channel = map.GetEntity<Channel>(Channel.Clone(c.Channel, map));
            return clone;
        }
    }

}