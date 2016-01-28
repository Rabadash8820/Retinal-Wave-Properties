using CommParse;

namespace MEACruncher {

    internal enum FlagType {
        Help,
        DispA,
        DispB,
        DispC,
        Disp1,
        Disp2,
        Disp3,
    }
    internal enum ArgType {
        FileName,
        VersionStr,
    }

    static class CommLineItemCollectionBuilder {

        public static CommLineItemCollection<FlagType, ArgType> Get() {
            // Define a command line item collection
            string preDesc = "MEA Cruncher is awesome yo!";
            string postDesc = "Here are some additional notes about starting MEA Cruncher from the command line";
            CommLineItemCollection<FlagType, ArgType> items = new CommLineItemCollection<FlagType, ArgType>(preDesc, postDesc);

            // Add flags
            items.AddHelpFlag(FlagType.Help);
            items.AddFlag(FlagType.DispA, new Flag('a', "disp-a", "Setting this flag displays A"));
            items.AddFlag(FlagType.DispB, new Flag('b', "disp-b", "Setting this flag displays B"));
            items.AddFlag(FlagType.DispC, new Flag('c', "disp-c", "Setting this flag displays C"));
            items.AddFlag(FlagType.Disp1, new Flag('1', "one", "Setting this flag displays 1"));
            items.AddFlag(FlagType.Disp2, new Flag('2', "two", "Setting this flag displays 2"));
            items.AddFlag(FlagType.Disp3, new Flag('3', "three", "Setting this flag displays 3"));

            // Add arguments (in the correct order
            items.AddArgument(ArgType.FileName, new Argument("FileName", "Fully qualified name of the file you want to modify"));
            items.AddArgument(ArgType.VersionStr, new Argument("VersionStr", "The new version string"));

            return items;
        }

    }

}
