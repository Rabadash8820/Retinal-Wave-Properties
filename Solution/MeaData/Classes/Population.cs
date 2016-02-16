using System.Collections.Generic;

namespace MeaData {

    public class Population : Entity {
        // PROPERTIES
        public string Name { get; set; }
        public ICollection<Age> Ages { get; protected set; } = new HashSet<Age>();
        public ICollection<Strain> Strains { get; protected set; } = new HashSet<Strain>();
        public ICollection<Condition> Conditions { get; protected set; } = new HashSet<Condition>();
        public ICollection<TissueType> TissueTypes { get; protected set; } = new HashSet<TissueType>();
        public ICollection<Project> Projects { get; protected set; } = new HashSet<Project>();
        public string Comments { get; set; }
    }

}
