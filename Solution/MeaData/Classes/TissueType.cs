using System.Collections.Generic;

namespace MeaData {

    public class TissueType : Entity {
        // PROPERTIES
        public string Name { get; set; }
        public TissueType Parent { get; set; }
        public string Comments { get; set; }
        public ICollection<Tissue> Tissues { get; protected set; } = new HashSet<Tissue>();
        public ICollection<TissueType> Children { get; protected set; } = new HashSet<TissueType>();
    }

}
