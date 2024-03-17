﻿using System;
using System.Collections.Generic;

namespace ngLifeCounter.Data.DataAccess;

public partial class ResetLoginPassword
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public DateTime CreationDate { get; set; }

    public DateTime ExpirationDate { get; set; }

    public virtual User User { get; set; } = null!;
}
