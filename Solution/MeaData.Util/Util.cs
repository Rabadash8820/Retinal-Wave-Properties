using System;
using System.Linq;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

using MeaData.Util.Properties;

namespace MeaData.Util {

    public static class Util {
        /// <summary>
        /// Get the name of a property from a property access lambda.
        /// </summary>
        /// <param name="nameof(propertyLambda)">lambda expression of the form: '(Class c) => c.Property'</param>
        /// <returns>The name of the property</returns>
        public static string GetPropertyName<TModel, TProperty>(Expression<Func<TModel, TProperty>> propertyLambda) {
            MemberExpression me = propertyLambda.Body as MemberExpression;
            if (me == null)
                throw new ArgumentException();
            return me.Member.Name;
        }
    }

}
