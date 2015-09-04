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
        public static string Date(string dateStr, DateTime earliest, DateTime latest) {
            // Return false if the string isn't in the right format
            bool isValidStr = Text(
                Resources.DateRegex,
                dateStr);
            if (!isValidStr) return Resources.EnterDateMsg;

            // Check that the numbers for month, day, and year are valid and are not after the current date
            bool isValidDate = false;
            try {
                int[] parts = dateStr.Split('/')
                                     .Select(p => Convert.ToInt32(p))
                                     .ToArray();
                DateTime dt = new DateTime(parts[2], parts[0], parts[1]);
                if (earliest <= dt && dt <= latest)
                    isValidDate = true;
            }
            catch (ArgumentOutOfRangeException) { }

            // If all above conditions pass then return true, otherwise show an error dialog and return false
            if (isValidDate)
                return "";
            string message = String.Format(
                Resources.InvalidDateError,
                earliest.ToShortDateString(),
                latest.ToShortDateString());
            return message;
        }
    }

}
