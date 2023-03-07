using System.Reflection.Metadata;
using System.Xml.Serialization;
using AdventOfCodeDay2;

namespace AdventOfCodeDay2.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {

        }

        [TestCase(new char[] { 'A', 'B', 'C' }, new char[] { 'Y', 'X', 'Z' }, 15)] // win - loss - draw -> WIN
        [TestCase(new char[] { 'A', 'A', 'A' }, new char[] { 'X', 'X', 'X' }, 12)] // draw - draw - draw
        [TestCase(new char[] { 'A', 'A', 'A' }, new char[] { 'Z', 'Z', 'Z' }, 9)] // loss - loss - loss
        public void RockPaperScissors_WhenPassingWinningStrategyArrays_ReturnExpectedScore(char[] opponentMoves, char[] playerMoves, int expResult)
        {
            Assert.That(DayTwo.RockPaperScissors(opponentMoves, playerMoves), Is.EqualTo(expResult));
        }

    }
}