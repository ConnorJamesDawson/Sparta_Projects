using SafariPark.App.Interfaces;

namespace SafariPark.App;

internal class Hunter : Person , IShootable
{

    IShootable Shooter { get; set; }

    public Hunter() : base ()
    {

    }

    public Hunter(string firstName, string lastName, IShootable shooter) : base (firstName, lastName)
    {
        Shooter = shooter;
    }

    public string Shoot(string target)
    {
        return $"{GetFullName} has taken a shot with their {Shooter.Shoot()}, They took a shot at {target}";
    }



    public override string ToString() //This override appends onto the parents override so you can build a specialised string for each child by calling base.ToString()
    {
        if (Shooter != null)
        {
            return $"{base.ToString()} has a {Shooter}";
        }
        else return $"{base.ToString()}";
    }
}
