using Insist.Exceptions;
using System;
using static Insist.ValidationHandler;

namespace Insist.Validations
{
    internal static class CustomValidations
    {
        internal static void CustomValidate<T>(Func<T, bool> validation, T value, bool suppressExceptions, Exception customException, string validationName)
        {
            var exception = customException ?? new ValidationException($"Insist exception thrown with registered validation: '{validationName}'");
            var exceptionMessage = customException?.GetType() != null ? $"exception: '{customException.GetType().Name}' and " : "";
            var displayMessage = $"{exceptionMessage}custom validation: '{validationName}'";
            if (!suppressExceptions)
                HandleValidation(value, validation, exception, displayMessage);
        }

    }
}
