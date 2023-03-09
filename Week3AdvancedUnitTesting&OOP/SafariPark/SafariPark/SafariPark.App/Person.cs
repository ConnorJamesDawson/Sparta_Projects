namespace SafariPark.App;

public class Person
{
    private string _occupation = "";
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
        //return $"{base.ToString()} Name: {GetFullName} Age: {Age}";
        return $"{base.ToString()}";
    }

}