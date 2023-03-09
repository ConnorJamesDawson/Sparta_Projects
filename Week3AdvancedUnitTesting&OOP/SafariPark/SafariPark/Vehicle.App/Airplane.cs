using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vehicle.App
{
    public class Airplane : Vehicle
    {
        private readonly string _airline;

        public Airplane(int capacity) : base (capacity)
        {
            Capacity = capacity;
        }

        public Airplane(int capacity = 0, int numPassengers = 0, int speed = 0, string airline = "") : base (capacity, speed)
        {
            Capacity = capacity;
            NumPassengers = numPassengers;
            Speed = speed;
            _airline = airline;
        }

        public int Altitude{get; private set;}
        public int Capacity{get; init;}


        public override string Move()
        {
            return $"Moving along at an altitude of {Altitude} meters";
        }

        public override string Move(int times)
        {
            return $"Moving along {times} times at an altitude of {Altitude} meters";
        }

        public override string ToString()
        {
            return $"Thank you for flying {_airline}: {base.ToString()} altitude: {Altitude}";
        }

        public void Ascend(int distance)
        {
            Altitude += distance;
        }

        public void Descend(int distance)
        {
            if (Altitude - distance < 0) throw new ArgumentOutOfRangeException("You cannot go below 0 altitude without crashing, that's not allowed!");
            Altitude -= distance;
        }
    }
}