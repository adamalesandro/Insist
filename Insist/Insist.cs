using Insist.Validations;
using System;
using System.Collections.Generic;

namespace Insist
{
    public static class Insist
    {
        public static void HasNoNulls<T>(IEnumerable<T> collection, bool suppressExceptions = false, Exception customException = null) 
            => CollectionValidations.HasNoNulls<T>(collection, suppressExceptions, customException);
        public static void HasNoNulls<T>(IEnumerable<T> collection, string propertyName, bool suppressExceptions = false, Exception customException = null)
            => CollectionValidations.HasNoNulls<T>(collection, propertyName, suppressExceptions, customException);
        public static void IsNotNull(object value, bool suppressExceptions = false, Exception customException = null) 
            => NullValidations.IsNotNull(value, suppressExceptions, customException);
        public static void IsNull(object value, bool suppressExceptions = false, Exception customException = null) 
            => NullValidations.IsNull(value, suppressExceptions, customException);
        public static void IsNotZero(object value, bool suppressExceptions = false, Exception customException = null) 
            => ZeroValidations.IsNotZero(value, suppressExceptions, customException);
        public static void IsZero(object value, bool suppressExceptions = false, Exception customException = null) 
            => ZeroValidations.IsZero(value, suppressExceptions, customException);
    }
}
