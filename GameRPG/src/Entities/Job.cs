namespace GameRPG;

public interface IJob
{
    string JobName { get; }
    int Hp { get; }
    int Dodge { get; }
    int Iniciative { get; }
    public void Attack(Monster monster);

    public int GetIniciative();
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
            }, new Sword("Long Sword", 3, 6)),
            "mage" => new Mage(status, new Build()
            {
                AttackPerStrength = 1.0f,
                AttackPerDex = 1.5f,
                AttackPerIntelligence = 2.0f
            }, new Staff("Simple Staff", 1, 3)),
            "rogue" => new Rogue(status, new Build()
            {
                AttackPerStrength = 1.5f,
                AttackPerDex = 2.0f,
                AttackPerIntelligence = 1.0f
            }, new Dagger("Simple Dagger", 2, 4)),
            _ => null
        };
    }
}

public class Warrior: IJob
{
    private Status _status;
    private Build _build;
    private Sword _weapon; 

    public Warrior(Status status, Build build, Sword weapon)
    {
        _status = status;
        _build = build;
        _weapon = weapon;
    }
    
    public string JobName => "Warrior";

    public int Hp => 18;

    public int StrengthMultiplier()
    {
        return Convert.ToInt32(_status.GetStrength() + _build.AttackPerStrength);
    }

    public void Attack(Monster monster)
    {
        var damage = _weapon.CalculateDamage() + StrengthMultiplier();
        monster.ReceiveDamage(damage);
        Console.WriteLine($"You attack with your {_weapon.Name}");
        Console.WriteLine($"The enemy receive {damage} damage");
    }

    public int GetIniciative()
    {
        var rand = new Random();
        var d20 = rand.Next(1, 20);
        return _status.GetDexModifier() + d20;
    }

    public int Dodge => 5;

    public int Iniciative => GetIniciative();
}

public class Mage: IJob
{
    
    private Status _status;
    private Build _build;
    private Staff _weapon; 

    public Mage(Status status, Build build, Staff weapon)
    {
        _status = status;
        _build = build;
        _weapon = weapon;
    }
    public string JobName => "Wizard";

    public int Hp => 12;

    public int StatusMultiplier()
    {
        return Convert.ToInt32(_status.GetIntelligence() + _build.AttackPerIntelligence);
    }

    public int Dodge => 7;

    public int Iniciative => GetIniciative();

    public void Attack(Monster monster)
    {
        var damage = _weapon.CalculateDamage() + StatusMultiplier();
        Console.WriteLine($"You attacked with your weapon and cause {damage}");
        monster.ReceiveDamage(damage);
    }

    public readonly List<ISpell> Spells = new List<ISpell> { new Fireball(), new Lightning() };
    
    public void CastSpell(string spellName, Monster monster)
    {
        var spell = Spells.FirstOrDefault(x => x.Name.Equals(spellName, StringComparison.OrdinalIgnoreCase));

        if (spell == null)
        {
            Console.WriteLine($"You don't know the spell '{spellName}'");
            return;
        }

        spell.Cast(monster);
    }

    public int GetIniciative()
    {
        var rand = new Random();
        var d20 = rand.Next(1, 20);
        return _status.GetDexModifier() + d20;
    }
}

public class Rogue: IJob
{
    private Status _status;
    private Build _build;
    private Dagger _weapon;

    public Rogue(Status status, Build build, Dagger weapon)
    {
        _status = status;
        _build = build;
        _weapon = weapon;
    }
    public string JobName => "Rogue";

    public int Hp => 15;

    public int StatusMultiplier()
    {
        return Convert.ToInt32(_status.GetIntelligence() + _build.AttackPerDex);
    }

    public int Dodge => 9;

    public int Iniciative => GetIniciative();

    public void Attack(Monster monster)
    {
        var damage = _weapon.CalculateDamage() + StatusMultiplier();
        monster.ReceiveDamage(damage);
    }

    public int GetIniciative()
    {
        var rand = new Random();
        var d20 = rand.Next(1, 20);
        return _status.GetDexModifier() + d20;
    }

    private void Hide()
    {
        
    }
 }