using HeavyService.Application.Utils;

namespace HeavyService.DataAccess.Common.Interfaces;

public interface ISearch<TViewModel>
{
    public Task<IList<TViewModel>> SearchAsync(string search, Paginationparams @params);
}