using System;
using System.Collections.Generic;

namespace Collections_Lib
{
    public class CollectionsExercises
    {

        /* removes and returns the next num entries in the queue, as a comma separated string */
        public static string NextInQueue(int num, Queue<string> queue)
        {
            string result = "";
            for (int i = 1; i <= num; i++)
            {
                if (queue.Count == 0)
                    break;
                result += queue.Dequeue();
                if (i != num && queue.Count != 0)
                    result += ", ";
            }
            return result;

        }

        /* uses a Stack to create and return array of ints in reverse order to the one supplied */
        public static int[] Reverse(int[] original)
        {
            Stack<int> stack = new Stack<int>();

            foreach (int i in original) { stack.Push(i); }

            return stack.ToArray();
        }
        // using a Dictionary, counts and returns (as a string) the occurence of the digits 0-9 in the given string
        public static string CountDigits(string input)
        {
            Dictionary<char, int> dic = new Dictionary<char, int>();

            string result = "";

            foreach (char c in input)
            {
                if (char.GetNumericValue(c) != -1)
                {
                    if (dic.ContainsKey(c))
                        dic[c]++;
                    else dic.Add(c, 1);
                }
            }

            foreach (var item in dic)
                result += item;

            return result;
        }
    }
}
