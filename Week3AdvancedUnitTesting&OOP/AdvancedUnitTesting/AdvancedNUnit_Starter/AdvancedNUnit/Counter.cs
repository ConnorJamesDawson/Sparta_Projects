using System;

namespace AdvancedNUnit
{
    public class Counter
    {
        public int Count { get; private set; } //Properties
        public Counter(int start) { Count = start; } // Constructor
        //public void Increment() { Count++; }
        public void Increment() { Console.WriteLine($"Count was: {Count}"); Count++; Console.WriteLine($"Count is now: {Count}"); }
        public void Decrement() { Count--; }
    }
}
