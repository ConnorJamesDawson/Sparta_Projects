using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DecoratorExample.App.Weapons
{
    public class Sword : Weapon
    {
        public Sword(string name = "sword")
        {
            _name = name;
            _description = $"This sword has {Attack()} attack and has the following enchantments applied to it: ";
        }

        public override int Attack()
        {
            return 15;
        }
    }
}
