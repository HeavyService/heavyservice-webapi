using HeavyService.Application.Utils;
using HeavyService.Domain.Entities.Transports;
using HeavyService.Persistance.Dtos.Transports;

namespace HeavyService.Service.Interfaces.Transports;

public interface ITransportService
{
    public Task<bool> CreateAsync(TransportCreateDto dto);
    public Task<bool> DeleteAsync(long id);
    public Task<Transport> GetByIdAsync(long id);
    public Task<long> CountAsync();
    public Task<Transport> GetAllAsync(Paginationparams @params);
    public Task<bool> UpdateAsync(long transportId, TransportUpdateDto dto);
}
