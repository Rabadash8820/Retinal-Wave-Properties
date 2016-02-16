using System;
using System.Collections.Generic;

namespace MeaData {

    public class Project : Entity {
        // PROPERTIES
        public string Name { get; set; }
        public DateTime DateStarted { get; set; }
        public string Comments { get; set; }
        public ICollection<Population> Populations { get; protected set; } = new HashSet<Population>();
    }

}
