using System;
using System.Collections.Generic;

namespace MeaData {

    public class Tissue : Entity {
        // PROPERTIES
        public Strain Strain { get; set; }
        public TissueType TissueType { get; set; }
        public Age Age { get; set; }
        public string Preparer { get; set; }
        public DateTime DatePrepared { get; set; }
        public ICollection<Recording> Recordings { get; protected set; } = new HashSet<Recording>();
        public string Comments { get; set; }
    }

}
