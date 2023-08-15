using HeavyService.Application.Exeptions.Users;
using HeavyService.Application.Utils;
using HeavyService.DataAccess.Interfaces.Users;
using HeavyService.DataAccess.ViewModels;
using HeavyService.Domain.Entities.Users;
using HeavyService.Persistance.Dtos.Users;
using HeavyService.Service.Interfaces.Users;

namespace HeavyService.Service.Services.Users;

public class UserService : IUserservice
{
    private readonly IUserRepository _repository;

    public UserService(IUserRepository userrepository)

    {
        this._repository = userrepository;
    }
    public async Task<long> CountAsync() => await _repository.CountAsync();
    public async Task<bool> CreateAsync(UserCreateDto dto)
    {
        User user = new User()
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Email = dto.Email,
            EmailConfirmed = dto.EmailConfirmed
        };
        var result = await _repository.CreateAsync(user);
        return result > 0;
    }
    public async Task<bool> DeleteAsync(long userId)
    {
        var user = await _repository.GetByIdAsync(userId);

        if (user is null) throw new UserNotFoundExeption();
        var dbResult = await _repository.DeleteAsync(userId);
        return dbResult > 0;
    }
    public async Task<IList<UserViewModel>> GetAllAsync(Paginationparams @params)
    {
        var user = await _repository.GetAllAsync(@params);
        return user;
    }
    public async Task<UserViewModel> GetByIdAsync(long id)
    {
        var user = await _repository.GetByIdAsync(id);
        if (user is null) throw new UserNotFoundExeption();
        else return user;
    }
}