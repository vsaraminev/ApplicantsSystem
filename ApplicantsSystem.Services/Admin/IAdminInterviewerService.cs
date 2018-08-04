namespace ApplicantsSystem.Services.Admin
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Common.Admin.BindingModels;
    using Common.Admin.ViewModels;

    public interface IAdminInterviewerService
    {
        Task<IEnumerable<AdminInterviewerListingViewModel>> All();

        Task Create(CreateInterviewerBindingModel model);

        Task<AdminInterviewerDetailsViewModel> Details(string id);

        Task Remove(string id);
    }
}
