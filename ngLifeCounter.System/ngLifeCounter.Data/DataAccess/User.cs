using System;
using System.Collections.Generic;

namespace ngLifeCounter.Data.DataAccess;

public partial class User
{
    public Guid Id { get; set; }

    public string UserName { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string Salt { get; set; } = null!;

    public string Email { get; set; } = null!;

    public bool AllowSysAdminAccess { get; set; }

    public DateTime CreationDate { get; set; }

    public virtual ICollection<EventCounter> EventCounters { get; set; } = new List<EventCounter>();

    public virtual ICollection<PersonalProfile> PersonalProfiles { get; set; } = new List<PersonalProfile>();

    public virtual ICollection<Relapse> Relapses { get; set; } = new List<Relapse>();
}
