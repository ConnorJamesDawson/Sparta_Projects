namespace DecoratorExample.App.Weapons;

internal class Axe : Weapon
{
    public Axe(string name = "axe")
    {
        _name = name;
        _description = $"This axe has {Attack()} attack and has the following enchantments applied to it: ";
    }

    public override int Attack()
    {
        return 20;
    }

}
