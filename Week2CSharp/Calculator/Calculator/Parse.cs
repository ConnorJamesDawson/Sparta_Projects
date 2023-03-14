namespace Calculator
{
    public class Parse
    {
        private static bool _isDebugging = false;
        private float _firstNum = 0;
        private char _operand = ' ';
        private float _secondNum = 0;
        private bool _lookingForFirst = true;
        private bool _firstNumIsMinusNumber = false;
        private bool _secondNumIsMinusNumber = false;
        private int _lastElementChecked = 0;

        public float FirstNumber 
        {
            get { return _firstNum; }
            private set { _firstNum = value; }
        }
        public float SecondNumber
        {
            get { return _secondNum; }
            private set { _secondNum = value; }
        }

        public char Operand
        {
            get { return _operand; }
            private set { _operand = value; }
        }

        public void ResetValues()
        {
            FirstNumber = 0;
            SecondNumber = 0;
            _lookingForFirst = true;
            _firstNumIsMinusNumber = false;
            _secondNumIsMinusNumber = false;
            Operand = ' ';
            _lastElementChecked = 0;
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
                            _firstNumIsMinusNumber = true;
                        }

                        if (_firstNumIsMinusNumber)
                        {
                            FirstNumber = (FirstNumber * 10) - Convert.ToInt32(userInput[i].ToString());
                        }
                        else
                        {
                            FirstNumber = (FirstNumber * 10) + Convert.ToInt32(userInput[i].ToString());
                        }
                        _lastElementChecked = i;
                        DebugPrint($"The first number is {FirstNumber}");
                    }

                    if (!Char.IsNumber(userInput[i + 1]))
                    {
                        break;
                    }
                }
            }
            return FirstNumber;
        }
        public Char ParseForOperand(string userInput)
        {
            if (userInput != null)
            {
                for (int i = _lastElementChecked; i < userInput.Length; i++)
                {
                    if (!Char.IsNumber(userInput[i]))
                    {
                        _lastElementChecked = i;
                        switch (userInput[i]) // Set the operand for use within calculation 
                        {
                            case '+':
                                Operand = '+';
                                return Operand;
                            case '-':
                                if (_firstNumIsMinusNumber)
                                {
                                    _firstNumIsMinusNumber = false;
                                    break;
                                }
                                Operand = '-';
                                return Operand;
                            case '*':
                                Operand = '*';
                                return Operand;
                            case '/':
                                Operand = '/';
                                return Operand;
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
                for (int i = _lastElementChecked; i < userInput.Length; i++)
                {
                    if (!Char.IsNumber(userInput[i]) && i > 0)
                    {
                        _lookingForFirst = false;
                        DebugPrint($"Found operand at {i}");
                    }

                    if (Char.IsNumber(userInput[i]) && !_lookingForFirst)
                    {
                        switch (Operand)
                        {
                            case '-':
                                if (i > 2 && userInput[i - 1] == '-' && userInput[i - 2] == '-') // i > 0 for exceptions
                                {
                                    DebugPrint($"Found minus at {i}");
                                    _secondNumIsMinusNumber = true;
                                }
                                break;
                            default:
                                if (userInput[i - 1] == '-')
                                {
                                    DebugPrint($"Found minus at {i}");
                                    _secondNumIsMinusNumber = true;
                                }
                                break;
                        }


                        if (_secondNumIsMinusNumber)
                        {
                            SecondNumber = (SecondNumber * 10) - Convert.ToInt32(userInput[i].ToString());
                        }
                        else
                        {
                            SecondNumber = (SecondNumber * 10) + Convert.ToInt32(userInput[i].ToString());
                        }
                        DebugPrint($"The second number is {SecondNumber}");
                    }
                }
            }
            return SecondNumber;
        }

        private static void DebugPrint(string output)
        {
            if(_isDebugging)
                Console.WriteLine(output);
        }
    }
}





