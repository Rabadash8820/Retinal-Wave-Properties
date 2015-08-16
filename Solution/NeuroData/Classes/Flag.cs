using System;
using System.Collections.Generic;

namespace MeaData {

    public class Flag : Entity {
        // VARIABLES
        private ISet<Channel> _channels;

        // CONSTRUCTORS
        public Flag() {
            this.Construct();
        }
        public Flag(Guid g)
            : base(g) {
            this.Construct();
        }

        // PROPERTIES
        public virtual string Description { get; set; }
        public virtual ISet<Channel> Channels {
            get { return _channels; }
        }

        // FUNCTIONS
        private void Construct() {
            _channels = new HashSet<Channel>();
        }
        public override object Clone() {
            return Flag.Clone(this, new EntityMap());
        }
        internal static Flag Clone(Flag f, EntityMap map) {
            // If this object is already a key in the map, then set the clone equal to its associated value
            Flag clone = null;
            if (map.Contains(f))
                clone = map.GetEntity<Flag>(f);

            // Otherwise, create its clone and add them as a key/value pair
            else {
                clone = Activator.CreateInstance(f.GetType()) as Flag;
                map.Add(f, clone);

                clone.Description = f.Description;
                foreach (Channel ch in f.Channels)
                    clone.Channels.Add(Channel.Clone(ch, map));
            }

            // Clone any remaining object members of the object, and return the clone
            return clone;
        }
    }

}