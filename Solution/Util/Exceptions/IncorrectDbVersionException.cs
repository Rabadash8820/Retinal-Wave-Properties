using System;
using System.Data.Common;
using MySql.Data.MySqlClient;

namespace Util.Exceptions {

    class IncorrectDbVersionException : DbException {
        // CONSTRUCTORS
        public IncorrectDbVersionException() : base() { }
        public IncorrectDbVersionException(string message, Exception innerException) : base(message, innerException) { }
        public IncorrectDbVersionException(string message, string thisVersion, string requiredVersion)
            : base(message) {
            ThisVersion = thisVersion;
            RequiredVersion = requiredVersion;
        }
        public IncorrectDbVersionException(string message, string thisVersion, string requiredVersion, Exception innerException)
            : base(message, innerException) {
            ThisVersion = thisVersion;
            RequiredVersion = requiredVersion;
        }

        // PROPERTIES
        public string ThisVersion { get; protected set; }
        public string RequiredVersion { get; protected set; }
    }

}
