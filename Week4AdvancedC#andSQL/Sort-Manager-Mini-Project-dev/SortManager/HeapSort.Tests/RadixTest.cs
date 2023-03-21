using SortManager.App.Model;
namespace MaxRadixTests;

public class Tests
{

    [TestCase(new int[] { 99, 88, 3, 34, 65, 53 }, new int[] { 3, 34, 53, 65, 88, 99 })]
    [TestCase(new int[] { 32, 99, 88, 3, 34, 65, 53 }, new int[] { 3, 32, 34, 53, 65, 88, 99 })]
    public void GivenUnsortedArray_SortArray_ReturnSortedArray(int[] unsortedArray, int[] expectedArray)
    {
        MaxRadix mr = new MaxRadix();
        Assert.That(mr.SortArray(unsortedArray), Is.EqualTo(expectedArray));
    }
}