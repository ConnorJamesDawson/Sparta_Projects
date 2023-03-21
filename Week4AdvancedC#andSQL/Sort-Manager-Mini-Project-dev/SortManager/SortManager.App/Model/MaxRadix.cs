using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortManager.App.Model
{
    public class MaxRadix : AbstractSort
    {
        static public int[] Radixing(int[] countarray, int[] list, bool tens)
        {
            int[] temp = new int[list.Length];
            for (int i = 0; i < countarray.Length; i++)
            {
                if (i == 0) countarray[i] -= 1;
                else
                {
                    countarray[i] = countarray[i - 1] + countarray[i];
                }
            }
            for (int i = temp.Length - 1; i >= 0; i--)
            {
                if (tens)
                {
                    if (list[i] >= 0)
                    {
                        temp[countarray[(list[i] / 10) + 9]] = list[i];
                        countarray[(list[i] / 10) + 9]--;
                    }
                    else
                    {
                        temp[countarray[9 + (list[i] / 10)]] = list[i];
                        countarray[9 + (list[i] / 10)]--;
                    }
                }
                if (!tens)
                {
                    if (list[i] >= 0)
                    {
                        temp[countarray[(list[i] % 10) + 9]] = list[i];
                        countarray[list[i] % 10 + 9]--;
                    }
                    else
                    {
                        temp[countarray[9 + (list[i] % 10)]] = list[i];
                        countarray[9 + (list[i] % 10)]--;
                    }
                }
            }
            return temp;
        }
        public override int[] SortArray(int[] list)
        {
            Stopwatch timer = TimerClass.StartTimer();
            int[] countarray = new int[19];
            for (int i = 0; i < list.Length; i++)
            {
                if (list[i] >= 0) countarray[(list[i] % 10) + 9]++;
                else countarray[9 + (list[i] % 10)]++;
            }
            list = Radixing(countarray, list, false);
            countarray = new int[19];
            for (int i = 0; i < list.Length; i++)
            {
                if (list[i] >= 0) countarray[(list[i] / 10) + 9]++;
                else countarray[9 + (list[i] / 10)]++;
            }
            list = Radixing(countarray, list, true);
            TimerClass.StopTimerAndReturnTime(timer);
            return list;
        }
    }
}
