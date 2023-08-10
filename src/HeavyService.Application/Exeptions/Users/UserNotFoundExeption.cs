namespace HeavyService.Application.Exeptions.Users;

public class UserNotFoundExeption : NotFoundExeption
{
    public UserNotFoundExeption()
    {
        this.TitleMessage = "User not found!";
    }
}