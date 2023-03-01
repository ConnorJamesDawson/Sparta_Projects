using Calculator;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace CalculatorTest;

public class Tests
{
    [TestCase("6+6", 12)]
    [TestCase("7+3", 10)]
    [TestCase("3-3", 0)]
    [TestCase("-3--6", 3)]
    [TestCase("6/3", 2)]
    [TestCase("5/2", 2.5f)]
    [TestCase("2*8", 16)]
    public void GivenEquation_Calculations(string input, float expected)
    {
        Calculations cal = new();
        Parse parse = new();

        parse.ParseForFirstNumber(input);

        parse.ParseForOperand(input);

        parse.ParseForSecondNumber(input);

        float result = cal.Calculate(parse.firstNum, parse.secondNum, parse.operand);

        Assert.That(result, Is.EqualTo(expected));
    }

    public void GivenEquation_GiveFirstNumber(string input, int expected)
    {

    }
}