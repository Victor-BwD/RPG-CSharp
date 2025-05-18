namespace GameRPG;

public interface ISpell
{
    string Name { get; }
    void Cast(Monster monster);
}

public class Fireball : ISpell
{
    private static readonly Random _rng = new();
    public string Name => "Fireball";

    public void Cast(Monster monster)
    {
        var roll = _rng.Next(1, 21);
        if (roll > monster.Dodge)
        {
            var damage = _rng.Next(16, 20);
            Console.WriteLine($"You attack with {Name} and cause {damage} of damage");
            monster.ReceiveDamage(damage);
        }
        else
        {
            Console.WriteLine("The monster managed to dodge.");
        }
    }
}

public class Lightning : ISpell
{
    private static readonly Random _rng = new();
    public string Name => "Lightning";

    public void Cast(Monster monster)
    {
        var roll = _rng.Next(1, 21);
        if (roll > monster.Dodge)
        {
            var damage = _rng.Next(14, 18);
            Console.WriteLine($"You attack with {Name} and cause {damage} of damage");
            monster.ReceiveDamage(damage);
        }
        else
        {
            Console.WriteLine("The monster managed to dodge.");
        }
    }
}
