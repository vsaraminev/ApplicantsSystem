namespace ApplicantsSystem.Common.Admin.ViewModels
{
    using Interviewer.ViewModels;
    using System;
    using System.Collections.Generic;

    public class AdminInPersonInterviewDetailsViewModel
    {
        public int Id { get; set; }

        public int ApplicantId { get; set; }

        public string ApplicantName { get; set; }
        
        public DateTime StartTime { get; set; }

        public DateTime? EndTime { get; set; }

        public ICollection<InterviewerInterviewsListingModel> Interviewers { get; set; }

        public ICollection<InterviewerFeedbackDetailsViewModel> Feedbacks { get; set; }
    }
}
