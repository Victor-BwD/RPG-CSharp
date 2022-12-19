namespace CreationStatusCaracter;

public class MonsterAttack
{
    private static Random rnd = new Random();
    
    public static int GoblinAttack()
    {
        return rnd.Next(2, 4);
    }
}