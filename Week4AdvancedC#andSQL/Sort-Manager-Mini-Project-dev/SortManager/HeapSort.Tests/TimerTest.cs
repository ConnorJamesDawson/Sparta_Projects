using SortManager.App.Model;
using System.Diagnostics;

namespace TimerClassTest;

public class TimerTests
{

    [Test]
    public void StopTimerAndCalculateTime_ReturnsCurrentTimeinSecond()
    {
        Stopwatch timer = Stopwatch.StartNew();
        Thread.Sleep(10);
        timer.Stop();
        double timePassed = timer.Elapsed.TotalMilliseconds;
        Assert.That(timePassed, Is.EqualTo(timer.Elapsed.TotalMilliseconds));
    }

}