namespace ApplicantsSystem.Services.Interviewer.Implementation
{
    using AutoMapper;
    using Common.Interviewer.BindingModels;
    using Common.Interviewer.ViewModels;
    using Data;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;

    public class InterviewerFeedbacksService : BaseService, IInterviewerFeedbacksService
    {
        private readonly UserManager<User> userManager;
        //private readonly IHtmlService html;

        public InterviewerFeedbacksService(ApplicantsSystemDbContext dbContext, IMapper mapper, UserManager<User> userManager)
            : base(dbContext, mapper)
        {
            this.userManager = userManager;
            //this.html = html;
        }

        public IEnumerable<InterviewerInterviewsListingModel> Index(ClaimsPrincipal user)
        {
            var currernUserId = this.userManager.GetUserId(user);

            var interviews = this.DbContext
                .InterviewInterviewers
                .Include(i => i.Interview)
                .ThenInclude(i => i.Applicant)
                .Where(i => i.InterviewerId == currernUserId)
                .Include(i => i.Interview)
                .ThenInclude(i => i.Feedbacks)
                .ToList();

            return this.Mapper.Map<IEnumerable<InterviewerInterviewsListingModel>>(interviews);
        }

        public async Task LeaveFeedback(InterviewerFeedbackBindingModel model, ClaimsPrincipal user)
        {
            var interview = await this.DbContext
                .InterviewInterviewers
                .Where(i => i.InterviewId == model.InterviewId)
                .ToListAsync();

            var currernUserId = this.userManager.GetUserId(user);

            var isInterviewer = interview.FirstOrDefault(i => i.InterviewerId == currernUserId);

            if (isInterviewer == null)
            {
                throw new InvalidOperationException();
            }

            var feedback = new Feedback()
            {
                InterviewId = model.InterviewId,
                InterviewerId = currernUserId,
                Context = model.Context,
                Score = model.Score
            };

            await this.DbContext.Feedbacks.AddAsync(feedback);
            await this.DbContext.SaveChangesAsync();
        }

        public async Task<InterviewerFeedbackDetailsViewModel> Details(int interviewId, ClaimsPrincipal user)
        {
            var currernUserId = this.userManager.GetUserId(user);

            var feedback = await this.DbContext
                .Feedbacks
                .Include(f => f.Interview)
                .ThenInclude(i => i.Applicant)
                .FirstOrDefaultAsync(f => f.InterviewId == interviewId && f.InterviewerId == currernUserId);

            return this.Mapper.Map<InterviewerFeedbackDetailsViewModel>(feedback);
        }
    }
}
