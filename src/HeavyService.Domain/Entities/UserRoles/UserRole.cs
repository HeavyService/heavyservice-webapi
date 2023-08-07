using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeavyService.Domain.Entities.UserRoles;

public class UserRole : AudiTable
{
    public long UserId { get; set; }

    public long RoleId { get; set; }

}
