using System;
using System.Linq;
using System.Windows.Forms;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

using MEACruncher.Resources;

namespace MEACruncher {

    static class Util {
        /// <summary>
        /// Get the name of a property from a property access lambda.
        /// </summary>
        /// <param name="propertyLambda">lambda expression of the form: '(Class c) => c.Property'</param>
        /// <returns>The name of the property</returns>
        public static string GetPropertyName<TModel, TProperty>(Expression<Func<TModel, TProperty>> propertyLambda) {
            MemberExpression me = propertyLambda.Body as MemberExpression;
            if (me == null)
                throw new ArgumentException();
            return me.Member.Name;
        }

        /// <summary>
        /// Check whether a string matches a given regular expression.
        /// </summary>
        /// <param name="regex">A regular expression</param>
        /// <param name="text">The text to be matched against the regex pattern</param>
        /// <returns>True or false, depending on whether the text matched the regex pattern</returns>
        public static bool validText(string regex, string text) {
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
        public static string validDate(string dateStr, DateTime earliest, DateTime latest) {
            // Return false if the string isn't in the right format
            bool isValidStr = validText(
                Resources.RegexRes.Date,
                dateStr);
            if (!isValidStr) return ValidateRes.Date;

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
                ValidateRes.DateValue,
                earliest.ToShortDateString(),
                latest.ToShortDateString());
            return message;
        }
    }

}
