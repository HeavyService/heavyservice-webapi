using System.Net;

namespace HeavyService.Application.Exeptions;

public class AllReadyExistsExeption : ClientExeption
{
    public override HttpStatusCode StatusCode { get; } = HttpStatusCode.NotFound;

    public override string TitleMessage { get; protected set; } = String.Empty;
}
