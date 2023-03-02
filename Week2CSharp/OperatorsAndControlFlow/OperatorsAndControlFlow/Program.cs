using System.Security.Cryptography.X509Certificates;

namespace OperatorsAndControlFlow;

public class Program
{
    static void Main()
    {
        #region Operators Lesson
        /*
        int x = 5;
        int y = 5;

        int a = x++;
        int b = ++y;

        Console.WriteLine("X: {0} should be 6, Y: {1} should be 6", x, y);
        Console.WriteLine("A: {0} should be 6, B: {1} should be 6", a, b);

        var c = 5 / 2;
        var d = 5.0f / 2;

        Console.WriteLine(GetStones(156));
        Console.WriteLine(GetPoundsLeft(156));
        int j = 5, k = 3, m = 4;
        m += +j++ + ++k; // = 13 because J isn't getting incremented before being added 

        bool apples = false;
        bool oranges = true;

        bool fruit = apples && oranges;

        string luke = "Luke";
        string alin = null;

        bool bothStartWithA = luke.StartsWith('a') && alin.StartsWith('a');
        */
        #endregion

        #region Turnery Operator
        /*        int testMark = 70;
                // Bool ? If true : if false
                string grade = testMark >= 65 ? "Pass": "Fail";
                string betterGrade = testMark >= 65 ? testMark >= 80 ? "Distinction" : "Pass": "Fail";*/
        #endregion

        #region Iterations
        // For
        // For Each
        // While
        // Do While
        #endregion

        /*        List<int> intList = new() {09,18,27,36,45,54,63,72,81,90,-10};

                Console.WriteLine("Highest for loop: " + LoopTypes.HighestForLoop(intList));
                Console.WriteLine("Highest foreach loop: " + LoopTypes.HighestForEachLoop(intList));
                Console.WriteLine("Highest do while loop: " + LoopTypes.HighestWhileLoop(intList));
                Console.WriteLine("Highest while loop:" + LoopTypes.HighestDoWhileLoop(intList));*/
        Console.WriteLine(ReturnGradeTurnery(-99));
    }

    public static string Priority(int level)
    {
        switch(level)
        {
            case 0:
                return "Defcon: 0";
            case 1:
                return "Defcon: 1!";
            case 2:
                return "Defcon: 2!!";
            case 3:
                return "Defcon: 3!!!";
            case 4:
                return "Defcon: 4!!!!";
            case 5:
                return "Defcon: 5!!!!!";
            default:
                throw new ArgumentOutOfRangeException("Error there is no DEFCON level at " + level);
        }
    }

    public static string ReturnGradeTurnery(int testMark)
    {
        if (testMark < 0 || testMark > 100)
            throw new ArgumentOutOfRangeException("Mark must be must be between 0-100");

        return testMark >= 35 ? testMark >= 65 ? (testMark >= 80 ? "Distinction" : "Pass") : "Resit" : "Fail"; ;
    }

    public static string ReturnGradeSwitch(int testMark)
    {
        switch(testMark)
        {
            case >= 80:
                return "Distinction";
            case >= 65:
                return "Pass";
            case >= 35:
                return "Resit";
            default:
                return "Fail";
        }
    }

    public static int GetStones(int totalPounds) //1 stone = 14 pounds
    {
        if (totalPounds < 14)
            throw new ArgumentOutOfRangeException("Please provide more than 14 total pounds to use equation");
        return totalPounds / 14;
    }

    public static int GetPoundsLeft(int totalPounds)//% gives the value left over from a /
    {
        if (totalPounds < 0)
            throw new ArgumentOutOfRangeException("Please provide a positive value");
        return totalPounds % 14;
    }
}

public static class LoopTypes
{
    public static string HighestForLoop(List<int> intList)
    {
        int max = intList[0];

        for (int i = 0; i < intList.Count; i++)
        {
            if (intList[i] > max)
            {
                max = intList[i];
            }
        }
        return max.ToString();
    }

    public static string HighestForEachLoop(List<int> intList)
    {
        int max = intList[0];

        foreach (var num in intList)
        {
            if (max < num) max = num;
        }

        return max.ToString();
    }
    public static string HighestDoWhileLoop(List<int> intList)
    {
        int max = intList[0];
        int count = 0;
        do
        {
            if (intList[count] > max)
            {
                max = intList[count];
                count++;
            }
        } while (count < intList.Count);
        return max.ToString();
    }


    public static string HighestWhileLoop(List<int> intList)
    {
        int max = intList[0];
        int count = 0;
        while (count < intList.Count)
        {
            foreach (var num in intList)
            {
                if (max < num) max = num;
                ++count;
            }
            break;
        }
        return max.ToString();
    }
}