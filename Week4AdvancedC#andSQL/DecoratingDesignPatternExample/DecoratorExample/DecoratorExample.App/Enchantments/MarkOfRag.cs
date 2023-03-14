using DecoratorExample.App.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorExample.App.Enchantments
{
    public class MarkOfRag : Enchantment
    {
        public MarkOfRag(Weapon weaponToBuff) : base(weaponToBuff)
        {
        }

        public override int Attack()
        {
            return base.Attack() + 120;
        }

        public override string? Descritption()
        {
            return base.Descritption() + ", The MarkOfRag(+120)";
        }
    }
}
