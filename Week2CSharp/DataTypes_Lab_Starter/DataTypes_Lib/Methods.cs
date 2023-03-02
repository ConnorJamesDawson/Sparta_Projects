using System;

namespace DataTypes_Lib
{
    public static class Methods
    {
        // write a method to return the product of all numbers from 1 to n inclusive
        public static double Factorial(int n)
        {
            double sum = 1;
            for(int i = 1; i <= n; i++)
            {
                sum *= i;
            }
            return sum;
        }

        public static float Mult(float num1, float num2)
        {
            return num1 * num2;
        }
    }
}
