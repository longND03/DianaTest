using System;
using System.Collections.Generic;

namespace PremaritalCounseling.Repository.Models;

public partial class Service
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public double Price { get; set; }

    public string Currency { get; set; } = null!;

    public double? Commission { get; set; }

    public double? CommissionRate { get; set; }

    public double? EstimatedDuration { get; set; }

    public string? DurationUnit { get; set; }

    public long ExpertId { get; set; }

    public long CategoryId { get; set; }

    public string? Image { get; set; }

    public string ServiceCode { get; set; } = null!;

    public double? AvgRating { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? ModifiedAt { get; set; }

    public string? CreatedBy { get; set; }

    public string? ModifiedBy { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ServiceCategory Category { get; set; } = null!;

    public virtual User Expert { get; set; } = null!;

    public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();

    public virtual ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();
}
