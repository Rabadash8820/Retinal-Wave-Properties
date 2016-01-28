using System;

namespace CommParse {

    public class HelpFlag : Flag {
        // CONSTRUCTORS
        public HelpFlag(string name = "help") : base('?', name, "Displays this help text.", 0) {

        }
        public HelpFlag(char letter, string name = "help") : base(letter, name, "Displays this help text.", 0) {

        }
    }

}
