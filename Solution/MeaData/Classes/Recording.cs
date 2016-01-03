using System.Collections.Generic;

namespace MeaData {

    public class Recording : Entity {
        // PROPERTIES
        public Tissue Tissue { get; set; }
        public int Number { get; set; }
        public int MeaRows { get; set; }
        public int MeaColumns { get; set; }
        public ICollection<RecordingFile> Files { get; protected set; } = new HashSet<RecordingFile>();
        public ICollection<Channel> Channels { get; protected set; } = new HashSet<Channel>();
        public ICollection<Condition> Conditions { get; protected set; } = new HashSet<Condition>();
        public string Comments { get; set; }
    }

}
