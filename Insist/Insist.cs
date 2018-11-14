using Insist.Validations;
using System;
using System.Collections.Generic;

namespace Insist
{
    public static class Insist
    {
        public static void IsNotNull(object value) => NullValidations.IsNotNull(value);
        public static void IsNull(object value) => NullValidations.IsNull(value);

        public static void HasNoNulls<T>(IEnumerable<T> collection) => CollectionValidations.HasNoNulls<T>(collection);
        public static void HasNoNulls<T>(IEnumerable<T> collection, string propertyName)
            => CollectionValidations.HasNoNulls<T>(collection, propertyName);
    }
}
