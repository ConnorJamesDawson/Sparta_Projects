using DecoratorExample.App.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorExample.App.Enchantments
{
    public class Enchantment : Weapon
    {

        protected Weapon _weapon;

        public Enchantment(Weapon weaponToBuff)
        {
            _weapon = weaponToBuff;
        }

        public override int Attack()
        {
            return _weapon.Attack();
        }

        public override string? Descritption()
        {
            return $"{_weapon.Descritption()}";
        }
    }
}
