using System;
using System.Text.RegularExpressions;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace ApplicantsSystem.Common.Admin.ViewModels
{
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc.Rendering;

    using static ApplicantsSystem.Common.Constants.WebConstants;

    public class AdminApplicantIndexViewModel
    {
        public IEnumerable<AdminApplicantListingViewModel> Applicants { get; set; }

        public IEnumerable<SelectListItem> Statuses { get; set; }

        public int TotalApplicants { get; set; }

        public int TotalPages => (int)Math.Ceiling((double)this.TotalApplicants / ListingApplicantsPageSize);

        public int CurrentPage { get; set; }

        public int PreviousPage => this.CurrentPage == 1 ? 1 : this.CurrentPage - 1;

        public int NextPage => this.CurrentPage == this.TotalPages ? this.TotalPages : this.CurrentPage + 1;

    }
}
