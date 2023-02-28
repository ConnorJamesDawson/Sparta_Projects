namespace OperatorsAndControlFlow;

public class Program
{
    static void Main()
    {
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
        m += +j++ + ++k;
        Console.WriteLine(m);
    }

    public static int GetStones(int totalPounds) //1 stone = 14 pounds
    {
        return totalPounds / 14;
    }

    public static int GetPoundsLeft(int totalPounds)
    {
        return totalPounds % 14;
    }
}