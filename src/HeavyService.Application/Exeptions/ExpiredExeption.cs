using System.Net;

namespace HeavyService.Application.Exeptions;

public class ExpiredExeption : ClientExeption
{
    public override HttpStatusCode StatusCode { get; } = HttpStatusCode.Gone;
    public override string TitleMessage { get; protected set; } = String.Empty;
}