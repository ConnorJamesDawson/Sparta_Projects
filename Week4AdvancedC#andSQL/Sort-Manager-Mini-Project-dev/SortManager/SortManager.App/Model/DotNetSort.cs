using System.Diagnostics;
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortManager.App.Model;

public class DotNetSort : AbstractSort
{
    public override int[] SortArray(int[] array)
    {
        Stopwatch timer = TimerClass.StartTimer();

        Array.Sort(array);

        TimerClass.StopTimerAndReturnTime(timer);

        return array;
    }
}