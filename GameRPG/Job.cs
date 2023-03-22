namespace GameRPG;

public interface IJob
{
    string JobName { get; }
    int Hp { get; }
    int Dodge { get; }

    static IJob? Create(string name, Status status)
    {
        if (ReferenceEquals(name, null)) return null;
        return name.Trim().ToLower() switch
        {
            "warrior" => new Warrior(status, new Build()
            {
                AttackPerStrength = 2.0f,
                AttackPerDex = 1.5f,
                AttackPerIntelligence = 1.0f
            }),
            "mage" => new Mage(status, new Build()
            {
                AttackPerStrength = 1.0f,
                AttackPerDex = 1.5f,
                AttackPerIntelligence = 2.0f
            }),
            "rogue" => new Rogue(status, new Build()
            {
                AttackPerStrength = 1.5f,
                AttackPerDex = 2.0f,
                AttackPerIntelligence = 1.0f
            }),
            _ => null
        };
    }
}

public class Warrior: IJob
{
    private Status _status;
    private Build _build;

    public Warrior(Status status, Build build)
    {
        _status = status;
        _build = build;
    }
    
    public string JobName => "Warrior";

    public int Hp => 15;

    public int StrengthMultiplier()
    {
        return Convert.ToInt32(_status.GetStrength() * _build.AttackPerStrength);
    }

    public int Dodge => 3;
}

public class Mage: IJob
{
    
    private Status _status;
    private Build _build;

    public Mage(Status status, Build build)
    {
        _status = status;
        _build = build;
    }
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
    private Status _status;
    private Build _build;

    public Rogue(Status status, Build build)
    {
        _status = status;
        _build = build;
    }
    public string JobName => "Rogue";

    public int Hp => 8;

    public int StrengthMultiplier()
    {
        return 2;
    }

    public int Dodge => 8;
}