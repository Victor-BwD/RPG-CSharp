namespace CreationStatusCaracter;

public interface IEnemies
{
    string EnemyName { get; }
    
    int Damage { get; }
    
    int Hp { get; }
    
    int Armor { get; }
}

public class Goblin : IEnemies
{
    public string EnemyName => "Goblin";
    public int Damage => 2;
    public int Hp => 5;
    public int Armor => 1;
}