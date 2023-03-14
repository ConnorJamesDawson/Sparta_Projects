using DecoratorExample.App.Enchantments;
using DecoratorExample.App.Weapons;

namespace DecoratorExample.App
{
    internal class Program
    {
        static bool debug = true;
        static bool quit = true;
        static void Main(string[] args)
        {

            Input input = new();
            while(!quit)
            {
                Console.WriteLine("Hello, welcome to the Forge, do you want to create a weapon or an enhantment?");

                switch(Console.ReadLine().ToLower().Trim())
                {
                    case "weapon":
                        input.HandleWeaponClassInput(input.ReadInputForWeaponClass());
                        break;
                    case "enchantment":
                    case "enchant":
                        input.HandleEnchantmentClassInput(input.ReadInputForEnchantClass());
                        break;
                }
            }
            Weapon[] enchantArray = { new MarkOfRag(), new Beserk(), new MarkOfRag()};
            Hammer hammer = new Hammer("The Lights Favour");
            int count = enchantArray.Length - 1;
            Console.WriteLine(RecursivlyAddEnchants(enchantArray, hammer, count));
        }


        public static void isDebuggable(string message)
        {
            if(debug) Console.WriteLine(message);
        }


        public static int RecursivlyAddEnchants(Weapon[] enchantArray, Weapon weapon, int count)
        {
            if (count < 0) return 0;

            RecursivlyAddEnchants(enchantArray, weapon, count - 1);

            return weapon.Attack() + enchantArray[count].Attack();
        }

        /*  Weapon hammer = new Hammer();

            Console.WriteLine($"{hammer.Attack()} {hammer.Descritption()}");

            Weapon markOfRagHammer = new MarkOfRag();

            Console.WriteLine($"{markOfRagHammer.Attack()} {markOfRagHammer.Descritption()}");

            Weapon beserkMarkOfRagHammer = new Beserk(new MarkOfRag(new Hammer()));

            Console.WriteLine($"{beserkMarkOfRagHammer.Attack()} {beserkMarkOfRagHammer.Descritption()}");*/
    }
}