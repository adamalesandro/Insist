using System;
using System.Runtime.Serialization;

namespace Insist.Exceptions
{
    public class ValueIsZeroException : ValidationException
    {
        public ValueIsZeroException()
        {
        }

        public ValueIsZeroException(string message) : base(message)
        {
        }

        public ValueIsZeroException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ValueIsZeroException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
