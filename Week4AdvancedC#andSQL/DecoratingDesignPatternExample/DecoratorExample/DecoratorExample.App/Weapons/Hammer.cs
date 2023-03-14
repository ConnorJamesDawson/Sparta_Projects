using System.Xml.Linq;

namespace DecoratorExample.App.Weapons
{
    public class Hammer : Weapon
    {
        public Hammer(string name = "hammer")
        {
            _name = name;
            _description = $"This hammer has {Attack()} attack and has the following enchantments applied to it: ";
        }
        public override int Attack()
        {
            return 10;
        }
    }
}
