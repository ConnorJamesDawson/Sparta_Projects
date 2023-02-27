using Calculator;

internal class Program
{
    private static void Main(string[] args)
    {
        Calculations cal = new Calculations();
        bool quit = false;
        int firstNum = 0;
        bool lookingForFirst = true;
        char operand = ' ';
        int secondNum = 0;
        Console.WriteLine("Welcome to my calculator");

        Console.WriteLine("Please input a calculation to be done with any of the following opperand + - * /");
        while (!quit)
        {
            string userInput = Console.ReadLine();



            if (userInput != null)
            {
                for (int i = 0; i < userInput.Length; i++)
                {
                    Console.WriteLine("Reading {0} " + char.IsNumber(userInput[i]), i);
                    if (userInput[i] == ' ')
                    {
                        lookingForFirst = false;
                        Console.WriteLine("Found Space");
                    }

                    if (char.IsNumber(userInput[i]))
                    {
                        if (lookingForFirst)
                        {
                            firstNum = Convert.ToInt32(userInput[i]);
                            Console.WriteLine("Writing {0} to first number", userInput[i]);
                        }
                        else
                        {
                            secondNum = Convert.ToInt32(userInput[i]);
                            Console.WriteLine("Writing {0} to second number", userInput[i]);
                        }
                    }
                    switch (userInput[i])
                    {
                        case '+':
                            operand = '+';
                            break;
                        case '-':
                            operand = '-';
                            break;
                        case '*':
                            operand = '*';
                            break;
                        case '/':
                            operand = '/';
                            break;
                    }
                }
            }
        Console.WriteLine(cal.Calculate(firstNum, secondNum, operand));
        }
    }
}