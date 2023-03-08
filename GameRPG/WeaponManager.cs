namespace GameRPG;

public class WeaponManager
{
    public List<Weapon> Weapons { get; }

    public WeaponManager()
    {
        Weapons = new List<Weapon>();
        Weapons.Add(new Sword("Sword", 4, 6));
        Weapons.Add(new Sword("Greatsword", 6, 8));
        // Adicione mais armas aqui
    }
}