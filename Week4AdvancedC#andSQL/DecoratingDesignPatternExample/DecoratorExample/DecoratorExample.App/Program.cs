using DecoratorExample.App.Enchantments;
using DecoratorExample.App.Weapons;

namespace DecoratorExample.App
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            Weapon hammer = new Hammer();

            Console.WriteLine($"{hammer.Attack()} {hammer.Descritption()}");

            Weapon markOfRagHammer = new MarkOfRag(new Hammer());

            Console.WriteLine($"{markOfRagHammer.Attack()} {markOfRagHammer.Descritption()}");

            Weapon beserkMarkOfRagHammer = new Beserk(new MarkOfRag(new Hammer()));

            Console.WriteLine($"{beserkMarkOfRagHammer.Attack()} {beserkMarkOfRagHammer.Descritption()}");


        }
    }
}