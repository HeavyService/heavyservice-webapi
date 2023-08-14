namespace HeavyService.Persistance.Validations;

public class EmailValidator
{
    public static bool IsValid(string email)
    {
        var trimmedEmail = email.Trim();
        if (trimmedEmail.EndsWith("."))
        {
            return false;
        }
        try
        {
            var addres = new System.Net.Mail.MailAddress(email);
            return addres.Address == trimmedEmail;
        }
        catch
        {
            return false;
        }
    }
}