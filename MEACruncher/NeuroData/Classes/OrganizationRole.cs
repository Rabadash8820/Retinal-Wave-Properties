using System;
using System.Collections.Generic;

namespace Neuro {

    public class OrganizationRole : Entity {
        // VARIABLES
        private ISet<Affiliation> _affiliations;

        // CONSTRUCTORS
        public OrganizationRole() {
            this.Construct();
        }
        public OrganizationRole(Guid g) : base(g) {
            this.Construct();
        }

        // PROPERTIES
        public virtual string Description { get; set; }
        public virtual ISet<Affiliation> Affiliations {
            get { return _affiliations; }
        }

        // FUNCTIONS
        private void Construct() {
            _affiliations = new HashSet<Affiliation>();
        }
        public override object Clone() {
            return OrganizationRole.Clone(this, new EntityMap());
        }
        internal static OrganizationRole Clone(OrganizationRole or, EntityMap map) {
            // If this object is already a key in the map, then set the clone equal to its associated value
            OrganizationRole clone = null;
            if (map.Contains(or))
                clone = map.GetEntity<OrganizationRole>(or);

            // Otherwise, create its clone and add them as a key/value pair
            else {
                clone = Activator.CreateInstance(or.GetType()) as OrganizationRole;
                map.Add(or, clone);

                clone.Description = or.Description;
                foreach (Affiliation a in or.Affiliations)
                    clone.Affiliations.Add(Affiliation.Clone(a, map));
            }

            // Clone any remaining object members of the object, and return the clone
            return clone;
        }
    }

}