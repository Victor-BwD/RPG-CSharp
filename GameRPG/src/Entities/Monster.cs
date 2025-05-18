namespace GameRPG;

public abstract class Monster
{
    public string Name { get; protected set; }
    public int Level { get; protected set; }
    public int HealthPoints { get; protected set; }
    public int AttackPower { get; protected set; }
    
    public int Dodge { get; protected set; }
    public int Iniciative { get; protected set; }
    public int XPReward { get; protected set; }

    public Monster(string name, int level, int healthPoints, int attackPower, int dodge, int xpReward)
    {
        Name = name;
        Level = level;
        HealthPoints = healthPoints;
        AttackPower = attackPower;
        Dodge = dodge;
        XPReward = xpReward;
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
    private static readonly Random _rng = new();
    public int PowerAttack { get; protected set; }
    public int Damage { get; protected set; }

    public Goblin() : base("Goblin", 1, 50, 2, 3, 50)
    {
        PowerAttack = 2;
        Iniciative = 4;
    }
    
    public override void Attack(PlayerCharacter player)
    {

        var attackRoll = _rng.Next(1, 21);
        if (attackRoll <= player.Dodge)
        {
            Console.WriteLine("You dodge the attack.");
            return;
        }

        Damage = _rng.Next(1, 3) + PowerAttack;
        player.TakeDamage(Damage);
        Console.WriteLine("You failed to dodge the enemy's attack.");
        Console.WriteLine($"{player.PlayerName} lost {Damage} health points");
    }
    
    public override void ReceiveDamage(int damage)
    {
        HealthPoints -= damage;
    }
}

public class Minotaur : Monster
{
    private static readonly Random _rng = new();
    public int PowerAttack { get; protected set; }
    public int Damage { get; protected set; }
    
    public Minotaur() : base("Minotaur", 2, 150, 4, 4, 150)
    {
        PowerAttack = 4;
        Iniciative = 5;
    }
    
    public override void Attack(PlayerCharacter player)
    {
        var attackRoll = _rng.Next(1, 21);
        if (attackRoll <= player.Dodge)
        {
            Console.WriteLine("You dodge the attack.");
            return;
        }

        Damage = _rng.Next(1, 3) + PowerAttack;
        player.TakeDamage(Damage);
        Console.WriteLine("You failed to dodge the enemy's attack.");
        Console.WriteLine($"{player.PlayerName} lost {Damage} health points");
    }
    
    public override void ReceiveDamage(int damage)
    {
        HealthPoints -= damage;
    }
}

public class Vampire : Monster
{
    private static readonly Random _rng = new();
    public int PowerAttack { get; protected set; }
    public int Damage { get; protected set; }
    
    public Vampire() : base("Vampire", 3, 250, 5, 7, 300)
    {
        PowerAttack = 5;
        Iniciative = 7;
    }
    
    public override void Attack(PlayerCharacter player)
    {
        var attackRoll = _rng.Next(1, 21); 
        if (attackRoll <= player.Dodge)
        {
            Console.WriteLine("You dodge the attack.");
            return;
        }

        Damage = _rng.Next(1, 6) + PowerAttack;
        player.TakeDamage(Damage);
        Console.WriteLine("You failed to dodge the enemy's attack.");
        Console.WriteLine($"{player.PlayerName} lost {Damage} health points");
    }
    
    public override void ReceiveDamage(int damage)
    {
        HealthPoints -= damage;
    }
}