using HeavyService.Application.Utils;
using HeavyService.Domain.Entities.InstrumentsComments;
using HeavyService.Domain.Entities.TransportComments;
using HeavyService.Persistance.Dtos.InstrumentComments;
using HeavyService.Persistance.Dtos.TransportComments;

namespace HeavyService.Service.Interfaces.InstrumentComments;

public interface IInstrumentCommentService
{
    public Task<bool> CreateAsync(InstrumentCommentCreateDto dto);
    public Task<bool> DeleteAsync(long id);
    public Task<long> CountAsync();
    public Task<InstrumentComment> GetAllAsync(Paginationparams @params);
    public Task<InstrumentComment> GetByIdAsync(long id);
    public Task<bool> UpdateAsync(long instrumentId, InstrumentCommentCreateDto dto);
}