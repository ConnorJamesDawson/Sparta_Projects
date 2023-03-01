namespace Calculator
{
    public class Parse
    {
        public float firstNum = 0;
        public bool lookingForFirst = true;
        public bool firstNumIsMinusNumber = false;
        public bool secondNumIsMinusNumber = false;
        public char operand = ' ';
        public float secondNum = 0;
        public void ResetValues()
        {
            firstNum = 0;
            secondNum = 0;
            lookingForFirst = true;
            firstNumIsMinusNumber = false;
            secondNumIsMinusNumber = false;
            operand = ' ';
        }
        /*
        public static void ParseInput(string userInput)
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
        */
        public float ParseForFirstNumber(string userInput)
        {
            ResetValues();
            if (userInput != null)
            {
                for (int i = 0; i < userInput.Length; i++)
                {
                    if (Char.IsNumber(userInput[i]))
                    {
                        if (i > 0 && userInput[i - 1] == '-') // i > 0 for exceptions
                        {
                            firstNumIsMinusNumber = true;
                        }

                        if (firstNumIsMinusNumber)
                        {
                            firstNum = (firstNum * 10) - Convert.ToInt32(userInput[i].ToString());
                        }
                        else
                        {
                            firstNum = (firstNum * 10) + Convert.ToInt32(userInput[i].ToString());
                        }
                        Console.WriteLine("The first number is {0}", firstNum);
                        return firstNum;
                    }

                    if (!Char.IsNumber(userInput[i + 1]))
                    {
                        break;
                    }
                }
            }
            return 0;
        }
        public Char ParseForOperand(string userInput)
        {
            if (userInput != null)
            {
                for (int i = 0; i < userInput.Length; i++)
                {
                    if (!Char.IsNumber(userInput[i]))
                    {
                        switch (userInput[i]) // Set the operand for use within calculation 
                        {
                            case '+':
                                operand = '+';
                                return operand;
                            case '-':
                                if (firstNumIsMinusNumber)
                                {
                                    firstNumIsMinusNumber = false;
                                    break;
                                }
                                operand = '-';
                                return operand;
                            case '*':
                                operand = '*';
                                return operand;
                            case '/':
                                operand = '/';
                                return operand;
                        }
                    }
                }
            }
            return ' ';
        }
        public float ParseForSecondNumber(string userInput)
        {
            if (userInput != null)
            {
                for (int i = 0; i < userInput.Length; i++)
                {
                    if (!Char.IsNumber(userInput[i]) && i > 0)
                    {
                        lookingForFirst = false;
                        Console.WriteLine("Found operand at {0}", i);
                    }

                    if (Char.IsNumber(userInput[i]) && !lookingForFirst)
                    {
                        switch (operand)
                        {
                            case '-':
                                if (i > 2 && userInput[i - 1] == '-' && userInput[i - 2] == '-') // i > 0 for exceptions
                                {
                                    Console.WriteLine("Found minus at {0}", i);
                                    secondNumIsMinusNumber = true;
                                }
                                break;
                            default:
                                if (userInput[i - 1] == '-')
                                {
                                    Console.WriteLine("Found minus at {0}", i);
                                    secondNumIsMinusNumber = true;
                                }
                                break;
                        }


                        if (secondNumIsMinusNumber)
                        {
                            secondNum = (secondNum * 10) - Convert.ToInt32(userInput[i].ToString());
                        }
                        else
                        {
                            secondNum = (secondNum * 10) + Convert.ToInt32(userInput[i].ToString());
                        }
                        Console.WriteLine("The second number is {0}", secondNum);
                        return secondNum;
                    }
                }
            }
            return 0;
        }
    }
}





