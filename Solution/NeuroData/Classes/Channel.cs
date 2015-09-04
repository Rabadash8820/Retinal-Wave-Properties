using System;
using System.Collections.Generic;

namespace MeaData {

    public class Channel : Entity {
        // VARIABLES
        private ISet<Cell> _cells;

        // CONSTRUCTORS
        public Channel() {
            this.Construct();
        }
        public Channel(Guid g) : base(g) {
            this.Construct();
        }

        // PROPERTIES
        public virtual Recording Recording { get; set; }
        public virtual int Row { get; set; }
        public virtual int Column { get; set; }
        public virtual ISet<Cell> Cells {
            get { return _cells; }
        }

        // FUNCTIONS
        private void Construct() {
            _cells = new HashSet<Cell>();
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

                clone.Row = ch.Row;
                clone.Column = ch.Column;
                foreach (Cell c in ch.Cells)
                    clone.Cells.Add(Cell.Clone(c, map));
            }

            // Clone any remaining object members of the object, and return the clone
            clone.Recording = map.GetEntity<Recording>(Recording.Clone(ch.Recording, map));
            return clone;
        }
    }

}