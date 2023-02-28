using OperatorsAndControlFlow;
namespace OperatorsTest;

public class Tests
{


    [TestCase(14, 1)]
    [TestCase(16, 1)]
    [TestCase(28, 2)]
    [TestCase(42, 3)]
    public void Test_GetStones_WithMultipleValues(int pounds, int expected)
    {
        int result = Program.GetStones(pounds);
        Assert.That(result, Is.EqualTo(expected));
    }
    [TestCase(15, 1)]
    [TestCase(7, 7)]
    [TestCase(30, 2)]
    [TestCase(45, 3)]
    public void Test_GetPoundsLeft_WithMultipleValues(int pounds, int expected)
    {
        int result = Program.GetPoundsLeft(pounds);
        Assert.That(result, Is.EqualTo(expected));
    }
}