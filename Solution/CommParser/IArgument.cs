namespace CommParse {

    public interface IArgument : ICommandLineItem {
        string Value { get; set; }
    }

    public interface IArgument<T> : ICommandLineItem where T : struct {
        T Value { get; set; }
    }

}
