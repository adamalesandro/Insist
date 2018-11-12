using Insist.Validations;

namespace Insist
{
    public static class Insist
    {
        public static void IsNotNull(object value) => NullValidations.IsNotNull(value);
        public static void IsNull(object value) => NullValidations.IsNull(value);
    }
}
