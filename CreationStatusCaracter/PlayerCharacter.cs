namespace CreationStatusCaracter;

public class PlayerCharacter
{
    public string Name { get; private set; }
    public int hp { get; private set; }
    private Job job;
    private Status status;
    

    public PlayerCharacter(string name, Job job, Status status)
    {
        this.Name = name;
        this.job = job;
        this.status = status;
    }

    public string JobName => job.JobName;
    public int HpMax => job.Hp;
}