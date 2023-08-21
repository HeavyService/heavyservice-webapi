using HeavyService.Domain.Entities.Users;

namespace HeavyService.Service.Interfaces.Auth;
public interface ITokenService
{
    public Task<string> GenerateToken(User user);
}