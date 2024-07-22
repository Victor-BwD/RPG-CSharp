using TreinarRPG.src.Entities;

namespace GameRPG;

public class CreationCharacter
{
    private readonly List<int> _statsNumbers = new () { 15, 12, 10, 8 };
    private readonly List<string> _jobs = new() { "warrior", "mage", "rogue" };

    public void CreateCharacter()
    {
        Console.WriteLine("----------- Welcome to my RPG made entirely in pure C# -----------");
        Console.WriteLine("Let's make create your character in a RPG game");

        Console.WriteLine();
        Thread.Sleep(1000);
        Console.WriteLine("""
            You are an adventurer in search of treasure and glory. 
            One day, you hear rumors of a mysterious cave hidden in a nearby forest. 
            They say that there is a valuable treasure hidden inside, but the cave is infested with dangerous monsters. 
            You decide to venture into the cave to see if the rumors are true.
            """);
        Console.WriteLine();
        Thread.Sleep(1000);


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

        StartCampaign startCampaign = new StartCampaign(playerCharacter, job);
        startCampaign.StartGame();
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
        ShowValidStats();

        do
        {
            Console.Write("Strength: ");
            status.SetStrength(int.Parse(Console.ReadLine()));
        } while (!_statsNumbers.Contains(status.GetStrength()));

        _statsNumbers.Remove(status.GetStrength());
        ShowValidStats();

        do
        {
            Console.Write("Dexterity: ");
            status.SetDexterity(int.Parse(Console.ReadLine()));
        } while (!_statsNumbers.Contains(status.GetDex()));

        _statsNumbers.Remove(status.GetDex());
        ShowValidStats();

        do
        {
            Console.Write("Intelligence: ");
            status.SetIntelligence(int.Parse(Console.ReadLine()));
        } while (!_statsNumbers.Contains(status.GetIntelligence()));
        
        _statsNumbers.Remove(status.GetIntelligence());
        ShowValidStats();

        do
        {
            Console.Write("Charisma: ");
            status.SetCharisma(int.Parse(Console.ReadLine()));
        } while (!_statsNumbers.Contains(status.GetCharisma()));
    }

    private void ClassChoosed(IJob job)
    {
        Console.WriteLine($"You are a {job.JobName}, with {job.Hp} Max Hp and you capacity to dodge attack is {job.Dodge}");
        Thread.Sleep(2000);
    }

    private void ShowValidStats()
    {
        Console.WriteLine("You have the following attributes to distribute among your stats: ");
        string numbersString = string.Join(", ", _statsNumbers);
        Console.WriteLine(numbersString);
    }
}