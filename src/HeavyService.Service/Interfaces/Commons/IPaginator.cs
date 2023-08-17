using HeavyService.Application.Utils;

namespace HeavyService.Service.Interfaces.Commons;

public interface IPaginator
{
    public void Paginate(long itemsCount, Paginationparams @params);
}