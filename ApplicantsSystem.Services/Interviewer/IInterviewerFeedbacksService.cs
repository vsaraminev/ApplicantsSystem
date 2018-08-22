namespace ApplicantsSystem.Services.Interviewer
{
    using Common.Interviewer.BindingModels;
    using Common.Interviewer.ViewModels;
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;

    public interface IInterviewerFeedbacksService
    {
        IEnumerable<InterviewerInterviewsListingModel> Index(ClaimsPrincipal user);

        Task LeaveFeedback(InterviewerFeedbackBindingModel model, ClaimsPrincipal user);

        Task<InterviewerFeedbackDetailsViewModel> Details(int interviewId, ClaimsPrincipal user);
    }
}
