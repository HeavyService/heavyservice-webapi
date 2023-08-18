using HeavyService.Application.Utils;
using HeavyService.DataAccess.Interfaces.Instruments;
using HeavyService.DataAccess.ViewModels;
using HeavyService.Domain.Entities.InstrumentsComments;
using HeavyService.Persistance.Dtos.InstrumentComments;
using HeavyService.Service.Interfaces.Commons;
using HeavyService.Service.Interfaces.InstrumentComments;

namespace HeavyService.Service.Services.InstrumentComments;

public class InstrumentCommentService : IInstrumentCommentService
{
    private readonly IInstrumentRepository _repository;
    private readonly IPaginator _paginator;

    public InstrumentCommentService(IInstrumentRepository instrumentRepository,
        IPaginator paginator)
    {
        this._repository = instrumentRepository;
        this._paginator = paginator;
    }
    public Task<long> CountAsync()
    {
        throw new NotImplementedException();
    }

    public Task<bool> CreateAsync(InstrumentCommentCreateDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<bool> CreateAsync(long instrumentId, InstrumentCommentCreateDto dto)
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

    public Task<IList<InstrumentComment>> GetAllAsync(Paginationparams @params)
    {
        throw new NotImplementedException();
    }

    public Task<IList<InstrumentComment>> GetByIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateAsync(long instrumentId, InstrumentCommentCreateDto dto)
    {
        throw new NotImplementedException();
    }

    Task<IList<InstrumentCommentViewModel>> IInstrumentCommentService.GetAllAsync(Paginationparams @params)
    {
        throw new NotImplementedException();
    }

    Task<IList<InstrumentCommentViewModel>> IInstrumentCommentService.GetByIdAsync(long id)
    {
        throw new NotImplementedException();
    }
}