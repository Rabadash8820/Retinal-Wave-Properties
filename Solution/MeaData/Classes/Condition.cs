using System.Collections.Generic;

namespace MeaData {

    public class Condition : Entity {
        // PROPERTIES
        public string Name { get; set; }
        public string Comments { get; set; }
        public ICollection<Recording> Recordings { get; protected set; } = new HashSet<Recording>();
    }

}
