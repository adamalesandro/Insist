using Insist.Exceptions;
using System;
using Xunit;

namespace Insist.Tests.Unit
{
    public class CustomValidationTests
    {
        [Fact(DisplayName = "Only registered validations can be called")]
        public void TestRegisteredValidationsExistence()
        {
            bool IsTodayValidation(DateTime val) => val == DateTime.Today;
            Insist.Register("IsEvenInt", (int x) => x % 2 == 0);
            Insist.Register("IsEvenDecimal", (decimal x) => x % 2 == 0);
            Insist.Register<DateTime>("IsToday", IsTodayValidation);

            Insist.That("IsEvenInt", 0);
            Insist.That("IsEvenDecimal", 0m);
            Insist.That("IsToday", DateTime.Today);
            
            var isNotRegisteredException = Assert.Throws<UnregisteredValidationException>(() => Insist.That("NOT REGISTERED", 0));
            Assert.Equal("Validation 'NOT REGISTERED' was not registered", isNotRegisteredException.Message); 
        }

        [Fact(DisplayName = "Registered validations throw exception when called object of different type than registered")]
        public void TestRegisteredValidationsTypes()
        {
            Insist.Register("IsEvenInt", (int x) => x % 2 == 0);
            Insist.That("IsEvenInt", 0);
           
            var isEvenIntDecimalException = Assert.Throws<ValidationException>(() => Insist.That("IsEvenInt", 0m));
            Assert.Equal("Validation 'IsEvenInt' failed since input value is of type 'Decimal' which is not the type the validation was registered with", isEvenIntDecimalException.Message);
            var createdClassException = Assert.Throws<ValidationException>(() => Insist.That("IsEvenInt", new TestClass()));
            Assert.Equal("Validation 'IsEvenInt' failed since input value is of type 'TestClass' which is not the type the validation was registered with", createdClassException.Message);
            var genericObjectException = Assert.Throws<ValidationException>(() => Insist.That("IsEvenInt", new {}));
            Assert.Equal("Validation 'IsEvenInt' failed since input value is of type '<>f__AnonymousType0' which is not the type the validation was registered with", genericObjectException.Message);
        }

        [Fact(DisplayName = "Registered validations can suppress exceptions and throw custom exceptions only if types match")]
        public void TestRegisteredCustomException()
        {
            Insist.Register("IsEvenInt", (int x) => x % 2 == 0);
            Insist.That("IsEvenInt", 1, suppressExceptions: true);

            Assert.Throws<TestException>(() => Insist.That("IsEvenInt", 123, customException: new TestException()));
            Assert.Throws<ValidationException>(() => Insist.That("IsEvenInt", 0m));
        }

        public class TestClass {}
    }
}


