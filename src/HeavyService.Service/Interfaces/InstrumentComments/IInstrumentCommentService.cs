using HeavyService.Application.Utils;
using HeavyService.DataAccess.ViewModels;
using HeavyService.Persistance.Dtos.InstrumentComments;

namespace HeavyService.Service.Interfaces.InstrumentComments;

public interface IInstrumentCommentService
{
    public Task<bool> CreateAsync(long instrumentId, InstrumentCommentCreateDto dto);
    public Task<bool> DeleteAsync(long id);
    public Task<long> CountAsync();
    public Task<IList<InstrumentCommentViewModel>> GetAllAsync(Paginationparams @params);
    public Task<InstrumentCommentViewModel> GetByIdAsync(long id);
}