using HeavyService.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeavyService.Domain.Entities.Transports;

public class Transport : AudiTable
{
    public long UserId { get; set; }

    [MaxLength(30)]
    public string Name { get; set; } = string.Empty;

    public string ImagePath { get; set; } = string.Empty;

    public int PricePerHours { get; set; }

    public string District { get; set; } = string.Empty;

    public string Region { get; set; } = string.Empty;

    public string Address { get; set; } = string.Empty;

    public Status Status { get; set; }

    [MaxLength(13)]
    public string PhoneNumber { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;
}
