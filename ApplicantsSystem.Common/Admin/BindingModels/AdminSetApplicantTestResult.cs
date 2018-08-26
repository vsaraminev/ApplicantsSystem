namespace ApplicantsSystem.Common.Admin.BindingModels
{
    using System.ComponentModel.DataAnnotations;

    public class AdminSetApplicantTestResult
    {
        [Required]
        public int ApplicantId { get; set; }

        [Required]
        public int InterviewId { get; set; }

        [Required]
        public int TestId { get; set; }

        [Required]
        public string ResultUrl { get; set; }
    }
}
