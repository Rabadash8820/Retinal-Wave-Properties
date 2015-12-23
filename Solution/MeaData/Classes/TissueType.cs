using System.Collections.Generic;

namespace MeaData {

    public class TissueType : Entity {
        // PROPERTIES
        public virtual string Name { get; set; }
        public virtual TissueType Parent { get; set; }
        public virtual string Comments { get; set; }
        public virtual ICollection<Tissue> Tissues { get; protected set; } = new HashSet<Tissue>();
        public virtual ICollection<TissueType> Children { get; protected set; } = new HashSet<TissueType>();
    }

}
