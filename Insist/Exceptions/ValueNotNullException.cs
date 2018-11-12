using System;
using System.Runtime.Serialization;

namespace Insist.Exceptions
{
    public class ValueNotNullException : ValidationException
    {
        public ValueNotNullException()
        {
        }

        public ValueNotNullException(string message) : base(message)
        {
        }

        public ValueNotNullException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ValueNotNullException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
