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

        if (timeOfDay > 5) return "Good evening!";
        else if (timeOfDay <= 12) return "Good morning!";
        else if(timeOfDay<= 18) return "Good afternoon!";
        else return "Good evening!";

    }
}