using System.Diagnostics;

namespace SortManager.App.Model;

public class MergeSort: AbstractSort
{
    public override int[] SortArray(int[] array)
    {
        Stopwatch timer = TimerClass.StartTimer();
        GetUnsortedArray = array;
        if (array == null || array.Length <= 1)
        {
            return array;
        }

        MergeSortAlgorithm(array, 0, array.Length - 1);
        GetArray = array;
        TimerClass.StopTimerAndReturnTime(timer);
        return array;
    }

    private void MergeSortAlgorithm(int[] array, int left, int right)
    {
        if (left < right)
        {
            int middle = (left + right) / 2;
            MergeSortAlgorithm(array, left, middle);
            MergeSortAlgorithm(array, middle + 1, right);
            Merge(array, left, middle, right);
        }
    }

    private void Merge(int[] array, int left, int middle, int right)
    {
        int leftSize = middle - left + 1;
        int rightSize = right - middle;

        int[] leftArray = new int[leftSize];
        int[] rightArray = new int[rightSize];

        Array.Copy(array, left, leftArray, 0, leftSize);
        Array.Copy(array, middle + 1, rightArray, 0, rightSize);

        int i = 0, j = 0;
        int k = left;

        while (i < leftSize && j < rightSize)
        {
            if (leftArray[i] <= rightArray[j])
            {
                array[k] = leftArray[i];
                i++;
            }
            else
            {
                array[k] = rightArray[j];
                j++;
            }
            k++;
        }

        while (i < leftSize)
        {
            array[k] = leftArray[i];
            i++;
            k++;
        }

        while (j < rightSize)
        {
            array[k] = rightArray[j];
            j++;
            k++;
        }
    }
}
