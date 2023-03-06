using RomanNumerals;

namespace Test_RomanNumeral
{
    public class Tests
    {
        [TestCase("I",1)]
        [TestCase("IX",9)]
        [TestCase("iii",3)]
        [TestCase("XXI",21)]
        [TestCase("IV",4)]
        [TestCase("Li",51)]
        [TestCase("C",100)]
        [TestCase("L",50)]
        [TestCase("D",500)]
        [TestCase("cM",900)]
        [TestCase("M",1000)]
        public void PassRomanNumeralTest(string romanNumerals, int result)
        {
            Assert.That(Program.PassRomanNumerals(romanNumerals), Is.EqualTo(result));
        }
    }
}