using System;
using System.Collections.Generic;

namespace CommParse {

    public class ListFlag : Flag {
        private IList<string> _args = new List<string>();

        // CONSTRUCTORS
        public ListFlag(char letter, string name, short maxArgs = -1) : base(letter, name) {
            reset(maxArgs);
        }

        // PROPERTIES
        public short MaxArgs { get; private set; }
        public IReadOnlyList<string> Args {
            get { return _args as IReadOnlyList<string>; }
        }

        public void AddArg(string arg) {
            if (ArgCount == MaxArgs)
                throw new ArgumentException($"Flag cannot accept any more arguments (max is {MaxArgs})", nameof(arg));

            ++ArgCount;
            _args.Add(arg);
        }

        // HELPER FUNCTIONS
        private void reset(short maxArgs) {
            MaxArgs = maxArgs;

            if (MaxArgs == -1)
                _args = new List<string>();
            else
                _args = new List<string>(MaxArgs);
        }
    }

    public class ListFlag<T> : Flag where T : struct {
        private IList<T> _args = new List<T>();

        // CONSTRUCTORS
        public ListFlag(char letter, string name, short maxArgs = -1) : base(letter, name) {
            reset(maxArgs);
        }

        // PROPERTIES
        public short MaxArgs { get; private set; }
        public IReadOnlyList<T> Args {
            get { return _args as IReadOnlyList<T>; }
        }

        public void AddArg(T arg) {
            if (ArgCount == MaxArgs)
                throw new ArgumentException($"Flag cannot accept any more arguments (max is {MaxArgs})", nameof(arg));

            ++ArgCount;
            _args.Add(arg);
        }

        // HELPER FUNCTIONS
        private void reset(short maxArgs) {
            MaxArgs = maxArgs;

            if (MaxArgs == -1)
                _args = new List<T>();
            else
                _args = new List<T>(MaxArgs);
        }
    }

}
