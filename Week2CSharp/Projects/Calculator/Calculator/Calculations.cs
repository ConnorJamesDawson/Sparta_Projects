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
                    return lhs + rhs;
                case '-':
                    return lhs - rhs;
                case '*':
                    return lhs * rhs;
                case '/':
                    return lhs / rhs;
                default:
                    throw new ArgumentException($"unknown operator {op}");
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
