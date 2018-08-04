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

        public DbSet<Result> Results { get; set; }

        public DbSet<Feedback> Feedbacks { get; set; }

        public DbSet<Interview> Interviews { get; set; }

        public DbSet<InterviewInterviewer> InterviewInterviewers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<InterviewInterviewer>()
                .HasOne(ii => ii.Interview)
                .WithMany(i => i.Interviewers)
                .HasForeignKey(ii => ii.InterviewId);

            builder.Entity<InterviewInterviewer>()
                .HasOne(ii => ii.Interviewer)
                .WithMany(i => i.Interviews)
                .HasForeignKey(ii => ii.InterviewerId);

            builder.Entity<Interview>()
                .HasOne(i => i.Applicant)
                .WithMany(a => a.Interviews)
                .HasForeignKey(i => i.ApplicantId);

            builder.Entity<Feedback>()
                .HasOne(f => f.Interview)
                .WithMany(i => i.Feedbacks)
                .HasForeignKey(f => f.InterviewId);

            base.OnModelCreating(builder);
        }
    }
}
