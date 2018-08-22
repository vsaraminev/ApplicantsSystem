namespace ApplicantsSystem.Common.Interviewer.ViewModels
{
    using System;
    using System.Collections.Generic;
    using static ApplicantsSystem.Common.Constants.WebConstants;

    public class InterviewerTestListingViewModel
    {
        public IEnumerable<InterviewerTestViewModel> Tests { get; set; }

        public int TotalTests { get; set; }

        public int TotalPages => (int)Math.Ceiling((double)this.TotalTests / ListingTestsPageSize);

        public int CurrentPage { get; set; }

        public int PreviousPage => this.CurrentPage <= 1 ? 1 : this.CurrentPage - 1;

        public int NextPage => this.CurrentPage == this.TotalPages ? this.TotalPages : this.CurrentPage + 1;
    }
}
