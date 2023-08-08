using HeavyService.DataAccess.Common.Interfaces;
using HeavyService.DataAccess.ViewModels;
using HeavyService.Domain.Entities.Transports;

namespace HeavyService.DataAccess.Interfaces.Transports
{
    public interface ITransportRepository : IRepository<Transport, TransportViewModel>, ISearch<TransportViewModel>,
        IGetAll<TransportViewModel>
    {

    }
}
