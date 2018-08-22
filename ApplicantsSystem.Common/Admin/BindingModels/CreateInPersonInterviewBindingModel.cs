namespace ApplicantsSystem.Common.Admin.BindingModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;
    using ApplicantsSystem.Common.Constants;
    using static ApplicantsSystem.Common.Constants.WebConstants;

    using Microsoft.AspNetCore.Mvc.Rendering;

    public class CreateInPersonInterviewBindingModel : IValidatableObject
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = Applicant)]
        public int ApplicantId { get; set; }

        public IEnumerable<SelectListItem> Applicants { get; set; }

        [Required]
        [Display(Name = WebConstants.StartTime)]
        [DataType(DataType.DateTime)]
        public DateTime StartTime { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = WebConstants.EndTime)]
        public DateTime EndTime { get; set; }

        [Required]
        [Display(Name = FirstInterviewer)]
        public string FirstInterviewerId { get; set; }

        [Display(Name = SecondInterviewer)]
        public string SecondInterviewerId { get; set; }

        public IEnumerable<SelectListItem> Interviewers { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (this.StartTime < DateTime.UtcNow)
            {
                yield return new ValidationResult("Start time should be in the future.");
            }

            if (this.StartTime > this.EndTime)
            {
                yield return new ValidationResult("Start time should be before end time.");
            }
        }
    }
}
