namespace ApplicantsSystem.Common.Interviewer.ViewModels
{
    using Models;

    public class InterviewerInterviewsListingModel
    {
        public int Id { get; set; }

        public int InterviewId { get; set; }

        public Interview Interview { get; set; }

        public string InterviewerId { get; set; }

        public User Interviewer { get; set; }
    }
}
