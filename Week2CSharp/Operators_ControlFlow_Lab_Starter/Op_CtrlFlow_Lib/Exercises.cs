using System;
using System.Collections.Generic;
using System.Linq;

namespace Op_CtrlFlow
{
    public class Exercises
    {
        public static bool MyMethod(int num1, int num2)
        {
            return num1 == num2 ? false : (num1 % num2) == 0;
        }

        // returns the average of the array nums
        public static double Average(List<int> nums)
        {
            if(nums.Count == 0)
            {
                return 0;
            }
            return nums.Sum() / Convert.ToDouble(nums.Count);
        }

        // returns the type of ticket a customer is eligible for based on their age
        // "Standard" if they are between 18 and 59 inclusive
        // "OAP" if they are 60 or over
        // "Student" if they are 13-17 inclusive
        // "Child" if they are 5-12
        // "Free" if they are under 5
        public static string TicketType(int age)
        {
            switch(age)
            {
                case >= 60:
                    return "OAP";
                case >= 18:
                    return "Standard";
                case >= 13:
                    return "Student";
                case >= 5:
                    return "Child";
                case < 5:
                    return "Free";
            }
        }

        public static string Grade(int mark)
        {
            if(mark >= 75 && mark <= 100)
            {
                return "Pass with Distinction";
            }
            else if(mark >= 60 && mark <= 74)
            {
                return "Pass with Merit";
            }
            else if(mark >= 40 && mark <= 59)
            {
                return "Pass";
            }
            else if(mark>=0 && mark <= 39)
            {
                return "Fail";
            }
            else
            {
                return "Invalid amount of marks";
            }
        }

        public static int GetScottishMaxWeddingNumbers(int covidLevel)
        {
            if(covidLevel < 0 || covidLevel > 4)
            {
                throw new ArgumentOutOfRangeException();
            }
            switch(covidLevel)
            {
                case 0:
                    return 200;
                case 1:
                    return 100;
                case 2:
                    return 50;
                case 3:
                    return 50;
                case 4:
                    return 20;
                default:
                    return 0;
            }
        }
    }
}
