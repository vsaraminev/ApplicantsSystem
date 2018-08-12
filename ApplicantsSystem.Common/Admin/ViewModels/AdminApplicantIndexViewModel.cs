namespace ApplicantsSystem.Common.Admin.ViewModels
{
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc.Rendering;

    public class AdminApplicantIndexViewModel
    {
        public IEnumerable<AdminApplicantListingViewModel> Applicants { get; set; }

        public IEnumerable<SelectListItem> Statuses { get; set; }
    }
}
