namespace ApplicantsSystem.Tests.Services.AdminApplicants
{
    using ApplicantsSystem.Services.Admin.Implementation;
    using Data;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Mocks;
    using Models;
    using System.Threading.Tasks;

    [TestClass]
    public class ApplicantDetailsTests
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
        public async Task ApplicantDetails_WithApplicantId_ShouldReturnApplicant()
        {
            //Arrange

            var applicantFirstName = "New applicant firstName";
            var applicantLastName = "New applicant lastName";

            this.dbContext.Applicants.Add(new Applicant() { Id = 1, FirstName = applicantFirstName, LastName = applicantLastName });

            this.dbContext.SaveChanges();

            //Act
            var applicant = await this.service.Details(1);

            ////Assert
            Assert.AreEqual(applicantFirstName, applicant.FirstName);
            Assert.AreEqual(applicantLastName, applicant.LastName);
        }

        [TestMethod]
        public async Task ApplicantDetails_WithNotExistingApplicant_ShouldReurnNull()
        {
            //Arrange
            var applicantFirstName = "New applicant firstName";
            var applicantLastName = "New applicant lastName";

            this.dbContext.Applicants.Add(new Applicant() { Id = 1, FirstName = applicantFirstName, LastName = applicantLastName });

            this.dbContext.SaveChanges();

            //Act
            var applicant = await this.service.Details(2);

            //Assert
            Assert.AreEqual(null, applicant);
        }
    }
}
