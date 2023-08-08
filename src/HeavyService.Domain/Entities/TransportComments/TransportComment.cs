using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeavyService.Domain.Entities.TransportComments;

public class TransportComment
{
    public long UserId { get; set; }

    public long TransportId { get; set; }

    public long ReplayId { get; set; }

    public string Comment { get; set; } = string.Empty;

    public bool IsEdited { get; set; }
}
