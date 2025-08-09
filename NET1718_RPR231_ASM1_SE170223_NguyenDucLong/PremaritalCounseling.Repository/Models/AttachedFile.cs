using System;
using System.Collections.Generic;

namespace PremaritalCounseling.Repository.Models;

public partial class AttachedFile
{
    public long Id { get; set; }

    public string Type { get; set; } = null!;

    public string ReferedLink { get; set; } = null!;

    public long? FeedbackId { get; set; }

    public long? ScheduleId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? ModifiedAt { get; set; }

    public string? CreatedBy { get; set; }

    public string? ModifiedBy { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public virtual Feedback? Feedback { get; set; }

    public virtual Schedule? Schedule { get; set; }
}
