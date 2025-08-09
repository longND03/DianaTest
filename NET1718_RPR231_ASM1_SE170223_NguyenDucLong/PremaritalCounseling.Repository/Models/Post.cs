using System;
using System.Collections.Generic;

namespace PremaritalCounseling.Repository.Models;

public partial class Post
{
    public long Id { get; set; }

    public long UserId { get; set; }

    public string UserName { get; set; } = null!;

    public string Content { get; set; } = null!;

    public long TypeId { get; set; }

    public long? View { get; set; }

    public string Title { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public DateTime? ModifiedAt { get; set; }

    public string? CreatedBy { get; set; }

    public string? ModifiedBy { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public virtual PostType Type { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
