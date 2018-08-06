namespace ApplicantsSystem.Common.Admin.BindingModels
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using static ApplicantsSystem.Common.Constants.WebConstants;

    public class CreateOffsiteInterviewBindingModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = Applicant)]
        public int ApplicantId { get; set; }

        public IEnumerable<SelectListItem> Applicants { get; set; }


        [Required]
        [Display(Name = Test)]
        public int TestId { get; set; }
        public IEnumerable<SelectListItem> Tests { get; set; }
    }
}
