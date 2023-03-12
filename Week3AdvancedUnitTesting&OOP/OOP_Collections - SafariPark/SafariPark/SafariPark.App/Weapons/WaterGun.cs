namespace SafariPark.App;

internal class WaterGun : Weapon
{
    public WaterGun(string brand) : base(brand)
    {

    }

    public override string Shoot(string target)
    {
        return $"{base.Shoot(target)} water gun Swish!!!";
    }
}
