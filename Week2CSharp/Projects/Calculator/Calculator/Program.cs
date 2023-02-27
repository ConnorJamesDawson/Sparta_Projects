using Calculator;

internal class Program
{
    private static void Main(string[] args)
    {
        Calculations cal = new Calculations();
        bool quit = false;
        Console.WriteLine("Welcome to my calculator");

        Console.WriteLine("Please input a calculation to be done with any of the following opperand + - * /");
        while (!quit)
        {// Have a general reset before any calculation 
            int firstNum = 0; 
            bool lookingForFirst = true;
            char operand = ' ';
            int secondNum = 0;
            string userInput = Console.ReadLine();

            if (userInput != null)
            {
                for (int i = 0; i < userInput.Length; i++)
                {
                    Console.WriteLine("Reading {0} ", userInput[i]);

                    if (char.IsNumber(userInput[i]))
                    {
                        if (lookingForFirst)
                        {//When adding numbers its important to move the numbers to the left (times by 10) so more than single figures can be used
                            firstNum = (firstNum * 10) + Convert.ToInt32(userInput[i].ToString());
                            Console.WriteLine("Writing {0} to first number, first number is now {1}", userInput[i], firstNum);
                        }
                        else
                        {
                            secondNum = (secondNum * 10) + Convert.ToInt32(userInput[i].ToString());
                            Console.WriteLine("Writing {0} to second number, second number is now {1}", userInput[i], secondNum);
                        }
                    }
                    else
                    {
                        lookingForFirst = false; //After the first number is parsed switch to reading for the second
                    }

                    switch (userInput[i]) // Set the operand for use within calculation 
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