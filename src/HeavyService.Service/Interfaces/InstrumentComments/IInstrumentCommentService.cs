using HeavyService.Application.Utils;
using HeavyService.DataAccess.ViewModels;
using HeavyService.Domain.Entities.InstrumentsComments;
using HeavyService.Domain.Entities.TransportComments;
using HeavyService.Persistance.Dtos.InstrumentComments;
using HeavyService.Persistance.Dtos.TransportComments;

namespace HeavyService.Service.Interfaces.InstrumentComments;

public interface IInstrumentCommentService
{
    public Task<bool> CreateAsync(long instrumentId,InstrumentCommentCreateDto dto);
    public Task<bool> DeleteAsync(long id);
    public Task<long> CountAsync();
    public Task<IList<InstrumentCommentViewModel>> GetAllAsync(Paginationparams @params);
    public Task<IList<InstrumentCommentViewModel>> GetByIdAsync(long id);
    public Task<bool> UpdateAsync(long instrumentId, InstrumentCommentCreateDto dto);
}