using System.Net.Cache;

namespace Methods;

internal class Program
{
    static void Main()
    {
        #region Methods
        /*        int result = SquarePlusOne(10);
                string feeling = SayThisFeeling("happy");

                Console.WriteLine(result + " " + feeling);
                Console.WriteLine(result + " " + SayThisFeeling("happy", day: "tomorrow"));
                Console.WriteLine(MakePizza(ham: true,chicken: false, jalapeno: true,stuffedCrust: true));*/
        #endregion
        #region OutVariables and Tuples
        bool successful = MyTryParse("One", out int num); //Out is allowing a variable to leave a method

        Console.WriteLine($"My TryPasre was successful {successful} \nNumber is {num}");

        var myTuple = ("Samsng", "Cross", (25));

        Console.WriteLine(myTuple.Item1 + " is " + myTuple.Item3);

        var namedTuple = (FirstName: "Connor", SecondName: "Dawson", Age: 20);
        Console.WriteLine(namedTuple.FirstName + " is " + namedTuple.Age);
        #endregion
    }

    private static bool MyTryParse(string inputnumber, out int number)
    {
        try
        {
            number = Int32.Parse(inputnumber);
            return true;
        }
        catch(Exception e)
        {
            number = 404;
            return false;
        }
    }

    private static int SquarePlusOne(int num)
    {
        return num * num + 1;
    }

    private static string SayThisFeeling(string feeling, string day = "today")
    {
        return ($"I'm feeling {feeling} {day}");
    }

    private static string MakePizza(bool ham, bool chicken, bool jalapeno, bool stuffedCrust, bool cheese = true)
    {
        string pizzaMade = "You have made a: ";

        if (ham) pizzaMade += " ham";
        if (chicken) pizzaMade += " chicken";
        if (jalapeno) pizzaMade += " jalapeno";
        if (stuffedCrust) pizzaMade += " stuffed crust";
        if (cheese) pizzaMade += " cheese";

        return pizzaMade;
    }

    private static (int pounds, int stones) ConversPoundsToStones(int pounds)
    {
        return (pounds % 14, pounds / 14);
    }
}