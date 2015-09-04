using System;
using System.Collections.Generic;

namespace MeaData {

    public class Flag : Entity {
        // VARIABLES
        private ISet<Cell> _cells;

        // CONSTRUCTORS
        public Flag() {
            this.Construct();
        }
        public Flag(Guid g) : base(g) {
            this.Construct();
        }

        // PROPERTIES
        public virtual string Description { get; set; }
        public virtual ISet<Cell> Cells {
            get { return _cells; }
        }

        // FUNCTIONS
        private void Construct() {
            _cells = new HashSet<Cell>();
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
                foreach (Cell c in f.Cells)
                    clone.Cells.Add(Cell.Clone(c, map));
            }

            // Clone any remaining object members of the object, and return the clone
            return clone;
        }
    }

}