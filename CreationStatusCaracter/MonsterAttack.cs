namespace CreationStatusCaracter;

public class MonsterAttack
{
    private  Random rnd = new Random();
    
    public int GoblinAttack()
    {
        Random hitRnd = new Random();
        var chance = hitRnd.Next(0, 1);
        if (chance == 1)
        {
            return rnd.Next(2, 4);
        }

        return 0;
    }
}