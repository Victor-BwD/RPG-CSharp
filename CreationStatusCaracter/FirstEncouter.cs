namespace CreationStatusCaracter;

public class FirstEncouter
{
    
    public void FirstContact(string name, string classe)
    {
        Console.WriteLine("You're in a tavern drinking and an old man approaches you with a paper...");
        Console.WriteLine("The man appears to be a sage or something. He shows you a contract with a prize. You must go to the dungeon and find an artifact.");
        Console.WriteLine($"- I see that you are a {classe} with incredible potential. Please, some goblins stole my mystical artifact. Can you get it for me? I can pay very well.");
        Console.WriteLine($"- Please, can you tell me your name? ");
        var tellName = Console.ReadLine();

        if (tellName != name) LiesManager.IncreaseLies();

        Console.WriteLine("You tell to him that your name is {0}.", tellName);

        Console.WriteLine($"- Glad to meet you, {tellName}. So, you'll help me? (YES or NO)");
        string accept = Console.ReadLine().ToUpper();
        if (accept != "YES")
        {
            throw new ArgumentOutOfRangeException("value", ("Oh, it's a shame... good bye."));
        }
    }
}