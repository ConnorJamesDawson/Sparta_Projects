using Calculator;
using System.Runtime.CompilerServices;

internal class Program
{
    public static void Main(string[] args)
    {
        Calculations cal = new();
        Parse parse = new();
        bool quit = false;

        Console.WriteLine("Welcome to my calculator");

        Console.WriteLine("Please input a calculation to be done with any of the following opperand + - * /");
        Console.WriteLine("If you want to quit, type 'Quit', if you want to clear calculations type 'Clear'");
        while (!quit)
        {// Have a general reset before any calculation 
            string userInput = Console.ReadLine();

            switch(userInput) //Look for specific commands
            {
                case "Quit":
                case "quit":
                    Console.WriteLine("Thank you for using my calculator");
                    Environment.Exit(0);
                    break;
                case "Clear":
                case "clear":
                    Console.Clear();
                    Console.WriteLine("This should clear");
                    Console.WriteLine("Welcome to my calculator");

                    Console.WriteLine("Please input a calculation to be done with any of the following opperand + - * /");
                    break;
                    default:
                    if (userInput != null)
                    {
                        //parse.ParseInput(userInput);
                        //Console.WriteLine(cal.Calculate(parse.firstNum, parse.secondNum, parse.operand));
                        parse.ParseForFirstNumber(userInput);
                        parse.ParseForOperand(userInput);
                        parse.ParseForSecondNumber(userInput);

                        Console.WriteLine(cal.Calculate(parse.firstNum, parse.secondNum, parse.operand));
                    }
                    else
                        Console.WriteLine("Please input a calculation to be performed");
                    break;
            }
        }
    }
}