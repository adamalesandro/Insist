namespace InsistTests;

public class NullValidationTest
{
    [Fact]
    public void Test1()
    {
        NullValidations.IsNotNull(null);
    }
}