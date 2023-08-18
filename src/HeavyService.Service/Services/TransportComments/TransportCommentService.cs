using HeavyService.Application.Exeptions.Comments;
using HeavyService.Application.Exeptions.Instruments;
using HeavyService.Application.Utils;
using HeavyService.DataAccess.Interfaces.TransportComments;
using HeavyService.DataAccess.ViewModels;
using HeavyService.Domain.Entities.TransportComments;
using HeavyService.Persistance.Dtos.TransportComments;
using HeavyService.Persistance.Helpers;
using HeavyService.Service.Interfaces.TransportComments;

namespace HeavyService.Service.Services.TransportComments;
public class TransportCommentService : ITransportCommentService
{
    private readonly ITransportCommentRepository _repository;
    public TransportCommentService(ITransportCommentRepository repository)
    {
        this._repository = repository;
    }
    public async Task<long> CountAsync() => await _repository.CountAsync();
    public async Task<bool> CreateAsync(long transportId, TransportCommentDto dto)
    {
        TransportComment comment = new TransportComment()
        {
            UserId = dto.UserId,
            TransportId = transportId,
            ReplyId = dto.ReplyId,
            Comment = dto.Comment,
            IsEdited = dto.IsEdited,
            CreatedAt = TimeHelper.GetDateTime(),
            UpdatedAt = TimeHelper.GetDateTime()
        };
        var result = await _repository.CreateAsync(comment);
        return result > 0;
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
        return result;
    }
    public async Task<IList<TransportCommentViewmodel>> GetByIdAsync(long id)
    {
        var comment = await _repository.GetByIdAsync(id);
        if (comment is null) throw new CommentNotFoundExeption();
        return (IList<TransportCommentViewmodel>)comment;
    }
    public async Task<bool> UpdateAsync(long transportId, TransportCommentDto dto)
    {
        var transportcomment = await _repository.GetIdAsync(transportId);
        if (transportcomment is null) throw new InstrumentNotFoundExeption();
        transportcomment.UserId = dto.UserId;
        transportcomment.ReplyId = dto.ReplyId;
        transportcomment.Comment = dto.Comment;
        transportcomment.UpdatedAt = TimeHelper.GetDateTime();
        var dbResult = await _repository.UpdateAsync(transportId, transportcomment);
        return dbResult > 0;
    }
}