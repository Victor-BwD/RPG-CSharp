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
            var damage = new Random().Next(4, 8);
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
    public string Name { get; }
    public void Cast(Monster monster)
    {
        var rng = new Random().Next(1, 20);
        if (rng > monster.Dodge)
        {
            var damage = new Random().Next(2, 5);
            monster.ReceiveDamage(damage);
        }
        else
        {
            Console.WriteLine("The monster managed to dodge.");
        }
    }
}