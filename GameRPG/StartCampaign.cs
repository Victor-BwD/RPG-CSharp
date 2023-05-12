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
        Console.WriteLine("");
        
    }
}