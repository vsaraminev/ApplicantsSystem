namespace ApplicantsSystem.Common.Interviewer.ViewModels
{
    using Models;

    public class InterviewerFeedbackDetailsViewModel
    {
        public int InterviewId { get; set; }

        public Interview Interview { get; set; }
        
        public string Context { get; set; }

        public int Score { get; set; }
    }
}
