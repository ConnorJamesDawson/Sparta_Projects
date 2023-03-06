namespace DataTypes;

public class Program
{
    static void Main()
    {
        /*        int n = 25;
                n = "25";
                string age = n;*/

        /*        double sum = 0;

                for (int i = 0; i < 1_000_000; i++)
                {
                    sum += 2 / 5f;
                }

                Console.WriteLine("w/5 added 1 million times is: {0}", sum);
                Console.WriteLine("w/5 multiplied by 1 million is in calculation: {0}", 2/5f * 1_000_000);*/
        #region implicit conversion
        /*        if (sum == 400_000) Console.WriteLine("calculation success");
                else Console.WriteLine("Calculation failure");

                int kangaroosInSydney = 652;
                long kangaroosInAus = kangaroosInSydney; //Implicit conversion
                //kangaroosInSydney = kangaroosInAus; Data size is a thing, can't fit a long in an int but can other way around

                int intDiv = 2;
                int intDiv2 = 5;

                Console.WriteLine(intDiv / intDiv2 + " " + (float)intDiv/(float)intDiv2); //Casting, force a conversion through

                float pi = 3.143f;
                double doublePi = pi;*/
        #endregion
        #region Underflow
        byte aggro = 0;

        Console.WriteLine("Ghandi's agro is {0}", aggro);

        aggro -= 1;

        Console.WriteLine("Ghandi's agro is now {0}", aggro);
        #endregion
        #region Overflow
        /*        byte maxAggro = 255;

                Console.WriteLine("Ghengis Khan's agro is {0}", maxAggro);

                maxAggro += 1;

                Console.WriteLine("Ghengis Khan's agro is now {0}", maxAggro);*/
        #endregion
        #region Casting
/*        double x = 3.14159265359;
        //Casting - Explicit conversion, unsafe
        float y = (float)x;

        Console.WriteLine("X is {0}, y = {1}", x, y);

        int numCows = 260;

        uint numCowsU = (uint)numCows;
        byte numCowsB = (byte)numCows;
        //Examples of Lost data 
        Console.WriteLine("NumCows is {0}, NumCowsU is {1}", numCows, numCowsU);
        Console.WriteLine("NumCows is {0}, NumCowsB is {1}", numCows, numCowsB);

        int studentLoan = -5000;
        uint studentLoanU = (uint)studentLoan;*/

        #endregion
    }
}