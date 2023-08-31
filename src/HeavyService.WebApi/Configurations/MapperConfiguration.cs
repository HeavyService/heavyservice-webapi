using AutoMapper;
using HeavyService.Domain.Entities.Instruments;
using HeavyService.Persistance.Dtos.Instruments;

namespace HeavyService.WebApi.Configurations;

public class MapperConfiguration : Profile
{
    public MapperConfiguration()
    {
        CreateMap<InstrumentCreateDto, Instrument>().ReverseMap()
            .ForMember(x => x.ImagePath.Name, y => y.MapFrom(obj => obj.ImagePath));
        CreateMap<InstrumentUpdateDto, Instrument>().ReverseMap();
    }
}