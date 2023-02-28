namespace UnitTestApp;

public class Program
{
    static void Main()
    {
        int userInput = Int32.Parse(Console.ReadLine());

        Console.WriteLine(MyMethod(userInput));
        
    }

    public static string MyMethod(int timeOfDay)
    {
        string greeting;

        if (timeOfDay >= 5 && timeOfDay <= 12)
        {
            greeting = "Good morning!";
        }
        else if (timeOfDay >= 12 && timeOfDay <= 18)
        {
            greeting = "Good afternoon!";
        }
        else
        {
            greeting = "Good evening!";
        }

        return greeting;
    }
}