using System;
using System.Linq;
using System.Collections.Generic;

namespace CommParse {

    public enum FlagSyntax {
        Dos,
        Unix,
        Both,
    }

    public class CommLineItemCollection<F, A> where F : struct, IConvertible where A : struct, IConvertible {
        // HIDDEN FIELDS
        private Dictionary<F, IFlag> _flags;
        private Dictionary<A, int> _argIndices;
        private IList<IArgument> _args;
        private int _numArgs = 0;
        private int _currentArg = 0;
        private string _preDesc = null;
        private string _postDesc = null;

        // CONSTRUCTORS
        public CommLineItemCollection(string preItemDescription = null, string postItemDescription = null, FlagSyntax flagSyntax = FlagSyntax.Both) {
            if (!typeof(F).IsEnum || !typeof(A).IsEnum)
                throw new ArgumentException("T must be an enumerated type");

            FlagSyntax = flagSyntax;

            _preDesc = preItemDescription;
            _postDesc = postItemDescription;

            _flags = new Dictionary<F, IFlag>();
            _argIndices = new Dictionary<A, int>();
            _args = new List<IArgument>();
        }

        // PROPERTIES
        public IFlag this[F key] {
            get {
                if (_flags.ContainsKey(key))
                    return _flags[key];
                else
                    throw new ArgumentException("This enum value has not been associated with a command line item");
            }
        }
        public IArgument this[A key] {
            get {
                if (_argIndices.ContainsKey(key))
                    return _args[_argIndices[key]];
                else
                    throw new ArgumentException("This enum value has not been associated with a command line item");
            }
        }
        public FlagSyntax FlagSyntax { get; private set; }
        public string CorrectUsage {
            get {
                return _preDesc + '\n' + _postDesc;
            }
        }
        public bool IsHelpSet {
            get {
                IFlag help = _flags.Values.Where(f => f is HelpFlag).SingleOrDefault() as HelpFlag;
                bool set = help?.Set ?? false;
                return set;
            }
        }

        // INTERFACE FUNCTIONS
        public void AddFlag(F key, IFlag flag) {
            if (_flags.ContainsKey(key))
                throw new NotImplementedException("This key already associated with a Flag");
            checkFlagUnique(flag);

            _flags.Add(key, flag);
        }
        public void AddHelpFlag(F key) {
            HelpFlag help = new HelpFlag();

            if (_flags.ContainsKey(key))
                throw new NotImplementedException("This key already associated with a Flag");
            checkFlagUnique(help);
            
            _flags.Add(key, help);
        }
        public void AddArgument(A key, IArgument arg) {
            if (_argIndices.ContainsKey(key))
                throw new NotImplementedException("This key already associated with an Argument");

            _argIndices.Add(key, _numArgs++);
            _args.Add(arg);
        }
        public void Parse(string[] items) {
            // Clear any old parsed values
            foreach (IArgument arg in _args)
                arg.Value = null;
            foreach (IFlag flag in _flags.Values) {
                for (int a = 0; a < flag.Args.Length; ++a)
                    flag.Args[a] = null;
            }

            // Parse the new strings
            int i = 0;
            int itemsParsed;
            while (i < items.Length) {
                parseItem(items, i, out itemsParsed);
                i += itemsParsed;
            }
        }
        public bool IsFlagSet(F key) {
            if (_flags.ContainsKey(key))
                return _flags[key].Set;
            else
                throw new ArgumentException("This enum value has not been associated with a Flag");
        }
        public string[] FlagArgs(F key) {
            if (_flags.ContainsKey(key))
                return _flags[key].Args;
            else
                throw new ArgumentException("This enum value has not been associated with a Flag");
        }
        public string ArgValue(A key) {
            if (_argIndices.ContainsKey(key))
                return _args[_argIndices[key]].Value;
            else
                throw new ArgumentException("This enum value has not been associated with an Argument");
        }

        // HELPER FUNCTIONS
        private void checkKeyUnique(F key) {
            // Make sure this key isn't already taken
        }
        private void checkFlagUnique(IFlag flag) {
            // Make sure this Flag's letter isn't already taken
            IEnumerable<IFlag> matches = (FlagSyntax == FlagSyntax.Dos || FlagSyntax == FlagSyntax.Both ?
                                            _flags.Values.Where(f => char.ToUpper(f.Letter) == char.ToUpper(flag.Letter)) :
                                            _flags.Values.Where(f => f.Letter == flag.Letter || (f.Name?.Equals(flag.Name) ?? false)));

            // If it is, then throw a DOS- or Unix-style exception
            if (matches.Count() > 0) {
                if (FlagSyntax == FlagSyntax.Dos || FlagSyntax == FlagSyntax.Both)
                    throw new NotImplementedException("Each Flag must have a unique letter (regardless of case)");
                else
                    throw new NotImplementedException("Each Flag must have a unique letter and name");
            }
        }
        private void checkArgUnique(IArgument arg) {
            // Make sure this Argument's name hasn't already been taken
            IEnumerable<IArgument> matches = _args.Where(a => a.Name?.Equals(arg.Name) ?? false);
            if (matches.Count() > 0)
                throw new NotImplementedException("Each Argument must have a unique name");
        }

        private void parseItem(string[] items, int index, out int itemsParsed) {
            // Determine if this Item is a Flag
            string item = items[index];
            bool isFlag = isItemFlag(item);

            // If not, parse it as an Argument
            if (!isFlag) {
                IArgument arg = parseArg(item);
                arg.Value = item;
                itemsParsed = 1;
            }

            // But if so, parse it as a Flag (may require parsing additional items after the Flag)
            else {
                FlagSyntax syntax = (item[0] == '-' ? FlagSyntax.Unix : FlagSyntax.Dos);
                IFlag flag = parseFlag(item, syntax);
                flag.Set = true;
                if (index + flag.Args.Length + 1 > items.Length)
                    throw new NotImplementedException($"Not enough arguments provided to {item} flag");
                parseFlagArgs(flag, items, index + 1);
                itemsParsed = 1 + flag.Args.Length;
            }
        }
        private bool isItemFlag(string item) {
            // If length 0, cant have a flag character, so return false
            int len = item.Length;
            if (len == 0)
                return false;

            // If first character is not a flag character, return false
            char ch = item[0];
            if (ch != '-' && ch != '/')
                return false;

            // If flag character does not match the required syntax, syntax error
            FlagSyntax syntax = (ch == '-' ? FlagSyntax.Unix : FlagSyntax.Dos);
            if (FlagSyntax == FlagSyntax.Both || syntax == FlagSyntax)
                return true;
            else
                throw new NotImplementedException("Invalid flag syntax");
        }
        private IArgument parseArg(string arg) {
            if (_currentArg >= _numArgs)
                throw new NotImplementedException("Too many arguments supplied.");

            return _args[_currentArg++];
        }
        private IFlag parseFlag(string flag, FlagSyntax syntax) {
            string str = flag.Substring(1);

            // Parse the Flag characters according to the proper syntax
            if (syntax == FlagSyntax.Dos)
                return parseDosFlag(str);
            else
                return parseUnixFlag(str);
        }

        private IFlag parseDosFlag(string flag) {
            char ch = flag[0];

            // If more than one character after flag character, return null (user was probably trying to provide a path)
            if (flag.Length > 1)
                return null;

            // If nothing after flag character, syntax error
            else if (flag == "")
                throw new NotImplementedException("Invalid switch - \"\"");

            // If non-letter/digit/help character after flag character, syntax error
            else if (!char.IsLetterOrDigit(ch) && ch != '?')
                throw new NotImplementedException($"Invalid switch - \"{ch}\"");

            // Otherwise, return the matching Flag if it exists
            else {
                IEnumerable<IFlag> matches = _flags.Values.Where(f => char.ToUpper(f.Letter) == char.ToUpper(ch));
                if (matches.Count() == 1)
                    return matches.Single();
                else
                    throw new NotImplementedException($"Invalid switch - \"{ch}\"");
            }
        }
        private IFlag parseUnixFlag(string flag) {
            char ch = flag[0];

            // If nothing after flag character, syntax error
            if (flag == "")
                throw new NotImplementedException("Unknown option: -");
            
            if (ch == '-')
                return parseUnixFlagName(flag.Substring(1));
            else
                return parseUnixFlagLetter(flag);
        }
        private IFlag parseUnixFlagLetter(string flag) {
            char letter = flag[0];

            // If not just a single character after flag character, or single character is invalid, syntax error
            if (flag.Length > 1 || !char.IsLetterOrDigit(letter))
                throw new NotImplementedException($"Unknown option: -{flag}");

            // Otherwise, return the matching Flag if it exists
            else {
                IEnumerable<IFlag> matches = _flags.Values.Where(f => f.Letter == letter);
                if (matches.Count() == 1)
                    return matches.Single();
                else
                    throw new NotImplementedException($"Unknown option:  -{letter}");
            }
        }
        private IFlag parseUnixFlagName(string flag) {
            // If nothing after flag character, syntax error
            if (flag.Length <= 1)
                throw new NotImplementedException($"Unknown option: --{flag}");

            // If equals sign or colon is present, it should ONLY be used to separate flag name and value
            string[] parts = flag.Split('=', ':');
            if (parts.Length > 2)
                throw new NotImplementedException("'=' and ':' characters can only be used to separate flag names/values");

            // If invalid characters in name character, syntax error
            string name = parts[0];
            foreach (char ch in name.ToCharArray()) {
                if (!char.IsLetterOrDigit(ch) && ch != '-')
                    throw new NotImplementedException($"Unknown option: --{name}");
            }

            // Otherwise, return the matching Flag if it exists
            IEnumerable<IFlag> matches = _flags.Values.Where(f => f.Name == name);
            if (matches.Count() == 1)
                return matches.Single();
            else
                throw new NotImplementedException($"Unknown option: -{name}");
        }
        private void parseFlagArgs(IFlag flag, string[] items, int index) {
            // If one of the command line items following the flag is also a flag, syntax error
            for (int a = 0; a < flag.Args.Length; ++a) {
                string arg = items[index + a];
                if (isItemFlag(arg))
                    throw new NotImplementedException($"Not enough arguments provided to {items[index - 1]} flag");
                else
                    flag.Args[a] = arg;
            }
        }

    }

}
