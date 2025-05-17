namespace GameRPG;

public class PlayerCharacter
{
    private string _name;
    private Status _stats;
    private int _xp;
    private readonly IJob _job;
    private int _dodge;


    private static int _level;
    
    public PlayerCharacter(string name, IJob job, Status stats)
    {
        _name = name;
        _stats = stats;
        _job = job;
        _dodge = job.Dodge;
    }

    public int ActualHp;

    public string PlayerName => _name;

    public string JobName => _job.JobName;
    public int Hp
    {
        get => _job.Hp;

       
        set => ActualHp = value;
    }
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
        if (ActualHp + amount > _job.Hp)
        {
            ActualHp = _job.Hp;
        }
        else
        {
            ActualHp += amount;
        }
    }


    public string DisplayLevel()
    {
        return $"Level: {_level}";
    }

    public void IncreaseXP(int xp)
    {
        _xp += xp;
        if (_level == 1 && _xp >= 200)
        {
            Console.WriteLine("You leveled up!");
            SetLevel(2);
        }

        if (_level == 2 && _xp >= 500)
        {
            SetLevel(3);
        }
    }

    public static void SetLevel(int level)
    {
        _level = level;
    }

    public void SetHp()
    {
        ActualHp = Hp;
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
}