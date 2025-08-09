using System;
using System.Collections.Generic;

namespace PremaritalCounseling.Repository.Models;

public partial class QuizResult
{
    public long Id { get; set; }

    public long Score { get; set; }

    public long QuizId { get; set; }

    public long UserId { get; set; }

    public string QuizResultCode { get; set; } = null!;

    public double TimeCompleted { get; set; }

    public long AttemptTime { get; set; }

    public string? SuggestionContent { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? ModifiedAt { get; set; }

    public string? CreatedBy { get; set; }

    public string? ModifiedBy { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public virtual Quiz Quiz { get; set; } = null!;

    public virtual ICollection<QuizResultDetail> QuizResultDetails { get; set; } = new List<QuizResultDetail>();

    public virtual User User { get; set; } = null!;
}
