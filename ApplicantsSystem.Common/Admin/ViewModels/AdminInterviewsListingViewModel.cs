namespace ApplicantsSystem.Common.Admin.ViewModels
{
    using Models;

    public class AdminInterviewsListingViewModel
    {
        public int Id { get; set; }

        public int ApplicantId { get; set; }

        public Applicant Applicant { get; set; }

        public int TestId { get; set; }

        public Test Test { get; set; }
    }
}
