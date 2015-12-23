using System.Collections.Generic;

namespace MeaData {

    public class Channel : Entity {
        // PROPERTIES
        public Recording Recording { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }
        public ICollection<Cell> Cells { get; protected set; } = new HashSet<Cell>();
    }

}
