namespace GameRPG;

public interface IEnemy
{
    public string Name { get; }
    public int Health { get; set; }
    public int Attack { get; }
    public void TakeDamage(int damage);
    public void AttackCharacter(int damage);
}