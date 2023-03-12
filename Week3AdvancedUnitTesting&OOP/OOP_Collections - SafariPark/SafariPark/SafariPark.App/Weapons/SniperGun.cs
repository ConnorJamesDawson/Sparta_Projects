using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafariPark.App
{
    internal class SniperGun : Weapon
    {
        public SniperGun (string brand) : base(brand)
        {

        }

        public override string Shoot(string target)
        {
            string message = $"{base.Shoot(target)} sniper BANG!!!\n This person was arrested for bringing a sniper rifle to a kids laser quest party";
            return message;
        }
    }
}
