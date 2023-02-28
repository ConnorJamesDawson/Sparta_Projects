using UnitTestApp;
namespace UnitTestTest;

public class FilmTests
{
    [TestCase(1, "U, PG & 12A films are available.")]
    [TestCase(7, "U, PG & 12A films are available.")]
    [TestCase(11, "U, PG & 12A films are available.")]
    [TestCase(12, "U, PG, 12, 12A films are available.")]
    [TestCase(13, "U, PG, 12, 12A films are available.")]
    [TestCase(14, "U, PG, 12, 12A films are available.")]
    [TestCase(15, "U, PG, 12, 12A & 15 films are available.")]
    [TestCase(16, "U, PG, 12, 12A & 15 films are available.")]
    [TestCase(17, "U, PG, 12, 12A & 15 films are available.")]
    [TestCase(18, "All films are available.")]
    [TestCase(25, "All films are available.")]
    public void CaseAges_AvailableClassifications_ReturnFilmAgeRatings(int input, string expected)
    { 

        string result = Program.AvailableClassifications(input);

        //Assert that the Act is equal to expected
        Assert.That(result, Is.EqualTo(expected));
    }

}