using SafariPark.App.Interfaces;

namespace SafariPark.App;

public class Person : IMovable, IEquatable<Person?>, IComparable<Person?>
{
    private int _age;

    public string FirstName{ get; init;} = "";

    public string LastName { get; init;} = "";

    public string MiddleName{ get; init;} = "Smith";

    public int Age 
    {
        get
        {
            return _age;
        } 
        set
        {
            if (value < 0)
            {
                throw new ArgumentException($"Please add an appropriate age for {FirstName}");
            }
            _age = value;
        }
    }
    public string GetFullName => $"{FirstName} {LastName}";

    public Person(string firstName = "", string lastName = "", int age = 0)
    {
        FirstName = firstName;

        LastName = lastName;

        Age = age;
    }
    public override string ToString() //Override looks for the virtual methods found in the parent Person
    {
        return $"Name: {GetFullName} Age: {Age}";
    }

    public string Move()
    {
        return $"{GetFullName} is Moving along";

    }

    public string Move(int times)
    {
        return $"{GetFullName} is Moving along {times} times";
    }

    public override bool Equals(object? obj)
    {
        return Equals(obj as Person);
    }

    public bool Equals(Person? other)
    {
        return other is not null &&
               _age == other._age &&
               FirstName == other.FirstName &&
               LastName == other.LastName &&
               MiddleName == other.MiddleName &&
               Age == other.Age &&
               GetFullName == other.GetFullName;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(_age, FirstName, LastName, MiddleName, Age, GetFullName);
    }

    public int CompareTo(Person? other) 
    {
        if (other == null) return 1;
        // This will sort by lowest value goes first, 1,2,3 a,b,c
/*        if (LastName != other.LastName) 
        { 
            return this.LastName.CompareTo(other.LastName); 
        } 
        else if (FirstName != other.FirstName) 
        { 
            return FirstName.CompareTo(other.FirstName); 
        } 
        else 
        { 
            return Age.CompareTo(other.Age); 
        }*/
        if (LastName != other.LastName) //If you want the inverse, 3,2,1 just swap the comparison 
        {
            return other.LastName.CompareTo(LastName);
        }
        else if (FirstName != other.FirstName)
        {
            return other.FirstName.CompareTo(FirstName);
        }
        else
        {
            return other.Age.CompareTo(Age);
        }
    }

    public static bool operator ==(Person? left, Person? right)
    {
        return EqualityComparer<Person>.Default.Equals(left, right);
    }

    public static bool operator !=(Person? left, Person? right)
    {
        return !(left == right);
    }
}