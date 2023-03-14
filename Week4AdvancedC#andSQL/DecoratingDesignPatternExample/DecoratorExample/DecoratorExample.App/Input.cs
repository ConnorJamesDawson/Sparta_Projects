using DecoratorExample.App.Enchantments;
using DecoratorExample.App.Weapons;

namespace DecoratorExample.App;

public class Input
{
    public Weapon weaponToMake;
    public List<Weapon> listOfWeapons = new();
    public Enchantment enchantToMake;
    public List<Enchantment> listOfEnchantments = new();
    public string ReadInputForWeaponClass(bool readingForClass = true)
    {
        if (readingForClass)
        {
            Console.WriteLine("Please enter which class you want to make: hammer, axe or sword");
        }
        else
        {
            Console.WriteLine($"Please enter the name for the weapon");
        }
        return Console.ReadLine()!.ToLower();
    }

    public string ReadInputForEnchantClass()
    {

        Console.WriteLine("Please enter which class you want to make: MarkOfRag or Beserk");

        return Console.ReadLine()!.ToLower();
    }

    public void HandleWeaponClassInput(string input)
    {
        switch (input)
        {
            case "hammer":
                weaponToMake = new Hammer(ReadInputForWeaponClass(false));
                Program.isDebuggable($"added {weaponToMake.Name()}, {weaponToMake.Descritption()}");
                break;
            case "axe":
                weaponToMake = new Axe(ReadInputForWeaponClass(false));
                Program.isDebuggable($"added {weaponToMake.Name()}, {weaponToMake.Descritption()}");
                break;
            case "sword":
                weaponToMake = new Sword(ReadInputForWeaponClass(false));
                Program.isDebuggable($"added {weaponToMake.Name()}, {weaponToMake.Descritption()}");
                break;
            default:
                Console.WriteLine($"{input} is not a correct class name please input either a hammer, an axe or a sword");
                return;
        }
        listOfWeapons.Add(weaponToMake);
    }

    public void HandleEnchantmentClassInput(string input)
    {
        switch (input)
        {
            case "markofrag":
                enchantToMake = new MarkOfRag();
                Program.isDebuggable($"added {enchantToMake.Name()}, {enchantToMake.Descritption()}");
                break;
            case "beserk":
                enchantToMake = new Beserk();
                Program.isDebuggable($"added {enchantToMake.Name()}, {enchantToMake.Descritption()}");
                break;
            default:
                Console.WriteLine($"{input} is not a correct class name please input either a MarkOfRag or beserk");
                return;
        }
        listOfEnchantments.Add(enchantToMake);
    }

}
