using System.Collections.Generic;

namespace MeaData {

    public class Mea : Entity {
        // PROPERTIES
        public int Rows { get; set; }
        public int Columns { get; set; }
        public string Manufacturer { get; set; }
        public string Owner { get; set; }
        public ICollection<Recording> Recordings { get; protected set; } = new HashSet<Recording>();
    }

}
