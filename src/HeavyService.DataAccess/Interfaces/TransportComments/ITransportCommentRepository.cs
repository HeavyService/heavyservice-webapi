using HeavyService.DataAccess.Common.Interfaces;
using HeavyService.DataAccess.ViewModels;
using HeavyService.Domain.Entities.TransportComments;

namespace HeavyService.DataAccess.Interfaces.TransportComments;

public interface ITransportCommentRepository : IRepository<TransportComment, TransportCommentViewmodel>,
    IGetAll<TransportCommentViewmodel>
{}
