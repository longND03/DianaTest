using System;
using System.Collections.Generic;

namespace PremaritalCounseling.Repository.Models;

public partial class Question
{
    public long Id { get; set; }

    public string? QuestionType { get; set; }

    public string Content { get; set; } = null!;

    public long QuizId { get; set; }

    public string? Image { get; set; }

    public string? RecommendedAnswer { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? ModifiedAt { get; set; }

    public string? CreatedBy { get; set; }

    public string? ModifiedBy { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<QuestionOption> QuestionOptions { get; set; } = new List<QuestionOption>();

    public virtual Quiz Quiz { get; set; } = null!;
}
