namespace CommParse {

    public enum EqualsSyntax {
        Required,
        Allowed,
        Forbidden,
    }

    public class ParamFlag : Flag {
        public ParamFlag(char letter, FlagSyntax flagSyntax = FlagSyntax.Both, EqualsSyntax equalsSyntax = EqualsSyntax.Allowed) : base(letter, flagSyntax) {
            reset(equalsSyntax);
        }
        public ParamFlag(char letter, string name, EqualsSyntax equalsSyntax = EqualsSyntax.Allowed) : base(letter, name) {
            reset(equalsSyntax);
        }
        
        public EqualsSyntax EqualsSyntax { get; private set; }
        public string Arg { get; set; }

        // HELPER FUNCTIONS
        private void reset(EqualsSyntax equalsSyntax) {
            ArgCount = 1;
            EqualsSyntax = equalsSyntax;
        }
    }

    public class ParamFlag<T> : Flag where T : struct {
        public ParamFlag(char letter, FlagSyntax flagSyntax = FlagSyntax.Both, EqualsSyntax equalsSyntax = EqualsSyntax.Allowed) : base(letter, flagSyntax) {
            reset(equalsSyntax);
        }
        public ParamFlag(char letter, string name, EqualsSyntax equalsSyntax = EqualsSyntax.Allowed) : base(letter, name) {
            reset(equalsSyntax);
        }

        public EqualsSyntax EqualsSyntax { get; private set; }
        public T Arg { get; set; }

        // HELPER FUNCTIONS
        private void reset(EqualsSyntax equalsSyntax) {
            ArgCount = 1;
            EqualsSyntax = equalsSyntax;
        }
    }

}
