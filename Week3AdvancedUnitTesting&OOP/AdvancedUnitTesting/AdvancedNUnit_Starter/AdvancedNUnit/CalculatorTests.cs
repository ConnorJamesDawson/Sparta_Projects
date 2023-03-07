using NUnit.Framework;

namespace AdvancedNUnit;

public class CalculatorTests
{
    [SetUp]
    public void Setup() { }

    [TestCaseSource("AddCases")]
    [Category("Happy Path")]
    public void Add_GivenValues_ReturnsExpectedResult(int num1, int num2, int expectedResult)
    {
        // Arrange
        var subject = new Calculator { Num1 = num1, Num2 = num2 };
        // Act
        var result = subject.Add();
        // Assert
        Assert.That(result, Is.EqualTo(expectedResult), "optional failure message"); //Constraint

        //Assert.AreEqual(expectedResult, result, "optional failure message"); // Classic model
    }

    private static object[] AddCases = //This is a field 
    {
        new int[]{ 2, 4, 6},
        new int[]{ 12, 4, 16},
        new int[]{ 2, 24, 26},
        new int[]{ 32, 34, 66}
    };

    [Test]
    [Category("Sad Path")]
    public void DivisibleBy3_GivenAnInputOf7_ReturnsFalse()
    {
        // Arrange
        var subject = new Calculator { Num1 = 7};
        // Act
        var result = subject.DivisibleBy3();
        // Assert
        Assert.That(result, Is.False); //Constraint
    }

    [Test]
    public void ToString_ContainsTheStringCalculator()
    {
        // Arrange
        Calculator subject = new Calculator(); // Act
        var result = subject.ToString(); // Assert

        Assert.That(result, Does.Contain("Calculator"));

        Assert.That(result, Is.EqualTo("AdvancedNUnit.Calculator"));

        Assert.That(result, Is.EqualTo("AdvancedNUnit.Calculator").IgnoreCase); //For case insensitive work

        Assert.That(result, Does.StartWith("A"));

        Assert.That(result, Does.Not.Contain("FooBar"));

        Assert.That(result, Has.Length.EqualTo(24));

        Assert.That(result, Is.Not.Empty);
    }
    [Test]
    public void CollectionConstraintsExercise()
    {
        string[] trainers = new string[] { "Laura", "Joe", "Phil", "Neil", "Martin", "Cathy" };

        //Assert.That(trainers.Length, Is.EqualTo(6));
        Assert.That(trainers, Has.Length.EqualTo(6));

        Assert.That(trainers, Does.Contain("Cathy").IgnoreCase);

        Assert.That(trainers, Has.Exactly(2).EndsWith("l"));

        Assert.That(trainers, Has.Exactly(3).Contains("i"));
    }

    [Test]
    public void RangeContraintsExercise()
    {
        var nums = new int[] { 4, 2, 6, 7, 1, 9 };

        Assert.That(8, Is.InRange(1,10));

        Assert.That(nums, Is.All.InRange(1,10));

        Assert.That(nums, Has.Exactly(3).InRange(1,5));
    }
}
