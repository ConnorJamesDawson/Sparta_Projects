namespace OOPFundamentals;

public  class Employee : Person
{
    private string _department;
    public Employee(string FName, string LName, string Department) : base(FName, LName)
    {
        _department = Department;
    }
    public string Department { get => _department; set => _department = value; }

    public override void Print()
    {
        base.Print();
        Console.WriteLine($"Department: {_department} ");
    }
}
