namespace ApplicantsSystem.Services.Admin.Implementation
{
    using AutoMapper;
    using Common.Admin.BindingModels;
    using Common.Admin.ViewModels;
    using Data;
    using Microsoft.AspNetCore.Identity;
    using Models;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class AdminApplicantService : BaseService, IAdminApplicantService
    {
        private readonly UserManager<Applicant> userManager;

        public AdminApplicantService(ApplicantsSystemDbContext db, IMapper mapper)
            : base(db, mapper)
        {
        }

        public IEnumerable<AdminApplicantListingViewModel> ApplicantsAll()
        {
            var applicants = this.DbContext.Applicants.ToList();

            return this.Mapper.Map<IEnumerable<AdminApplicantListingViewModel>>(applicants);
        }

        public async Task Create(CreateApplicantBindingModel model)
        {
            var applicant = this.Mapper.Map<Applicant>(model);

            await this.DbContext.Applicants.AddAsync(applicant);
            await this.DbContext.SaveChangesAsync();
        }

        public async Task<AdminApplicantDetailsViewModel> Details(int id)
        {
            var applicant = await this.DbContext
                .Applicants
                .FindAsync(id);

            return this.Mapper.Map<AdminApplicantDetailsViewModel>(applicant);
        }

        public async Task Hire(int id)
        {
            var applicant = await this.DbContext
                .Applicants
                .FindAsync(id);

            applicant.IsHired = true;

            await this.DbContext.SaveChangesAsync();
        }

        public async Task Remove(int id)
        {
            var applicant = await this.DbContext
                .Applicants
                .FindAsync(id);

            this.DbContext.Applicants.Remove(applicant);

            await this.DbContext.SaveChangesAsync();
        }
    }
}
