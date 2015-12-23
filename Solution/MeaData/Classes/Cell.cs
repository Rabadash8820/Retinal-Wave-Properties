using System.Collections.Generic;

namespace MeaData {

    public class Cell : Entity {
        // PROPERTIES
        public Channel Channel { get; set; }
        public string Identifier { get; set; }
        public ICollection<Spike> Spikes { get; protected set; } = new HashSet<Spike>();
        public ICollection<Burst> Bursts { get; protected set; } = new HashSet<Burst>();
        public ICollection<Flag> Flags { get; protected set; } = new HashSet<Flag>();
    }

}
