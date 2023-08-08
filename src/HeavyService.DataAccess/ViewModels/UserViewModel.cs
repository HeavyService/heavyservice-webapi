using HeavyService.Domain.Entities;

namespace HeavyService.DataAccess.ViewModels;

public class UserViewModel : AudiTable
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}
