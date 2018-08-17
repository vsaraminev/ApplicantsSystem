namespace ApplicantsSystem.Services.Admin.Implementation
{
    using AutoMapper;
    using Common.Admin.BindingModels;
    using Common.Admin.ViewModels;
    using Data;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Caching.Memory;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using static ApplicantsSystem.Common.Constants.WebConstants;

    public class AdminApplicantService : BaseService, IAdminApplicantService
    {
        private const string AppCacheKey = "app-cache-key";

        private readonly IMemoryCache cache;

        public AdminApplicantService(ApplicantsSystemDbContext db, IMapper mapper, IMemoryCache cache)
            : base(db, mapper)
        {
            this.cache = cache;
        }

        public IEnumerable<AdminApplicantListingViewModel> ApplicantsAll()
        {
            var applicants = this.DbContext
                .Applicants
                .Include(a => a.Statuses)
                .ThenInclude(s => s.Status)
                .ToList();

            return this.Mapper.Map<IEnumerable<AdminApplicantListingViewModel>>(applicants);
        }

        public async Task Create(CreateApplicantBindingModel model)
        {
            var applicant = this.Mapper.Map<Applicant>(model);

            var status = await this.DbContext.Statuses.FirstOrDefaultAsync(s => s.Name == InInterviewStatus);

            applicant.CurrentStatus = status.Id;

            applicant.Statuses = new List<AplicantStatus>()
            {
                new AplicantStatus
                {
                    StatusId = status.Id,
                    Time = DateTime.UtcNow
                }
            };

            await this.DbContext.Applicants.AddAsync(applicant);
            await this.DbContext.SaveChangesAsync();
        }

        public async Task<AdminApplicantDetailsViewModel> Details(int id)
        {
            var applicant = await this.DbContext
                .Applicants
                .FirstOrDefaultAsync(a => a.Id == id);

            return this.Mapper.Map<AdminApplicantDetailsViewModel>(applicant);
        }

        public async Task<AdminApplicantInterviewsViewModel> GetInterviews(int id)
        {
            var interviews = await this.DbContext
                .Applicants
                .Include(i => i.Interviews)
                .ThenInclude(i => i.Interviewers)
                .FirstOrDefaultAsync(a => a.Id == id);

            return this.Mapper.Map<AdminApplicantInterviewsViewModel>(interviews);
        }

        public async Task<IEnumerable<AdminApplicantStatusesViewModel>> GetStatuses(int id)
        {
            var statuses = await this.DbContext
                .AplicantStatuses
                .Include(a => a.Applicant)
                .Where(a => a.ApplicantId == id)
                .Select(a => new AdminApplicantStatusesViewModel()
                {
                    ApplicantName = a.Applicant.FirstName + " " + a.Applicant.LastName,
                    StatusName = a.Status.Name,
                    Time = a.Time
                })
                .ToListAsync();

            return statuses;
        }

        public async Task ChangeStatus(AdminChangeApplicantsStatus model)
        {
            var applicant = await this.DbContext.Applicants.FirstOrDefaultAsync(a => a.Id == model.ApplicantId);

            var status = await this.DbContext.Statuses.FirstOrDefaultAsync(s => s.Id == model.StatusId);

            if (status == null || applicant == null)
            {
                throw new InvalidOperationException("Invalid Identity details.");
            }

            applicant.CurrentStatus = status.Id;

            applicant.Statuses.Add(
                new AplicantStatus
                {
                    StatusId = status.Id,
                    Time = DateTime.UtcNow
                });

            await this.DbContext.SaveChangesAsync();
        }

        public List<SelectListItem> GetStatuses()
        {
            var statuses = this.DbContext.Statuses.Select(s => new SelectListItem
            {
                Text = s.Name,
                Value = s.Id.ToString()
            })
                .ToList();

            return statuses;
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
