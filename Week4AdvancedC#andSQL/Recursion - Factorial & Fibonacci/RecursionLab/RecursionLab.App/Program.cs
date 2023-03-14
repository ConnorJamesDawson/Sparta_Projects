namespace RecursionLab.App;

public class Program
{
    static void Main()
    {
        Console.WriteLine(ReturnFactorialOf(4));
        Console.WriteLine(ReturnRecurisonFactorialOf(4));
        Console.WriteLine();
        Console.WriteLine(FibonacciLoop(10));
        Console.WriteLine(FibonacciRecursion(10));
    }

    public static int ReturnFactorialOf(int x)
    {
        int sum = 1;
        for (int i = 1; i <= x; i++)
        {
            sum *= i;
        }
        return sum;
    }

    public static int ReturnRecurisonFactorialOf(int x)
    {
        if (x <= 1) return 1;

        return x * ReturnRecurisonFactorialOf(x - 1);
    }

    public static int FibonacciLoop(int x)
    {
        int firstnumber = 0, secondnumber = 1, result = 0;

        if (x == 0) return 0; //To return the first Fibonacci number   
        if (x == 1) return 1; //To return the second Fibonacci number   


        for (int i = 2; i <= x; i++)
        {
            result = firstnumber + secondnumber;
            firstnumber = secondnumber;
            secondnumber = result;
        }

        return result;
    }

    public static int FibonacciRecursion(int x)
    {
        if ((x == 0) || (x == 1))
        {
            return x;
        }
        else
        {
            return (FibonacciRecursion(x - 1) + FibonacciRecursion(x - 2));
        }
    }
}