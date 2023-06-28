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
        _playerCharacter.SetHp();
        var iniciative = _job.Iniciative;

        Console.WriteLine("You enter the cave and begin to explore. Soon you come across a group of goblins, who are guarding the entrance to the treasure. You need to defeat them in order to pass.");
        List<Goblin> goblins = CreateGoblins(2);

        Console.WriteLine($"{goblins.Count} goblins appears!");

        if(iniciative > goblins[0].Iniciative)
        {
            for (int i = 0; i < goblins.Count; i++)
            {
                Console.WriteLine($"[{i + 1}] {goblins[i].Name} (HP: {goblins[i].HealthPoints})");
            }

            // Solicitar ao jogador que escolha o número correspondente ao goblin a ser atacado
            Console.Write("Choose the goblin to attack: ");
            int selectedGoblinIndex = int.Parse(Console.ReadLine()) - 1;
            
        }
        else
        {
            foreach(var goblin in goblins)
            {
                Console.WriteLine("Goblin attack player");
                var dodgeChange = _job.Dodge;
                var randomNumber = new Random().Next(1, 21);

                if(randomNumber <= dodgeChange)
                {
                    Console.WriteLine("You dodge the goblin's attack!");
                }
                else
                {
                    goblin.Attack(_playerCharacter);
                    Console.WriteLine($"{_playerCharacter.ActualHp}");
                }
                Console.WriteLine($"{_playerCharacter.ActualHp}");

                if (_playerCharacter.ActualHp <= 0)
                {
                    Console.WriteLine("You have been defeated.");
                    break;
                }
            }
        }
    }

    private List<Goblin> CreateGoblins(int quantGoblins)
    {
        List<Goblin> goblins = new List<Goblin>();

        for (int i = 0; i < quantGoblins; i++)
        {
            goblins.Add(new Goblin());
        }

        return goblins;
    }
}