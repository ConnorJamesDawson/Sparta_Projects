namespace NorthwindData.App.Models;

public partial class Customer //Partial classes join when run
{

    public override string ToString()
    {
        return $"{CustomerId} - {ContactName} - {CompanyName} - {City}";
    }

}
