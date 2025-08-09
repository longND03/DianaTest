using System;
using System.Collections.Generic;

namespace PremaritalCounseling.Repository.Models;

public partial class Feedback
{
    public long Id { get; set; }

    public long UserId { get; set; }

    public string UserName { get; set; } = null!;

    public short? Rating { get; set; }

    public long TypeId { get; set; }

    public string Content { get; set; } = null!;

    public long ServiceId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? ModifiedAt { get; set; }

    public string? CreatedBy { get; set; }

    public string? ModifiedBy { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<AttachedFile> AttachedFiles { get; set; } = new List<AttachedFile>();

    public virtual Service Service { get; set; } = null!;

    public virtual FeedbackType Type { get; set; } = null!;
}
