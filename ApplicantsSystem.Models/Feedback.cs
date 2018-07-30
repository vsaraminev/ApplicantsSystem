namespace ApplicantsSystem.Models
{
    using System.ComponentModel.DataAnnotations;
    using Constants;

    public class Feedback
    {
        public int Id { get; set; }

        [Required]
        [MinLength(DataConstants.FeedbackContextMinLength)]
        [MaxLength(DataConstants.FeedbackContextMaxLength)]
        public string Context { get; set; }

        [Range(DataConstants.FeedbackMinScore, DataConstants.FeedbackMaxScore)]
        public int Score { get; set; }
    }
}
