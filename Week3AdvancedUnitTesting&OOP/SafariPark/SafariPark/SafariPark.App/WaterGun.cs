namespace SafariPark.App;

internal class WaterGun : Weapon
{
    public WaterGun(string brand) : base(brand)
    {

    }

    public override string Shoot()
    {
        return $"{base.Shoot()} water gun Swish!!!";
    }
}
