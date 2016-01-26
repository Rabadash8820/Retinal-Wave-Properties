using System.Collections.Generic;

namespace MeaData {

    public class Burst : Entity {
        // PROPERTIES
        public CellChannel CellChannel { get; set; }
        public int Number { get; set; }
        public bool IsWaveAssociated { get; set; }
        public ICollection<Spike> Spikes { get; protected set; } = new HashSet<Spike>();
    }

}
