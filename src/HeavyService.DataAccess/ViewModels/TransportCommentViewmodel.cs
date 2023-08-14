using HeavyService.Domain.Entities;

namespace HeavyService.DataAccess.ViewModels;

public class TransportCommentViewmodel : AudiTable
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Comment { get; set; } = string.Empty;
}