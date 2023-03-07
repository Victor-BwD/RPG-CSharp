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

    public string JobName => _job.JobName;
    public int HpMax => _job.Hp;
    public int Hp
    {
        get { return _job.Hp; }
        
    }
    public int Dodge => _job.Dodge;

    public string DisplayCharacterInfo()
    {
        return $"Name: {_name}, strength: {_stats.Strength}, dexterity: {_stats.Dexterity}, intelligence: {_stats.Intelligence}, charisma: {_stats.Intelligence}. Your character is lvl {_level}.";
    }

    public static void SetLevel(int level)
    {
        _level = level;
    }
}