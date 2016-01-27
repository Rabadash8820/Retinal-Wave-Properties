namespace CommParse {

    public class Flag : IFlag {
        // CONSTRUCTORS
        public Flag(char letter, FlagSyntax flagSyntax = FlagSyntax.Both) {
            reset(letter, null, flagSyntax);
        }
        public Flag(char letter, string name) {
            reset(letter, name, FlagSyntax.Unix);
        }

        // PROPERTIES
        public char Letter { get; private set; }
        public string Name { get; private set; }
        public FlagSyntax FlagSyntax { get; private set; }
        public short ArgCount { get; protected set; } = 0;

        // HELPER FUNCTIONS
        private void reset(char letter, string name, FlagSyntax flagSyntax) {
            Letter = letter;
            Name = name;
            FlagSyntax = flagSyntax;
        }
    }

}
