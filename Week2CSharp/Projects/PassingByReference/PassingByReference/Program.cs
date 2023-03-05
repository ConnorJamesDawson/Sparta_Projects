using System;

namespace PassingByReference;

internal class Program
{
    static void Main()
    {
        int a = 6;
        int b = 3;
        int d = Int32.MaxValue;
        int c = (a % b == 0) ? c = a : c = b;
        Console.WriteLine(c);

        checked
        {
            d++;
        }
    }
}