using HeavyService.Application.Utils;
using HeavyService.DataAccess.Interfaces.Transports;
using HeavyService.DataAccess.ViewModels;
using HeavyService.Domain.Entities.TransportComments;
using HeavyService.Persistance.Dtos.TransportComments;
using HeavyService.Service.Interfaces.Commons;
using HeavyService.Service.Interfaces.TransportComments;

namespace HeavyService.Service.Services.TransportComments;

public class TransportCommentService : ITransportCommentService
{
    private readonly ITransportRepository _repository;
    private readonly IPaginator _paginator;

    public TransportCommentService(ITransportRepository repository,
        IPaginator paginator)
    {
        this._repository = repository;
        this._paginator = paginator;
    }
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