using System.Net;

namespace ClassesApp;

public class Address
{

    public int HouseNumber { get; set; }

    public string StreetName { get; set; }

    public string TownName { get; set; }

    public Address(int houseNumber, string streetName, string townName)
    {
        HouseNumber = houseNumber;
        StreetName = streetName;
        TownName = townName;
    }

    public override string ToString()
    {
        return $"Address: {HouseNumber} {StreetName}, {TownName}";
    }

}
