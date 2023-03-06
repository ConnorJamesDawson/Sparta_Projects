namespace OOPFundamentals;

public class Customer : Person
{
    private string _delivaryAddress;
    public Customer(string FName, string LName, string DAddress) : base (FName, LName)
    {
        _delivaryAddress = DAddress;
    }

    public string DelivaryAddress { get => _delivaryAddress; set => _delivaryAddress = value; }

    public override void Print()
    {
        base.Print();
        Console.WriteLine($"Delivary Address: {_delivaryAddress} ");
    }
}
