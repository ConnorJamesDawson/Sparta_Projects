using SortManager.App.Model;
namespace DotNetSort.Tests;
public class Tests
{
    private MergeSort _dotNetSort;
    [SetUp]
    public void Setup()
    {
        _dotNetSort = new SortManager.App.Model.MergeSort();
    }


    [Test]
    public void WhenRandomArray_BubbleSort_ReturnsSortedArray()
    {
        int[] array = new int[] { 64, 34, 25, 12, 22, 11, 90 };
        int[] expected = new int[] { 11, 12, 22, 25, 34, 64, 90 };

        int[] result = _dotNetSort.SortArray(array);

        Assert.That(result, Is.EqualTo(expected));

    }
}
