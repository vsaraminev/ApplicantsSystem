namespace ApplicantsSystem.Common.Admin.BindingModels
{
    using ApplicantsSystem.Common.Constants;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Models;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class CreateOnlineInterviewBindingModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = WebConstants.Applicant)]
        public int ApplicantId { get; set; }

        public Applicant Applicant { get; set; }

        public IEnumerable<SelectListItem> Applicants { get; set; }

        [Required]
        [Display(Name = WebConstants.Test)]
        public int TestId { get; set; }

        public Test Test { get; set; }

        public IEnumerable<SelectListItem> Tests { get; set; }
    }
}
