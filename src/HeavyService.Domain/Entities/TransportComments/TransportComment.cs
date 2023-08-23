namespace HeavyService.Domain.Entities.TransportComments;

public class TransportComment : AudiTable
{
    public long UserId { get; set; }
    public long TransportId { get; set; }
    public long ReplayId { get; set; }
    public string Comment { get; set; } = string.Empty;
    public bool IsEdited { get; set; }
}