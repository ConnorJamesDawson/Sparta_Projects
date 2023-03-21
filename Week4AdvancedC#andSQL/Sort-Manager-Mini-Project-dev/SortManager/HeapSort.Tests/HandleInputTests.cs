using SortManager.App;
using SortManager.App.Controller;
namespace SortingAlgorithms.Tests
{
    public class HandleInputTests
    {
        [Test]
        public void WhenArrayLengthInput_GetRandomArray_ReturnsArrayWithSpecifiedLength()
        {
            // Arrange
            int expectedLength = 5;             // Act
            int[] array = HandleInput.GetRandomArray(expectedLength);             // Assert
            Assert.That(expectedLength, Is.EqualTo(array.Length));
        }
        [Test]
        public void WhenNegativeArrayLengthInput_GetRandomArray_ReturnsError()
        {
            // Arrange
            int negativeLength = -5; Assert.Throws<ArgumentOutOfRangeException>(() => HandleInput.GetRandomArray(negativeLength));
        }
        [Test]
        public void WhenArrayLength0_GetRandomArray_ReturnsError()
        {
            // Arrange
            int negativeLength = 0; Assert.Throws<ArgumentOutOfRangeException>(() => HandleInput.GetRandomArray(negativeLength));
        }
    }
}
