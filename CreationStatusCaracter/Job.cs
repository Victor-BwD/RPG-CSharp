namespace CreationStatusCaracter;

public interface Job
{
    string JobName { get; }

    int Hp { get; }
    int StrengthMultiplier();

    static Job? Create(string name)
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

public class Warrior: Job
{
    public string JobName => "Warrior";

    public int Hp => 15;

    public int StrengthMultiplier()
    {
        return 5;
    }
}

public class Wizard: Job
{
    public string JobName => "Wizard";

    public int Hp => 6;

    public int StrengthMultiplier()
    {
        return 1;
    }
}

public class Rogue: Job
{
    public string JobName => "Rogue";

    public int Hp => 8;

    public int StrengthMultiplier()
    {
        return 2;
    }
}