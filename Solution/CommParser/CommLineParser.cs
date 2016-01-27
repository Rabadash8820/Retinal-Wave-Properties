using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommParse {

    public sealed class CommLineParser {
        private static CommLineItemCollection _commLineItems;
        private static int _currentArg = -1;

        // INTERFACE FUNCTIONS
        public static void Parse(CommLineItemCollection commLineItems, params string[] args) {
            _commLineItems = commLineItems;

            int i = 0;
            int numNextItems;
            while (i < args.Length) {
                parseItem(args[i], out numNextItems);

                i += (numNextItems + 1);
            }
        }

        // HELPER FUNCTIONS
        private static void parseItem(string item, out int numNextItems) {
            numNextItems = 0;

            // Determine if this Item is a Flag
            bool isFlag = isItemFlag(item);

            // If not, parse it as an Argument
            if (!isFlag) {
                IArgument arg = parseArg(item);
                arg.Value = item;
            }

            // But if so, parse it as a Flag
            // Store how many items need to be parsed after this Flag in the out parameter
            else {
                IFlag flag = parseFlag(item);
                flag.Set = true;
                if (flag.Args.Length > 1)
                    numNextItems = 1;
            }

        }

        private static bool isItemFlag(string item) {
            // If length 0, cant have a flag character, so return false
            int len = item.Length;
            if (len == 0)
                return false;

            // If first character is not a flag character, return false
            char ch0 = item[0];
            if (ch0 == '-' || ch0 == '/')
                return false;

            // If flag character does not match the required syntax, syntax error
            FlagSyntax syntax = (ch0 == '-' ? FlagSyntax.Unix : FlagSyntax.Dos);
            if (syntax == _commLineItems.FlagSyntax)
                return true;
            else
                throw new NotImplementedException("Invalid flag syntax");
        }
        private static IFlag parseFlag(string flag) {
            // Parse the Flag characters according to the proper syntax
            string str = flag.Substring(1);
            if (_commLineItems.FlagSyntax == FlagSyntax.Dos)
                return parseDosFlag(str);
            else
                return parseUnixFlag(str);
        }
        private static IFlag parseDosFlag(string flag) {
            char ch = flag[0];

            // If more than one character after flag character, return null (user was probably trying to provide a path)
            if (flag.Length > 1)
                return null;

            // If nothing after flag character, syntax error
            else if (flag == "")
                throw new NotImplementedException("Invalid switch - \"\"");

            // If non-letter or non-digit after flag character, syntax error
            else if (!char.IsLetterOrDigit(ch))
                throw new NotImplementedException($"Invalid switch - \"{ch}\"");

            // Otherwise, return the matching Flag if it exists
            else {
                IEnumerable<IFlag> matches = _commLineItems.Flags.Where(f => char.ToUpper(f.Letter) == char.ToUpper(ch));
                if (matches.Count() == 1)
                    return matches.Single();
                else
                    throw new NotImplementedException($"Invalid switch - \"{ch}\"");
            }
        }
        private static IFlag parseUnixFlag(string flag) {
            char ch = flag[0];

            // If nothing after flag character, syntax error
            if (flag == "")
                throw new NotImplementedException("Unknown option: -");

            string str = flag.Substring(1);
            if (ch == '-')
                return parseUnixFlagName(str);
            else
                return parseUnixFlagLetter(str);
        }
        private static IFlag parseUnixFlagLetter(string flag) {
            char letter = flag[0];

            // If not just a single character after flag character, or single character is invalid, syntax error
            if (flag.Length > 1 || !char.IsLetterOrDigit(letter))
                throw new NotImplementedException($"Unknown option: -{flag.Substring(1)}");

            // Otherwise, return the matching Flag if it exists
            else {
                IEnumerable<IFlag> matches = _commLineItems.Flags.Where(f => f.Letter == letter);
                if (matches.Count() == 1)
                    return matches.Single();
                else
                    throw new NotImplementedException($"Unknown option:  -{letter}");
            }
        }
        private static IFlag parseUnixFlagName(string name) {
            // If nothing after flag character, syntax error
            if (name.Length <= 1)
                throw new NotImplementedException($"Unknown option: --{name}");

            // If invalid characters after flag character, syntax error
            foreach (char ch in name.ToCharArray()) {
                if (!char.IsLetterOrDigit(ch) && ch != '-' && ch != '=')
                    throw new NotImplementedException($"Unknown option: --{name}");
            }

            // Otherwise, return the matching Flag if it exists
            IEnumerable<IFlag> matches = _commLineItems.Flags.Where(f => f.Name == name);
            if (matches.Count() == 1)
                return matches.Single();
            else
                throw new NotImplementedException($"Unknown option: -{name}");
        }

        private static IArgument parseArg(string arg) {
            IArgument a = _commLineItems.Args[++_currentArg];
            return a;
        }

    }

}
