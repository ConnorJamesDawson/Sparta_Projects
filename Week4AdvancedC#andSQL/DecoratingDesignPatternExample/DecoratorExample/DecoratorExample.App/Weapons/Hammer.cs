namespace DecoratorExample.App.Weapons
{
    public class Hammer : Weapon
    {
        public Hammer()
        {
            _description = "This hammer has applied to it: ";
        }
        public override int Attack()
        {
            return 10;
        }
    }
}
