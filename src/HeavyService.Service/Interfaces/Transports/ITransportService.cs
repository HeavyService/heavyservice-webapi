using HeavyService.Application.Utils;
using HeavyService.DataAccess.ViewModels;
using HeavyService.Persistance.Dtos.Transports;

namespace HeavyService.Service.Interfaces.Transports;

public interface ITransportService
{
    public Task<bool> CreateAsync(TransportCreateDto dto);
    public Task<bool> DeleteAsync(long transportId);
    public Task<TransportViewModel> GetByIdAsync(long transportId);
    public Task<long> CountAsync();
    public Task<IList<TransportViewModel>> GetAllAsync(Paginationparams @params);
    public Task<bool> UpdateAsync(long transportId, TransportUpdateDto dto);
}