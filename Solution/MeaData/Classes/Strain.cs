using System.Collections.Generic;

namespace MeaData {

    public class Strain : Entity {
        // PROPERTIES
        public ModelOrganism Organism { get; set; }
        public string Name { get; set; }
        public string Breeder { get; set; }
        public string Comments { get; set; }
        public ICollection<Tissue> Tissues { get; protected set; } = new HashSet<Tissue>();
    }

}
