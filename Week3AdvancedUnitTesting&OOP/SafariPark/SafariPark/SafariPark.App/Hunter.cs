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

    public string Shoot()
    {
        return $"{GetFullName} has taken a shot with their {Shooter.Shoot()}";
    }

    public override string ToString() //This override appends onto the parents override so you can build a specialised string for each child
    {
        return $"{base.ToString()} Shooter: {Shooter}";
    }
}
