namespace ApplicantsSystem.Services.Admin.Implementation
{
    using AutoMapper;
    using Common.Admin.BindingModels;
    using Common.Admin.ViewModels;
    using Data;
    using Microsoft.EntityFrameworkCore;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class AdminInterviewService : BaseService, IAdminInterviewService
    {
        public AdminInterviewService(ApplicantsSystemDbContext dbContext, IMapper mapper)
            : base(dbContext, mapper)
        {
        }

        public IEnumerable<AdminInterviewsListingViewModel> All()
        {
            var interviews = this.DbContext.Interviews.ToList();

            return this.Mapper.Map<IEnumerable<AdminInterviewsListingViewModel>>(interviews);
        }

        public async Task CreateOffSite(CreateOffsiteInterviewBindingModel model)
        {
            var interview = new Interview()
            {
                ApplicantId = model.ApplicantId,
                TestId = model.TestId,
                StartTime = DateTime.UtcNow.ToLocalTime(),
                EndTime = null
            };

            await this.DbContext.Interviews.AddAsync(interview);
            await this.DbContext.SaveChangesAsync();
        }

        public async Task CreateOnSite(CreateOnsiteInterviewBindingModel model)
        {
            //var interview = this.Mapper.Map<Interview>(model);

            var firstInterviewer = this.DbContext.Users.Find(model.FirstInterviewerId);
            var secondInterviewer = this.DbContext.Users.Find(model.SecondInterviewerId);

            var test = await this.DbContext.Tests.FirstOrDefaultAsync(t => t.Name == "OnSiteTest");

            var interview = new Interview()
            {
                ApplicantId = model.ApplicantId,
                StartTime = model.StartTime,
                EndTime = model.EndTime,
                TestId = null,
                Interviewers = new List<InterviewInterviewer>()
                {
                    new InterviewInterviewer()
                    {
                        InterviewerId = firstInterviewer.Id
                    },
                    new InterviewInterviewer()
                    {
                        InterviewerId = secondInterviewer.Id
                    }
                }
            };

            await this.DbContext.Interviews.AddAsync(interview);
            await this.DbContext.SaveChangesAsync();
        }

        public async Task<AdminInterviewDetailsViewModel> Details(int id)
        {
            var interview = await this.DbContext
                .Interviews
                .FirstOrDefaultAsync(i => i.Id == id);

            var interviewers = this.DbContext.InterviewInterviewers.Where(i => i.InterviewId == interview.Id).ToList();

            foreach (var interviewer in interviewers)
            {
                var interv =await this.DbContext.Users.FirstOrDefaultAsync(i => i.Id == interviewer.InterviewerId);

                interviewer.Interviewer = interv;
            }

            var test = await this.DbContext.Tests.FindAsync(interview.TestId);

            var applicant = await this.DbContext.Applicants.FindAsync(interview.ApplicantId);

            var result = await this.DbContext.Results.FirstOrDefaultAsync(i => i.Id == interview.Id);
            
            if (result == null)
            {
                interview.Result = new Result();
            }
            else
            {
                interview.Result = result;
            }

            interview.Result.Id = interview.Id;

            interview.Applicant = applicant;
            interview.Test = test;

            return this.Mapper.Map<AdminInterviewDetailsViewModel>(interview);
        }

        public Task SetTestResult(AdminSetApplicantTestResult model)
        {
            // TODO
            throw new NotImplementedException();
        }
    }
}
