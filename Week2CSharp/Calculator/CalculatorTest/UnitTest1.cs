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
    [TestCase('a')]
    [TestCase('d')]
    [TestCase('+')]
    public void GivenWrongOperand_ThrowError_Calculation(char op)
    {
        Calculations cal = new();
        Assert.That(()=> cal.Calculate(0,0,op), Throws.TypeOf<ArgumentNullException>().With.Message.Contain("You have inputed an incorrect value, " + op + " is not a operand that this system can use"));
    }

    [TestCase("6+3", 6)]
    [TestCase("-3--2", -3)]
    public void GivenEquation_GiveFirstNumber(string input, int expected)
    {
        Parse par = new();

        float result = par.ParseForFirstNumber(input);

        Assert.That(result, Is.EqualTo(expected));
    }
    [TestCase("3+3", '+')]
    [TestCase("3-3", '-')]
    [TestCase("3*3", '*')]
    [TestCase("3/3", '/')]
    public void GivenEquation_GiveOperand(string input, char expected)
    {
        Parse par = new();

        char result = par.ParseForOperand(input);

        Assert.That(result, Is.EqualTo(expected));
    }
}