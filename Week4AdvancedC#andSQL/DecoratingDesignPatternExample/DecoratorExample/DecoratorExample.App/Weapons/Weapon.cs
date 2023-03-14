using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorExample.App.Weapons
{
    public abstract class Weapon
    {
        protected string? _name = "A name hasn't been set yet";

        protected string? _description = "A desc hasn't been set yet";

        public virtual string? Descritption()
        {
            return _description;
        }

        public virtual string? Name()
        {
            return _name;
        }

        public abstract int Attack();

    }
}
