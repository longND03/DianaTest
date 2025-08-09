using System;
using System.Collections.Generic;

namespace PremaritalCounseling.Repository.Models;

public partial class User
{
    public long Id { get; set; }

    public string UserName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string FullName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string EmployeeCode { get; set; } = null!;

    public short RoleId { get; set; }

    public string RequestCode { get; set; } = null!;

    public string ApplicationCode { get; set; } = null!;

    public string? Avatar { get; set; }

    public string? BackgroundImg { get; set; }

    public string? RefreshToken { get; set; }

    public DateTime RefreshTokenExpiryTime { get; set; }

    public long? PartnerId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? ModifiedAt { get; set; }

    public string? CreatedBy { get; set; }

    public string? ModifiedBy { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public virtual User? InversePartner { get; set; }

    public virtual User? Partner { get; set; }

    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();

    public virtual ICollection<QuizResult> QuizResults { get; set; } = new List<QuizResult>();

    public virtual Role Role { get; set; } = null!;

    public virtual ICollection<ScheduleUser> ScheduleUsers { get; set; } = new List<ScheduleUser>();

    public virtual ICollection<Service> Services { get; set; } = new List<Service>();

    public virtual ICollection<UserDetail> UserDetails { get; set; } = new List<UserDetail>();
}
