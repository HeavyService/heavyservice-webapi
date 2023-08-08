﻿using HeavyService.Domain.Entities;
using HeavyService.Domain.Enums;

namespace HeavyService.DataAccess.ViewModels;

public class TransportViewModel : AudiTable
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string ImagePath { get; set; } = string.Empty;
    public int PricePerHours { get; set; }
    public string District { get; set; } = string.Empty;
    public string Region { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public Status Status { get; set; }
}
