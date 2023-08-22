namespace HeavyService.Persistance.Dtos.TransportComments;

public class TransportCommentDto
{
    public long ReplyId { get; set; }
    public string Comment { get; set; } = string.Empty;
    public bool IsEdited { get; set; }
}