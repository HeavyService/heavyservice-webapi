using HeavyService.DataAccess.Common.Interfaces;
using HeavyService.DataAccess.ViewModels;
using HeavyService.Domain.Entities.InstrumentsComments;

namespace HeavyService.DataAccess.Interfaces.InstrumentComments
{
    public interface IInstrumentComment : IRepository<InstrumentComment, InstrumentCommentViewModel>, IGetAll<InstrumentCommentViewModel>
    {

    }
}
