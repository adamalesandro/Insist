using Insist.Exceptions;
using System;
using System.Runtime.Remoting.Messaging;
using Xunit;

namespace Insist.Tests.Unit
{
    public class ZeroTests
    {
        [Fact(DisplayName = "Zero check is correctly evaluated")]
        public void TestZero()
        {
            int? nullIntZero = 0;
            int? nullInt = null;
            int intZero = 0;
            decimal decimalMinValue = decimal.MinValue;
            decimal decimalZero = decimal.Zero;

            Insist.IsZero(0);
            Insist.IsZero(nullIntZero);
            Insist.IsZero(intZero);
            Insist.IsZero(decimalZero);
            Insist.IsZero(1, suppressExceptions: true);

            Assert.Throws<ValueNotZeroException>(() => Insist.IsZero(1));
            Assert.Throws<ValueNotZeroException>(() => Insist.IsZero(decimalMinValue));
            Assert.Throws<ValueNotZeroException>(() => Insist.IsZero("testing is so fun"));
            Assert.Throws<ValueNotZeroException>(() => Insist.IsZero(nullInt));
            Assert.Throws<ValueNotZeroException>(() => Insist.IsZero(DateTime.Now));
            Assert.Throws<ValueNotZeroException>(() => Insist.IsZero(new {}));
            Assert.Throws<TestException>(() => Insist.IsZero(1, customException: new TestException()));
        }

        [Fact(DisplayName = "Not zero check is correctly evaluated")]
        public void TestNotZero()
        {
            int? nullIntZero = 0;
            int? nullInt = null;
            int intZero = 0;
            decimal decimalMinValue = decimal.MinValue;
            decimal decimalZero = decimal.Zero;

            Insist.IsNotZero(nullInt);
            Insist.IsNotZero(decimalMinValue);
            Insist.IsNotZero("testing is pretty cool");
            Insist.IsNotZero(DateTime.Now);
            Insist.IsNotZero(new {});
            Insist.IsNotZero(123);
            Insist.IsNotZero(0, suppressExceptions: true);

            Assert.Throws<ValueIsZeroException>(() => Insist.IsNotZero(0));
            Assert.Throws<ValueIsZeroException>(() => Insist.IsNotZero(nullIntZero));
            Assert.Throws<ValueIsZeroException>(() => Insist.IsNotZero(intZero));
            Assert.Throws<ValueIsZeroException>(() => Insist.IsNotZero(decimalZero));
            Assert.Throws<TestException>(() => Insist.IsNotZero(0, customException: new TestException()));
        }
    }
}


