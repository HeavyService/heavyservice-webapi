namespace HeavyService.Application.Exeptions.Transports;

public class TransportNotFoundExeption : NotFoundExeption
{
    public TransportNotFoundExeption()
    {
        this.TitleMessage = "Transport not found!";
    }
}
