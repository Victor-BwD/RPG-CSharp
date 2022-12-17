namespace CreationStatusCaracter;

public class LiesManager
{
    private static int Lies;
    
    public static void IncreaseLies()
    {
        Lies++;
    }

    public static void IncreaseLiesForTwo()
    {
        Lies += 2;
    }

    public static int GetLies()
    {
        return Lies;
    }
}