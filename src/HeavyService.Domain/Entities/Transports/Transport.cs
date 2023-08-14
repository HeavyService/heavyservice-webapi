using HeavyService.Domain.Enums;

namespace HeavyService.Domain.Entities.Transports;
public class Transport : AudiTable
{
    public long UserId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string ImagePath { get; set; } = string.Empty;
    public int PricePerHours { get; set; }
    public string District { get; set; } = string.Empty;
    public string Region { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public Status Status { get; set; }
    public string PhoneNumber { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}