using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortManager.App.Model;

public abstract class AbstractSort
{
    public int[] GetUnsortedArray {get; set;}
    public int[] GetArray {get; set;}

    public abstract int[] SortArray(int[] array);
}
