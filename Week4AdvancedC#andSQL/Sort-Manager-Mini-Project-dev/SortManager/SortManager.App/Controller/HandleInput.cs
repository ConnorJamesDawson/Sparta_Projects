using SortManager.App.Model;
using SortManager.App.View;

namespace SortManager.App.Controller;

public class HandleInput
{
    public static int[] GetRandomArray(int lengthArray)
    {
        if (lengthArray <= 0 || lengthArray > Int32.MaxValue) { throw new ArgumentOutOfRangeException("lengthArray must be greater than 0 and not greater than the IntMax value"); }
        List<int> unsorted = new List<int>();
        Random random = new Random();

        Console.WriteLine("Original array elements:");
        for (int i = 0; i < lengthArray; i++)
        {
            unsorted.Add(random.Next(-99, 99));
            
            Console.Write(unsorted[i] + " ");
        }
        int[] unsortedArray = unsorted.ToArray();
        Console.WriteLine();
        return unsortedArray;
        
    }

    public static void HandleUserInput(string userInput, int[] unsortedArray)
    {
        var sortAlgorithm = Factory.Factory.CreateSortAlgorithm(userInput);

        GetSortedArray(sortAlgorithm.SortArray(unsortedArray));

        Console.WriteLine("Do you want to continue? y/n?");

        string isUserExiting = Console.ReadLine().ToLower();
        if (isUserExiting == "y")
        {
            Console.Clear();
            StartUpMenu.StartUpMessage();
        }
        else Environment.Exit(0);
    }

    public static void GetSortedArray(int[] array)
    {
        Console.WriteLine("Sorted array elements: ");
        foreach(var entry in array)
        {
            Console.Write(entry + " ");
        }
        Console.Write("\n");
    }

}
