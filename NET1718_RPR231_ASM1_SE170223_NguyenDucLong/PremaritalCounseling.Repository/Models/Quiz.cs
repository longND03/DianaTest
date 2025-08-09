using System;
using System.Collections.Generic;

namespace PremaritalCounseling.Repository.Models;

public partial class Quiz
{
    public long Id { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public string? Image { get; set; }

    public long? Duration { get; set; }

    public string? DurationUnit { get; set; }

    public double? AvgTimeCompleted { get; set; }

    public string? Tags { get; set; }

    public string? Difficulty { get; set; }

    public long? PassScore { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? ModifiedAt { get; set; }

    public string? CreatedBy { get; set; }

    public string? ModifiedBy { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<Question> Questions { get; set; } = new List<Question>();

    public virtual ICollection<QuizResult> QuizResults { get; set; } = new List<QuizResult>();
}
