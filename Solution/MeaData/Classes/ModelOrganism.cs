using System.Collections.Generic;

namespace MeaData {

    public class ModelOrganism : Entity {
        // PROPERTIES
        public string ScientificName { get; set; }
        public string CommonName { get; set; }
        public string Comments { get; set; }
        public ICollection<Strain> Strains { get; protected set; } = new HashSet<Strain>();
    }

}
