namespace ApplicantsSystem.Services.Admin
{
    using Common.Admin.BindingModels;
    using Common.Admin.ViewModels;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IAdminApplicantService
    {
        IEnumerable<AdminApplicantListingViewModel> ApplicantsAll();

        Task Create(CreateApplicantBindingModel model);

        Task <AdminApplicantDetailsViewModel> Details(int id);

        Task<AdminApplicantInterviewsViewModel> GetInterviews(int id);

        Task<IEnumerable<AdminApplicantStatusesViewModel>> GetStatuses(int id);
        
        Task ChangeStatus(AdminChangeApplicantsStatus model);

        List<SelectListItem> GetStatuses();

        List<SelectListItem> GetApplicants();

        Task Remove(int id);
    }
}
