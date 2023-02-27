using System.Diagnostics;

namespace HelloWorld;

public class Program
{
    static void Main()
    {
        int x = 100;
        x += 10;
        for (int i = 0; i <= 10; i++)
        {
            Console.WriteLine("i: " + i + " x: " + x);
            x += i;
        }
    }
}