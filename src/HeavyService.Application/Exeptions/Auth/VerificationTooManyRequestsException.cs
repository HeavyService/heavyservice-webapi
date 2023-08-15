namespace HeavyService.Application.Exeptions.Auth;

public class VerificationTooManyRequestsException : TooManyRequestException
{
    public VerificationTooManyRequestsException()
    {
        TitleMessage = "You tried more than limits!";
    }
}