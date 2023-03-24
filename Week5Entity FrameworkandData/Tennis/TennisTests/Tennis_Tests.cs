using System.Numerics;
using Tennis.App;
using static System.Formats.Asn1.AsnWriter;

namespace TennisTests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
        MatchController.ResetScores();
        MatchController.ResetSetWins();
    }

    [TestCase(1, 0, "Fifteen - Love")]
    [TestCase(0, 1, "Love - Fifteen")]
    [TestCase(2, 0, "Thirty - Love")]
    [TestCase(0, 2, "Love - Thirty")]
    [TestCase(3, 0, "Fourty - Love")]
    [TestCase(0, 3, "Love - Fourty")]
    [TestCase(1, 1, "Fifteen - Fifteen")]
    [TestCase(3, 3, "Deuce")]
    [TestCase(4, 4, "Deuce")]
    [TestCase(4, 3, "Advantage Player One")]
    [TestCase(4, 0, "Player One Wins")]
    [TestCase(0, 4, "Player Two Wins")]
    [TestCase(5, 3, "Player One Wins")]
    [TestCase(3, 4, "Advantage Player Two")]
    [TestCase(7, 6, "Advantage Player One")]
    public void GivenPlayersWinGivenNumberOfRounds_AddPoints_OutPutIsExpected(int score1, int score2, string expected)
    {
        string result = "";
        int minScore = Math.Min(score1, score2);
        for (int i = 0; i < minScore; i++)
        {
            result = MatchController.Player1Scores();
            result = MatchController.Player2Scores();
        }

        if (score1 > score2)
        {
            for (int j = minScore; j < score1; j++)
            {
                result = MatchController.Player1Scores();
            }
        }
        else if (score1 < score2)
        {
            for (int j = minScore; j < score2; j++)
            {
                result = MatchController.Player2Scores();
            }
        }

        Assert.That(result, Is.EqualTo(expected));
    }

    [TestCase(0, 0, "Player One Sets: 0, Player Two Sets: 0")]
    [TestCase(2, 1, "Player One Sets: 2, Player Two Sets: 1")]
    [TestCase(3, 1, "Player One wins the match!")]
    [TestCase(2, 3, "Player Two wins the match!")]
    public void GivenSetsHaveBeenWon_GetSetsWon_ReturnsExpected(int wins1, int wins2, string expected)
    {
        for (int i = 0; i < wins1; i++)
        {
            MatchController.Player1Scores();
            MatchController.Player1Scores();
            MatchController.Player1Scores();
            MatchController.Player1Scores();
        }

        for (int j = 0; j < wins2; j++)
        {
            MatchController.Player2Scores();
            MatchController.Player2Scores();
            MatchController.Player2Scores();
            MatchController.Player2Scores();
        }

        Assert.That(MatchController.GetSetsWon(), Is.EqualTo(expected));
    }
}