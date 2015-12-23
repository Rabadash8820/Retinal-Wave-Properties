using System.Collections.Generic;

namespace MeaData {

    public class Recording : Entity {
        // PROPERTIES
        public virtual Tissue Tissue { get; set; }
        public virtual Condition Condition { get; set; }
        public virtual int Number { get; set; }
        public virtual int MeaRows { get; set; }
        public virtual int MeaColumns { get; set; }
        public virtual ICollection<RecordingFile> Files { get; protected set; } = new HashSet<RecordingFile>();
        public virtual ICollection<Channel> Channels { get; protected set; } = new HashSet<Channel>();
        public virtual ICollection<Condition> Conditions { get; protected set; } = new HashSet<Condition>();
        public virtual string Comments { get; set; }
    }

}
