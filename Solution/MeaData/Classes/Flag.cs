using System.Collections.Generic;

namespace MeaData {

    public class Flag : Entity {
        // PROPERTIES
        public virtual string Description { get; set; }
        public virtual ICollection<Cell> Cells { get; protected set; } = new HashSet<Cell>();
    }

}
