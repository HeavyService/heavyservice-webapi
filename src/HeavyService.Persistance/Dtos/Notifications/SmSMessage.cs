namespace HeavyService.Persistance.Dtos.Notifications;

public class SmSMessage
{
    public string Resipient { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
}