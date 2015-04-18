using System;
using System.Collections.Generic;

namespace Neuro {

    public class Organization : Entity {
        // VARIABLES
        private ISet<Strain> _strains;
        private ISet<Affiliation> _affiliations;

        // CONSTRUCTORS
        public Organization() {
            this.Construct();
        }
        public Organization(Guid g) : base(g) {
            this.Construct();
        }

        // PROPERTIES
        public virtual string Title { get; set; }
        public virtual OrganizationType Type { get; set; }
        public virtual string Comments { get; set; }
        public virtual ISet<Strain> Strains {
            get { return _strains; }
        }
        public virtual ISet<Affiliation> Affiliations {
            get { return _affiliations; }
        }

        // FUNCTIONS
        private void Construct() {
            _affiliations = new HashSet<Affiliation>();
        }
        public override object Clone() {
            return Organization.Clone(this, new EntityMap());
        }
        internal static Organization Clone(Organization o, EntityMap map) {
            // If this object is already a key in the map, then set the clone equal to its associated value
            Organization clone = null;
            if (map.Contains(o))
                clone = map.GetEntity<Organization>(o);

            // Otherwise, create its clone and add them as a key/value pair
            else {
                clone = Activator.CreateInstance(o.GetType()) as Organization;
                map.Add(o, clone);

                clone.Title = o.Title;
                clone.Comments = o.Comments;
                foreach (Strain s in o.Strains)
                    clone.Strains.Add(Strain.Clone(s, map));
                foreach (Affiliation a in o.Affiliations)
                    clone.Affiliations.Add(Affiliation.Clone(a, map));
            }

            // Clone any remaining object members of the object, and return the clone
            clone.Type = map.GetEntity<OrganizationType>(OrganizationType.Clone(o.Type, map));
            return clone;
        }
    }

}