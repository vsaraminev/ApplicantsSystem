namespace ApplicantsSystem.Common.Admin.ViewModels
{
    using System;
    using System.Collections.Generic;
    using static ApplicantsSystem.Common.Constants.WebConstants;

    public class AdminInterviewsListingViewModel
    {
        public IEnumerable<AdminInterviewsViewModel> Interviews { get; set; }

        public int TotalInterviews { get; set; }

        public int TotalPages => (int)Math.Ceiling((double)this.TotalInterviews / ListingInterviewsPageSize);

        public int CurrentPage { get; set; }

        public int PreviousPage => this.CurrentPage <= 1 ? 1 : this.CurrentPage - 1;

        public int NextPage => this.CurrentPage == this.TotalPages ? this.TotalPages : this.CurrentPage + 1;
    }
}
