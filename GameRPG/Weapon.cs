namespace GameRPG;

public abstract class Weapon
{
    public string Name { get; }
    public int MinDamage { get; }
    public int MaxDamage { get; }

    public Weapon(string name, int minDamage, int maxDamage)
    {
        Name = name;
        MinDamage = minDamage;
        MaxDamage = maxDamage;
    }

    public abstract int CalculateDamage();
}

public class Sword : Weapon
{
    private int _minDamage;
    private int _maxDamage;
    private string _name;
    
    public Sword(string name, int minDamage, int maxDamage) : base(name, minDamage, maxDamage)
    {
        _maxDamage = maxDamage;
        _minDamage = minDamage;
        _name = name;
    }
    
    public override int CalculateDamage()
    {
        return new Random().Next(_minDamage, _maxDamage);
    }
}

public class Staff : Weapon
{
    private int _minDamage;
    private int _maxDamage;
    private string _name;
    
    public Staff(string name, int minDamage, int maxDamage) : base(name, minDamage, maxDamage)
    {
        _maxDamage = maxDamage;
        _minDamage = minDamage;
        _name = name;
    }
    
    public override int CalculateDamage()
    {
        return new Random().Next(_minDamage, _maxDamage);
    }
}

public class Dagger : Weapon
{
    private int _minDamage;
    private int _maxDamage;
    private string _name;
    
    public Dagger(string name, int minDamage, int maxDamage) : base(name, minDamage, maxDamage)
    {
        _maxDamage = maxDamage;
        _minDamage = minDamage;
        _name = name;
    }
    
    public override int CalculateDamage()
    {
        return new Random().Next(_minDamage, _maxDamage);
    }
}