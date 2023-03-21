using SortManager.App.Model;
namespace MergeSortTest;

public class Tests
{
    private MergeSort _mergeSort;
    [SetUp]
    public void Setup()
    {
        _mergeSort = new SortManager.App.Model.MergeSort();
    }

    [Test]
    public void WhenRandomAray_BuubleSort_ReturnsSortedArray()
    {
        int[] array = new int[] { 64, 34, 25, 12, 22, 11, 90 };
        int[] expected = new int[] { 11, 12, 22, 25, 34, 64, 90 };

        int[] result = _mergeSort.SortArray(array);

        Assert.That(result, Is.EqualTo(expected));
    }
    [Test]
    public void WhenArrayPassed_GetUnsorted_IsUnsortedArray()
    {
        int[] array = new int[] { 64, 34, 25, 12, 22, 11, 90 };

        int[] act = _mergeSort.SortArray(array);
        int[] result = _mergeSort.GetUnsortedArray;

        Assert.That(result, Is.EqualTo(array));

    }

    [Test]
    public void WhenArrayPassed_GetArray_IsSortedArray()
    {
        int[] array = new int[] { 64, 34, 25, 12, 22, 11, 90 };

        int[] act = _mergeSort.SortArray(array);
        int[] result = _mergeSort.GetArray;

        Assert.That(result, Is.EqualTo(array));
    }
}