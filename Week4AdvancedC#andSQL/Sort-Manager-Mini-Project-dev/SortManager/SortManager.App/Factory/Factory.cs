using SortManager.App.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortManager.App.Factory
{
    public static class Factory
    {
        public static AbstractSort CreateSortAlgorithm(string algorithmType)
        {
            algorithmType = algorithmType.ToLower();

            switch(algorithmType) 
            {
                case "1":
                    return new BubbleSort();
                case "2":
                    return new HeapSort();
                case "3":
                     return new MergeSort();
                case "4":
                    return new DotNetSort();
                case "5":
                    return new MaxRadix();
                case "6":
                    return new ShellSort();
                default:
                    throw new ArgumentException("Could not instantiate that type of sorting algorithm");
            }
        }
    }
}
