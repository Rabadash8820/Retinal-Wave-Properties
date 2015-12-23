namespace MeaData {

    public class RecordingFile : Entity {
        // PROPERTIES
        public virtual Recording Recording { get; set; }
        public virtual int Number { get; set; }
        public virtual string FileDir { get; set; }
    }

}
