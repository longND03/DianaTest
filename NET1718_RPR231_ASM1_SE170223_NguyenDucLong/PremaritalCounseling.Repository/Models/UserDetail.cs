using System;
using System.Collections.Generic;

namespace PremaritalCounseling.Repository.Models;

public partial class UserDetail
{
    public long Id { get; set; }

    public string Summary { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? ReferedLink { get; set; }

    public string? AttachedDocument { get; set; }

    public string? Image { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public long CategoryId { get; set; }

    public long UserId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? ModifiedAt { get; set; }

    public string? CreatedBy { get; set; }

    public string? ModifiedBy { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public virtual UserDetailCategory Category { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
