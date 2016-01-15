using System.Collections.Generic;

namespace MeaData {

    public class Channel : Entity {
        // PROPERTIES
        public Recording Recording { get; set; }
        public int MeaRow { get; set; }
        public int MeaColumn { get; set; }
        public string Name { get; set; }
        public ICollection<CellChannel> CellChannels { get; protected set; } = new HashSet<CellChannel>();
    }

}
