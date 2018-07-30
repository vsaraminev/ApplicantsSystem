namespace ApplicantsSystem.Models
{
    using System.ComponentModel.DataAnnotations;

    public class InterviewInterviewer
    {
        public int Id { get; set; }

        [Required]
        public int InterviewId { get; set; }

        public Interview Interview { get; set; }

        [Required]
        public string InterviewerId { get; set; }

        public User Interviewer { get; set; }

        public int FeedbackId { get; set; }

        public Feedback Feedback { get; set; }
    }
}
