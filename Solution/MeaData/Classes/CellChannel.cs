using System.Collections.Generic;

namespace MeaData {

    public class CellChannel : Entity {
        // PROPERTIES
        public Cell Cell { get; set; }
        public Channel Channel { get; set; }
        public string Name { get; set; }
        public ICollection<Spike> Spikes { get; protected set; } = new HashSet<Spike>();
        public ICollection<Burst> Bursts { get; protected set; } = new HashSet<Burst>();
    }

}
