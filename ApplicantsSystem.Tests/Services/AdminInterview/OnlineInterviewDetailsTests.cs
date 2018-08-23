using ApplicantsSystem.Models;
using Microsoft.AspNetCore.Identity;
using Moq;

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
    using System.Threading.Tasks;

    [TestClass]
    public class OnlineInterviewDetailsTests
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
        public async Task OnlineInterviewDetails_WithInterviewId_ShouldReturnInterview()
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
                Id = 1,
                ApplicantId = applicantModel.Id,
                TestId = testModel.Id
            };

            await this.interviews.CreateOnline(interviewModel);

            //Act
            var interview = this.interviews.OnlineDetails(1);

            //Assert

            Assert.AreEqual(1, interview.Id);
        }

        [TestMethod]
        public async Task OnlineInterviewDetails_WithNotExistingInterview_ShouldThrowException()
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
                Id = 1,
                ApplicantId = applicantModel.Id,
                TestId = testModel.Id
            };

            await this.interviews.CreateOnline(interviewModel);

            //Act
            Func<Task> interview = () => this.interviews.OnlineDetails(2);

            //Assert
            await Assert.ThrowsExceptionAsync<InvalidOperationException>(interview);
        }
    }
}
