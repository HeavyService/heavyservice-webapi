using HeavyService.Application.Exeptions.Comments;
using HeavyService.Application.Exeptions.Instruments;
using HeavyService.Application.Exeptions.Transports;
using HeavyService.Application.Utils;
using HeavyService.DataAccess.Interfaces.TransportComments;
using HeavyService.DataAccess.Interfaces.Transports;
using HeavyService.DataAccess.ViewModels;
using HeavyService.Domain.Entities.TransportComments;
using HeavyService.Persistance.Dtos.TransportComments;
using HeavyService.Persistance.Helpers;
using HeavyService.Service.Interfaces.Commons;
using HeavyService.Service.Interfaces.TransportComments;
using HeavyService.Service.Interfaces.Users;

namespace HeavyService.Service.Services.TransportComments;
public class TransportCommentService : ITransportCommentService
{
    private readonly ITransportCommentRepository _repository;
    private readonly ITransportRepository _transrepository;
    private readonly IIdentityService _service;
    private readonly IPaginator _paginator;

    public TransportCommentService(ITransportCommentRepository repository,
        IIdentityService service, IPaginator paginator,
        ITransportRepository transrepository)
    {
        this._repository = repository;
        this._service = service;
        this._paginator = paginator;
        this._transrepository = transrepository;
    }
    public async Task<long> CountAsync() => await _repository.CountAsync();
    public async Task<bool> CreateAsync(TransportCommentDto dto)
    {
        var trans = await _transrepository.GetIdAsync(dto.TransportId);
        if (trans is not null)
        {
            TransportComment comment = new TransportComment()
            {
                UserId = _service.UserId,
                TransportId = dto.TransportId,
                ReplyId = dto.ReplyId,
                Comment = dto.Comment,
                IsEdited = dto.IsEdited,
                CreatedAt = TimeHelper.GetDateTime(),
                UpdatedAt = TimeHelper.GetDateTime()
            };
            var result = await _repository.CreateAsync(comment);

            return result > 0;
        }
        else throw new TransportNotFoundExeption();
    }

    public async Task<bool> DeleteAsync(long transportId)
    {
        var comment = await _repository.GetByIdAsync(transportId);
        if (comment is null) throw new InstrumentNotFoundExeption();
        var dbResult = await _repository.DeleteAsync(transportId);

        return dbResult > 0;
    }

    public async Task<IList<TransportCommentViewmodel>> GetAllAsync(Paginationparams @params)
    {
        var result = await _repository.GetAllAsync(@params);
        var count = await _repository.CountAsync();
        _paginator.Paginate(count, @params);

        return result;
    }

    public async Task<TransportCommentViewmodel> GetByIdAsync(long id)
    {
        var comment = await _repository.GetByIdAsync(id);
        if (comment is null) throw new CommentNotFoundExeption();

        return comment;
    }
}