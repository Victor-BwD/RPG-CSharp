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

    public int GetStrenghModifier()
    {
        if (strength > 12) return 3;

        if(strength == 12) return 2;

        if (strength == 10) return 1;

        if (strength == 8) return 0;

        return 0;
    }

    public int GetDexModifier()
    {
        if (dexterity > 12) return 3;

        if (dexterity == 12) return 2;

        if (dexterity == 10) return 1;

        if (dexterity == 8) return 0;

        return 0;
    }

    public int GetIntModifier()
    {
        if (intelligence > 12) return 3;

        if (intelligence == 12) return 2;

        if (intelligence == 10) return 1;

        if (intelligence == 8) return 0;

        return 0;
    }

    public int GetCharismaModifier()
    {
        if (charisma > 12) return 3;

        if (charisma == 12) return 2;

        if (charisma == 10) return 1;

        if (charisma == 8) return 0;

        return 0;
    }
}