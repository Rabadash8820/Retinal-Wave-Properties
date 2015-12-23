using System.Collections.Generic;

namespace MeaData {

    public class Cell : Entity {
        // PROPERTIES
        public virtual Channel Channel { get; set; }
        public virtual string Identifier { get; set; }
        public virtual ICollection<Spike> Spikes { get; protected set; } = new HashSet<Spike>();
        public virtual ICollection<Burst> Bursts { get; protected set; } = new HashSet<Burst>();
        public virtual ICollection<Flag> Flags { get; protected set; } = new HashSet<Flag>();
    }

}
