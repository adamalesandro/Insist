using System;
using System.Runtime.Serialization;

namespace Insist.Exceptions
{
    public class UnregisteredValidationException : ValidationException
    {
        public UnregisteredValidationException()
        {
        }

        public UnregisteredValidationException(string message) : base(message)
        {
        }

        public UnregisteredValidationException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected UnregisteredValidationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
