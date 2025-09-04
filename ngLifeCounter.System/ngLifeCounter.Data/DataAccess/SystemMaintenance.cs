using System;
using System.Collections.Generic;

namespace ngLifeCounter.Data.DataAccess;

public partial class SystemMaintenance
{
    public Guid Id { get; set; }

    public bool IsOnMaintenance { get; set; }
}
