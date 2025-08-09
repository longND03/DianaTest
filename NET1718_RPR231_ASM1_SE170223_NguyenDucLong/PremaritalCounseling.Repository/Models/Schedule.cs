using System;
using System.Collections.Generic;

namespace PremaritalCounseling.Repository.Models;

public partial class Schedule
{
    public long Id { get; set; }

    public long ServiceId { get; set; }

    public DateTime? CompletedAt { get; set; }

    public DateTime Time { get; set; }

    public long ScheduleTypeId { get; set; }

    public string? ExpertNote { get; set; }

    public string? ReferedLink { get; set; }

    public string? CustomerNote { get; set; }

    public string? ExpertResponse { get; set; }

    public DateTime? RescheduledTime { get; set; }

    public short RescheduledCount { get; set; }

    public string? AppointmentMode { get; set; }

    public string? Location { get; set; }

    public string? Priority { get; set; }

    public bool ReminderSent { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? ModifiedAt { get; set; }

    public string? CreatedBy { get; set; }

    public string? ModifiedBy { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<AttachedFile> AttachedFiles { get; set; } = new List<AttachedFile>();

    public virtual ScheduleType ScheduleType { get; set; } = null!;

    public virtual ICollection<ScheduleUser> ScheduleUsers { get; set; } = new List<ScheduleUser>();

    public virtual Service Service { get; set; } = null!;
}
