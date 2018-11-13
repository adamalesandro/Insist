using Insist.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Insist.ValidationHandler;

namespace Insist.Validations
{
    public static class CollectionValidations
    {
        public static void HasNoNulls<T>(IEnumerable<T> collection, string propertyName, bool suppressExceptions, Exception customException)
        {
            bool Func(IEnumerable<T> set)
            {
                foreach (var item in set)
                {
                    var value = item?.GetType()?.GetProperty(propertyName)?.GetValue(item, null);
                    if (value == null)
                        return false;
                }
                return true;
            }

            if (!suppressExceptions)
                HandleValidation(collection, Func, customException ?? new CollectionContainsNullValueException());
        }

        public static void HasNoNulls<T>(IEnumerable<T> collection, bool suppressExceptions, Exception customException)
        {
            bool Func(IEnumerable<T> set) => set.All(x => x != null);

            if (!suppressExceptions)
                HandleValidation(collection, Func, customException ?? new CollectionContainsNullValueException());
        }
    }
}
