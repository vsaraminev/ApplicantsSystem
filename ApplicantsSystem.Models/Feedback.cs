namespace ApplicantsSystem.Models
{
    using Constants;
    using System.ComponentModel.DataAnnotations;

    public class Feedback
    {
        public int Id { get; set; }

        [Required]
        [MinLength(DataConstants.FeedbackContextMinLength)]
        [MaxLength(DataConstants.FeedbackContextMaxLength)]
        public int InterviewId { get; set; }

        [Required]
        public Interview Interview { get; set; }

        public string Context { get; set; }

        [Range(DataConstants.FeedbackMinScore, DataConstants.FeedbackMaxScore)]
        public int Score { get; set; }
    }
}
