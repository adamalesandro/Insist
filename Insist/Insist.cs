using Insist.Validations;
using System;
using System.Collections.Generic;
using Insist.Exceptions;
using Insist.Helpers;

namespace Insist
{
    public static class Insist
    {
        private static Dictionary<string, object> _dictionary;

        public static void Register<T>(string name, Func<T, bool> validation)
        {
            if (_dictionary == null)
                _dictionary = new Dictionary<string, object>();

            _dictionary.Set(name, validation);
        }

        public static void That<T>(string name, T value, bool suppressExceptions = false, Exception customException = null)
        {
            if (!_dictionary.ContainsKey(name))
            {
                throw new UnregisteredValidationException($"Validation '{name}' was not registered");
            }
            if (_dictionary.TryGet<T>(name, out var validation)) 
            {
                CustomValidations.CustomValidate(validation, value, suppressExceptions, customException, name);
            }
            else
            {
                throw new ValidationException($"Validation '{name}' failed since input value is of type '{typeof(T).Name}' which is not the type the validation was registered with");
            }
        }

        public static void IsNotNull(object value, bool suppressExceptions = false, Exception customException = null) => NullValidations.IsNotNull(value, suppressExceptions, customException);
        public static void IsNull(object value, bool suppressExceptions = false, Exception customException = null) => NullValidations.IsNull(value, suppressExceptions, customException);
        public static void IsNotZero(object value, bool suppressExceptions = false, Exception customException = null) => ZeroValidations.IsNotZero(value, suppressExceptions, customException);
        public static void IsZero(object value, bool suppressExceptions = false, Exception customException = null) => ZeroValidations.IsZero(value, suppressExceptions, customException);
    }
}
