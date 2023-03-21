namespace GameRPG;

public abstract class Monster
{
    public string Name { get; protected set; }
    public int Level { get; protected set; }
    public int HealthPoints { get; protected set; }
    public int AttackPower { get; protected set; }
    
    public int Dodge { get; protected set; }

    public Monster(string name, int level, int healthPoints, int attackPower, int dodge)
    {
        Name = name;
        Level = level;
        HealthPoints = healthPoints;
        AttackPower = attackPower;
        Dodge = dodge;
    }
    
    public virtual void Attack(PlayerCharacter player)
    {
        // Implementação do ataque do monstro ao jogador
    }
    
    public virtual void ReceiveDamage(int damage)
    {
        // Implementação do recebimento de dano pelo monstro
    }
}

public class Goblin : Monster
{
    public Goblin() : base("Goblin", 1, 10, 2, 3)
    {
        
    }
    
    public override void Attack(PlayerCharacter player)
    {
        var damage = new Random().Next(1, 3);
        player.Hp -= damage;
    }
    
    public override void ReceiveDamage(int damage)
    {
        HealthPoints -= damage;
    }
}

public class Minotaur : Monster
{
    public Minotaur() : base("Minotaur", 2, 13, 4, 4)
    {
    }
    
    public override void Attack(PlayerCharacter player)
    {
        base.Attack(player);
        // Implementação específica do ataque do Goblin ao jogador
    }
    
    public override void ReceiveDamage(int damage)
    {
        base.ReceiveDamage(damage);
        // Implementação específica do recebimento de dano pelo Goblin
    }
}

public class Vampire : Monster
{
    public Vampire() : base("Vampire", 3, 16, 5, 7)
    {
    }
    
    public override void Attack(PlayerCharacter player)
    {
        base.Attack(player);
        // Implementação específica do ataque do Goblin ao jogador
    }
    
    public override void ReceiveDamage(int damage)
    {
        base.ReceiveDamage(damage);
        // Implementação específica do recebimento de dano pelo Goblin
    }
}