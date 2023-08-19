using HeavyService.Application.Exeptions.Users;
using HeavyService.Application.Utils;
using HeavyService.DataAccess.Interfaces.Users;
using HeavyService.DataAccess.ViewModels;
using HeavyService.Domain.Entities.Users;
using HeavyService.Persistance.Dtos.Users;
using HeavyService.Persistance.Helpers;
using HeavyService.Service.Commons.Securities;
using HeavyService.Service.Interfaces.Commons;
using HeavyService.Service.Interfaces.Users;

namespace HeavyService.Service.Services.Users;

public class UserService : IUserservice
{
    private readonly IUserRepository _repository;
    private readonly IPaginator _paginator;

    public UserService(IUserRepository userrepository, IPaginator paginator)

    {
        this._repository = userrepository;
        this._paginator = paginator;
    }
    public async Task<long> CountAsync() => await _repository.CountAsync();
    public async Task<bool> CreateAsync(UserCreateDto dto)
    {
        User user = new User()
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Email = dto.Email,
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
        var count = await _repository.CountAsync();
        _paginator.Paginate(count, @params);

        return user;
    }
    public async Task<UserViewModel> GetByIdAsync(long id)
    {
        var user = await _repository.GetByIdAsync(id);

        if (user is null) throw new UserNotFoundExeption();
        else return user;
    }

    public async Task<bool> UpdateAsync(long userId, UserUpdateDto dto)
    {
        var user = await _repository.GetIdAsync(userId);
        if (user is null) throw new UserNotFoundExeption();

        user.FirstName = dto.FirstName;
        user.LastName = dto.LastName;

        var email = await _repository.GetByEmailAsync(dto.Email);
        if (email is not null) throw new UserAllReadyExeptions();

        user.Email = dto.Email;

        var password = PasswordHasher.Hash(dto.Password);
        user.PasswordHash = password.Hash;
        user.Salt = password.Salt;
        user.UpdatedAt = TimeHelper.GetDateTime();
        var result = await _repository.UpdateAsync(userId, user);

        return result > 0;
    }
}