namespace ApplicantsSystem.Tests.Services.AdminApplicants
{
    using ApplicantsSystem.Services.Admin.Implementation;
    using Common.Admin.BindingModels;
    using Data;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Mocks;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    [TestClass]
    public class CreateApplicantTests
    {
        private ApplicantsSystemDbContext dbContext;
        private AdminApplicantService service;

        [TestInitialize]
        public void InitializeTests()
        {
            this.dbContext = MockDbContext.GetContext();
            this.service = new AdminApplicantService(dbContext, MockAutoMapper.GetAutoMapper());
        }

        [TestMethod]
        public async Task CreateApplicant_WithProperApplicant_ShouldCreateCorrectly()
        {
            //Arrange

            var applicantFirstName = "New applicant firstName";
            var applicantLastName = "New applicant lastName";

            var applicantModel = new CreateApplicantBindingModel()
            {
                FirstName = applicantFirstName,
                LastName = applicantLastName,
            };

            //Act
            await this.service.Create(applicantModel);

            //Assert

            var applicant = this.dbContext.Applicants.First();

            Assert.AreEqual(applicantFirstName, applicant.FirstName);
            Assert.AreEqual(applicantLastName, applicant.LastName);
        }

        [TestMethod]
        public async Task CreateApplicant_WithNullApplicant_ShouldThrowException()
        {
            //Arrange

            CreateApplicantBindingModel applicantModel = null;

            //Act
            Func<Task> createApplicant = () => this.service.Create(applicantModel);

            //Assert
            await Assert.ThrowsExceptionAsync<ArgumentException>(createApplicant);
        }
    }
}
