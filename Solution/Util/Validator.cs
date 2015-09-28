using System;
using System.Linq;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

using Util.Properties;

namespace Util {

    public static class Validator {
        /// <summary>
        /// Check whether a string matches a given regular expression.
        /// </summary>
        /// <param name="regex">A regular expression</param>
        /// <param name="text">The text to be matched against the regex pattern</param>
        /// <returns>True or false, depending on whether the text matched the regex pattern</returns>
        public static bool Text(string regex, string text) {
            // Return whether the input has exactly one match
            Regex regexObj = new Regex(regex);
            int numMatches = regexObj.Matches(text).Count;
            return (numMatches > 0);
        }

        /// <summary>
        /// Check whether a string is a valid DateTime expression.
        /// </summary>
        /// <param name="dateStr">The text to be interpreted as a DateTime</param>
        /// <returns>True or false, depending on whether the text is a valid DateTime expression</returns>
        public static bool Date(string dateStr, DateTime earliest, DateTime latest) {
            // Return false if the string isn't in the right format
            bool validStr = Validator.Text(Resources.DateRegex, dateStr);
            if (!validStr)
                return false;

            // Return whether the provided date falls within the provided timespan
            try {
                int[] parts = dateStr.Split('/', '\\', '-')
                                     .Select(p => Convert.ToInt32(p))
                                     .ToArray();
                int month = parts[0];
                int day   = parts[1];
                int year  = parts[2];
                DateTime date = new DateTime(year, month, day);
                bool validDate = (earliest <= date && date <= latest);
                return validDate;
            }

            // If the provided date has invalid numbers for month, day, or year then return false
            catch (ArgumentOutOfRangeException) {
                return false;
            }
        }
    }

}
