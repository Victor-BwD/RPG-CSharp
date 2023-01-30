namespace CreationStatusCaracter;

public class MageGame
{
    public void MageBegins(PlayerCharacter playerCharacter)
    {
        Console.WriteLine("You're in a tavern drinking and an old man approaches you with a paper...");
        Console.WriteLine("The man appears to be a sage or something. He shows you a contract with a prize. You must go to the dungeon and find an artifact.");
        Console.WriteLine($"- I see that you are a {playerCharacter.JobName.ToLower()} with incredible potential. Please, some goblins stole my mystical artifact. Can you get it for me? I can pay very well.");
    }
}