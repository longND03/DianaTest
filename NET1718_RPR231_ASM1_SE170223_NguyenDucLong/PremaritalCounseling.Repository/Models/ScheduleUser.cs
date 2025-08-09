using System;
using System.Collections.Generic;

namespace PremaritalCounseling.Repository.Models;

public partial class ScheduleUser
{
    public long Id { get; set; }

    public long CustomerId { get; set; }

    public long ScheduleId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? ModifiedAt { get; set; }

    public string? CreatedBy { get; set; }

    public string? ModifiedBy { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public virtual User Customer { get; set; } = null!;

    public virtual Schedule Schedule { get; set; } = null!;
}
