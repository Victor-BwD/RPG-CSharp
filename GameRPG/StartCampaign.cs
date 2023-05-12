namespace GameRPG;

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
        Console.WriteLine("You enter the cave and begin to explore. Soon you come across a group of goblins, who are guarding the entrance to the treasure. You need to defeat them in order to pass.");
        
    }
}