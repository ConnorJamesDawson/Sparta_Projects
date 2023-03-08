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
}
