using HeavyService.DataAccess.Common.Interfaces;
using HeavyService.DataAccess.ViewModels;
using HeavyService.Domain.Entities.Users;

namespace HeavyService.DataAccess.Interfaces.Users;

public interface IUserRepository : IRepository<User, UserViewModel>, ISearch<UserViewModel>, IGetAll<UserViewModel>
{
    public Task<User?> GetByEmailAsync(string email);
    public Task<User?> GetByPhoneAsync(string phone);
    public Task<User?> GetIdAsync(long id);
    public Task<User?> GetLastIdAsync();
}