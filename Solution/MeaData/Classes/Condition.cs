using System.Collections.Generic;

namespace MeaData {

    public class Condition : Entity {
        // PROPERTIES
        public virtual string Name { get; set; }
        public virtual string Comments { get; set; }
        public virtual ICollection<Recording> Recordings { get; protected set; } = new HashSet<Recording>();
        public virtual ICollection<Population> Populations { get; protected set; } = new HashSet<Population>();
    }

}
