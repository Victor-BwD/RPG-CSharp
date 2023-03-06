namespace GameRPG;

public class WeaponManager
{
    public List<Weapon> Weapons { get; }

    public WeaponManager()
    {
        Weapons = new List<Weapon>();
        Weapons.Add(new Sword("Sword", 4, 6));
        // Adicione mais armas aqui
    }
}