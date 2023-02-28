using UnitTestApp;
namespace UnitTestTest;

public class Tests
{
    [TestCase(12, "Good afternoon!")]
    [TestCase(16, "Good afternoon!")]
    [TestCase(18, "Good afternoon!")]
    public void CaseTimes_MyMethod_ReturnGoodAfternoon(int input, string expected)
    { //Add in different ifs for different time zones
        //Arrange what is expected
        //Act out the arrangment
        string result = Program.MyMethod(input);

        //Assert that the Act is equal to expected
        Assert.That(result, Is.EqualTo(expected));
    }

}