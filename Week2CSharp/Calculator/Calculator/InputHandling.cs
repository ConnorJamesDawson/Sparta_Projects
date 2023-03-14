

namespace Calculator;

public static class InputHandling
{
    static Parse parse = new(new Calculations());

    public static string ReadInput()
    {
        return Console.ReadLine().ToLower().Trim();
    }
    public static void handleInput(string userInput)
    {
        switch (userInput) //Look for specific commands
        {
            case "quit":
                Console.WriteLine("Thank you for using my calculator, Goodbye");
                Environment.Exit(0);
                break;
            case "clear":
                Console.Clear();
                WelcomeMessage();
                break;
            default:
                if (userInput != null)
                {
                    //parse.ParseInput(userInput);
                    //Console.WriteLine(cal.Calculate(parse.firstNum, parse.secondNum, parse.operand));
                    parse.ParseForFirstNumber(userInput);
                    parse.ParseForOperand(userInput);
                    parse.ParseForSecondNumber(userInput);

                    Console.WriteLine(parse.CalculateEquation());
                }
                else
                    Console.WriteLine("Please input a calculation to be performed");
                break;
        }
    }

    public static void WelcomeMessage()
    {
        Console.WriteLine("Welcome to my calculator -");
        Console.WriteLine("Please input a calculation to be done with any of the following opperand + - * /");
        Console.WriteLine("If you want to quit, type 'Quit', if you want to clear calculations type 'Clear'");
    }

}
