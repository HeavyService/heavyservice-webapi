using HeavyService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeavyService.Domain.ViewModels;

public class UserViewModel : AudiTable
{
    [MaxLength(30)]
    public string FirstName { get; set; } = string.Empty;


    [MaxLength(30)]
    public string LastName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;
}
