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
    [TestCase(34, "Fail")]
    [TestCase(20, "Fail")]
    [TestCase(0, "Fail")]

    [TestCase(35, "Resit")]
    [TestCase(45, "Resit")]
    [TestCase(64, "Resit")]

    [TestCase(65, "Pass")]
    [TestCase(70, "Pass")]
    [TestCase(79, "Pass")]

    [TestCase(80, "Distinction")]
    [TestCase(90, "Distinction")]
    [TestCase(100, "Distinction")]
    public void Test_GetGrade_WithMultipleMarkValues(int marks, string expected)
    {
        string result = Program.ReturnGradeSwitch(marks);
        Assert.That(result, Is.EqualTo(expected));
    }

    [TestCase("5", 1,2,3,4,5)]
    [TestCase("10", 1,-2,10,4,5)]
    public void Test_GetHighestInt_WithForLoop( string expected, params int[] intList)
    {
        string result = LoopTypes.HighestForLoop(intList.ToList());
        Assert.That(result, Is.EqualTo(expected));
    }

    [TestCase("5", 1,2,3,4,5)]
    [TestCase("11", 11,2,3,4,-5)]
    public void Test_GetHighestInt_WithForEachLoop( string expected, params int[] intList)
    {
        string result = LoopTypes.HighestForEachLoop(intList.ToList());
        Assert.That(result, Is.EqualTo(expected));
    }    

    [TestCase("5", 1,2,3,4,5)]
    [TestCase("-1", -1,-2,-3,-4,-5)]
    public void Test_GetHighestInt_WithWhileLoop( string expected, params int[] intList)
    {
        string result = LoopTypes.HighestWhileLoop(intList.ToList());
        Assert.That(result, Is.EqualTo(expected));
    }

    [TestCase("5", 1,2,3,4,5)]
    [TestCase("15", 1,2,3,4,15)]
    public void Test_GetHighestInt_WithDoWhileLoop( string expected, params int[] intList)
    {
        string result = LoopTypes.HighestDoWhileLoop(intList.ToList());
        Assert.That(result, Is.EqualTo(expected));
    }
}