using Insist.Exceptions;
using System;
using Xunit;

namespace Insist.Tests.Unit
{
    public class NullTests
    {
        [Fact(DisplayName = "Null check is correctly evaluated")]
        public void TestNull()
        {
            string nullString = null;

            Insist.IsNull(null);
            Insist.IsNull(nullString);
            Insist.IsNull(new DateTime?());
            Insist.IsNull(new int?());
            Insist.IsNull(null);
            Insist.IsNull(1, suppressExceptions: true);

            Assert.Throws<ValueNotNullException>(() => Insist.IsNull(32));
            Assert.Throws<ValueNotNullException>(() => Insist.IsNull(DateTime.Today));
            Assert.Throws<ValueNotNullException>(() => Insist.IsNull("string"));
            Assert.Throws<ValueNotNullException>(() => Insist.IsNull(new object()));
            Assert.Throws<TestException>(() => Insist.IsNull(1, customException: new TestException()));
        }

        [Fact(DisplayName = "Not null check is correctly evaluated")]
        public void TestNotNull()
        {
            string nullString = null;

            Insist.IsNotNull(32);
            Insist.IsNotNull(DateTime.Now);
            Insist.IsNotNull(100m);
            Insist.IsNotNull("notnull");
            Insist.IsNotNull(null, suppressExceptions: true);

            Assert.Throws<ValueIsNullException>(() => Insist.IsNotNull(default(object)));
            Assert.Throws<ValueIsNullException>(() => Insist.IsNotNull(nullString));
            Assert.Throws<ValueIsNullException>(() => Insist.IsNotNull(new DateTime?()));
            Assert.Throws<ValueIsNullException>(() => Insist.IsNotNull(new int?()));
            Assert.Throws<TestException>(() => Insist.IsNotNull(null, customException: new TestException()));
        }
    }
}


