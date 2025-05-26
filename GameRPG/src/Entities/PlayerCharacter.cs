namespace GameRPG;

public class PlayerCharacter
{
    private string _name;
    private Status _stats;
    private int _xp;
    private readonly IJob _job;
    private int _dodge;

    public int MaxHp { get; private set; }

    private static int _level;
    
    public PlayerCharacter(string name, IJob job, Status stats)
    {
        _name = name;
        _stats = stats;
        _job = job;
        _dodge = job.Dodge;
        MaxHp = job.Hp;
    }

    public int ActualHp;

    public string PlayerName => _name;

    public string JobName => _job.JobName;

    public int Dodge
    {
        get => _dodge;
        set => _dodge = value;
   
    }

    public string DisplayCharacterInfo()
    {
        return $"Name: {_name}, strength: {_stats.GetStrength()}, dexterity: {_stats.GetDex()}, intelligence: {_stats.GetIntelligence()}, charisma: {_stats.GetCharisma()}. Your character is lvl {_level}.";
    }

    public void Heal(int amount)
    {
        ActualHp += amount;
        if (ActualHp > MaxHp)
            ActualHp = MaxHp;
    }


    public string DisplayLevel()
    {
        return $"Level: {_level}";
    }

    public void IncreaseXP(int xp)
    {
        _xp += xp;
        if (_level == 1 && _xp >= 100)
        {
            SetLevel(2);
            ApplyLevelUpBonus();
            Console.WriteLine("You leveled up to level 2!");
            Console.WriteLine($"New stats: Strength: {_stats.GetStrength()}, Dexterity: {_stats.GetDex()}, Intelligence: {_stats.GetIntelligence()}, Charisma: {_stats.GetCharisma()}");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        else if (_level == 2 && _xp >= 350)
        {
            SetLevel(3);
            ApplyLevelUpBonus();
            Console.WriteLine("You leveled up to level 3!");
            Console.WriteLine($"New stats: Strength: {_stats.GetStrength()}, Dexterity: {_stats.GetDex()}, Intelligence: {_stats.GetIntelligence()}, Charisma: {_stats.GetCharisma()}");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }

    private void ApplyLevelUpBonus()
    {
        switch (_job.JobName.ToLower())
        {
            case "warrior":
                _stats.SetStrength(_stats.GetStrength() + 2);
                MaxHp += 10;
                Console.WriteLine("You gained +2 Strength and +10 Max HP!");
                break;
            case "mage":
                _stats.SetIntelligence(_stats.GetIntelligence() + 2);
                MaxHp += 6;
                Console.WriteLine("You gained +2 Intelligence and +6 Max HP!");
                break;
            case "rogue":
                _stats.SetDexterity(_stats.GetDex() + 2);
                MaxHp += 8;
                Console.WriteLine("You gained +2 Dexterity and +8 Max HP!");
                break;
        }
    }

    public static void SetLevel(int level)
    {
        _level = level;
    }

    public void SetHp()
    {
        ActualHp = MaxHp;
    }
    
    public int IncreaseDodge(int amount)
    {
        return Dodge += amount;
    }

    public void TakeDamage(int amount)
    {
        ActualHp -= amount;
        if (ActualHp < 0)
            ActualHp = 0;
    }

    public void RestoreHp(int amount)
    {
        ActualHp += amount;
        if (ActualHp > MaxHp)
            ActualHp = MaxHp;
    }
}