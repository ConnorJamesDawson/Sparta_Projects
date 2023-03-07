using NUnit.Framework;

namespace AdvancedNUnit
{
    [TestFixture]
    //[Ignore("Not using these tests yet")]
    public class CounterTests
    {
        private Counter _sut; // sut - system under test
        [SetUp]
        public void SetUp()
        {

        }
        private void CreateSut()
        {
            _sut = new Counter(6);
        }

        [Test]
        public void Decrement_DecreasesCountByOne() //So because Decrement gets called first _sut goes to 5 for increment 
        {
            CreateSut();
            _sut.Decrement();
            Assert.That(_sut.Count, Is.EqualTo(5));
        }

        [Test]
        public void Increment_IncreaseCountByOne() //This is doing it's job
        {
            CreateSut();
            _sut.Increment();
            Assert.That(_sut.Count, Is.EqualTo(7));
        }

    }
}
