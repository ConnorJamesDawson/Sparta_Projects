namespace SafariPark.App;

internal class Hunter : Person
{

    private string? _camera;

    public Hunter() : base ()
    {

    }

    public Hunter(string firstName, string lastName, string camera = "" ) : base (firstName, lastName)
    {
        _camera = camera;
    }

    public string Shoot()
    {
        return $"{GetFullName} has taken a photo with their {_camera}";
    }

    public override string ToString() //This override appends onto the parents override so you can build a specialised string for each child
    {
        return $"{base.ToString()} Camera: {_camera}";
    }
}
