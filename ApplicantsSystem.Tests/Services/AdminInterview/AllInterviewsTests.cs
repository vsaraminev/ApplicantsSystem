namespace ApplicantsSystem.Tests.Services.AdminInterview
{
    using ApplicantsSystem.Services.Admin.Implementation;
    using Data;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Mocks;
    using Models;
    using System.Threading.Tasks;

    [TestClass]
    public class AllInterviewsTests
    {
        private ApplicantsSystemDbContext dbContext;
        private AdminInterviewService service;

        [TestInitialize]
        public void InitializeTests()
        {
            this.dbContext = MockDbContext.GetContext();
            this.service = new AdminInterviewService(dbContext, MockAutoMapper.GetAutoMapper());
        }

        [TestMethod]
        public async Task InterviewsAll_WithFewInterviews_ShouldReturnAll()
        {
            //Arrange

            this.dbContext.Interviews.Add(new Interview() { Id = 1, ApplicantId = 1, TestId = 1 });
            this.dbContext.Interviews.Add(new Interview() { Id = 2, ApplicantId = 2, TestId = 2 });
            this.dbContext.Interviews.Add(new Interview() { Id = 3, ApplicantId = 3, TestId = 3 });

            this.dbContext.SaveChanges();

            //Act

            var interviews =await this.service.TotalAsync();

            //Assert

            Assert.AreEqual(3, interviews);
        }

        [TestMethod]
        public async Task ApplicantsAll_WithNoApplicants_ShouldReturnNone()
        {
            //Arrange

            //Act

            var interviews =await this.service.TotalAsync();

            //Assert

            Assert.AreEqual(0, interviews);
        }
    }
}
