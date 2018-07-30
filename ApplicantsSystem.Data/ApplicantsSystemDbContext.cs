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
                .WithMany(i => i.InterviewerInterviewrs)
                .HasForeignKey(ii => ii.InterviewerId);

            builder.Entity<Interview>()
                .HasOne(i => i.Test)
                .WithMany(t => t.Interviews)
                .HasForeignKey(i => i.TestId);

            builder.Entity<User>()
                .HasMany(u => u.Interviews)
                .WithOne(i => i.Applicant)
                .HasForeignKey(i => i.ApplicantId)
                .OnDelete(DeleteBehavior.Cascade);
            
            base.OnModelCreating(builder);
        }
    }
}
