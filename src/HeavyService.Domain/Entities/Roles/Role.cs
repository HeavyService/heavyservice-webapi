using System.ComponentModel.DataAnnotations;

namespace HeavyService.Domain.Entities.Roles;

public class Role : AudiTable
{
    [MaxLength(30)]
    public string Name { get; set; } = string.Empty;
}
