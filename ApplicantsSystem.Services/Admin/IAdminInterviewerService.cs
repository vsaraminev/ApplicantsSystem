namespace ApplicantsSystem.Services.Admin
{
    using Common.Admin.BindingModels;
    using Common.Admin.ViewModels;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IAdminInterviewerService
    {
        Task<IEnumerable<AdminInterviewerListingViewModel>> All();

        Task Create(CreateInterviewerBindingModel model);

        Task<AdminInterviewerDetailsViewModel> Details(string id);
        
        Task Remove(string id);
    }
}
