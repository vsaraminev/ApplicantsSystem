namespace ApplicantsSystem.Services.Interviewer
{
    using Common.Interviewer.ViewModels;
    using System.Collections.Generic;

    public interface IInterviewerTestsService
    {
        IEnumerable<InterviewerTestListingModel> All { get; set; }
    }
}
