namespace CreationStatusCaracter;

public class FirstEncouter
{
    
    public void FirstContact(PlayerCharacter playerCharacter)
    {
        if (playerCharacter.JobName.ToLower() == "wizard")
        {
            MageGame mageGame = new MageGame();
            mageGame.MageBegins(playerCharacter);
            return;
        }
        
        Console.WriteLine("You're in a tavern drinking and an old man approaches you with a paper...");
        Console.WriteLine("The man appears to be a sage or something. He shows you a contract with a prize. You must go to the dungeon and find an artifact.");
        Console.WriteLine($"- I see that you are a {playerCharacter.JobName.ToLower()} with incredible potential. Please, some goblins stole my mystical artifact. Can you get it for me? I can pay very well.");
        Console.WriteLine($"- Please, can you tell me your name? ");
        var tellName = Console.ReadLine();

        if (tellName != playerCharacter.Name) LiesManager.IncreaseLies();

        Console.WriteLine("You tell to him that your name is {0}.", tellName);

        Console.WriteLine($"- Glad to meet you, {tellName}. So, you'll help me? (YES or NO)");
        string accept = Console.ReadLine().ToUpper();
        if (accept != "YES")
        {
            throw new ArgumentOutOfRangeException("value", ("Oh, it's a shame... good bye."));
        }

        Console.WriteLine("You leave the tavern, holding a piece of paper the old man gave to you. In it is a coordinate for a dungeon, it says that it contains a lost sacred tome that belonged to the old master of this strange person.");
        Console.WriteLine($"You are a experienced {playerCharacter.JobName.ToLower()}, you recognize the region, you know that to go to this dungeon you will have to face a not very inviting forest.");
        Console.WriteLine("You're walking through the forest, but you hear thin voices in different languages, something you've heard before... It's goblins, they're trying to ambush you.");
        Console.WriteLine("You still have a few km to walk inside the forest. You need to roll the dice and roll a number greater than 11 so that you can hide from the goblins and not be attacked. Roll the dice now...");

        Random forestDice = new Random();
        int rndNumber = forestDice.Next(1, 20);
        Console.WriteLine($"You roll {rndNumber}");
        if (rndNumber < 11)
        {
            Console.WriteLine("They see you, a goblin jumps in front of you and attacks you!");

            Console.WriteLine($"You get your {playerCharacter.WeaponName.ToLower()}");
        }
    }
}