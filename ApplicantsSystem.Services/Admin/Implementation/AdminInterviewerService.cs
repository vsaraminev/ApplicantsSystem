namespace ApplicantsSystem.Services.Admin.Implementation
{
    using AutoMapper;
    using Common.Admin.BindingModels;
    using Common.Admin.ViewModels;
    using Data;
    using Microsoft.AspNetCore.Identity;
    using Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using static ApplicantsSystem.Common.Constants.WebConstants;

    public class AdminInterviewerService : BaseService, IAdminInterviewerService
    {
        private readonly UserManager<User> userManager;

        public AdminInterviewerService(ApplicantsSystemDbContext dbContext, IMapper mapper, UserManager<User> userManager)
            : base(dbContext, mapper)
        {
            this.userManager = userManager;
        }

        public async Task<IEnumerable<AdminInterviewerListingViewModel>> All()
        {
            var interviewers = await this.userManager.GetUsersInRoleAsync(InterviewerRole);

            return this.Mapper.Map<IEnumerable<AdminInterviewerListingViewModel>>(interviewers);
        }

        public async Task Create(CreateInterviewerBindingModel model)
        {
            var interviewer = this.Mapper.Map<User>(model);

            await this.userManager.CreateAsync(interviewer, model.Password);

            await this.userManager.AddToRoleAsync(interviewer, InterviewerRole);

            this.DbContext.Users.Add(interviewer);
            this.DbContext.SaveChanges();
        }
        
        public async Task<AdminInterviewerDetailsViewModel> Details(string id)
        {
            var interviewer = await this.userManager.FindByIdAsync(id);
            
            return this.Mapper.Map<AdminInterviewerDetailsViewModel>(interviewer);
        }

        public async Task Remove(string id)
        {
            var interviewer = await this.userManager.FindByIdAsync(id);
            
            this.DbContext.Users.Remove(interviewer);

            await this.DbContext.SaveChangesAsync();
        }
    }
}
