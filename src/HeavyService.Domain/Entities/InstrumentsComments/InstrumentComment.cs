﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeavyService.Domain.Entities.InstrumentsComments;

public class InstrumentComment : AudiTable
{
    public long UserId { get; set; }

    public long InstrumentId { get; set; }

    public long ReplayId { get; set; }

    public string Comment { get; set; } = string.Empty;

    public bool IsEdited { get; set; }
}