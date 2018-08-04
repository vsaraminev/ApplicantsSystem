namespace ApplicantsSystem.Common.Interviewer.BindingModels
{
    using System.ComponentModel.DataAnnotations;
    using static ApplicantsSystem.Models.Constants.DataConstants;

    public class InterviewerTestBindingModel
    {
        public int Id { get; set; }

        [Required]
        [MinLength(TestNameMinLength)]
        [MaxLength(TestNameMaxLength)]
        public string Name { get; set; }

        [Url]
        public string Url { get; set; }
    }
}
