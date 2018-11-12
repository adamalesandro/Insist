
# Insist: An Assertion Libary for Fast and Descriptive Assertions in .NET

By: Adam Alesandro
On: October 12, 2018


Modern applications are complex, often filled with overloaded methods, optional parameters, and conditional logic. Developers of these applications cannot always predict the ways in which their code will be reused by other components or consumers. At the same time, frameworks and languages themselves have been adopting shortened syntax for increased readability and to condense unneeded “legacy” syntax. In particular, C# has introduced Expression Bodied Members, Local Functions, Pattern Matching and Inline Out Variable declarations to name a few. Often appropriately validating all the inputs to a function can be a syntax consuming issue. This paper proposes a library based loosely around the Python `assert` keyword and the conceptual underpinning of Assert in nUnit / xUnit libraries.

The **Insist** library seeks to solve this validation and value checking problem in a concise, descriptive manner. By providing a static class and methods, Insist allows developers to perform various assertions in their code, similar to how one would when using a testing framework. In the xUnit testing framework, a developer can assert a condition is True by simply writing:

```csharp
Assert.True(variableToTest);
```

Similarly, we can check that a value we received back from a function is valid:

```csharp
var result = _service.GetLatestSalaryForEmployee(“RALPH”);
Assert.NotNull(result);
```

-- or --

```csharp
Assert.Equal(100000, result);
```

While these assertions are meant to run on the result of an action during text execution to confirm values, Insist is meant to perform a similar function at the beginning of normal method execution:

```csharp
public void SetSalary(decimal salary)
{
	Insist.IsNotNull(salary);
	Insist.IsNotZero(salary);
	this.Salary = salary;
}
```

Insist should handle custom assertions:

```csharp
Insist.Register("IsAnEvenNumber", (int x) => (x % 2) == 0);
Insist.This("IsAnEvenNumber", 5); //false
Insist.This("IsAnEvenNumber", 4); //true
```

Insist throws exceptions by default:

```csharp
Insist.IsNotZero(0); // throws AssertionException(“Value is zero.”)
```

You can turn this off:

```csharp
var result = Insist.IsNotZero(0, suppressExceptions: true);
if (result)
{
    ...
}
```

Custom Exception types:

```csharp
Insist.IsNotZero(0, customException: new SalaryCannotBeZeroException());
```