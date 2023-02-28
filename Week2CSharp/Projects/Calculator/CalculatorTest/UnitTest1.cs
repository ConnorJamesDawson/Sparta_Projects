using Calculator;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace CalculatorTest;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Givensix_Calculations()
    {
        Calculations cal = new Calculations();
        Parse parse = new Calculator.Parse();

        string input = "6+6";
        int expected = 12;
        parse.ParseInput(input);
        int result = cal.Calculate(parse.firstNum, parse.secondNum, parse.operand);
        Assert.That(result, Is.EqualTo(expected));
    }
}