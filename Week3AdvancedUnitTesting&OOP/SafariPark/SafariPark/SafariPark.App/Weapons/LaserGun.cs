namespace SafariPark.App
{
    internal class LaserGun : Weapon
    {
        public LaserGun(string brand) : base(brand)
        {

        }

        public override string Shoot(string target)
        {
            return $"{base.Shoot(target)} laser gun Zing!!!";
        }

    }
}
