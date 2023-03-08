namespace GameRPG;

public abstract class Weapon
{
    public string Name { get; }
    public int MinDamage { get; }
    public int MaxDamage { get; }

    public Weapon(string name, int minDamage, int maxDamage)
    {
        Name = name;
        MinDamage = minDamage;
        MaxDamage = maxDamage;
    }

    public abstract void Attack(Monster target);
}

public class Sword : Weapon
{
    public Sword(string name, int minDamage, int maxDamage) : base(name, minDamage, maxDamage)
    {
    }

    public override void Attack(Monster target)
    {
        var rnd = new Random();
        int damage = rnd.Next(MinDamage, MaxDamage + 1);
        target.ReceiveDamage(damage);
        
    }
}