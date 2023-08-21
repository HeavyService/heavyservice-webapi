using HeavyService.DataAccess.Common.Interfaces;
using HeavyService.DataAccess.ViewModels;
using HeavyService.Domain.Entities.UserRoles;

namespace HeavyService.DataAccess.Interfaces.UserRoles
{
    public interface IUserRoleRepository : IRepository<UserRole, UserRoleViewModel>, IGetAll<UserRoleViewModel>
    {
        public Task<UserRoleViewModel> GetByUserIdAsync(long id);
    }
}