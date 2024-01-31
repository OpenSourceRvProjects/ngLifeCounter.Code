using System;
using System.Collections.Generic;

namespace ngLifeCounter.Data.DataAccess;

public partial class EventCounter
{
    public Guid Id { get; set; }

    public string EventName { get; set; } = null!;

    public int StartDay { get; set; }

    public int StartMonth { get; set; }

    public long StartYear { get; set; }

    public int? Hour { get; set; }

    public int? Minutes { get; set; }

    public Guid UserId { get; set; }

    public Guid PersonalProfileId { get; set; }

    public virtual PersonalProfile PersonalProfile { get; set; } = null!;

    public virtual ICollection<Relapse> Relapses { get; set; } = new List<Relapse>();

    public virtual User User { get; set; } = null!;
}
