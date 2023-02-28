using UnitTestApp;
namespace UnitTestTest;

public class Tests
{
    [Test]
    public void Given5_MyMethod_ReturnGoodMorning()
    {
        //Arrange what is expected
        int input = 5;
        string expected = "Good morning!";

        //Act out the arrangment
        string result = Program.MyMethod(input);

        //Assert that the Act is equal to expected
        Assert.That(result, Is.EqualTo(expected));
    }
    [Test] //Testing the quivalence value, The middle value
    public void Given8_MyMethod_ReturnGoodMorning()
    {
        //Arrange what is expected
        int input = 8;
        string expected = "Good morning!";

        //Act out the arrangment
        string result = Program.MyMethod(input);

        //Assert that the Act is equal to expected
        Assert.That(result, Is.EqualTo(expected));
    }
    [Test]
    public void Given11_MyMethod_ReturnGoodMorning()
    {
        //Arrange what is expected
        int input = 11;
        string expected = "Good morning!";

        //Act out the arrangment
        string result = Program.MyMethod(input);

        //Assert that the Act is equal to expected
        Assert.That(result, Is.EqualTo(expected));
    }
    [Test]
    public void Given12_MyMethod_ReturnGoodAfternoon()
    {
        //Arrange what is expected
        int input = 12;
        string expected = "Good afternoon!";

        //Act out the arrangment
        string result = Program.MyMethod(input);

        //Assert that the Act is equal to expected
        Assert.That(result, Is.EqualTo(expected));
    }
    [Test]
    public void Given16_MyMethod_ReturnGoodAfternoon()
    {
        //Arrange what is expected
        int input = 16;
        string expected = "Good afternoon!";

        //Act out the arrangment
        string result = Program.MyMethod(input);

        //Assert that the Act is equal to expected
        Assert.That(result, Is.EqualTo(expected));
    }
    [Test]
    public void Given18_MyMethod_ReturnGoodAfternoon()
    {
        //Arrange what is expected
        int input = 18;
        string expected = "Good afternoon!";

        //Act out the arrangment
        string result = Program.MyMethod(input);

        //Assert that the Act is equal to expected
        Assert.That(result, Is.EqualTo(expected));
    }
    [Test]
    public void Given19_MyMethod_ReturnGoodEvening()
    {
        //Arrange what is expected
        int input = 19;
        string expected = "Good evening!";

        //Act out the arrangment
        string result = Program.MyMethod(input);

        //Assert that the Act is equal to expected
        Assert.That(result, Is.EqualTo(expected));
    }
    [Test]
    public void Given24_MyMethod_ReturnGoodEvening()
    {
        //Arrange what is expected
        int input = 24;
        string expected = "Good evening!";

        //Act out the arrangment
        string result = Program.MyMethod(input);

        //Assert that the Act is equal to expected
        Assert.That(result, Is.EqualTo(expected));
    }
    [Test]
    public void Given0_MyMethod_ReturnGoodEvening()
    {
        //Arrange what is expected
        int input = 0;
        string expected = "Good evening!";

        //Act out the arrangment
        string result = Program.MyMethod(input);

        //Assert that the Act is equal to expected
        Assert.That(result, Is.EqualTo(expected));
    }
    [Test]
    public void Given2_MyMethod_ReturnGoodEvening()
    {
        //Arrange what is expected
        int input = 24;
        string expected = "Good evening!";

        //Act out the arrangment
        string result = Program.MyMethod(input);

        //Assert that the Act is equal to expected
        Assert.That(result, Is.EqualTo(expected));
    }
    [Test]
    public void Given4_MyMethod_ReturnGoodEvening()
    {
        //Arrange what is expected
        int input = 4;
        string expected = "Good evening!";

        //Act out the arrangment
        string result = Program.MyMethod(input);

        //Assert that the Act is equal to expected
        Assert.That(result, Is.EqualTo(expected));
    }

    [TestCase(12)]
    [TestCase(16)]
    [TestCase(18)]
    public void CaseTimes_MyMethod_ReturnGoodAfternoon(int input)
    { //Add in different ifs for different time zones
        //Arrange what is expected
        string expected = "Good afternoon!";

        //Act out the arrangment
        string result = Program.MyMethod(input);

        //Assert that the Act is equal to expected
        Assert.That(result, Is.EqualTo(expected));
    }

}