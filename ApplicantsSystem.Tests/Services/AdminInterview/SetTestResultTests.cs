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
    public class SetTestResultTests
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
        public async Task SetStatusInterview_WithProperStatus_ShouldSetCorrectly()
        {
            //Arrange

            var applicantId = 1;
            var applicantFirstName = "New applicant firstName";
            var applicantLastName = "New applicant lastName";

            var testId = 1;
            var testDescription = "Description";
            var testUrl = "https://www.mysite.bg/";
            var ResultUrl = "https://www.resultMyTest.bg/";

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
                Id = 1,
                ApplicantId = applicantModel.Id,
                TestId = testModel.Id
            };

            await this.interviews.CreateOnline(interviewModel);

            var setResultModel = new AdminSetApplicantTestResult()
            {
                ApplicantId = applicantModel.Id,
                InterviewId = interviewModel.Id,
                ResultUrl = ResultUrl
            };

            //Act

            await this.interviews.SetTestResult(setResultModel);

            //Assert

            var interview = this.dbContext.Interviews.First();

            Assert.AreEqual(ResultUrl, interview.Result.ResultUrl);
        }

        [TestMethod]
        public async Task SetTestResult_WithNullResult_ShouldThrowException()
        {
            //Arrange

            AdminSetApplicantTestResult testResultModel = null;

            //Act
            Func<Task> setTestResult = () => this.interviews.SetTestResult(testResultModel);

            //Assert
            await Assert.ThrowsExceptionAsync<NullReferenceException>(setTestResult);
        }
    }
}
