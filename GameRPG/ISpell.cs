namespace GameRPG;

public interface ISpell
{
    string Name { get; }
    void Cast(Monster monster);
}

public class Fireball : ISpell
{
    public string Name => "Fireball";
    public void Cast(Monster monster)
    {
        throw new NotImplementedException();
    }
}