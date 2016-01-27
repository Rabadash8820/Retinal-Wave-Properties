namespace CommParse {

    public interface IFlag : ICommLineItem {
        char Letter { get; }
        string Name { get; }
        string Description { get; }

        string[] Args { get; }
        bool Set { get; set; }
    }

}
