using System.Collections.Generic;

namespace MeaData {

    public class Age : Entity {
        // PROPERTIES
        public double Value { get; set; }
        public AgeUnit Unit { get; set; }
        public ICollection<Tissue> Tissues { get; protected set; } = new HashSet<Tissue>();
    }

}
