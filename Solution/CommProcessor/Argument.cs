namespace CommParse {

    public class Argument : IArgument {
        public string Value { get; set; }
    }

    public class Argument<T> : IArgument<T> where T : struct {
        public T Value { get; set; }
    }

}
