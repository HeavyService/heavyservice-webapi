namespace HeavyService.Domain.Entities.InstrumentsComments;

public class InstrumentComment : AudiTable
{
    public long UserId { get; set; }
    public long InstrumentId { get; set; }
    public long ReplyId { get; set; }
    public string Comment { get; set; } = string.Empty;
    public bool IsEdited { get; set; }
}
