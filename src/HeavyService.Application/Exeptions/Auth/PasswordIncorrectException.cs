namespace HeavyService.Application.Exeptions.Auth;

public class PasswordIncorrectException : BadRequestExeption
{
    public PasswordIncorrectException()
    {
        TitleMessage = "Password is Invalid!";
    }
}
