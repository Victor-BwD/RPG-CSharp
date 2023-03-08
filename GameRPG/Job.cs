namespace GameRPG;

public interface IJob
{
    string JobName { get; }

    int Hp { get; }
    int StrengthMultiplier();
    
    int Dodge { get; }

    static IJob? Create(string name)
    {
        if (ReferenceEquals(name, null)) return null;
        return name.Trim().ToLower() switch
        {
            "warrior" => new Warrior(),
            "wizard" => new Wizard(),
            "rogue" => new Rogue(),
            _ => null
        };
    }
}

public class Warrior: IJob
{
    public string JobName => "Warrior";

    public int Hp => 15;

    public int StrengthMultiplier()
    {
        return 5;
    }

    public int Dodge => 3;
}

public class Wizard: IJob
{
    public string JobName => "Wizard";

    public int Hp => 6;

    public int StrengthMultiplier()
    {
        return 1;
    }

    public int Dodge => 6;
    
    private readonly List<ISpell> _spells = new List<ISpell> { new Fireball() };

    public void CastSpell(string spellName, Monster monster)
    {
        var spell = _spells.FirstOrDefault(x => x.Name.Equals(spellName, StringComparison.OrdinalIgnoreCase));

        if (spell == null)
        {
            Console.WriteLine($"You don't know the spell '{spellName}'");
            return;
        }

        spell.Cast(monster);
    }
}

public class Rogue: IJob
{
    public string JobName => "Rogue";

    public int Hp => 8;

    public int StrengthMultiplier()
    {
        return 2;
    }

    public int Dodge => 8;
}