using System.Collections.Generic;

namespace MeaData {

    public class ModelOrganism : Entity {
        // PROPERTIES
        public virtual string ScientificName { get; set; }
        public virtual string CommonName { get; set; }
        public virtual string Comments { get; set; }
        public virtual ICollection<Strain> Strains { get; protected set; } = new HashSet<Strain>();
    }

}
