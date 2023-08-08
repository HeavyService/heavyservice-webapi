using HeavyService.Application.Utils;

namespace HeavyService.DataAccess.Common.Interfaces;

public interface IGetAll<TViewModel>
{
    public Task<IList<TViewModel>> GetAllAsync(Paginationparams @params);
}
