namespace GameRPG;

public class PlayerCharacter
{
    private string _name;
    private Status _stats;
    private readonly IJob _job;

    private static int _level;
    
    public PlayerCharacter(string name, IJob job, Status stats)
    {
        _name = name;
        _stats = stats;
        _job = job;
    }

    private int actualHp;

    public string JobName => _job.JobName;
    public int Hp
    {
        get => _job.Hp;
        set => actualHp = value;
    }
    public int Dodge => _job.Dodge;

    public string DisplayCharacterInfo()
    {
        return $"Name: {_name}, strength: {_stats.GetStrength()}, dexterity: {_stats.GetDex()}, intelligence: {_stats.GetIntelligence()}, charisma: {_stats.GetCharisma()}. Your character is lvl {_level}.";
    }

    public static void SetLevel(int level)
    {
        _level = level;
    }
}