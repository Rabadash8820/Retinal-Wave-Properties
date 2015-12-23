using System.Collections.Generic;

namespace MeaData {

    public class ResultType : Entity {
        // PROPERTIES
        public string Description { get; set; }
        public string Comments { get; set; }
        public ICollection<Result> Results { get; protected set; } = new HashSet<Result>();
    }

}
