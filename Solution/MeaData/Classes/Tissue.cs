using System;
using System.Collections.Generic;

namespace MeaData {

    public class Tissue : Entity {
        // PROPERTIES
        public virtual Strain Strain { get; set; }
        public virtual TissueType TissueType { get; set; }
        public virtual double Age { get; set; }
        public virtual AgeUnit AgeUnit { get; set; }
        public virtual string Preparer { get; set; }
        public virtual DateTime DatePrepared { get; set; }
        public virtual ICollection<Population> Populations { get; protected set; } = new HashSet<Population>();
        public virtual ICollection<Recording> Recordings { get; protected set; } = new HashSet<Recording>();
        public virtual string Comments { get; set; }
    }

}
