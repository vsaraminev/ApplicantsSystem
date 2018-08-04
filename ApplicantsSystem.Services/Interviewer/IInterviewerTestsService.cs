namespace ApplicantsSystem.Services.Interviewer
{
    using Common.Interviewer.BindingModels;
    using Common.Interviewer.ViewModels;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IInterviewerTestsService
    {
        IEnumerable<InterviewerTestListingModel> All();

        Task Create(InterviewerTestBindingModel model);

        Task Remove(int id);
    }
}
