namespace Calculator
{
    internal class Parse
    {
        public int firstNum = 0;
        public bool lookingForFirst = true;
        public char operand = ' ';
        public int secondNum = 0;
        public void ResetValues()
        {
            firstNum = 0;
            secondNum = 0;
            lookingForFirst = true;
            operand = ' ';
        }

        public void ParseInput(string userInput)
        {
            ResetValues();
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
                        if (operand != ' ')
                            break;
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
        }
    }
}





