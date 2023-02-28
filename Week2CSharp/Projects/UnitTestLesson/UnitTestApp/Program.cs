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
        Console.WriteLine("Testing {0}", timeOfDay);
        if (timeOfDay < 5) return "Good evening!";
        else if (timeOfDay <= 11) return "Good morning!";
        else if (timeOfDay <= 18) return "Good afternoon!";
        else return "Good evening!";
    }
    public static string AvailableClassifications(int ageOfViewer)
    {
        string result;
        if (ageOfViewer < 12)
        {
            result = "U, PG & 12A films are available."; // 12A is available only for children accompanied by an adult.
        }
        else if (ageOfViewer < 15)
        {
            result = "U, PG, 12, 12A films are available.";
        }
        else if (ageOfViewer < 18)
        {
            result = "U, PG, 12, 12A & 15 films are available.";
        }
        else
        {
            result = "All films are available.";
        }
        return result;
    }
}