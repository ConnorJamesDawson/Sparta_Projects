using FactoryMethodExample.DrinkShop;


namespace FactoryMethodExample.Beverages
{
    internal class Americano : Beverage
    {
        public override string Name => "Americano";

        public override void Prepare()
        {
            Console.WriteLine("Pressed the Americano button..chug chug chug gurgle!");
        }

        public override void Serve()
        {
            Console.WriteLine("Pass the mug of Americano to the customer!");
        }
    }
}
