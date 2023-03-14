using DecoratorExample.App.Weapons;
namespace DecoratorExample.App.Enchantments;

public class Enchantment : Weapon
{

    public Weapon weapon;

    public Enchantment(Weapon? weaponToBuff = null)
    {
        weapon = weaponToBuff;
    }

    public override int Attack()
    {
        if(weapon == null)
        {
            return 0;
        }
        else
        {
            return weapon.Attack();
        }
    }

    public override string? Descritption()
    {
        if (weapon == null)
            return $"{Name()} : This is an enchantment";
        else
        {
            return $"{weapon.Descritption()}";
        }
    }


}
