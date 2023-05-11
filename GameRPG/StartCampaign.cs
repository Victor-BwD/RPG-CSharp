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
        Console.WriteLine();
        var goblin = new Goblin();
        goblin.Attack(_playerCharacter);
        Console.WriteLine($"O goblin atacou o jogador com poder de ataque {goblin.PowerAttack} e causou {goblin.Damage} de dano.");
        Console.WriteLine($"A vida do jogador agora é {_playerCharacter.ActualHp}.");
    }
}