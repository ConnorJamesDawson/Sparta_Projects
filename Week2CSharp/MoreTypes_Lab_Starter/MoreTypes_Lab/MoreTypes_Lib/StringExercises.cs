using System;
using System.Text;

namespace MoreTypes_Lib
{
    public class StringExercises
    {
        // manipulates and returns a string - see the unit test for requirements
        public static string ManipulateString(string input, int num)
        {
            string trim = input.Trim();
            string upper = trim.ToUpper();
            string alteredString = upper;

            for (int i = 0; i < num; i++)
            {
                alteredString +=  i.ToString();
            }

            return alteredString;
        }

        // returns a formatted address string given its components
        public static string Address(int number, string street, string city, string postcode)
        {
            string addressString = number.ToString() + " " + street + ", " + city + " " + postcode +".";
            return addressString;
        }
        // returns a string representing a test score, written as percentage to 1 decimal place
        public static string Scorer(int score, int outOf)
        {
            float percentage = score / (float)outOf * 100;
            double num = Math.Round(percentage, 1);
            string result = $"You got {score} out of {outOf}: {num}%";
            return result;
        }

        // returns the double represented by the string, or -999 if conversion is not possible
        public static double ParseNum(string numString)
        {
            double number;
            try
            {
                number = Convert.ToDouble(numString);
            }
            catch (Exception e)
            {
                return -999;
            }
            return number;
        }

        // Returns the a string containing the count of As, Bs, Cs and Ds in the parameter string
        // all other letters are ignored
        public static string CountLetters(string input)
        {
            string inputUpper = input.ToUpper();
            int aCounter = 0;
            int bCounter = 0;
            int cCounter = 0;
            int dCounter = 0;
            foreach (char character in input)
            {
                switch (character)
                {
                    case 'A':
                        aCounter++;
                        break;
                    case 'B':
                        bCounter++;
                        break;
                    case 'C':
                        cCounter++;
                        break;
                    case 'D':
                        dCounter++;
                        break;
                }
            }
            return $"A:{aCounter} B:{bCounter} C:{cCounter} D:{dCounter}";
        }
    }
}
