using System;

namespace MeaData {

    public class DbVersion : Entity {
        // CONSTRUCTORS
        public DbVersion() {
            this.Construct();
        }
        public DbVersion(Guid g) : base(g) {
            this.Construct();
        }

        // PROPERTIES
        public virtual string Version { get; set; }

        // FUNCTIONS
        private void Construct() { }
        public override object Clone() {
            return DbVersion.Clone(this, new EntityMap());
        }
        internal static DbVersion Clone(DbVersion v, EntityMap map) {
            // If this object is already a key in the map, then set the clone equal to its associated value
            DbVersion clone = null;
            if (map.Contains(v))
                clone = map.GetEntity<DbVersion>(v);

            // Otherwise, create its clone and add them as a key/value pair
            else {
                clone = Activator.CreateInstance(v.GetType()) as DbVersion;
                map.Add(v, clone);

                clone.Version = v.Version;
            }

            // Clone any remaining object members of the object, and return the clone
            return clone;
        }
    }

}