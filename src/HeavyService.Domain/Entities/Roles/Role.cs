using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeavyService.Domain.Entities.Roles;

public class Role : AudiTable
{
    [MaxLength(30)]
    public string Name { get; set; } = string.Empty;
}
