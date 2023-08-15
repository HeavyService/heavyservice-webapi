namespace HeavyService.Application.Exeptions.Files;

public class FilesNotFoundExeption : NotFoundExeption
{
    public FilesNotFoundExeption()
    {
        this.TitleMessage = "File not found!";
    }
}