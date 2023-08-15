using HeavyService.Application.Utils;
using HeavyService.Domain.Entities.Instruments;
using HeavyService.Persistance.Dtos.Instruments;

namespace HeavyService.Service.Interfaces.Instruments;

public interface IInstrumentService
{
    public Task<bool> CreateAsync(InstrumentCreateDto dto);
    public Task<bool> DeleteAsync(long instrumentId);
    public Task<long> CountAsync();
    public Task<Instrument> GetByIdAsync(long instrumentId);
    public Task<Instrument> GetAllAsync(Paginationparams @params);
    public Task<bool> UpdateAsync(long instrumentId, InstrumentUpdateDto dto);
}