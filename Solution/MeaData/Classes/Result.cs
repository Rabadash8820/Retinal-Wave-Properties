namespace MeaData {

    public class Result : Entity {
        // PROPERTIES
        public virtual Population Population { get; set; }
        public virtual ResultType ResultType { get; set; }
        public virtual double Value { get; set; }
    }

}
