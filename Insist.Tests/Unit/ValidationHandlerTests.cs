using System;
using Insist.Exceptions;
using Xunit;
using static Insist.ValidationHandler;

namespace Insist.Tests.Unit
{
    public class ValidationHandlerTests
    {
        [Fact(DisplayName = "HandleValidations throws passed in exception if validation does not succeed")]
        public void HandleValidationsPassedInExceptionTest()
        {
            bool Func(object val) => val == null;
            HandleValidation<object>(null, Func, new TestException());
            Assert.Throws<TestException>(() => HandleValidation("a thing", Func, new TestException()));
        }

        [Fact(DisplayName = "HandleValidations throws general exception with relevant message if other type of exception is thrown during validation")]
        public void HandleValidationsGeneralExceptionTest()
        {
            bool Func(dynamic val) => val != 0;
            HandleValidation<object>(null, Func, new TestException());
            var exception = Assert.Throws<ValidationException>(() => HandleValidation("a thing", Func, new TestException()));
            Assert.Equal("Insist Validation failed on exception: 'TestException' due to general exception: [Operator '!=' cannot be applied to operands of type 'string' and 'int'] thrown", exception.Message);
        }
    }
}


