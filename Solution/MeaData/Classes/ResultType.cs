using System.Collections.Generic;

namespace MeaData {

    public class ResultType : Entity {
        // PROPERTIES
        public virtual string Description { get; set; }
        public virtual string Comments { get; set; }
        public virtual ICollection<Result> Results { get; protected set; } = new HashSet<Result>();
    }

}
