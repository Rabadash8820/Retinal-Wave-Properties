using System.Collections.Generic;

namespace MeaData {

    public class Burst : Entity {
        // PROPERTIES
        public virtual Cell Cell { get; set; }
        public virtual int Number { get; set; }
        public virtual double StartTimestamp { get; set; }
        public virtual double EndTimestamp { get; set; }
        public virtual bool IsWaveAssociated { get; set; }
        public virtual ICollection<Spike> Spikes { get; protected set; } = new HashSet<Spike>();
    }

}
