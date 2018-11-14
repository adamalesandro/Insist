using Insist.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insist.Validations
{
    public static class CollectionValidations
    {
        public static void HasNoNulls<T>(IEnumerable<T> collection, string propertyName)
        {
            foreach (var item in collection)
            {
                var value = item?.GetType()?.GetProperty(propertyName)?.GetValue(item, null);

                if (value == null)
                    throw new CollectionContainsNullValueException();
            }
        }

        public static void HasNoNulls<T>(IEnumerable<T> collection)
        {
            if (collection.Any(x => x == null))
                throw new CollectionContainsNullValueException();
        }
    }
}
