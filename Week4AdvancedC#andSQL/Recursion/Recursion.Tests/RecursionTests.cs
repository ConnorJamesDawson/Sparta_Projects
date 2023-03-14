namespace Recursion.Tests;
using Recursion;

public class Tests
{
    [TestCaseSource("_sourceLists")]
    public void GivenAnUnSortedArray_MergeSort_ReturnsASortedArray(List<int> ListToSort, List<int> expectedOutput)
    {
        Assert.That(Program.MergeSort(ListToSort), Is.EqualTo(expectedOutput));
    }

    private static readonly object[] _sourceLists =
        {

            new object[] {new List<int> {4, 3, 2, 1}, new List<int> {1, 2, 3, 4}}, //Case 1
            new object[] {new List<int> {1, 2, 3, 4}, new List<int> {1, 2, 3, 4}}, //Case 2
            new object[] {new List<int> {94, 53, 22, 1}, new List<int> {1, 22, 53, 94}}, //Case 3

        };
}