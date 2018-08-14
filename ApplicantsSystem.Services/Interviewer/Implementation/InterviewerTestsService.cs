namespace ApplicantsSystem.Services.Interviewer.Implementation
{
    using AutoMapper;
    using Common.Interviewer.BindingModels;
    using Common.Interviewer.ViewModels;
    using Data;
    using Microsoft.EntityFrameworkCore;
    using Models;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class InterviewerTestsService : BaseService, IInterviewerTestsService
    {
        public InterviewerTestsService(ApplicantsSystemDbContext dbContext, IMapper mapper)
            : base(dbContext, mapper)
        {
        }

        public IEnumerable<InterviewerTestListingModel> All()
        {
            var tests = this.DbContext.Tests.Include(t => t.Interviews).ToList();
            return this.Mapper.Map<IEnumerable<InterviewerTestListingModel>>(tests);
        }

        public async Task Create(InterviewerTestBindingModel model)
        {
            var test = this.Mapper.Map<Test>(model);

            await this.DbContext.Tests.AddAsync(test);
            await this.DbContext.SaveChangesAsync();
        }

        public async Task Remove(int id)
        {
            var test = await this.DbContext.Tests.FindAsync(id);

            this.DbContext.Tests.Remove(test);

            await this.DbContext.SaveChangesAsync();
        }
    }
}
