using DecoratorExample.App.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorExample.App.Enchantments
{
    internal class Beserk : Enchantment
    {
        public Beserk(Weapon weaponToBuff) : base(weaponToBuff)
        {
        }

        public override int Attack()
        {
            return base.Attack() * 3;
        }

        public override string? Descritption()
        {
            return base.Descritption() + ", The MarkOfRag(*3)";
        }
    }
}
