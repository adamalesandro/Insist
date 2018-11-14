using System;
using Insist.Exceptions;

namespace Insist
{
    public static class ValidationHandler
    {
        public static void HandleValidation<T>(T value, Func<T, bool> validation, Exception exception, string validationExceptionMessage = null)
        {
            var shouldThrowException = false;
            try
            {
                if (!validation(value))
                    shouldThrowException = true;
            }
            catch (Exception generalException)
            {
                var displayMessage = validationExceptionMessage ?? $"exception: '{exception.GetType().Name}'";
                throw new ValidationException($"Insist Validation failed on {displayMessage} due to general exception: [{generalException.Message}] thrown");
            }

            if (shouldThrowException)
                throw exception;
        }
    }
}
