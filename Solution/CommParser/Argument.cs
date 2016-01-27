using System;

namespace CommParse {

    public class Argument : IArgument {
        public Argument(string name) {
            reset(name, null);
        }
        public Argument(string name, string description) {
            reset(name, description);
        }

        public string Name { get; private set; }
        public string Description { get; private set; }
        public string Value { get; set; }

        private void reset(string name, string description) {
            if (name?.Length == 0)
                throw new NotImplementedException("Name must be null or have a non-zero length");

            Name = name;
            Description = description;
        }
    }

}
