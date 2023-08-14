using HeavyService.DataAccess.Common.Interfaces;
using HeavyService.DataAccess.ViewModels;
using HeavyService.Domain.Entities.Instruments;

namespace HeavyService.DataAccess.Interfaces.Instruments
{
    public interface IInstrumentRepository : IRepository<Instrument, InstrumentViewModel>, ISearch<InstrumentViewModel>,
        IGetAll<InstrumentViewModel>
    {}
}