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

    public int Dodge => 4;
}

public class Rogue: IJob
{
    public string JobName => "Rogue";

    public int Hp => 8;

    public int StrengthMultiplier()
    {
        return 2;
    }

    public int Dodge => 6;
}