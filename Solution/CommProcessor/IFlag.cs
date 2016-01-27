namespace CommParse {

    public enum FlagSyntax {
        Windows,
        Unix,
        Both
    }

    public interface IFlag : ICommandLineItem {
        char Letter { get; }
        string Name { get; }
        FlagSyntax FlagSyntax { get; }
        short ArgCount { get; }
    }

}
