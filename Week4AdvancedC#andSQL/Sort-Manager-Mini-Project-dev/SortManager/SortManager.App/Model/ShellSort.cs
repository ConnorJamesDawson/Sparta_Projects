using System.Diagnostics;

namespace SortManager.App.Model;

public class ShellSort : AbstractSort
{
    public override int[] SortArray(int[] array)
    {
        Stopwatch timer = TimerClass.StartTimer();
        int n = array.Length;

        // Start with a big gap, then reduce the gap
        for (int gap = n / 2; gap > 0; gap /= 2)
        {
            // Do a gapped insertion sort for this gap size.
            for (int i = gap; i < n; i += 1)
            {

                int temp = array[i];

                // Looks at the value on the other side of the gap and sees if its smaller, if it's samller swap positions
                int checker;
                for (checker = i; checker >= gap && array[checker - gap] > temp; checker -= gap)
                {
                    array[checker] = array[checker - gap];
                }
                // put temp (the original a[i]) in its correct location
                array[checker] = temp;
            }
        }
        TimerClass.StopTimerAndReturnTime(timer);
        return array;
    }
}
