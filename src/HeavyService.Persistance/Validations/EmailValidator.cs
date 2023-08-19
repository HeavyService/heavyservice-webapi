namespace HeavyService.Persistance.Validations;

public class EmailValidator
{
    public static bool IsValid(string email)
    {
        if (email.EndsWith("@gmail.com") == false) return false;

        if (email == "@gmail.com") return false;

        return true;
    }
}