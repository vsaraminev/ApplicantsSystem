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

    using static ApplicantsSystem.Common.Constants.WebConstants;

    public class AdminInterviewService : BaseService, IAdminInterviewService
    {
        public AdminInterviewService(ApplicantsSystemDbContext dbContext, IMapper mapper)
            : base(dbContext, mapper)
        {
        }

        public async Task<IEnumerable<AdminInterviewsViewModel>> All(int page = 1)
        {
            var interviews = await this.DbContext
                .Interviews
                .Include(i => i.Applicant)
                .OrderByDescending(i => i.Id)
                .Skip((page - 1) * ListingInterviewsPageSize)
                .Take(ListingInterviewsPageSize)
                .ToListAsync();

            return this.Mapper.Map<IEnumerable<AdminInterviewsViewModel>>(interviews);
        }

        public async Task<int> TotalAsync()
            => await this.DbContext.Interviews.CountAsync();

        public async Task CreateOnline(CreateOnlineInterviewBindingModel model)
        {
            var applicant = await this.DbContext.Applicants.FirstOrDefaultAsync(a => a.Id == model.ApplicantId);
            var test = await this.DbContext.Tests.FirstOrDefaultAsync(t => t.Id == model.TestId);

            if (applicant == null || test == null)
            {
                throw new InvalidOperationException("Invalid Identity details.");
            }

            var interview = new Interview()
            {
                ApplicantId = model.ApplicantId,
                TestId = model.TestId,
                Applicant = applicant,
                Test = test,
                StartTime = DateTime.UtcNow.ToLocalTime(),
                EndTime = null
            };

            await this.DbContext.Interviews.AddAsync(interview);
            await this.DbContext.SaveChangesAsync();
        }

        public async Task CreateInPerson(CreateInPersonInterviewBindingModel model)
        {
            //var interview = this.Mapper.Map<Interview>(model);

            var firstInterviewer = this.DbContext.Users.Find(model.FirstInterviewerId);
            var secondInterviewer = this.DbContext.Users.Find(model.SecondInterviewerId);

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

        public async Task<AdminOnlineInterviewDetailsViewModel> OnlineDetails(int id)
        {
            var interview = await this.DbContext
                .Interviews
                .Include(f => f.Applicant)
                .Include(i => i.Test)
                .FirstOrDefaultAsync(i => i.Id == id);

            var result = await this.DbContext.Results.FirstOrDefaultAsync(i => i.Id == interview.Id);

            interview.Result = result ?? new Result();

            interview.Result.Id = interview.Id;

            return this.Mapper.Map<AdminOnlineInterviewDetailsViewModel>(interview);
        }

        public async Task<AdminInPersonInterviewDetailsViewModel> InPersonDetails(int id)
        {
            var interview = await this.DbContext
                .Interviews
                .Include(i => i.Interviewers)
                .Include(i => i.Feedbacks)
                .Include(f => f.Applicant)
                .FirstOrDefaultAsync(i => i.Id == id);

            foreach (var interviewer in interview.Interviewers)
            {
                var interviewerUser = await this.DbContext.Users.FirstOrDefaultAsync(i => i.Id == interviewer.InterviewerId);

                interviewer.Interviewer = interviewerUser;
            }

            return this.Mapper.Map<AdminInPersonInterviewDetailsViewModel>(interview);
        }

        public async Task SetTestResult(AdminSetApplicantTestResult model)
        {
            var interview = await this.DbContext.Interviews.FindAsync(model.InterviewId);

            interview.Result = new Result()
            {
                InterviewId = interview.Id
            };

            if (interview.ApplicantId != model.ApplicantId)
            {
                throw new InvalidOperationException("Invalid Identity details.");
            }

            interview.Result.ResultUrl = model.ResultUrl;

            await this.DbContext.SaveChangesAsync();
        }
    }
}
