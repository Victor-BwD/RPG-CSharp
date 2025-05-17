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

        string name;
        do
        {
            Console.WriteLine("Your name: ");
            name = Console.ReadLine().Trim();

            if (string.IsNullOrEmpty(name))
            Console.WriteLine("Is not possible create a character with no name...");
        } while (string.IsNullOrEmpty(name));

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
            
            while (!_jobs.Contains(input))
            {
                Console.WriteLine("Choose between Warrior, Mage or Rogue: ");
                input = Console.ReadLine().ToLower().Trim();
            }
            
            job = IJob.Create(input, status);
        } while (ReferenceEquals(job, null));
        
        PlayerCharacter.SetLevel(1);

        return job;
    }

    private int GetValidStat(string attributeName)
    {
        int value;
        do
        {
            Console.Write($"{attributeName}: ");
            if (int.TryParse(Console.ReadLine(), out value) && _statsNumbers.Contains(value))
            {
                _statsNumbers.Remove(value);
                return value;
            }

            Console.WriteLine("Invalid stat. Try again.");
        } while (true);
    }

    private void DistributeStatus(Status status)
    {
        ShowValidStats();

        status.SetStrength(GetValidStat("Strength"));
        status.SetDexterity(GetValidStat("Dexterity"));
        status.SetIntelligence(GetValidStat("Intelligence"));     
        status.SetCharisma(GetValidStat("Charisma"));

        _statsNumbers.Remove(status.GetIntelligence());
        ShowValidStats();
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