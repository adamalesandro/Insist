using Insist.Exceptions;
using System;
using static Insist.ValidationHandler;

namespace Insist.Validations
{
    internal static class NullValidations
    {
        internal static void IsNull(object value, bool suppressExceptions, Exception customException)
        {
            bool Func(object val) => val == null;
            if (!suppressExceptions)
                HandleValidation(value, Func, customException ?? new ValueNotNullException());
        }

        internal static void IsNotNull(object value, bool suppressExceptions, Exception customException)
        {
            bool Func(object val) => val != null;
            if (!suppressExceptions)
                HandleValidation(value, Func, customException ?? new ValueIsNullException());
        }
    }
}
