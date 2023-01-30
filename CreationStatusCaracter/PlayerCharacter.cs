namespace CreationStatusCaracter;

public class PlayerCharacter
{
    public string Name { get; private set; }
    public int hp { get; private set; }
    private Job job;
    private Weapons weapon;
    private Status status;
    

    public PlayerCharacter(string name, Job job, Status status, Weapons weapon)
    {
        this.Name = name;
        this.job = job;
        this.status = status;
        this.weapon = weapon;
    }

    public string JobName => job.JobName;
    public int HpMax => job.Hp;

    public string WeaponName => weapon.WeaponName;
}