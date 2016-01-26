using System;
using System.Linq;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

using MeaData.Util.Properties;

namespace MeaData.Util {

    public static class Validator {
        /// <summary>
        /// Checks whether a string has at least one non-whitespace character.
        /// </summary>
        /// <param name="text">The text to be checked for whitespace characters.</param>
        /// <returns>True or false, depending on whether the text has at least one non-whitespace character.</returns>
        public static bool NonEmpty(string text) {
            // Return whether the input has exactly one match
            Regex regexObj = new Regex(RegexRes.NonEmpty);
            int numMatches = regexObj.Matches(text).Count;
            return (numMatches > 0);
        }

        /// <summary>
        /// Checks whether a string matches a given regular expression.
        /// </summary>
        /// <param name="text">The text to be matched against the regex pattern.</param>
        /// <param name="regex">A regular expression.</param>
        /// <returns>True or false, depending on whether the text matched the regex pattern.</returns>
        public static bool Text(string text, string regex) {
            // Return whether the input has exactly one match
            Regex regexObj = new Regex(regex);
            int numMatches = regexObj.Matches(text).Count;
            return (numMatches > 0);
        }

        /// <summary>
        /// Checks whether a string is a valid Email address.
        /// </summary>
        /// <param name="text">The text to be matched against an Email format.</param>
        /// <returns>True or false, depending on whether the text is a valid Email address.</returns>
        public static bool Email(string text) {
            // Return whether the input has exactly one match
            Regex regex = new Regex(RegexRes.EmailAddress);
            int numMatches = regex.Matches(text).Count;
            return (numMatches > 0);
        }

        /// <summary>
        /// Checks whether a string is a valid phone number.
        /// </summary>
        /// <param name="text">The text to be matched against a phone number format.</param>
        /// <returns>True or false, depending on whether the text is a valid phone number.</returns>
        public static bool PhoneNumber(string text) {
            // Return whether the input has exactly one match
            Regex regex = new Regex(RegexRes.PhoneNumber);
            int numMatches = regex.Matches(text).Count;
            return (numMatches > 0);
        }

        /// <summary>
        /// Checks whether a string is a person's name.
        /// </summary>
        /// <param name="text">The text to be matched against a name format.</param>
        /// <returns>True or false, depending on whether the text is a person's name.</returns>
        public static bool PersonName(string text) {
            // Return whether the input has exactly one match
            Regex regex = new Regex(RegexRes.PersonName);
            int numMatches = regex.Matches(text).Count;
            return (numMatches > 0);
        }

        /// <summary>
        /// Checks whether a string is a valid date expression.
        /// </summary>
        /// <param name="dateStr">The text to be interpreted as a date.</param>
        /// <returns>True or false, depending on whether the text is a valid date expression</returns>
        public static bool Date(string dateStr) {
            DateTime date;
            bool validStr = DateTime.TryParse(dateStr, out date);
            return validStr;
        }

        /// <summary>
        /// Checks whether a date string is between two given DateTimes.
        /// </summary>
        /// <param name="dateStr">The text to be interpreted as a DateTime</param>
        /// <exception cref="FormatException">Thrown when the provided string is not in a valid DateTime format.</exception>
        /// <returns>True or false, depending on whether the given date is between the two DateTime expressions.</returns>
        public static bool DateBetween(string dateStr, DateTime earliest, DateTime latest) {
            // Return false if the string isn't in the right format
            bool validStr = Validator.Date(dateStr);
            if (!validStr)
                throw new FormatException($"{nameof(dateStr)} was not in a valid DateTime format");

            // Return whether the provided date falls within the provided timespan
            DateTime date = DateTime.Parse(dateStr);
            bool dateBtwn = (earliest <= date && date <= latest);
            return dateBtwn;
        }
    }

}
