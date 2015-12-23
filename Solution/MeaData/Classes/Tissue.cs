using System;
using System.Collections.Generic;

namespace MeaData {

    public class Tissue : Entity {
        // PROPERTIES
        public Strain Strain { get; set; }
        public TissueType TissueType { get; set; }
        public double Age { get; set; }
        public AgeUnit AgeUnit { get; set; }
        public string Preparer { get; set; }
        public DateTime DatePrepared { get; set; }
        public ICollection<Population> Populations { get; protected set; } = new HashSet<Population>();
        public ICollection<Recording> Recordings { get; protected set; } = new HashSet<Recording>();
        public string Comments { get; set; }
    }

}
