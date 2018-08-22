namespace ApplicantsSystem.Services.Interviewer.Implementation
{
    using AutoMapper;
    using Common.Interviewer.BindingModels;
    using Common.Interviewer.ViewModels;
    using Data;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;
    using Models;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using static ApplicantsSystem.Common.Constants.WebConstants;

    public class InterviewerTestsService : BaseService, IInterviewerTestsService
    {
        public InterviewerTestsService(ApplicantsSystemDbContext dbContext, IMapper mapper)
            : base(dbContext, mapper)
        {
        }

        public async Task<IEnumerable<InterviewerTestViewModel>> All(int page = 1)
        {
            var tests = await this.DbContext
                .Tests
                .Include(t => t.Interviews)
                .OrderByDescending(i => i.Id)
                .Skip((page - 1) * ListingTestsPageSize)
                .Take(ListingTestsPageSize)
                .ToListAsync();

            return this.Mapper.Map<IEnumerable<InterviewerTestViewModel>>(tests);
        }

        public async Task<int> TotalAsync()
            => await this.DbContext.Tests.CountAsync();

        public InterviewerTestViewModel GetById(int id)
        {
            var test = this.DbContext.Tests.Find(id);
            return this.Mapper.Map<InterviewerTestViewModel>(test);
        }

        public async Task Create(InterviewerTestBindingModel model)
        {
            var test = this.Mapper.Map<Test>(model);

            await this.DbContext.Tests.AddAsync(test);
            await this.DbContext.SaveChangesAsync();
        }

        public async Task<InterviewerTestEditBindingModel> PrepareTestForEdit(int id)
        {
            var test = await this.DbContext.Tests.FindAsync(id);

            return this.Mapper.Map<InterviewerTestEditBindingModel>(test);
        }

        public async Task Edit(int id, InterviewerTestEditBindingModel model)
        {
            var test = await this.DbContext.Tests.FindAsync(id);

            test.Description = model.Description;

            await this.DbContext.SaveChangesAsync();
        }

        public async Task<InterviewerTestDetailsViewModel> Details(int id)
        {
            var details = await this.DbContext.Tests.FindAsync(id);

            return this.Mapper.Map<InterviewerTestDetailsViewModel>(details);
        }

        public List<SelectListItem> GetTests()
        {
            var tests = this.DbContext
                .Tests
                .Select(t => new SelectListItem
                {
                    Text = t.Name,
                    Value = t.Id.ToString()
                })
                .ToList();

            return tests;
        }

        public async Task Remove(int id)
        {
            var test = await this.DbContext.Tests.FindAsync(id);

            this.DbContext.Tests.Remove(test);

            await this.DbContext.SaveChangesAsync();
        }
    }
}
