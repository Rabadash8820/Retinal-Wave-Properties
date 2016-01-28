namespace CommParse {

    public interface IArgument : ICommLineItem {
        string Name { get; }
        string Description { get; }
        string Value { get; set; }
    }

}
