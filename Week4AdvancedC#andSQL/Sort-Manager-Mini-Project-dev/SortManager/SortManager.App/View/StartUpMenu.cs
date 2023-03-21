using SortManager.App.Controller;

namespace SortManager.App.View;

public class StartUpMenu
{
    public static void StartUpMessage()
    {
        Console.WriteLine("Welcome to our Sort Manager");

        Console.WriteLine("Please choose a length of your array: ");
        int lengthInput = 0;

        if(!Int32.TryParse(Console.ReadLine(), out lengthInput))
        {
            Console.WriteLine("Please input a number");
            StartUpMessage();
        }
        else
        {
            int[] unsortedArray = HandleInput.GetRandomArray(lengthInput);

            Console.WriteLine("Please choose from the following sort Methods to sort an unsorted array: \n1: BubbleSort, \n2: HeapSort, \n3: MergeSort \n4: .NET LibrarySort, \n5: RadixSort, \n6: ShellSort");
            string input = Console.ReadLine().ToLower();

            if (input == "quit") Environment.Exit(0);
            HandleInput.HandleUserInput(input, unsortedArray);
        }

    }
}
