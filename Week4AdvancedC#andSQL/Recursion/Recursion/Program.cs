using System.Linq;

namespace Recursion;

internal class Program
{
    static void Main()
    {
        List<int> unsorted = new List<int>();
        List<int> sorted;

        Random random = new Random();

        Console.WriteLine("Original array elements:");
        for (int i = 0; i < 10; i++)
        {
            unsorted.Add(random.Next(0, 100));
            Console.Write(unsorted[i] + " ");
        }
        Console.WriteLine();

        sorted = MergeSort(unsorted);

        Console.WriteLine("Sorted array elements: ");
        foreach (int x in sorted)
        {
            Console.Write(x + " ");
        }
        Console.Write("\n");
    }

    public static int sumLoopToMax(int max)
    {
        int sum = 0;
        for (int i = 0; i <= max; i++)
        {
            sum += i;
            //Console.WriteLine($"Adding {i} to {sum}");
        }
        return sum;
    }

    public static int RecursiveLoopToMax(int max)
    {

        if (max == 1) return 1; // Base case

        int prev = RecursiveLoopToMax(max - 1);
        int sum = max + prev;

        return sum;
    }

    private static List<int> MergeSort(List<int> unsorted)
    {
        if (unsorted.Count <= 1)
            return unsorted;

        List<int> left = new List<int>();
        List<int> right = new List<int>();

        int middle = unsorted.Count / 2;

        for (int i = 0; i < middle; i++)  //Dividing the unsorted list
        {
            left.Add(unsorted[i]);
        }
        for (int i = middle; i < unsorted.Count; i++)
        {
            right.Add(unsorted[i]);
        }

        left = MergeSort(left);
        right = MergeSort(right);


        return Merge(left, right);
    }

    private static List<int> Merge(List<int> left, List<int> right)
    {
        List<int> result = new List<int>();

        while (left.Count > 0 || right.Count > 0)
        {
            if (left.Count > 0 && right.Count > 0) //If they both 
            {
                if (left.First() <= right.First())  //Comparing First two elements to see which is smaller
                {
                    result.Add(left.First());
                    left.Remove(left.First());      //Rest of the list minus the first element
                }
                else
                {
                    result.Add(right.First());
                    right.Remove(right.First());
                }
            }
            else if (left.Count > 0)
            {
                result.Add(left.First());
                left.Remove(left.First());
            }
            else if (right.Count > 0)
            {
                result.Add(right.First());

                right.Remove(right.First());
            }
        }
        Console.WriteLine($"Result is :");
        return result;
    }
}
