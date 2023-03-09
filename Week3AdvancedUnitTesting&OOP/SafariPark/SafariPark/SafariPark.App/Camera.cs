namespace SafariPark.App
{
    internal class Camera : IShootable
    {
        private string _brand;
        public string Shoot()
        {
            return $"thier camera, it's an {_brand}";
        }

        public Camera (string cameraBrand)
        {
            _brand = cameraBrand;
        }

        public override string ToString()
        {
            return _brand;
        }
    }
}
