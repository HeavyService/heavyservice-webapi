using HeavyService.Application.Utils;
using HeavyService.DataAccess.ViewModels;
using HeavyService.Domain.Entities.TransportComments;
using HeavyService.Persistance.Dtos.TransportComments;
using HeavyService.Service.Interfaces.TransportComments;

namespace HeavyService.Service.Services.TransportComments;

public class TransportCommentService : ITransportCommentService
{
    public Task<long> CountAsync()
    {
        throw new NotImplementedException();
    }

    public Task<bool> CreateAsync(long transportId, TransportCommentDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(long transportId)
    {
        throw new NotImplementedException();
    }

    public Task<TransportComment> GetAllAsync(long transportId)
    {
        throw new NotImplementedException();
    }

    public Task<TransportComment> GetAllAsync(Paginationparams @params)
    {
        throw new NotImplementedException();
    }

    public Task<TransportComment> GetByIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateAsync(long transportId, TransportCommentDto dto)
    {
        throw new NotImplementedException();
    }

    Task<TransportCommentViewmodel> ITransportCommentService.GetAllAsync(Paginationparams @params)
    {
        throw new NotImplementedException();
    }

    Task<TransportCommentViewmodel> ITransportCommentService.GetByIdAsync(long id)
    {
        throw new NotImplementedException();
    }
}
