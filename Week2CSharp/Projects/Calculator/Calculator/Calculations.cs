using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class Calculations
    {
        public int Calculate(int lhs, int rhs, char op)
        {
            switch (op)
            {
                case '+':
                    Console.WriteLine("Adding {0} to {1}", lhs, rhs);
                    return lhs + rhs;
                case '-':
                    Console.WriteLine("Subtracting {0} to {1}", lhs, rhs);
                    return lhs - rhs;
                case '*':
                    Console.WriteLine("Timesing {0} to {1}", lhs, rhs);
                    return lhs * rhs;
                case '/':
                    Console.WriteLine("Dividing {0} by {1}", lhs, rhs);
                    return lhs / rhs;
                default:
                    Console.WriteLine("You have inputed an incorrect value");
                    return 0;
                }
        }

        public int Add(int lhs, int rhs)
        {
            return lhs + rhs;
        }

        public int Subtract (int lhs, int rhs)
        {
            return lhs - rhs;
        }

        public int Multiply(int lhs, int rhs)
        { 
            return lhs * rhs; 
        }

        public int Divide(int lhs, int rhs)
        {
            return lhs / rhs;
        }
    }

}
