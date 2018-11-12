using Insist.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insist.Validations
{
    public static class NullValidations
    {
        public static void IsNotNull(object value)
        {
            if (value == null)
                throw new ValueIsNullException();
        }

        public static void IsNull(object value)
        {
            if (value != null)
                throw new ValueNotNullException();
        }
    }
}
