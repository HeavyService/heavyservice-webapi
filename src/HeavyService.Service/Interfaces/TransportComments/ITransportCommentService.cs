﻿using HeavyService.Application.Utils;
using HeavyService.Domain.Entities.TransportComments;
using HeavyService.Persistance.Dtos.TransportComments;

namespace HeavyService.Service.Interfaces.TransportComments;

public interface ITransportCommentService
{
    public Task<bool> CreateAsync(long transportId,TransportCommentDto dto);
    public Task<bool> DeleteAsync(long transportId);
    public Task<long> CountAsync();
    public Task<TransportComment> GetAllAsync(Paginationparams @params);
    public Task<TransportComment> GetByIdAsync(long id);
    public Task<bool> UpdateAsync(long transportId,TransportCommentDto dto);
}