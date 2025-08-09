using System;
using System.Collections.Generic;

namespace PremaritalCounseling.Repository.Models;

public partial class QuestionOption
{
    public long Id { get; set; }

    public string Content { get; set; } = null!;

    public bool IsCorrect { get; set; }

    public long QuestionId { get; set; }

    public string? Explanation { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? ModifiedAt { get; set; }

    public string? CreatedBy { get; set; }

    public string? ModifiedBy { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public virtual Question Question { get; set; } = null!;
}
