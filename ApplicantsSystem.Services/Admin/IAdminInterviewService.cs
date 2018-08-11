namespace ApplicantsSystem.Services.Admin
{
    using Common.Admin.BindingModels;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Common.Admin.ViewModels;

    public interface IAdminInterviewService
    {
        IEnumerable<AdminInterviewsListingViewModel> All();

        Task CreateOffSite(CreateOffsiteInterviewBindingModel model);

        Task CreateOnSite(CreateOnsiteInterviewBindingModel model);

        Task<AdminInterviewDetailsViewModel> Details(int id);
    }
}
