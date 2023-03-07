using FizzBuzz.app;

namespace FizzBuzz.Tests
{
    public class FizzBuzzerShould
    {

        [Test]
        public void FizzBuzz_WhenGivenTheNumber1_Output1AsASting()
        {
            Assert.That(FizzBuzzer.FizzBuzz(1), Is.EqualTo("1"));
        }

        [TestCase(2, "2")]
        [TestCase(4, "4")]
        public void FizzBuzz_WhenGivenANumber_NotDivisableBy3or5_ReturnItAsASting(int number, string expected)
        {
            Assert.That(FizzBuzzer.FizzBuzz(number), Is.EqualTo(expected));
        }
        [TestCase(3)]
        [TestCase(6)]
        [TestCase(12)]
        public void FizzBuzz_WhenGivenANumber_DivisableBy3_ReturnFizzAsASting(int number)
        {
            Assert.That(FizzBuzzer.FizzBuzz(number), Is.EqualTo("Fizz"));
        }
        [TestCase(5)]
        [TestCase(10)]
        [TestCase(20)]
        public void FizzBuzz_WhenGivenANumber_DivisableBy5_ReturnBuzzAsASting(int number)
        {
            Assert.That(FizzBuzzer.FizzBuzz(number), Is.EqualTo("Buzz"));
        }
        [TestCase(15)]
        [TestCase(30)]
        [TestCase(60)]
        public void FizzBuzz_WhenGivenANumber_DivisableBy5and5_ReturnFizzBuzzAsASting(int number)
        {
            Assert.That(FizzBuzzer.FizzBuzz(number), Is.EqualTo("FizzBuzz"));
        }

        [TestCase(1,"1")]
        public void FizzBuzz_WhenGivenAnEndNumber_IfDivisableBy5and5_ReturnFizzBuzz_ElseReturnNumberAsString(int number, string expected)
        {
            Assert.That(FizzBuzzer.FizzBuzz(number), Is.EqualTo(expected));
        }
    }
}
