namespace CreationStatusCaracter;

public interface Weapons
{
    string WeaponName { get; }
    
    int Damage { get; }

    int StatusMultiplier();

    static Weapons? Equip(string name)
    {
        if (ReferenceEquals(name, null)) return null;
        return name.Trim().ToLower() switch
        {
            "warrior" => new Sword(),
            "greatsword" => new Greatsword(),
            "rogue" => new Dagger(),
            "wizard" => new Staff(),
            _ => null
        };
    }
}

public class Sword : Weapons
{
    public string WeaponName => "Sword";

    public int Damage => 5;
    
    public int StatusMultiplier()
    {
        return 3;
    }
}

public class Greatsword : Weapons
{
    public string WeaponName => "Greatsword";

    public int Damage => 10;
    
    public int StatusMultiplier()
    {
        return 5;
    }
}

public class Dagger : Weapons
{
    public string WeaponName => "Dagger";

    public int Damage => 3;
    
    public int StatusMultiplier()
    {
        return 2;
    }
}

public class Staff : Weapons
{
    public string WeaponName => "Staff";

    public int Damage => 1;
    
    public int StatusMultiplier()
    {
        return 1;
    }
}