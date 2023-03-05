namespace MoneyTask;

public class Program
{
    static void Main()
    {
        float input = 160.70f;
        if(float.TryParse(Console.ReadLine(), out float result))
        {
            input = result;
        }
        Console.WriteLine(MoneyParse(input));
    }

    public static string MoneyParse(float money)
    { //Remember working in pennies
        if (money < 0) throw new ArgumentOutOfRangeException("Please add a positive value to get a result from");

        float pennies = money * 100;
        Console.WriteLine(pennies);
        int fiftyNote = 0; 
        int twentyNote = 0; 
        int tenNote = 0; 
        int fiveNote = 0; 
        int twoPoundCoin = 0; 
        int onePoundCoin = 0; 
        int fiftyPence = 0; 
        int twentyPence = 0; 
        int tenPence = 0; 
        int fivePence = 0; 
        int twoPence = 0; 
        int onePence = 0;

        double remainder = pennies;

        if(remainder >= 5000)
        {
            fiftyNote = (int)remainder / 5000;
            remainder = remainder % 5000;
            Console.WriteLine(remainder);
        }

        if (remainder >= 2000)
        {
            twentyNote = (int)remainder / 2000;
            remainder = remainder % 2000;
            Console.WriteLine(remainder);
        }

        if (remainder >= 1000)
        {
            tenNote = (int)remainder / 1000;
            remainder = remainder % 1000;
            Console.WriteLine(remainder);
        }
        if (remainder >= 500)
        {
            fiveNote = (int)remainder / 500;
            remainder = remainder % 500;
            Console.WriteLine(remainder);
        }
        if (remainder >= 200)
        {
            twoPoundCoin = (int)remainder / 200;
            remainder = remainder % 200;
            Console.WriteLine(remainder);
        }
        if (remainder >= 100)
        {
            onePoundCoin = (int)remainder / 100;
            remainder = remainder % 100;
            Console.WriteLine(remainder);
        }
        if (remainder >= 50)
        {
            fiftyPence = (int)remainder / 50;
            remainder = remainder % 50;
            Console.WriteLine(remainder);
        }
        if (remainder >= 20)
        {
            twentyPence = (int)remainder / 20;
            remainder = remainder % 20;
            Console.WriteLine(remainder);
        }
        if (remainder >= 10)
        {
            tenPence = (int)remainder / 10;
            remainder = remainder % 10;
            Console.WriteLine(remainder);
        }
        if (remainder >= 5)
        {
            fivePence = (int)remainder / 5;
            remainder = remainder % 5;
            Console.WriteLine(remainder);
        }
        if (remainder >= 2)
        {
            twoPence = (int)remainder / 2;
            remainder = remainder % 2;
            Console.WriteLine(remainder); // remainder is 0 here
        }
        if (remainder >= 1)
        {
            onePence = (int)remainder / 1;
            remainder = remainder % 1;
        }

        return $"£50:{fiftyNote}, £20:{twentyNote}, £10:{tenNote}, £5:{fiveNote}, £2:{twoPoundCoin}, £1:{onePoundCoin}," +
               $"50p:{fiftyPence}, 20p:{twentyPence}, 10p:{tenPence}, 5p:{fivePence}, 2p:{twoPence}, 1p:{onePence}";

    }
}