namespace CreationStatusCaracter;

public class FirstEncouter
{
    
    public void FirstContact(string name, int age)
    {
        Console.WriteLine("Lets start the history, remember that your actions impact.");
        Console.WriteLine("A old man finds you in a tavern and asks your name and age...");
        var tellName = Console.ReadLine();
        var tellAge = int.Parse(Console.ReadLine());
        
        if (tellName != name || tellAge != age) LiesManager.IncreaseLies();
        
        if (tellName != name && tellAge != age) LiesManager.IncreaseLiesForTwo();

        Console.WriteLine("You tell to him that your name is {0} and you have {1} years old...", tellName, tellAge);
    }
}