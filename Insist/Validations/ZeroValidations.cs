using Insist.Exceptions;
using System;
using static Insist.ValidationHandler;
using static Insist.Helpers.DataValidationHelpers;

namespace Insist.Validations
{
    internal static class ZeroValidations
    {
        internal static void IsZero(object value, bool suppressExceptions, Exception customException)
        {
            var exception = customException ?? new ValueNotZeroException();
            if (!IsNumber(value)) throw exception;

            bool Func(dynamic val) => val == 0;
            if (!suppressExceptions)
                HandleValidation(value, Func, exception);
        }

        internal static void IsNotZero(object value, bool suppressExceptions, Exception customException)
        {
            if (!IsNumber(value)) return;

            bool Func(dynamic val) => val != 0;
            if (!suppressExceptions)
                HandleValidation(value, Func, customException ?? new ValueIsZeroException());
        }
    }
}
