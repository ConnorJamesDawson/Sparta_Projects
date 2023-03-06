namespace OOPFundamentals;

public class Person
{
    private string _firstName;
    private string _lastName;
    public Person(string FName, string LName) // Constructor, this is called on 
    {
        _firstName = FName;
        _lastName = LName;
    }

    public string FirstName { get => _firstName; set => _firstName = value; } //These are properties
    public string LastName { get => _lastName; set => _lastName = value; }

    public virtual void Print()
    {
        Console.WriteLine($"First Name: {_firstName}, Last Name: {LastName}");
    }

}
