namespace BubbleTest.Tests;

using BubbleSort.App;

public class BubbleTests
{

    [TestCase(new int[] { 6, 4, 2, 1 }, new int[] {1, 2, 4, 6})]
    [TestCase(new int[] { 13, 17, 504, 1}, new int[] {1, 13, 17, 504})]
    [TestCase(new int[] { -4, -54, -2, -1 }, new int[] {-54, -4, -2, -1})]
    public void GivenAnArrayOfInts_UsingBubbleSort_ReturnsExpectedArray(int[] intArray, int[] expectedArray)
    {
        int[] result = Program.BubbleSort(intArray);

        Assert.That(result, Is.EqualTo(expectedArray));
    }

}

public class MergerTests
{
    [TestCase(new int[] { 1,2,3,7},new int[] {3,4,5,6 }, new int[] {1,2,3,3,4,5,6,7 })]
    [TestCase(new int[] { },new int[] { }, new int[] { })]

    public void GivenTwoArrays_Merge_ReturnsMergedArray(int[] arr1, int[] arr2, int[] expResult)
    {

        Assert.That(Program.ArrayMerge(arr1,arr2), Is.EqualTo(expResult));
    }

    [Test]
    public void Given2NullArrays_Merger_ThrowsException()
    {
        Assert.That(()=> Program.ArrayMerge(null,null), Throws.TypeOf<ArgumentNullException>());
    }
}