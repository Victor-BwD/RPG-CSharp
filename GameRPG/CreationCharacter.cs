namespace GameRPG;

public class CreationCharacter
{
    private readonly List<int> _statsNumbers = new () { 15, 12, 10, 8 };
    private readonly List<string> _jobs = new() { "warrior", "mage", "rogue" };

    public void CreateCharacter()
    {
        Console.WriteLine("----------- Welcome to my RPG made entirely in pure C# -----------");
        Console.WriteLine("Let's make create your character in a RPG game");
        Console.WriteLine("Your name: ");
        var name = Console.ReadLine().Trim();
        while (string.Equals(name, ""))
        {
            Console.WriteLine("Is not possible create a character with no name...");
            CreateCharacter();
        }

        var status = new Status();

        var job = ChooseJob(status);

        DistributeStatus(status);

        PlayerCharacter playerCharacter = new PlayerCharacter(name, job, status);
        var display = playerCharacter.DisplayCharacterInfo();
        ClassChoosed(job);
        Console.WriteLine(display);
    }

    private IJob ChooseJob(Status status)
    {
        IJob job;
        string input;
        
        do
        {
            Console.WriteLine("Choose between Warrior, Mage or Rogue: ");
            input = Console.ReadLine().ToLower().Trim();
            
            while (!_jobs.Contains(input)) // Não contém
            {
                Console.WriteLine("Choose between Warrior, Mage or Rogue: ");
                input = Console.ReadLine().ToLower().Trim();
            }
            
            job = IJob.Create(input, status);
        } while (ReferenceEquals(job, null));
        
        PlayerCharacter.SetLevel(1);

        return job;
    }
    
    private void DistributeStatus(Status status)
    {

        do
        {
            Console.Write("Strength: ");
            status.SetStrength(int.Parse(Console.ReadLine()));
        } while (!_statsNumbers.Contains(status.GetStrength()));

        _statsNumbers.Remove(status.GetStrength());

        do
        {
            Console.Write("Dexterity: ");
            status.SetDexterity(int.Parse(Console.ReadLine()));
        } while (!_statsNumbers.Contains(status.GetDex()));

        _statsNumbers.Remove(status.GetDex());

        do
        {
            Console.Write("Intelligence: ");
            status.SetIntelligence(int.Parse(Console.ReadLine()));
        } while (!_statsNumbers.Contains(status.GetIntelligence()));
        
        _statsNumbers.Remove(status.GetIntelligence());

        do
        {
            Console.Write("Charisma: ");
            status.SetCharisma(int.Parse(Console.ReadLine()));
        } while (!_statsNumbers.Contains(status.GetCharisma()));
    }

    private void ClassChoosed(IJob job)
    {
        Console.WriteLine($"You are a {job.JobName}, with {job.Hp} Max Hp and you capacity to dodge attack is {job.Dodge}");
    }
}