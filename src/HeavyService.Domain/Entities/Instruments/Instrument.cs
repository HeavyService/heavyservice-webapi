using HeavyService.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace HeavyService.Domain.Entities.Instruments;

public class Instrument : AudiTable
{
    [MaxLength(30)]
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string ImagePath { get; set; } = string.Empty;
    public int PricePerDay { get; set; }
    public string Region { get; set; } = string.Empty;
    public string District { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public Status Status { get; set; }
    [MaxLength(13)]
    public string PhoneNumber { get; set; } = string.Empty;
    public long UserId { get; set; }
}
