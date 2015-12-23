using System.Collections.Generic;

namespace MeaData {

    public class Population : Entity {
        // PROPERTIES
        public virtual Tissue Tissue{ get; set; }
        public virtual Strain Strain { get; set; }
        public virtual double Age { get; set; }
        public virtual AgeUnit AgeUnit { get; set; }
        public virtual Condition Condition { get; set; }
        public virtual ICollection<Condition> Conditions { get; protected set; } = new HashSet<Condition>();
        public virtual ICollection<Tissue> Tissues { get; protected set; } = new HashSet<Tissue>();
        public virtual ICollection<Project> Projects { get; protected set; } = new HashSet<Project>();
        public virtual string Comments { get; set; }
    }

}
