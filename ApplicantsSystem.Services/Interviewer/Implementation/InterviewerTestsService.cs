namespace ApplicantsSystem.Services.Interviewer.Implementation
{
    using AutoMapper;
    using Common.Interviewer.ViewModels;
    using Data;
    using System.Collections.Generic;

    public class InterviewerTestsService : BaseService, IInterviewerTestsService
    {
        public InterviewerTestsService(ApplicantsSystemDbContext dbContext, IMapper mapper)
            : base(dbContext, mapper)
        {
        }

        public IEnumerable<InterviewerTestListingModel> All { get; set; }
    }
}
