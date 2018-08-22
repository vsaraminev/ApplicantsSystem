namespace ApplicantsSystem.Common.Interviewer.BindingModels
{
    using Models;
    using System.ComponentModel.DataAnnotations;

    public class InterviewerFeedbackBindingModel
    {
        public int Id { get; set; }

        public int InterviewId { get; set; }

        public Interview Interview { get; set; }

        [Required]
        public string Context { get; set; }

        [Required]
        [Range(1, 6)]
        public int Score { get; set; }
    }
}
