using HeavyService.DataAccess.Common.Interfaces;
using HeavyService.DataAccess.ViewModels;
using HeavyService.Domain.Entities.Users;

namespace HeavyService.DataAccess.Interfaces.Users;

public interface IUserRepository : IRepository<User, UserViewModel>, ISearch<UserViewModel>, IGetAll<UserViewModel>
{

}
