namespace HeavyService.Application.Exeptions.Admins;

public class AdminNotFoundExeption : NotFoundExeption
{
    public AdminNotFoundExeption()
    {
        this.TitleMessage = "Admin not found!";
    }
}