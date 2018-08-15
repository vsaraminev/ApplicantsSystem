namespace ApplicantsSystem.Common.Admin.ViewModels
{
    using Interviewer.ViewModels;
    using Models;
    using System;
    using System.Collections.Generic;

    public class AdminInterviewDetailsViewModel
    {
        public int Id { get; set; }

        public int ApplicantId { get; set; }

        public Applicant Applicant { get; set; }

        public int? TestId { get; set; }

        public Test Test { get; set; }

        public Result Result { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime? EndTime { get; set; }

        public ICollection<InterviewerInterviewsListingModel> Interviewers { get; set; }

        public ICollection<InterviewerFeedbackDetailsViewModel> Feedbacks { get; set; }
    }
}
