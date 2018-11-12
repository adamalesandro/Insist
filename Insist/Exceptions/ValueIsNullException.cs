using System;
using System.Runtime.Serialization;

namespace Insist.Exceptions
{
    public class ValueIsNullException : ValidationException
    {
        public ValueIsNullException()
        {
        }

        public ValueIsNullException(string message) : base(message)
        {
        }

        public ValueIsNullException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ValueIsNullException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
