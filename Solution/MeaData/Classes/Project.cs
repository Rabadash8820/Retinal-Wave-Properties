using System;
using System.Collections.Generic;

namespace MeaData {

    public class Project : Entity {
        // PROPERTIES
        public virtual string Name { get; set; }
        public virtual DateTime DateStarted { get; set; }
        public virtual string Comments { get; set; }
        public virtual ICollection<Population> Populations { get; protected set; } = new HashSet<Population>();
    }

}
