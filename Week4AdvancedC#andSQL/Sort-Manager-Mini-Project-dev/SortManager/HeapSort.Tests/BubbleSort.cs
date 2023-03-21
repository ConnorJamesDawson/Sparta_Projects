using SortManager.App.Model;

namespace BubbleSortTest
{
    public class Tests
    {
        private BubbleSort _bubbleSort;
        [SetUp]
        public void Setup()
        {
            _bubbleSort = new SortManager.App.Model.BubbleSort();
        }

        [Test]
        public void WhenRandomArray_BubbleSort_ReturnsSortedArray()
        {
            int[] array = new int[] { 64, 34, 25, 12, 22, 11, 90 };
            int[] expected = new int[] { 11, 12, 22, 25, 34, 64, 90 };

            int[] result = _bubbleSort.SortArray(array);

            Assert.That(result, Is.EqualTo(expected));
        }
        [Test]
        public void WhenArrayPassed_GetUnsorted_IsUnsortedArray() 
        {
            int[] array = new int[] { 64, 34, 25, 12, 22, 11, 90 };

            int[] act = _bubbleSort.SortArray(array);
            int[] result = _bubbleSort.GetUnsortedArray;

            Assert.That(result, Is.EqualTo(array));

        }

        [Test]
        public void WhenArrayPassed_GetArray_IsSortedArray()
        {
            int[] array = new int[] { 64, 34, 25, 12, 22, 11, 90 };

            int[] act = _bubbleSort.SortArray(array);
            int[] result = _bubbleSort.GetArray;

            Assert.That(result, Is.EqualTo(array));

        }
    }
}