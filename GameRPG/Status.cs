namespace GameRPG;

public class Status
{
    private int strength { get; set; }
    private int dexterity { get; set; }
    private int intelligence { get; set; }
    private int charisma { get; set; }
    
    public void SetStrength(int strength)
    {
        this.strength = strength;
    }

    public int GetStrength()
    {
        return strength;
    }

    public void SetDexterity(int dexterity)
    {
        this.dexterity = dexterity;
    }
    
    public int GetDex()
    {
        return dexterity;
    }

    public void SetIntelligence(int intelligence)
    {
        this.intelligence = intelligence;
    }
    
    public int GetIntelligence()
    {
        return intelligence;
    }
    
    public void SetCharisma(int charisma)
    {
        this.charisma = charisma;
    }
    
    public int GetCharisma()
    {
        return charisma;
    }
}