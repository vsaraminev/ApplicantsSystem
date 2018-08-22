namespace ApplicantsSystem.Models
{
    using Constants;
    using System.ComponentModel.DataAnnotations;

    public class Feedback
    {
        [Required]
        public int InterviewId { get; set; }

        public Interview Interview { get; set; }

        public string InterviewerId { get; set; }

        public User Interviewer { get; set; }

        [MinLength(DataConstants.FeedbackContextMinLength)]
        [MaxLength(DataConstants.FeedbackContextMaxLength)]
        public string Context { get; set; }

        [Range(DataConstants.FeedbackMinScore, DataConstants.FeedbackMaxScore)]
        public int Score { get; set; }
    }
}
