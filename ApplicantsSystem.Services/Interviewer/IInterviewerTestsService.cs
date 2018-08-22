namespace ApplicantsSystem.Services.Interviewer
{
    using Common.Interviewer.BindingModels;
    using Common.Interviewer.ViewModels;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IInterviewerTestsService
    {
        Task<IEnumerable<InterviewerTestViewModel>> All(int page = 1);

        Task Create(InterviewerTestBindingModel model);

        Task<InterviewerTestEditBindingModel> PrepareTestForEdit(int id);

        Task Edit(int id, InterviewerTestEditBindingModel model);
        
        Task<InterviewerTestDetailsViewModel> Details(int id);

        Task<int> TotalAsync();

        InterviewerTestViewModel GetById(int id);

        List<SelectListItem> GetTests();

        Task Remove(int id);
    }
}
