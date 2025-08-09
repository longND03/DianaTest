using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PremaritalCounseling.Repository.Models;

namespace PremaritalCounseling.Repository.DBContext;

public partial class Net1718Prn231PrjG2PremaritalCounselingContext : DbContext
{
    public Net1718Prn231PrjG2PremaritalCounselingContext()
    {
    }

    public Net1718Prn231PrjG2PremaritalCounselingContext(DbContextOptions<Net1718Prn231PrjG2PremaritalCounselingContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AttachedFile> AttachedFiles { get; set; }

    public virtual DbSet<Feedback> Feedbacks { get; set; }

    public virtual DbSet<FeedbackType> FeedbackTypes { get; set; }

    public virtual DbSet<Post> Posts { get; set; }

    public virtual DbSet<PostType> PostTypes { get; set; }

    public virtual DbSet<Question> Questions { get; set; }

    public virtual DbSet<QuestionOption> QuestionOptions { get; set; }

    public virtual DbSet<Quiz> Quizzes { get; set; }

    public virtual DbSet<QuizResult> QuizResults { get; set; }

    public virtual DbSet<QuizResultDetail> QuizResultDetails { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Schedule> Schedules { get; set; }

    public virtual DbSet<ScheduleType> ScheduleTypes { get; set; }

    public virtual DbSet<ScheduleUser> ScheduleUsers { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<ServiceCategory> ServiceCategories { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserDetail> UserDetails { get; set; }

    public virtual DbSet<UserDetailCategory> UserDetailCategories { get; set; }

    public static string GetConnectionString(string connectionStringName)
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();

        string connectionString = config.GetConnectionString(connectionStringName);
        return connectionString;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(GetConnectionString("DefaultConnection"));

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=LAPTOP-I16M506G\\LONGSE; uid=sa; pwd=12345; database=NET1718_PRN231_PRJ_G2_PremaritalCounseling; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AttachedFile>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("attached_file_id_primary");

            entity.ToTable("Attached_File");

            entity.HasIndex(e => e.ScheduleId, "IX_Attached_File_ScheduleId");

            entity.HasIndex(e => e.FeedbackId, "IX_Attached_File_feedback_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.FeedbackId).HasColumnName("feedback_id");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");
            entity.Property(e => e.ModifiedAt)
                .HasColumnType("datetime")
                .HasColumnName("modified_at");
            entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");
            entity.Property(e => e.ReferedLink)
                .HasColumnType("text")
                .HasColumnName("refered_link");
            entity.Property(e => e.Type)
                .HasMaxLength(255)
                .HasColumnName("type");

            entity.HasOne(d => d.Feedback).WithMany(p => p.AttachedFiles)
                .HasForeignKey(d => d.FeedbackId)
                .HasConstraintName("attached_file_feedback_id_foreign");

            entity.HasOne(d => d.Schedule).WithMany(p => p.AttachedFiles)
                .HasForeignKey(d => d.ScheduleId)
                .HasConstraintName("attached_file_schedule_id_foreign");
        });

        modelBuilder.Entity<Feedback>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("feedback_id_primary");

            entity.ToTable("Feedback");

            entity.HasIndex(e => e.ServiceId, "IX_Feedback_service_id");

            entity.HasIndex(e => e.TypeId, "IX_Feedback_type_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Content)
                .HasColumnType("text")
                .HasColumnName("content");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");
            entity.Property(e => e.ModifiedAt)
                .HasColumnType("datetime")
                .HasColumnName("modified_at");
            entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");
            entity.Property(e => e.Rating).HasColumnName("rating");
            entity.Property(e => e.ServiceId).HasColumnName("service_id");
            entity.Property(e => e.TypeId).HasColumnName("type_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.UserName)
                .HasMaxLength(255)
                .HasColumnName("user_name");

            entity.HasOne(d => d.Service).WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.ServiceId)
                .HasConstraintName("feedback_service_id_foreign");

            entity.HasOne(d => d.Type).WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.TypeId)
                .HasConstraintName("feedback_type_id_foreign");
        });

        modelBuilder.Entity<FeedbackType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("feedback_type_id_primary");

            entity.ToTable("Feedback_Type");

            entity.HasIndex(e => e.Name, "feedback_type_name_unique").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");
            entity.Property(e => e.ModifiedAt)
                .HasColumnType("datetime")
                .HasColumnName("modified_at");
            entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("post_id_primary");

            entity.ToTable("Post");

            entity.HasIndex(e => e.TypeId, "IX_Post_type_id");

            entity.HasIndex(e => e.UserId, "IX_Post_user_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Content)
                .HasColumnType("text")
                .HasColumnName("content");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");
            entity.Property(e => e.ModifiedAt)
                .HasColumnType("datetime")
                .HasColumnName("modified_at");
            entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");
            entity.Property(e => e.Title).HasColumnName("title");
            entity.Property(e => e.TypeId).HasColumnName("type_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.UserName)
                .HasMaxLength(255)
                .HasColumnName("user_name");
            entity.Property(e => e.View).HasColumnName("view");

            entity.HasOne(d => d.Type).WithMany(p => p.Posts)
                .HasForeignKey(d => d.TypeId)
                .HasConstraintName("post_type_id_foreign");

            entity.HasOne(d => d.User).WithMany(p => p.Posts)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("post_user_id_foreign");
        });

        modelBuilder.Entity<PostType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("post_type_id_primary");

            entity.ToTable("Post_Type");

            entity.HasIndex(e => e.Name, "post_type_name_unique").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");
            entity.Property(e => e.ModifiedAt)
                .HasColumnType("datetime")
                .HasColumnName("modified_at");
            entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Question>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("question_id_primary");

            entity.ToTable("Question");

            entity.HasIndex(e => e.QuizId, "IX_Question_QuizId");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Content)
                .HasColumnType("text")
                .HasColumnName("content");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.Image)
                .HasColumnType("text")
                .HasColumnName("image");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");
            entity.Property(e => e.ModifiedAt)
                .HasColumnType("datetime")
                .HasColumnName("modified_at");
            entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");
            entity.Property(e => e.QuestionType).HasColumnName("question_type");
            entity.Property(e => e.RecommendedAnswer)
                .HasColumnType("text")
                .HasColumnName("recommended_answer");

            entity.HasOne(d => d.Quiz).WithMany(p => p.Questions)
                .HasForeignKey(d => d.QuizId)
                .HasConstraintName("question_id_foreign");
        });

        modelBuilder.Entity<QuestionOption>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("question_option_id_primary");

            entity.ToTable("Question_Option");

            entity.HasIndex(e => e.QuestionId, "IX_Question_Option_question_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Content)
                .HasColumnType("text")
                .HasColumnName("content");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.Explanation)
                .HasColumnType("text")
                .HasColumnName("explanation");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.IsCorrect).HasColumnName("is_correct");
            entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");
            entity.Property(e => e.ModifiedAt)
                .HasColumnType("datetime")
                .HasColumnName("modified_at");
            entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");
            entity.Property(e => e.QuestionId).HasColumnName("question_id");

            entity.HasOne(d => d.Question).WithMany(p => p.QuestionOptions)
                .HasForeignKey(d => d.QuestionId)
                .HasConstraintName("question_option_id_foreign");
        });

        modelBuilder.Entity<Quiz>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("quiz_id_primary");

            entity.ToTable("Quiz");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AvgTimeCompleted).HasColumnName("avg_time_completed");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.Difficulty)
                .HasMaxLength(255)
                .HasColumnName("difficulty");
            entity.Property(e => e.Duration).HasColumnName("duration");
            entity.Property(e => e.DurationUnit)
                .HasMaxLength(255)
                .HasColumnName("duration_unit");
            entity.Property(e => e.Image)
                .HasColumnType("text")
                .HasColumnName("image");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");
            entity.Property(e => e.ModifiedAt)
                .HasColumnType("datetime")
                .HasColumnName("modified_at");
            entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");
            entity.Property(e => e.PassScore).HasColumnName("pass_score");
            entity.Property(e => e.Tags)
                .HasColumnType("text")
                .HasColumnName("tags");
            entity.Property(e => e.Title)
                .HasColumnType("text")
                .HasColumnName("title");
        });

        modelBuilder.Entity<QuizResult>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("quiz_result_id_primary");

            entity.ToTable("Quiz_Result");

            entity.HasIndex(e => e.QuizId, "IX_Quiz_Result_quiz_id");

            entity.HasIndex(e => e.UserId, "IX_Quiz_Result_user_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AttemptTime).HasColumnName("attempt_time");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");
            entity.Property(e => e.ModifiedAt)
                .HasColumnType("datetime")
                .HasColumnName("modified_at");
            entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");
            entity.Property(e => e.QuizId).HasColumnName("quiz_id");
            entity.Property(e => e.QuizResultCode)
                .HasMaxLength(255)
                .HasColumnName("quiz_result_code");
            entity.Property(e => e.Score).HasColumnName("score");
            entity.Property(e => e.SuggestionContent)
                .HasColumnType("text")
                .HasColumnName("suggestion_content");
            entity.Property(e => e.TimeCompleted).HasColumnName("time_completed");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Quiz).WithMany(p => p.QuizResults)
                .HasForeignKey(d => d.QuizId)
                .HasConstraintName("quiz_result_quiz_id_foreign");

            entity.HasOne(d => d.User).WithMany(p => p.QuizResults)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("quiz_result_user_id_foreign");
        });

        modelBuilder.Entity<QuizResultDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("quiz_result_detail_id_primary");

            entity.ToTable("Quiz_Result_Detail");

            entity.HasIndex(e => e.QuizResultId, "IX_Quiz_Result_Detail_quiz_result_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");
            entity.Property(e => e.ModifiedAt)
                .HasColumnType("datetime")
                .HasColumnName("modified_at");
            entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");
            entity.Property(e => e.QuizResultId).HasColumnName("quiz_result_id");
            entity.Property(e => e.RecommendedAnswer)
                .HasColumnType("text")
                .HasColumnName("recommended_answer");
            entity.Property(e => e.UserAnswer)
                .HasColumnType("text")
                .HasColumnName("user_answer");

            entity.HasOne(d => d.QuizResult).WithMany(p => p.QuizResultDetails)
                .HasForeignKey(d => d.QuizResultId)
                .HasConstraintName("quiz_result_detail_quiz_result_id_foreign");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("role_id_primary");

            entity.ToTable("Role");

            entity.HasIndex(e => e.Name, "role_name_unique").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");
            entity.Property(e => e.ModifiedAt)
                .HasColumnType("datetime")
                .HasColumnName("modified_at");
            entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Schedule>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("schedule_id_primary");

            entity.ToTable("Schedule");

            entity.HasIndex(e => e.ScheduleTypeId, "IX_Schedule_schedule_type_id");

            entity.HasIndex(e => e.ServiceId, "IX_Schedule_service_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AppointmentMode)
                .HasMaxLength(255)
                .HasColumnName("appointment_mode");
            entity.Property(e => e.CompletedAt).HasColumnName("completed_at");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.CustomerNote)
                .HasColumnType("text")
                .HasColumnName("customer_note");
            entity.Property(e => e.ExpertNote)
                .HasColumnType("text")
                .HasColumnName("expert_note");
            entity.Property(e => e.ExpertResponse)
                .HasColumnType("text")
                .HasColumnName("expert_response");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");
            entity.Property(e => e.Location)
                .HasColumnType("text")
                .HasColumnName("location");
            entity.Property(e => e.ModifiedAt)
                .HasColumnType("datetime")
                .HasColumnName("modified_at");
            entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");
            entity.Property(e => e.Priority)
                .HasMaxLength(255)
                .HasColumnName("priority");
            entity.Property(e => e.ReferedLink)
                .HasColumnType("text")
                .HasColumnName("refered_link");
            entity.Property(e => e.ReminderSent).HasColumnName("reminder_sent");
            entity.Property(e => e.RescheduledCount).HasColumnName("rescheduled_count");
            entity.Property(e => e.RescheduledTime)
                .HasColumnType("datetime")
                .HasColumnName("rescheduled_time");
            entity.Property(e => e.ScheduleTypeId).HasColumnName("schedule_type_id");
            entity.Property(e => e.ServiceId).HasColumnName("service_id");
            entity.Property(e => e.Time)
                .HasColumnType("datetime")
                .HasColumnName("time");

            entity.HasOne(d => d.ScheduleType).WithMany(p => p.Schedules)
                .HasForeignKey(d => d.ScheduleTypeId)
                .HasConstraintName("schedule_schedule_type_id_foreign");

            entity.HasOne(d => d.Service).WithMany(p => p.Schedules)
                .HasForeignKey(d => d.ServiceId)
                .HasConstraintName("schedule_service_id_foreign");
        });

        modelBuilder.Entity<ScheduleType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("schedule_type_id_primary");

            entity.ToTable("Schedule_Type");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Buffer).HasColumnName("buffer");
            entity.Property(e => e.BufferUnit)
                .HasMaxLength(255)
                .HasColumnName("buffer_unit");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.EndDate).HasColumnName("end_date");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");
            entity.Property(e => e.ModifiedAt)
                .HasColumnType("datetime")
                .HasColumnName("modified_at");
            entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.StartDate).HasColumnName("start_date");
        });

        modelBuilder.Entity<ScheduleUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("schedule_user_id_primary");

            entity.ToTable("Schedule_User");

            entity.HasIndex(e => e.CustomerId, "IX_Schedule_User_customer_id");

            entity.HasIndex(e => e.ScheduleId, "IX_Schedule_User_schedule_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");
            entity.Property(e => e.ModifiedAt)
                .HasColumnType("datetime")
                .HasColumnName("modified_at");
            entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");
            entity.Property(e => e.ScheduleId).HasColumnName("schedule_id");

            entity.HasOne(d => d.Customer).WithMany(p => p.ScheduleUsers)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("schedule_user_customer_id_foreign");

            entity.HasOne(d => d.Schedule).WithMany(p => p.ScheduleUsers)
                .HasForeignKey(d => d.ScheduleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("schedule_user_schedule_id_foreign");
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("service_id_primary");

            entity.ToTable("Service");

            entity.HasIndex(e => e.CategoryId, "IX_Service_category_id");

            entity.HasIndex(e => e.ExpertId, "IX_Service_expert_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AvgRating).HasColumnName("avg_rating");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.Commission).HasColumnName("commission");
            entity.Property(e => e.CommissionRate).HasColumnName("commission_rate");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.Currency)
                .HasMaxLength(255)
                .HasColumnName("currency");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.DurationUnit)
                .HasMaxLength(255)
                .HasColumnName("duration_unit");
            entity.Property(e => e.EstimatedDuration).HasColumnName("estimated_duration");
            entity.Property(e => e.ExpertId).HasColumnName("expert_id");
            entity.Property(e => e.Image)
                .HasColumnType("text")
                .HasColumnName("image");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");
            entity.Property(e => e.ModifiedAt)
                .HasColumnType("datetime")
                .HasColumnName("modified_at");
            entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.ServiceCode).HasColumnName("service_code");

            entity.HasOne(d => d.Category).WithMany(p => p.Services)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("service_category_id_foreign");

            entity.HasOne(d => d.Expert).WithMany(p => p.Services)
                .HasForeignKey(d => d.ExpertId)
                .HasConstraintName("service_expert_id_foreign");
        });

        modelBuilder.Entity<ServiceCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("service_category_id_primary");

            entity.ToTable("Service_Category");

            entity.HasIndex(e => e.Name, "service_category_name_unique").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CategoryCode)
                .HasMaxLength(255)
                .HasColumnName("category_code");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.Image)
                .HasColumnType("text")
                .HasColumnName("image");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");
            entity.Property(e => e.ModifiedAt)
                .HasColumnType("datetime")
                .HasColumnName("modified_at");
            entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("user_id_primary");

            entity.ToTable("User");

            entity.HasIndex(e => e.PartnerId, "IX_User_partner_id")
                .IsUnique()
                .HasFilter("([partner_id] IS NOT NULL)");

            entity.HasIndex(e => e.RoleId, "IX_User_role_id");

            entity.HasIndex(e => e.UserName, "user_user_name_unique").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ApplicationCode)
                .HasMaxLength(255)
                .HasColumnName("application_code");
            entity.Property(e => e.Avatar)
                .HasColumnType("text")
                .HasColumnName("avatar");
            entity.Property(e => e.BackgroundImg)
                .HasColumnType("text")
                .HasColumnName("background_img");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.EmployeeCode)
                .HasMaxLength(255)
                .HasColumnName("employee_code");
            entity.Property(e => e.FullName)
                .HasMaxLength(255)
                .HasColumnName("full_name");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");
            entity.Property(e => e.ModifiedAt)
                .HasColumnType("datetime")
                .HasColumnName("modified_at");
            entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");
            entity.Property(e => e.PartnerId).HasColumnName("partner_id");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");
            entity.Property(e => e.Phone)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("phone");
            entity.Property(e => e.RequestCode)
                .HasMaxLength(255)
                .HasColumnName("request_code");
            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.UserName)
                .HasMaxLength(255)
                .HasColumnName("user_name");

            entity.HasOne(d => d.Partner).WithOne(p => p.InversePartner)
                .HasForeignKey<User>(d => d.PartnerId)
                .HasConstraintName("user_partner_id_foreign");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("user_role_id_foreign");
        });

        modelBuilder.Entity<UserDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("user_detail_id_primary");

            entity.ToTable("User_Detail");

            entity.HasIndex(e => e.CategoryId, "IX_User_Detail_category_id");

            entity.HasIndex(e => e.UserId, "IX_User_Detail_user_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AttachedDocument)
                .HasColumnType("text")
                .HasColumnName("attached_document");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.EndDate)
                .HasColumnType("datetime")
                .HasColumnName("end_date");
            entity.Property(e => e.Image)
                .HasColumnType("text")
                .HasColumnName("image");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");
            entity.Property(e => e.ModifiedAt)
                .HasColumnType("datetime")
                .HasColumnName("modified_at");
            entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");
            entity.Property(e => e.Name)
                .HasColumnType("text")
                .HasColumnName("name");
            entity.Property(e => e.ReferedLink)
                .HasColumnType("text")
                .HasColumnName("refered_link");
            entity.Property(e => e.StartDate)
                .HasColumnType("datetime")
                .HasColumnName("start_date");
            entity.Property(e => e.Summary)
                .HasColumnType("text")
                .HasColumnName("summary");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Category).WithMany(p => p.UserDetails)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("user_detail_category_id_foreign");

            entity.HasOne(d => d.User).WithMany(p => p.UserDetails)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("user_detail_user_id_foreign");
        });

        modelBuilder.Entity<UserDetailCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("user_detail_category_id_primary");

            entity.ToTable("User_Detail_Category");

            entity.HasIndex(e => e.Name, "user_detail_category_name_unique").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.Image)
                .HasColumnType("text")
                .HasColumnName("image");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");
            entity.Property(e => e.ModifiedAt)
                .HasColumnType("datetime")
                .HasColumnName("modified_at");
            entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
