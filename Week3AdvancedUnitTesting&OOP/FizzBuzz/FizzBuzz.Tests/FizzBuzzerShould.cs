using FizzBuzz.app;

namespace FizzBuzz.Tests
{
    public class FizzBuzzerShould
    {

        [Test]
        public void FizzBuzz_WheGivenTheNumber1_Output1AsASting()
        {
            Assert.That(FizzBuzzer.FizzBuzz(1), Is.EqualTo("1"));
        }
    }
}
