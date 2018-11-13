using System;
using System.Runtime.Serialization;

namespace Insist.Exceptions
{
    public class ValueNotZeroException : ValidationException
    {
        public ValueNotZeroException()
        {
        }

        public ValueNotZeroException(string message) : base(message)
        {
        }

        public ValueNotZeroException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ValueNotZeroException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
