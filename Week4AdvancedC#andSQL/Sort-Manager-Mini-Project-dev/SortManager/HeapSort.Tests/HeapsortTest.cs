namespace HeapSorts.Tests;

using SortManager.App.Model;

public class Tests
{
    [TestCase(new int[] {999, 88, 3, 34, 65, 53}, new int[] { 3, 34, 53, 65, 88, 999})]
    [TestCase(new int[] {-32, 99, 88, 3, 34, 65, 53}, new int[] { -32, 3, 34, 53, 65, 88, 99})]
    public void GivenAnUnsortedArray_UseHeapSort_ReturnASortedArray(int[] unsortedArray, int[] expectedArray)
    {
        HeapSort HS = new HeapSort();

        Assert.That(HS.SortArray(unsortedArray), Is.EqualTo(expectedArray));
    }
}