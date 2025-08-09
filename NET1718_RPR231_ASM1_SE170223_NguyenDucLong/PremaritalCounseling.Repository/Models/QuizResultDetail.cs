using System;
using System.Collections.Generic;

namespace PremaritalCounseling.Repository.Models;

public partial class QuizResultDetail
{
    public long Id { get; set; }

    public long QuizResultId { get; set; }

    public string UserAnswer { get; set; } = null!;

    public string RecommendedAnswer { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public DateTime? ModifiedAt { get; set; }

    public string? CreatedBy { get; set; }

    public string? ModifiedBy { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public virtual QuizResult QuizResult { get; set; } = null!;
}
