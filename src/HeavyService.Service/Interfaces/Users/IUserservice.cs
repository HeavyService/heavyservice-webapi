using HeavyService.Application.Utils;
using HeavyService.DataAccess.ViewModels;
using HeavyService.Persistance.Dtos.Users;

namespace HeavyService.Service.Interfaces.Users;

public interface IUserservice
{
    public Task<bool> CreateAsync(UserCreateDto dto);
    public Task<IList<UserViewModel>> GetAllAsync(Paginationparams @params);
    public Task<bool> DeleteAsync(long userId);
    public Task<long> CountAsync();
    public Task<UserViewModel> GetByIdAsync(long userId);
    public Task<IList<UserViewModel>> SearchAsync(string search, Paginationparams @params);
    public Task<bool> UpdateAsync(long userId, UserUpdateDto dto);
}