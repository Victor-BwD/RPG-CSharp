using GameRPG;
using TreinarRPG.Entities;

namespace TreinarRPG.src.Entities;

public class StartCampaign
{
    private PlayerCharacter _playerCharacter;
    private IJob _job;
    private CampaignControl _campaignControl;

    public StartCampaign(PlayerCharacter playerCharacter, IJob job, CampaignControl campaignControl)
    {
        _playerCharacter = playerCharacter;
        _job = job;
        _campaignControl = campaignControl;
    }

    public StartCampaign(PlayerCharacter playerCharacter, IJob job)
    {
        _playerCharacter = playerCharacter;
        _job = job;
    }

    public StartCampaign()
    {

    }

    public void StartGame()
    {
        Console.WriteLine("Entering in dungeon...");
        Thread.Sleep(3000);
        Console.Clear();

        Console.WriteLine("""
                You enter the cave and begin to explore. 
                Soon you come across a group of goblins, who are guarding the entrance to the treasure. 
                You need to defeat them in order to pass."
                """);
        Thread.Sleep(3000);
        Console.WriteLine();

        MonsterCreator creator = new MonsterCreator();

        List<Monster> monstersToCreate = new List<Monster>();
        monstersToCreate.Add(new Goblin());
        monstersToCreate.Add(new Goblin());

        List<Monster> createdMonsters = creator.CreateMonster(monstersToCreate);

        CombatManager<Monster> combatManager = new CombatManager<Monster>(_playerCharacter, createdMonsters, _job);
        combatManager.StartCombat();
    }

    public void ContinueCampaign()
    {
        Console.WriteLine(_playerCharacter.ActualHp);
        _campaignControl.AdvanceStory();
        NextStage();
    }

    public void NextStage()
    {
        if (_campaignControl.GetStoryProgress() == 1)
        {
            DisplayStoryProgress();
            HandleRestArea();
        }
    }

    private void DisplayStoryProgress()
    {
        Console.WriteLine("You defeated the goblins and now you can continue your journey.");
        Thread.Sleep(2000);
        Console.Clear();

        Console.WriteLine("You find a small room with a campfire and a waterskin.");
    }

    private void HandleRestArea()
    {
        bool willRest = GetYesNoInput("Do you want to rest here and recover some HP?");

        if (willRest)
        {
            const int healAmount = 20;
            _playerCharacter.RestoreHp(healAmount);
            Console.WriteLine("You take a moment to rest and recover.");
            Console.WriteLine($"Your HP is now: {_playerCharacter.ActualHp}");
        }
        else
        {
            Console.WriteLine("You decide to keep moving cautiously.");
        }

        Thread.Sleep(2000);
        Console.Clear();
    }

    private bool GetYesNoInput(string question)
    {
        string input;
        do
        {
            Console.WriteLine($"{question} (y/n)");
            input = Console.ReadLine() ?? string.Empty;
            input = input.Trim().ToLower();
            
            if (input != "y" && input != "n")
            {
                Console.WriteLine("Your character don't know what to do. Please enter 'y' or 'n'.");
            }
        } while (input != "y" && input != "n");

        return input == "y";
    }
}