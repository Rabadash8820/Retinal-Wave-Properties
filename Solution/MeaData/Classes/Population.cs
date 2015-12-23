using System.Collections.Generic;

namespace MeaData {

    public class Population : Entity {
        // PROPERTIES
        public Tissue Tissue{ get; set; }
        public Strain Strain { get; set; }
        public double Age { get; set; }
        public AgeUnit AgeUnit { get; set; }
        public Condition Condition { get; set; }
        public ICollection<Condition> Conditions { get; protected set; } = new HashSet<Condition>();
        public ICollection<Tissue> Tissues { get; protected set; } = new HashSet<Tissue>();
        public ICollection<Project> Projects { get; protected set; } = new HashSet<Project>();
        public string Comments { get; set; }
    }

}
