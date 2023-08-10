namespace HeavyService.Persistance.Dtos.Auth;

public class VerifyDto
{
    public string Email { get; set; } = string.Empty;
    public int Code { get; set; }
}