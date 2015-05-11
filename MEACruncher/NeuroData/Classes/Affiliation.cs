using System;
using System.Collections.Generic;

namespace MeaData {

    public class Affiliation : Entity {
        // CONSTRUCTORS
        public Affiliation() {
            this.Construct();
        }
        public Affiliation(Guid g) : base(g) {
            this.Construct();
        }

        // PROPERTIES
        public virtual Experimenter Experimenter { get; set; }
        public virtual Organization Organization { get; set; }
        public virtual OrganizationRole Role { get; set; }
        public virtual DateTime StartDate { get; set; }
        public virtual DateTime EndDate { get; set; }

        // FUNCTIONS
        private void Construct() { }
        public override object Clone() {
            return Affiliation.Clone(this, new EntityMap());
        }
        internal static Affiliation Clone(Affiliation a, EntityMap map) {
            // If this object is already a key in the map, then set the clone equal to its associated value
            Affiliation clone = null;
            if (map.Contains(a))
                clone = map.GetEntity<Affiliation>(a);

            // Otherwise, create its clone and add them as a key/value pair
            else {
                clone = Activator.CreateInstance(a.GetType()) as Affiliation;
                map.Add(a, clone);

                clone.StartDate = a.StartDate;
                clone.EndDate = a.EndDate;
            }

            // Clone any remaining object members of the object, and return the clone
            clone.Experimenter = map.GetEntity<Experimenter>(Experimenter.Clone(a.Experimenter, map));
            clone.Organization = map.GetEntity<Organization>(Organization.Clone(a.Organization, map));
            clone.Role = map.GetEntity<OrganizationRole>(OrganizationRole.Clone(a.Role, map));
            return clone;
        }
    }

}