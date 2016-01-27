namespace CommParse {

    public interface IArgument : ICommLineItem {
        string Name { get; }
        string Description { get; }
        string Value { get; set; }
    }

    public interface IArgument<T> : ICommLineItem where T : struct {
        string Name { get; }
        string Description { get; }
        T Value { get; set; }
    }

}
