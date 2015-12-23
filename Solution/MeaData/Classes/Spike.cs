namespace MeaData {

    public class Spike : Entity {
        // PROPERTIES
        public Cell Cell { get; set; }
        public int Number { get; set; }
        public double Timestamp { get; set; }
        public Burst Burst{ get; set; }
    }

}
