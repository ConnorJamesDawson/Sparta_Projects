namespace RecursionLab.Tests;
using RecursionLab.App;
public class Tests
{
    [TestCase(4)]
    [TestCase(10)]
    [TestCase(98)]
    public void GivenANumber_ReturnRecurisonFactorialOf_ReturnTheSameAnswerAsIterativeMethod(int number)
    {
        Assert.That(Program.ReturnRecurisonFactorialOf(number), Is.EqualTo(Program.ReturnFactorialOf(number)));
    }

    [TestCase(4)]
    [TestCase(10)]
    [TestCase(98)]
    public void GivenANumber_FibonacciRecursion_ReturnTheSameAnswerAsIterativeMethod(int number)
    {
        Assert.That(Program.FibonacciRecursion(number), Is.EqualTo(Program.FibonacciLoop(number)));
    }
}