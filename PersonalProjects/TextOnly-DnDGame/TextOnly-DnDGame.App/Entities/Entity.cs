namespace TextOnly_DnDGame.App.Entities;
public enum TargetAlive
{
    Alive,
    Dead
}
public abstract class Entity : IEquatable<Entity?>
{
    public string Name { get; init; }
    public int Health { get; private set; }
    public int Attack { get; private set; }
    public int Armour { get; private set; }
    public int Speed { get; private set; }

    public Entity(string name = " ", int health = 0, int attack = 0, int armour = 0, int speed = 0)
    {
        Name = name;
        Health = health;
        Attack = attack;
        Armour = armour;
        Speed = speed;
    }

    public TargetAlive AttackTarget(Entity target)
    {
        Console.WriteLine($"{this.Name} attacked {target.Name}");
        target.Health -= Attack;
        Console.WriteLine($"{target.Name} has {target.Health} health left");
        if (target.Health <= 0)
        {
            Console.WriteLine($"{target.Name} has died!");
            return TargetAlive.Dead;
        }
        return TargetAlive.Alive;
    }

    public override string? ToString()
    {
        return $"{Name}";
    }

    public override bool Equals(object? obj)
    {
        return Equals(obj as Entity);
    }

    public bool Equals(Entity? other)
    {
        return other is not null &&
               Name == other.Name &&
               Health == other.Health &&
               Attack == other.Attack &&
               Armour == other.Armour &&
               Speed == other.Speed;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Name, Health, Attack, Armour, Speed);
    }

    public static bool operator ==(Entity? left, Entity? right)
    {
        return EqualityComparer<Entity>.Default.Equals(left, right);
    }

    public static bool operator !=(Entity? left, Entity? right)
    {
        return !(left == right);
    }
}
