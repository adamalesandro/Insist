using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Insist.Exceptions
{
    public class CollectionContainsNullValueException : ValidationException
    {
        public CollectionContainsNullValueException()
        {
        }

        public CollectionContainsNullValueException(string message) : base(message)
        {
        }

        public CollectionContainsNullValueException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CollectionContainsNullValueException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
