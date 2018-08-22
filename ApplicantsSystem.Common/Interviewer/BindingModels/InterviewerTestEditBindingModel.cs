namespace ApplicantsSystem.Common.Interviewer.BindingModels
{
    using System.ComponentModel.DataAnnotations;
    using static ApplicantsSystem.Models.Constants.DataConstants;

    public class InterviewerTestEditBindingModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [MinLength(TestDescriptionMinLength)]
        [MaxLength(TestDescriptionMaxLength)]
        public string Description { get; set; }
    }
}
