namespace MoneyTaskTest;
using MoneyTask;

public class Tests
{
    [TestCase(160.70f, "£50:3, £20:0, £10:1, £5:0, £2:0, £1:0," +
               "50p:1, 20p:1, 10p:0, 5p:0, 2p:0, 1p:0")]    
    [TestCase(49.69f, "£50:0, £20:2, £10:0, £5:1, £2:2, £1:0," +
               "50p:1, 20p:0, 10p:1, 5p:1, 2p:2, 1p:0")]
    public void GivenCorrectValues_Test_MoneyParse(float money, string expected)
    {
        string result = Program.MoneyParse(money);
        Assert.That(result, Is.EqualTo(expected));
    }
    [TestCase(-1.50f)]
    public void GivenOutOfBoundsValues_TestThrowsRangeException(float money)
    {
        Assert.That(()=>Program.MoneyParse(money), Throws.TypeOf<ArgumentOutOfRangeException>().With.Message.Contain("Please add a positive value to get a result from"));
    }
}