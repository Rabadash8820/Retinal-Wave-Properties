using System.Collections.Generic;

namespace MeaData {

    public class Strain : Entity {
        // PROPERTIES
        public virtual ModelOrganism Organism { get; set; }
        public virtual string Name { get; set; }
        public virtual string Breeder { get; set; }
        public virtual string Comments { get; set; }
        public virtual ICollection<Tissue> Tissues { get; protected set; } = new HashSet<Tissue>();
    }

}
