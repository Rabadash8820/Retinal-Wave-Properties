namespace MeaData {

    public class Spike : Entity {
        // PROPERTIES
        public virtual Cell Cell { get; set; }
        public virtual int Number { get; set; }
        public virtual double Timestamp { get; set; }
        public virtual Burst Burst{ get; set; }
    }

}
