using HeavyService.Application.Exeptions.Comments;
using HeavyService.Application.Exeptions.Instruments;
using HeavyService.Application.Utils;
using HeavyService.DataAccess.Interfaces.InstrumentComments;
using HeavyService.DataAccess.Interfaces.Instruments;
using HeavyService.DataAccess.ViewModels;
using HeavyService.Domain.Entities.InstrumentsComments;
using HeavyService.Persistance.Dtos.InstrumentComments;
using HeavyService.Persistance.Helpers;
using HeavyService.Service.Interfaces.Commons;
using HeavyService.Service.Interfaces.InstrumentComments;
using HeavyService.Service.Interfaces.Users;

namespace HeavyService.Service.Services.InstrumentComments;

public class InstrumentCommentService : IInstrumentCommentService
{
    private readonly IInstrumentComment _repository;
    private readonly IIdentityService _service;
    private readonly IInstrumentRepository _instrument;
    private readonly IPaginator _paginator;

    public InstrumentCommentService(IInstrumentComment repository,
        IPaginator paginator, IInstrumentRepository repostory,
        IIdentityService identityservice)
    {
        this._repository = repository;
        this._service = identityservice;
        this._instrument = repostory;
        this._paginator = paginator;
    }
    public async Task<long> CountAsync() => await _repository.CountAsync();
    public async Task<bool> CreateAsync(InstrumentCommentCreateDto dto)
    {
        var instrument = await _instrument.GetIdAsync(dto.InstrumentId);
        if (instrument is not null)
        {
            InstrumentComment comment = new InstrumentComment()
            {
                UserId = _service.UserId,
                ReplyId = dto.ReplyId,
                InstrumentId = dto.InstrumentId,
                Comment = dto.Comment,
                IsEdited = dto.IsEdited,
                CreatedAt = TimeHelper.GetDateTime(),
                UpdatedAt = TimeHelper.GetDateTime()
            };
            var result = await _repository.CreateAsync(comment);

            return result > 0;
        }
        else throw new InstrumentNotFoundExeption();
    }
    public async Task<bool> DeleteAsync(long id)
    {
        var instrument = await _repository.GetByIdAsync(id);
        if (instrument is null) throw new InstrumentNotFoundExeption();
        var dbResult = await _repository.DeleteAsync(id);

        return dbResult > 0;
    }
    public async Task<IList<InstrumentCommentViewModel>> GetAllAsync(Paginationparams @params)
    {
        var result = await _repository.GetAllAsync(@params);
        var count = await _repository.CountAsync();
        _paginator.Paginate(count, @params);

        return result;
    }
    public async Task<InstrumentCommentViewModel> GetByIdAsync(long id)
    {
        var comment = await _repository.GetByIdAsync(id);
        if (comment is null) throw new CommentNotFoundExeption();

        return comment;
    }
}