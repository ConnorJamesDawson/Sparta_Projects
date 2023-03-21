using System.Diagnostics;

namespace SortManager.App.Model;

public class HeapSort : AbstractSort
{
    private bool _debug = false;
    public override int[] SortArray(int[] array)
    {
        Stopwatch timer = TimerClass.StartTimer();
        int N = array.Length;

        // Build heap (rearrange array)
        for (int i = N / 2 - 1; i >= 0; i--)
        {
            heapify(array, N, i);
        }

        // One by one extract an element from heap but do it backwards (-1 because of Length)
        for (int i = N - 1; i > 0; i--)
        {
            ifDebugging($"Extracting {array[0]} from the heap");

            // Move current root to end
            int temp = array[0];
            array[0] = array[i];
            array[i] = temp; //Assigning the largest value to the end of the array

            // call max heapify on the reduced heap as i--
            heapify(array, i, 0);
        }
        TimerClass.StopTimerAndReturnTime(timer);
        return array;
    }

    void heapify(int[] array, int sizeOfTheHeap, int rootNumber)
    {
        int largest = rootNumber; // Initialize largest as root
        int leftNode = 2 * rootNumber + 1; // left = 2*i + 1
        int rightNode = 2 * rootNumber + 2; // right = 2*i + 2

        // If left child is larger than root
        if (leftNode < sizeOfTheHeap && array[leftNode] > array[largest])
        {
            ifDebugging($"{array[leftNode]} is grater than {array[largest]}");
            largest = leftNode;
        }

        // If right child is larger than largest so far, this is intentional as the method should always look for the rightmost value 
        if (rightNode < sizeOfTheHeap && array[rightNode] > array[largest])
        {
            ifDebugging($"{array[rightNode]} is grater than {array[largest]}");
            largest = rightNode;
        }

        // If largest is not root
        if (largest != rootNumber)
        {
            ifDebugging($"Swapping {array[rootNumber]} for {array[largest]}");
            int swap = array[rootNumber];
            array[rootNumber] = array[largest];
            array[largest] = swap;

            // Recursively heapify the affected sub-tree
            heapify(array, sizeOfTheHeap, largest);
        }
    }

    public void ifDebugging(string message)
    {
        if(_debug)
        {
            Console.WriteLine($"{message}");
        }
    }
}
