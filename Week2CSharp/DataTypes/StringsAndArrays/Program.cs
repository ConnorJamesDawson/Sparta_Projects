using System.Text;

namespace StringsAndArrays;

public class Program
{
    static void Main()
    {
        #region strings
        /*        string myPassword = "LookMomNoHands".ToLower();
                char grade = 'p';

                char firstLetter = myPassword[0];

                foreach(char letter in myPassword)
                {
                    Console.WriteLine(letter);
                }

                myPassword = myPassword.ToUpper(); //Nonmutable, have to assign change

                Console.WriteLine(myPassword);*/

        /*        var myString = "  C# list fundamentals ";

                Console.WriteLine(StringBuilderExercise(myString));

                string firstName = "Peter";
                string lastName = "Wright";

                Console.WriteLine($"FirstName: {firstName}, Last name: {lastName}");
                Console.WriteLine(@"FirstName: {{firstName}}, Last name: {lastName}");
                Console.WriteLine("FirstName: {0}, Last name: {1}", firstName, lastName);

                Console.WriteLine($"Barman says { 5f / 2 :C} please");*/

        //Parsing strings

        /*        string input = Console.ReadLine();
                //int numApples = Int32.Parse(input);
                var tryParseOutput = Int32.TryParse(input, out int numApples);
                if(tryParseOutput) Console.WriteLine(numApples);
                else Console.WriteLine("Not an integer");*/
        /*        string input = Console.ReadLine();
                //int numApples = Int32.Parse(input);
                var tryParseOutput = Int32.TryParse(input, out int numApples);
                if(tryParseOutput) Console.WriteLine(numApples);
                else Console.WriteLine("Not an integer");*/
        #endregion
        #region Arrays
        /*        int[] intArray = {12,23,34,45,56};
                int[] empty1DArray = new int[10];


                Array.Reverse(intArray);

                foreach (var num in intArray)
                {
                    //Console.Write(num + " ");
                }
                //Multidiemsional Array 0,1
                int[,] chessboard = { { 0,1 }, 
                                      { 2,3 }, 
                                      { 4,5 }, 
                                      { 6,7 }, 
                                      { 8,9 }, 
                                      { 10,11 } };
                int[,,] empty3DArray = new int[2, 3, 4];

                foreach (var item in chessboard)
                {
                    //Console.WriteLine(item);
                }
                for(int i = 0; i <= chessboard.GetUpperBound(0); i++)
                {
                    for (int j = 0; j <= chessboard.GetUpperBound(1); j++)
                    {
                        Console.WriteLine(chessboard[i,j]);
                    }
                }


                empty3DArray[0, 2, 1] = 99;

                //Jagged Arrays

                int[][] jaggedArray = new int[2][];
                jaggedArray[0] = new int[4];
                jaggedArray[1] = new int[3];
                jaggedArray[2] = new int[1];

                string[][] fruits = new string[2][] { 
                    new string[] { "Apple", "Apricot" }, 
                    new string[] { "Mango", "Orange", "Melon"} 
                };

                foreach (var animalGroup in fruits)
                {
                    foreach (var animal in animalGroup)
                    {
                        Console.WriteLine(animal);
                    }
                }*/
        #endregion
        #region Date/Time Object

        var now = DateTime.Now;
        Console.WriteLine(now.Date);

        var tomorrow = now.AddDays(1);
        Console.WriteLine(tomorrow);

        #endregion
        #region enums/Enumerater Types
        Suits myCard = Suits.CLUBS;

        Console.WriteLine($"I have a {myCard} suit card");

        #endregion
        int countRow1 = 2;
        int countRow2 = 4;
        int p = 0;
        string[][] newJaggedArray = new string[][]{
                new string[countRow1],
                new string[countRow2]
            };

        List<string> _list = new List<string> { "Alpha", "Beta", "Gamma", "Delta", "Epsilon", "Zeta" };
        for (int i = 0; i < countRow1; i++)
        {
            for (int j = 0; j < countRow2; j++)
            {
                Console.WriteLine($"Trying to wrtie to {i} {j}");
                try
                {
                    if(p<_list.Count)
                    {
                        newJaggedArray[i][j] = _list[p++];
                        //Console.WriteLine($"Writing {_list[p]} to {i} {j}");
                    }
                }
                catch (IndexOutOfRangeException e)
                {
                    p--;
                    break;
                }
            }
        }
    }
public static string StringExercise(string myString)
{
    string newString = myString;
    foreach (char letter in myString)
    {
        if (letter == ' ')
        {
            newString = newString.Trim();
        }
        switch (letter)
        {
            case 'l':
            case 'L':
            case 't':
            case 'T':
                newString = newString.Replace(letter, '*');
                break;
            case 'n':
            case 'N':
                int indexOfN = newString.IndexOf('n');
                newString = newString.Remove(indexOfN + 1);
                break;
        }
    }
    return newString;
}

public static string StringBuilderExercise(string myString)
{
    string newString = myString.Trim();
    string upper = newString.ToUpper();
    int indexOfN = upper.IndexOf('N');

    StringBuilder sb = new StringBuilder(upper);

    sb.Replace('L', '*').Replace('N', '*').Remove(indexOfN + 1, sb.Length - indexOfN - 1);

    return sb.ToString();
}



}