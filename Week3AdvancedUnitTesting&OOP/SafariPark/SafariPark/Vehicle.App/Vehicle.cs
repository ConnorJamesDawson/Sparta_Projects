﻿namespace Vehicle.App;

public class Vehicle
{
    private int _capacity;
    private int _numPassengers;

    public Vehicle(){ }

    public Vehicle(int capacity = 5, int speed = 10){ _capacity = capacity; Speed = speed;}

    public int NumPassengers
    {
        get { return _numPassengers; }

        set
        { 
            if(value <= _capacity && value >= 0)
            {
                _numPassengers = value;
            }
        }
    }

    public int Position{get; set;}

    public int Speed{get; init;} = 10;

    public string Move(int times)
    {
        Position = Speed * times;
        return $"Moving along {times} times";
    }

    public string Move()
    {
        Position = Speed;
        return $"Moving along";
    }
}