using System.Collections.Immutable;

namespace BubbleSort.App;

public class Program
{
    static void Main()
    {

        Console.WriteLine(String.Join(",", Program.ArrayMerge(new int[] { 1, 2, 3, 7 }, new int[] { 3, 4, 5, 6 })));

    }

    public static int[] BubbleSort(int[] intArray)
    {
        int count = intArray.Length;
        int value = 0;
        while(count > 0)
        {
            for (int i = 0; i < count - 1; i++)
            {
                if (intArray[i] > intArray[i+1])
                {
                    value = intArray[i];
                    intArray[i] = intArray[i+1];
                    intArray[i + 1] = value;
                }
            }
            count--;
        }
        return intArray;

    }

    public static int[] ArrayMerge(int[] array1, int[]array2)
    {
        if (array1 is null || array2 is null) throw new ArgumentNullException();
        int[] result = array1.Concat(array2).ToArray();
        Array.Sort(result);
        return result;
    }
}