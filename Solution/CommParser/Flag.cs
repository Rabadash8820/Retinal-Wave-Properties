using System;

namespace CommParse {

    public enum EqualsSyntax {
        Required,
        Allowed,
        Forbidden,
    }

    public class Flag : IFlag {
        // CONSTRUCTORS
        public Flag(char letter, EqualsSyntax equalsSyntax = EqualsSyntax.Allowed) {
            reset(letter, null, null, 0, equalsSyntax);
        }
        public Flag(char letter, string name, short argCount = 0, EqualsSyntax equalsSyntax = EqualsSyntax.Allowed) {
            reset(letter, name, null, argCount, equalsSyntax);
        }
        public Flag(char letter, string name, string description, short argCount = 0, EqualsSyntax equalsSyntax = EqualsSyntax.Allowed) {
            reset(letter, name, description, 0, equalsSyntax);
        }

        // PROPERTIES
        public char Letter { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string[] Args { get; protected set; }
        public EqualsSyntax EqualsSyntax { get; private set; }
        public bool Set { get; set; }

        // HELPER FUNCTIONS
        private void reset(char letter, string name, string description, short argCount, EqualsSyntax equalsSyntax) {
            // Make sure letter and name are valid
            if (!char.IsLetter(letter))
                throw new NotImplementedException("Letter must be a letter");
            if (name?.Length <= 1)
                throw new NotImplementedException("Name must be null or have length greater than 1");
            foreach (char ch in name?.ToCharArray()) {
                if (!char.IsLetterOrDigit(ch) && ch != '-')
                    throw new NotImplementedException("Name can only contain letters, digits, and hyphens");
            }

            Letter = letter;
            Name = name;
            Description = description;
            Args = new string[argCount];
            EqualsSyntax = equalsSyntax;
        }
    }

}
