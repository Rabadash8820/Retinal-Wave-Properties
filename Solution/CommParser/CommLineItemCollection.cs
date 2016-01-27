using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommParse {

    public enum FlagSyntax {
        Dos,
        Unix
    }

    public class CommLineItemCollection {
        public CommLineItemCollection(FlagSyntax flagSyntax) {
            FlagSyntax = flagSyntax;
        }

        public void AddFlag(IFlag flag) {
            IEnumerable<IFlag> matches = (FlagSyntax == FlagSyntax.Dos ?
                                            Flags.Where(f => char.ToUpper(f.Letter) == char.ToUpper(flag.Letter)) :
                                            Flags.Where(f => f.Letter == flag.Letter || (f.Name?.Equals(flag.Name) ?? false)));

            if (matches.Count() > 0) {
                if (FlagSyntax == FlagSyntax.Dos)
                    throw new NotImplementedException("Each Dos-style Flag must have a unique letter (case insensitive)");
                else
                    throw new NotImplementedException("Each Unix-style Flag must have a unique letter and name");
            }
        }
        public void AddArgument(IArgument arg) {
            IEnumerable<IArgument> matches = Args.Where(a => a.Name?.Equals(arg.Name) ?? false);
            if (matches.Count() > 0)
                throw new NotImplementedException("Each Argument must have a unique name");
        }
        
        public FlagSyntax FlagSyntax { get; private set; }
        public ISet<IFlag> Flags { get; } = new HashSet<IFlag>();
        public IList<IArgument> Args { get; } = new List<IArgument>();
    }

}
