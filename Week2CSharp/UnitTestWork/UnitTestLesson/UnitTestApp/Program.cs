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
    public static string AvailableClassifications(int ageOfViewer, bool accompaniedByAdult)
    {
        switch(ageOfViewer)
        {
            case < 12:
                if (accompaniedByAdult)
                {
                    return "U, PG & 12A films are available."; // 12A is available only for children accompanied by an adult.
                }
                else
                {
                    return "U & PG films are available.";
                }
            case < 15:
                return "U, PG, 12, 12A films are available.";
            case < 18:
                return "U, PG, 12, 12A & 15 films are available.";
            case >= 18:
                return "All films are available.";
            default:
                return "Input an incorrect value for system to use";
        }
    }
}