namespace ApplicantsSystem.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class ApplicantsSystemDbContext : IdentityDbContext<User>
    {
        public ApplicantsSystemDbContext(DbContextOptions<ApplicantsSystemDbContext> options)
            : base(options)
        {
        }

        public DbSet<Applicant> Applicants { get; set; }

        public DbSet<Test> Tests { get; set; }
        
        public DbSet<Feedback> Feedbacks { get; set; }

        public DbSet<Interview> Interviews { get; set; }

        public DbSet<AplicantStatus> AplicantStatuses { get; set; }

        public DbSet<Status> Statuses { get; set; }

        public DbSet<InterviewInterviewer> InterviewInterviewers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Applicant>()
                .HasIndex(a => a.Email)
                .IsUnique();

            builder.Entity<InterviewInterviewer>()
                .HasOne(ii => ii.Interview)
                .WithMany(i => i.Interviewers)
                .HasForeignKey(ii => ii.InterviewId);

            builder.Entity<InterviewInterviewer>()
                .HasOne(ii => ii.Interviewer)
                .WithMany(i => i.Interviews)
                .HasForeignKey(ii => ii.InterviewerId);

            builder.Entity<AplicantStatus>()
                .HasOne(s => s.Applicant)
                .WithMany(a => a.Statuses)
                .HasForeignKey(s => s.ApplicantId);

            builder.Entity<AplicantStatus>()
                .HasOne(s => s.Status)
                .WithMany(st => st.Applicants)
                .HasForeignKey(s => s.StatusId);

            builder.Entity<Interview>()
                .HasOne(i => i.Applicant)
                .WithMany(a => a.Interviews)
                .HasForeignKey(i => i.ApplicantId);

            builder.Entity<Interview>()
                .HasOne(i => i.Test)
                .WithMany(t => t.Interviews)
                .HasForeignKey(i => i.TestId);

            builder.Entity<Feedback>()
                .HasKey(f => new {f.InterviewId, f.InterviewerId});

            builder.Entity<Feedback>()
                .HasOne(f => f.Interview)
                .WithMany(i => i.Feedbacks)
                .HasForeignKey(f => f.InterviewId);

            builder.Entity<Feedback>()
                .HasOne(f => f.Interviewer)
                .WithMany(i => i.Feedbacks)
                .HasForeignKey(f => f.InterviewerId);

            base.OnModelCreating(builder);
        }
    }
}
