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
using HeavyService.Service.Interfaces.TransportComments;
using HeavyService.Service.Interfaces.Users;
using Microsoft.AspNetCore.Server.IIS.Core;

namespace HeavyService.Service.Services.TransportComments;
public class TransportCommentService : ITransportCommentService
{
    private readonly ITransportCommentRepository _repository;
    private readonly ITransportRepository _transrepository;
    private readonly IIdentityService _service;
    public TransportCommentService(ITransportCommentRepository repository,
        ITransportRepository transrepository,
        IIdentityService service)
    {
        this._repository = repository;
        this._transrepository = transrepository;
    private readonly IIdentityService _service;
    public TransportCommentService(ITransportCommentRepository repository,
        IIdentityService service)
    {
        this._repository = repository;
        this._service = service;
    }
    public async Task<long> CountAsync() => await _repository.CountAsync();
    public async Task<bool> CreateAsync(long transportId, TransportCommentDto dto)
    {
        var trans = await _transrepository.GetIdAsync(transportId);
        var trans = await _repository.GetByIdAsync(transportId);
        if (trans is not null)
        {
            TransportComment comment = new TransportComment()
            {
                UserId = _service.UserId,
                TransportId = transportId,
                ReplayId = dto.ReplyId,
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

        return result;
    }
    public async Task<TransportCommentViewmodel> GetByIdAsync(long id)
    {
        var comment = await _repository.GetByIdAsync(id);
        if (comment is null) throw new CommentNotFoundExeption();

        return comment;
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
        transportcomment.UserId = _service.UserId;
        transportcomment.ReplayId = dto.ReplyId;
        transportcomment.Comment = dto.Comment;
        transportcomment.UpdatedAt = TimeHelper.GetDateTime();
        var dbResult = await _repository.UpdateAsync(transportId, transportcomment);

        transportcomment.ReplyId = dto.ReplyId;
        transportcomment.Comment = dto.Comment;
        transportcomment.UpdatedAt = TimeHelper.GetDateTime();
        var dbResult = await _repository.UpdateAsync(transportId, transportcomment);
        return dbResult > 0;
    }
}