using System.Net;

namespace HeavyService.Application.Exeptions;

public class NotFoundExeption : Exception
{
    public HttpStatusCode StatusCode { get; } = HttpStatusCode.NotFound;

    public string TitleMessage { get; protected set; } = string.Empty;
}
