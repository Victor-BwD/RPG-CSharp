using GameRPG;
using TreinarRPG.Entities;

namespace TreinarRPG.src.Entities;

public class StartCampaign
{
    private PlayerCharacter _playerCharacter;
    private IJob _job;

    public StartCampaign(PlayerCharacter playerCharacter, IJob job)
    {
        _playerCharacter = playerCharacter;
        _job = job;
    }

    public void StartGame()
    {
        Console.WriteLine("Entering in dungeon...");
        Thread.Sleep(3000);
        Console.Clear();

        MonsterCreator creator = new MonsterCreator();

        List<Monster> monstersToCreate = new List<Monster>();
        monstersToCreate.Add(new Goblin());
        monstersToCreate.Add(new Goblin());

        List<Monster> createdMonsters = creator.CreateMonster(monstersToCreate);

        CombatManager<Monster> combatManager = new CombatManager<Monster>(_playerCharacter, createdMonsters, _job);
        combatManager.StartCombate();
    }
}