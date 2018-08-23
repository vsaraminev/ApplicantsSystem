namespace ApplicantsSystem.Tests.Services.AdminInterview
{
    using ApplicantsSystem.Services.Admin.Implementation;
    using ApplicantsSystem.Services.Interviewer.Implementation;
    using Common.Admin.BindingModels;
    using Common.Interviewer.BindingModels;
    using Data;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Mocks;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    [TestClass]
    public class CreateOnlineTests
    {
        private ApplicantsSystemDbContext dbContext;
        private AdminInterviewService interviews;
        private AdminApplicantService applicants;
        private InterviewerTestsService tests;

        [TestInitialize]
        public void InitializeTests()
        {
            this.dbContext = MockDbContext.GetContext();
            this.interviews = new AdminInterviewService(dbContext, MockAutoMapper.GetAutoMapper());
            this.applicants = new AdminApplicantService(dbContext, MockAutoMapper.GetAutoMapper());
            this.tests = new InterviewerTestsService(dbContext, MockAutoMapper.GetAutoMapper());
        }

        [TestMethod]
        public async Task CreateInterview_WithProperInterview_ShouldCreateCorrectly()
        {
            //Arrange

            var applicantId = 1;
            var applicantFirstName = "New applicant firstName";
            var applicantLastName = "New applicant lastName";

            var testId = 1;
            var testDescription = "Description";
            var testUrl = "https://www.mysite.bg/";

            var applicantModel = new CreateApplicantBindingModel()
            {
                Id = applicantId,
                FirstName = applicantFirstName,
                LastName = applicantLastName,
            };

            await this.applicants.Create(applicantModel);

            var testModel = new InterviewerTestBindingModel()
            {
                Id = testId,
                Description = testDescription,
                Url = testUrl
            };

            await this.tests.Create(testModel);

            var interviewModel = new CreateOnlineInterviewBindingModel()
            {
                ApplicantId = applicantModel.Id,
                TestId = testModel.Id
            };

            //Act
            await this.interviews.CreateOnline(interviewModel);

            //Assert

            var interview = this.dbContext.Interviews.First();

            Assert.AreEqual(applicantModel.Id, interview.ApplicantId);
            Assert.AreEqual(testModel.Id, interview.TestId);
        }

        [TestMethod]
        public async Task CreateInterview_WithNullInterview_ShouldThrowException()
        {
            //Arrange

            CreateOnlineInterviewBindingModel interviewModel = null;

            //Act
            Func<Task> createInterview = () => this.interviews.CreateOnline(interviewModel);

            //Assert
            await Assert.ThrowsExceptionAsync<InvalidOperationException>(createInterview);
        }
    }
}
