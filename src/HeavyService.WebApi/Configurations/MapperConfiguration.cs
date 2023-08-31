using AutoMapper;
using HeavyService.Persistance.Dtos.Instruments;
using System.Diagnostics.Metrics;

namespace HeavyService.WebApi.Configurations;

public class MapperConfiguration : Profile
{
    public MapperConfiguration()
    {
        CreateMap<InstrumentCreateDto, Instrument>().ReverseMap();
        CreateMap<InstrumentUpdateDto, Instrument>().ReverseMap();
    }
}