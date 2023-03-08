namespace GameRPG;

public class CreationCharacter
{
    private readonly List<int> _statsNumbers = new () { 15, 12, 10, 8 };

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

        var job = ChooseJob();

        DistributeStatus(out Status stats);

        PlayerCharacter playerCharacter = new PlayerCharacter(name, job, stats);
        var display = playerCharacter.DisplayCharacterInfo();
        ClassChoosed(job);
        Console.WriteLine(display);
    }

    private IJob ChooseJob()
    {
        IJob job;
        string input;
        
        do
        {
            Console.WriteLine("Choose between Warrior, Mage or Rogue: ");
            input = Console.ReadLine().ToLower().Trim();
            job = IJob.Create(input);
        } while (ReferenceEquals(job, null));
        
        PlayerCharacter.SetLevel(1);

        return job;
    }
    
    private void DistributeStatus(out Status stats)
    {
        stats = new Status();
        
        do
        {
            Console.Write("Strength: ");
            stats.Strength = int.Parse(Console.ReadLine());
        } while (!_statsNumbers.Contains(stats.Strength));

        _statsNumbers.Remove(stats.Strength);

        do
        {
            Console.Write("Dexterity: ");
            stats.Dexterity = int.Parse(Console.ReadLine());
        } while (!_statsNumbers.Contains(stats.Dexterity));

        _statsNumbers.Remove(stats.Dexterity);

        do
        {
            Console.Write("Intelligence: ");
            stats.Intelligence = int.Parse(Console.ReadLine());
        } while (!_statsNumbers.Contains(stats.Intelligence));
        
        _statsNumbers.Remove(stats.Intelligence);

        do
        {
            Console.Write("Charisma: ");
            stats.Charisma = int.Parse(Console.ReadLine());
        } while (!_statsNumbers.Contains(stats.Charisma));
    }

    private void ClassChoosed(IJob job)
    {
        Console.WriteLine($"You are a {job.JobName}, with {job.Hp} Max Hp and you capacity to dodge attack is {job.Dodge}");
    }
}