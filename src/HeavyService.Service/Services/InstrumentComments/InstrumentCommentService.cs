using HeavyService.Application.Utils;
using HeavyService.Domain.Entities.InstrumentsComments;
using HeavyService.Persistance.Dtos.InstrumentComments;
using HeavyService.Service.Interfaces.InstrumentComments;

namespace HeavyService.Service.Services.InstrumentComments;

public class InstrumentCommentService : IInstrumentCommentService
{
    public Task<long> CountAsync()
    {
        throw new NotImplementedException();
    }

    public Task<bool> CreateAsync(InstrumentCommentCreateDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<InstrumentComment> GetAllAsync(long instrumentId)
    {
        throw new NotImplementedException();
    }

    public Task<InstrumentComment> GetAllAsync(Paginationparams @params)
    {
        throw new NotImplementedException();
    }

    public Task<InstrumentComment> GetByIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateAsync(long instrumentId, InstrumentCommentCreateDto dto)
    {
        throw new NotImplementedException();
    }
}
