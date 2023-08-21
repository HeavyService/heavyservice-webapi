using HeavyService.Domain.Entities;

namespace HeavyService.DataAccess.ViewModels;

public class UserRoleViewModel
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
}