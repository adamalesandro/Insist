using static Insist.Helpers;
using System;
using Xunit;

namespace Insist.Tests.Unit
{
    public class HelperTests
    {
        [Fact(DisplayName = "IsNumber returns correct value")]
        public void TestIsNumber()
        {
            sbyte sbyteNum = 1;
            byte byteNum = 1;
            short shortNum = 1;
            ushort ushortNum = 1;
            int intNum = 1;
            uint uintNum = 1;
            long longNum = 1;
            ulong ulongNum = 1;
            float floatNum = 1;
            double doubleNum = 1;
            decimal decimalNum = 1;

            Assert.True(IsNumber(sbyteNum));
            Assert.True(IsNumber(byteNum));
            Assert.True(IsNumber(shortNum));
            Assert.True(IsNumber(ushortNum));
            Assert.True(IsNumber(intNum));
            Assert.True(IsNumber(uintNum));
            Assert.True(IsNumber(longNum));
            Assert.True(IsNumber(ulongNum));
            Assert.True(IsNumber(floatNum));
            Assert.True(IsNumber(doubleNum));
            Assert.True(IsNumber(decimalNum));

            Assert.False(IsNumber(new {}));
            Assert.False(IsNumber(new int?()));
            Assert.False(IsNumber(DateTime.Now));
            Assert.False(IsNumber(null));
            Assert.False(IsNumber("You can't fail tests if you don't have any"));
            Assert.False(IsNumber(decimalNum.GetType()));
        }
    }
}


