namespace GameRPG;

public interface ISpell
{
    string Name { get; }
    void Cast(Monster monster);
}

public class Fireball : ISpell
{
    public string Name => "Fireball";
    public void Cast(Monster monster)
    {
        var rng = new Random().Next(1, 20);
        if (rng > monster.Dodge)
        {
            var damage = new Random().Next(16, 19);
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
    public string Name => "Lightning";
    public void Cast(Monster monster)
    {
        var rng = new Random().Next(1, 20);
        if (rng > monster.Dodge)
        {
            var damage = new Random().Next(14, 18);
            Console.WriteLine($"You attack with {Name} and cause {damage} of damage");
            monster.ReceiveDamage(damage);
        }
        else
        {
            Console.WriteLine("The monster managed to dodge.");
        }
    }
}