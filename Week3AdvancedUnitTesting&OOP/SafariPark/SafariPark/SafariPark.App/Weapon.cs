namespace SafariPark.App
{
    internal abstract class Weapon : IShootable
    {
        private string _brand;

        public Weapon(string brand)
        {
            _brand = brand;
        }

        public virtual string Shoot()
        {
            return $"{_brand}";
        }
    }
}
