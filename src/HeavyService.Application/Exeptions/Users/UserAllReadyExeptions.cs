namespace HeavyService.Application.Exeptions.Users;

public class UserAllReadyExeptions : AllReadyExistsExeption
{
    public UserAllReadyExeptions()
    {
        TitleMessage = "User allready exists";
    }

    public UserAllReadyExeptions(string phone)
    {
        TitleMessage = "This email is allready registered";
    }
}