namespace ApplicantsSystem.Services.Admin
{
    using Common.Admin.BindingModels;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Common.Admin.ViewModels;

    public interface IAdminInterviewService
    {
        Task<IEnumerable<AdminInterviewsListingViewModel>> All();

        Task CreateOnline(CreateOnlineInterviewBindingModel model);

        Task CreateInPerson(CreateInPersonInterviewBindingModel model);
        
        Task<AdminOnlineInterviewDetailsViewModel> OnlineDetails(int id);

        Task<AdminInPersonInterviewDetailsViewModel> InPersonDetails(int id);

        Task SetTestResult(AdminSetApplicantTestResult model);
    }
}
