using System.Collections.Generic;

namespace MeaData {

    public class Channel : Entity {
        // PROPERTIES
        public virtual Recording Recording { get; set; }
        public virtual int Row { get; set; }
        public virtual int Column { get; set; }
        public virtual ICollection<Cell> Cells { get; protected set; } = new HashSet<Cell>();
    }

}
