using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class Calculations
    {
        public float Calculate(float lhs, float rhs, char op)
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
                    throw new ArgumentNullException("You have inputed an incorrect value, " + op + " is not a operand that this system can use");
                }
        }
    }

}
