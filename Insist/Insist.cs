using Insist.Validations;
using System;

namespace Insist
{
    public static class Insist
    {
        public static void IsNotNull(object value, bool suppressExceptions = false, Exception customException = null) => NullValidations.IsNotNull(value, suppressExceptions, customException);
        public static void IsNull(object value, bool suppressExceptions = false, Exception customException = null) => NullValidations.IsNull(value, suppressExceptions, customException);
        public static void IsNotZero(object value, bool suppressExceptions = false, Exception customException = null) => ZeroValidations.IsNotZero(value, suppressExceptions, customException);
        public static void IsZero(object value, bool suppressExceptions = false, Exception customException = null) => ZeroValidations.IsZero(value, suppressExceptions, customException);
    }
}
