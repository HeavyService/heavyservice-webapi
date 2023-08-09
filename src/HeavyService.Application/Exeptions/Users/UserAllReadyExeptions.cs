namespace HeavyService.Application.Exeptions.Users;

public class UserAllReadyExeptions : AllReadyExistsExeption
{
    public UserAllReadyExeptions()
    {
        TitleMessage = "User olready exists";
    }

    public UserAllReadyExeptions(string phone)
    {
        TitleMessage = "This phone is already registered";
    }
}
