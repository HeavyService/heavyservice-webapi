using HeavyService.Domain.Entities.Users;

namespace HeavyService.Service.Interfaces.Auth;
public interface ITokenService
{
    public string GenerateToken(User user);
}