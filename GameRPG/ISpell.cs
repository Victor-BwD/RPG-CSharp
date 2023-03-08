namespace GameRPG;

public interface ISpell
{
    string Name { get; }
    void Cast(Monster monster);
}