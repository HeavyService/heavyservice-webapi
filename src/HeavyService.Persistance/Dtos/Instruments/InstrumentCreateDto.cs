using HeavyService.Domain.Enums;
using Microsoft.AspNetCore.Http;

namespace HeavyService.Persistance.Dtos.Instruments;

public class InstrumentCreateDto
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public IFormFile ImagePath { get; set; } = default!;
    public int PricePerDay { get; set; }
    public string Region { get; set; } = string.Empty;
    public string District { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public Status Status { get; set; }
    public string PhoneNumber { get; set; } = string.Empty;
}