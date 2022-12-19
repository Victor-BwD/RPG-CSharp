namespace CreationStatusCaracter;

public class FirstEncouter
{
    
    public void FirstContact(string name, int age)
    {
        Console.WriteLine("You're in a tavern drinking and an old man approaches you with a paper...");
        Console.WriteLine("The man appears to be a sage or something. He shows you a contract with a prize.");
        var tellName = Console.ReadLine();
        var tellAge = int.Parse(Console.ReadLine());
        
        if (tellName != name || tellAge != age) LiesManager.IncreaseLies();
        
        if (tellName != name && tellAge != age) LiesManager.IncreaseLiesForTwo();

        Console.WriteLine("You tell to him that your name is {0} and you have {1} years old...", tellName, tellAge);
    }
}