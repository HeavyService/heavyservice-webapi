﻿using HeavyService.Application.Exeptions.Comments;
using HeavyService.Application.Exeptions.Instruments;
using HeavyService.Application.Utils;
using HeavyService.DataAccess.Interfaces.InstrumentComments;
using HeavyService.DataAccess.ViewModels;
using HeavyService.Domain.Entities.InstrumentsComments;
using HeavyService.Persistance.Dtos.InstrumentComments;
using HeavyService.Persistance.Helpers;
using HeavyService.Service.Interfaces.InstrumentComments;

namespace HeavyService.Service.Services.InstrumentComments;
public class InstrumentCommentService : IInstrumentCommentService
{
    private readonly IInstrumentComment _repository;
    public InstrumentCommentService(IInstrumentComment instrumentrepository)
    {
        this._repository = instrumentrepository;
    }
    public async Task<long> CountAsync() => await _repository.CountAsync();
    public async Task<bool> CreateAsync(long instrumentId, InstrumentCommentCreateDto dto)
    {
        InstrumentComment comment = new InstrumentComment()
        {
            UserId = dto.UserId,
            ReplyId = dto.ReplyId,
            InstrumentId = instrumentId,
            Comment = dto.Comment,
            CreatedAt = TimeHelper.GetDateTime(),
            UpdatedAt = TimeHelper.GetDateTime()
        };
        var result = await _repository.CreateAsync(comment);
        return result > 0;
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
        return result;
    }
    public async Task<IList<InstrumentCommentViewModel>> GetByIdAsync(long id)
    {
        var comment = await _repository.GetByIdAsync(id);
        if (comment is null) throw new CommentNotFoundExeption();
        return (IList<InstrumentCommentViewModel>)comment;
    }
    public async Task<bool> UpdateAsync(long instrumentcommentId, InstrumentCommentCreateDto dto)
    {
        var instrumentcomment = await _repository.GetIdAsync(instrumentcommentId);
        if (instrumentcomment is null) throw new InstrumentNotFoundExeption();
        instrumentcomment.UserId = dto.UserId;
        instrumentcomment.ReplyId = dto.ReplyId;
        instrumentcomment.Comment = dto.Comment;
        instrumentcomment.UpdatedAt = TimeHelper.GetDateTime();
        var dbResult = await _repository.UpdateAsync(instrumentcommentId, instrumentcomment);
        return dbResult > 0;
    }
}