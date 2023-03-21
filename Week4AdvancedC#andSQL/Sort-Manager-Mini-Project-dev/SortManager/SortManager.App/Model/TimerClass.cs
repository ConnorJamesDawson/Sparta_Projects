using System.Diagnostics;

namespace SortManager.App.Model;

public class TimerClass
{
    public static decimal GetTime(decimal time) => time;
    public static Stopwatch StartTimer()
    {
        Stopwatch timer = Stopwatch.StartNew();
        return timer;
    }

    public static void StopTimerAndReturnTime(Stopwatch timer)
    {
        timer.Stop();
        Console.WriteLine($"Time taken: {timer.Elapsed.TotalMilliseconds} milliseconds");
    }

}
