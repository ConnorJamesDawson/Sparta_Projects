namespace SafariPark.App
{
    internal class LaserGun : Weapon
    {
        public LaserGun(string brand) : base(brand)
        {

        }

        public override string Shoot()
        {
            return $"{base.Shoot()} laser gun Zing!!!";
        }

    }
}
