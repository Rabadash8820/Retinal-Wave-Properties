using System;
using System.Collections.Generic;

namespace MeaData {

    public class OrganizationType : Entity {
        // VARIABLES
        private ISet<Organization> _organizations;

        // CONSTRUCTORS
        public OrganizationType() {
            this.Construct();
        }
        public OrganizationType(Guid g) : base(g) {
            this.Construct();
        }

        // PROPERTIES
        public virtual string Description { get; set; }
        public virtual ISet<Organization> Organizations {
            get { return _organizations; }
        }

        // FUNCTIONS
        private void Construct() {
            _organizations = new HashSet<Organization>();
        }
        public override object Clone() {
            return OrganizationType.Clone(this, new EntityMap());
        }
        internal static OrganizationType Clone(OrganizationType ot, EntityMap map) {
            // If this object is already a key in the map, then set the clone equal to its associated value
            OrganizationType clone = null;
            if (map.Contains(ot))
                clone = map.GetEntity<OrganizationType>(ot);

            // Otherwise, create its clone and add them as a key/value pair
            else {
                clone = Activator.CreateInstance(ot.GetType()) as OrganizationType;
                map.Add(ot, clone);

                clone.Description = ot.Description;
                foreach (Organization o in ot.Organizations)
                    clone.Organizations.Add(Organization.Clone(o, map));
            }

            // Clone any remaining object members of the object, and return the clone
            return clone;
        }
    }

}