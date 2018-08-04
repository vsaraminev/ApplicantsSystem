namespace ApplicantsSystem.Services.Admin
{
    using Common.Admin.BindingModels;
    using Common.Admin.ViewModels;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IAdminApplicantService
    {
        IEnumerable<AdminApplicantListingViewModel> ApplicantsAll();

        Task Create(CreateApplicantBindingModel model);

        Task <AdminApplicantDetailsViewModel> Details(int id);

        Task Hire(int id);

        Task Remove(int id);
    }
}
