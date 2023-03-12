namespace SafariPark.Tests;
using SafariPark;
using SafariPark.App;

public class Tests
{
    [TestCase("", "", " ")]
    [TestCase("Connor","Dawson","Connor Dawson")]
    public void FullName_WhenGivenFirstAndLastName_ReturnsConcatenantedString(string fName, string lName, string expected)
    {
        Person subject = new Person(fName, lName);
        string result = subject.GetFullName;

        Assert.That(result, Is.EqualTo(expected));
    }
}