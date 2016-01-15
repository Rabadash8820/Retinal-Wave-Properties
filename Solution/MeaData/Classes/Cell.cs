using System.Collections.Generic;

namespace MeaData {

    public class Cell : Entity {
        // PROPERTIES
        public Tissue Tissue { get; set; }
        public ICollection<CellChannel> CellChannels { get; protected set; } = new HashSet<CellChannel>();
        public ICollection<Flag> Flags { get; protected set; } = new HashSet<Flag>();
    }

}
