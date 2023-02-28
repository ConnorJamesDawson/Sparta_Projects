using UnitTestApp;
namespace UnitTestTest;

public class Tests
{
    [SetUp]
    public void Setup()
    {

    }

    [Test]
    public void Given5_MyMethod_ReturnGoodMorning()
    {
        int input = 5;
        string expected = "Good morning!";
        string result = Program.MyMethod(input);

        Assert.That(result, Is.EqualTo(expected));
    }
}