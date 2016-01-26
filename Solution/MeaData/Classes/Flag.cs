using System.Collections.Generic;

namespace MeaData {

    public class Flag : Entity {
        // PROPERTIES
        public string Description { get; set; }
        public ICollection<Cell> Cells { get; protected set; } = new HashSet<Cell>();
    }

}
