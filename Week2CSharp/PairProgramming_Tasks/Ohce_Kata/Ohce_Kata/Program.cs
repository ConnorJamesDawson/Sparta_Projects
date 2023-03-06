using System.Xml.Linq;

namespace Ohce_Kata;

public class Program
{
    static void Main()
    { //Store name as variable
        bool quit = false;
        int hourOfDay = DateTime.Now.TimeOfDay.Hours;

        GetTimeOfDayForGreeting(hourOfDay);

        while(!quit)
        {
            string userInput = Console.ReadLine();

            if(userInput == "Stop!")
            {
                Console.WriteLine("Adios Connor");
                quit = false;
                break;
            }

            ReverseUserInput(userInput);
        }
    }

    private static void GetTimeOfDayForGreeting(int hour)
    {
        Console.WriteLine($"Hour is {0}");
        if (hour >= 7 && hour >= 12)
        {
            Console.WriteLine($"Buenas noches Connor!");
        }
        if (hour >= 13 && hour >= 20)
        {
            Console.WriteLine($"Buenas días Connor!");
        }
        if (hour >= 21 || hour >= 6)
        {
            Console.WriteLine($"Buenas tardes Connor!");
        }
    }

    private static void ReverseUserInput(string userInput)
    {
        char[] stringArray = userInput.ToCharArray();

        Array.Reverse(stringArray);

        string reverse = new string(stringArray);

        Console.WriteLine(reverse);

        if (userInput == reverse) Console.WriteLine("¡Bonita palabra!");
    }
}