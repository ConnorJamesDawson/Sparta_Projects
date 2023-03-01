using UnitTestApp;
namespace UnitTestTest;

public class FilmTests
{
    [TestCase(1, true, "U, PG & 12A films are available.")]
    [TestCase(7, false, "U & PG films are available.")]
    [TestCase(11, true,  "U, PG & 12A films are available.")]
    [TestCase(12, false, "U, PG, 12, 12A films are available.")]
    [TestCase(13, true, "U, PG, 12, 12A films are available.")]
    [TestCase(14, false, "U, PG, 12, 12A films are available.")]
    [TestCase(15, true, "U, PG, 12, 12A & 15 films are available.")]
    [TestCase(16, false, "U, PG, 12, 12A & 15 films are available.")]
    [TestCase(17, true, "U, PG, 12, 12A & 15 films are available.")]
    [TestCase(18, false, "All films are available.")]
    [TestCase(25, true, "All films are available.")]
    public void CaseAges_AvailableClassifications_ReturnFilmAgeRatings(int input, bool accompaniedByAdult, string expected)
    { 

        string result = Program.AvailableClassifications(input, accompaniedByAdult);

        //Assert that the Act is equal to expected
        Assert.That(result, Is.EqualTo(expected));
    }

}