namespace HeavyService.Persistance.Helpers;

public class CodeGenerater
{
    public static int GenerateRandomNumber()
    {
        Random random = new Random();
        return random.Next(100000, 999999);
    }
}