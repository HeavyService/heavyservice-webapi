namespace HeavyService.Domain.Entities.UserRoles;

public class UserRole : AudiTable
{
    public long UserId { get; set; }
    public long RoleId { get; set; }
}