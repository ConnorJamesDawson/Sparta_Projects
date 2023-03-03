using System;
using System.Collections.Generic;

namespace MoreTypes_Lib
{
    public class ArraysExercises
    {
        // returns a 1D array containing the contents of a given List
        public static string[] Make1DArray(List<string> contents)
        {
            return contents.ToArray();
        }

        // returns a 3D array containing the contents of a given List
        public static string[,,] Make3DArray(int length1, int length2, int length3, List<string> contents)
        {
            if (contents.Count != length1 * length2 * length3) throw new ArgumentException("Number of elements in list must match array size");

            string[,,] new3DArray = new string[length1,length2,length3];

            int p = 0; //A counter for the contents list 
            for (int i = 0; i < length1; i++)
            {
                for (int j = 0; j < length2; j++)
                {
                    for (int k = 0; k < length3; k++)
                    {
                        new3DArray[i, j, k] = contents[p++];
                    }
                }
            }

            return new3DArray;
        }

        // returns a jagged array containing the contents of a given List
        public static string[][] MakeJagged2DArray(int countRow1, int countRow2, List<string> contents)
        {
            if (contents.Count != countRow1 + countRow2) throw new ArgumentException("Number of elements in list must match array size");

            string[][] newJaggedArray = new string[][]{
                new string[countRow1],
                new string[countRow2]
            };
            int p = 0;
            for (int i = 0; i < newJaggedArray.Length; i++)
            {
                for (int j = 0; j < newJaggedArray[i].Length; j++)
                {
                    /*                    Console.WriteLine($"Trying to wrtie to {i} {j}");
                                        try
                                        {
                                            newJaggedArray[i][j] = contents[p++];
                                            //Console.WriteLine($"Writing {contents[p]} to {i} {j}");
                                        }
                                        catch(System.IndexOutOfRangeException e)
                                        {
                                            p--;
                                            break;
                                        } Brute force much */
                    newJaggedArray[i][j] = contents[p++];

                }
            }

            return newJaggedArray;
        }
    }
}
