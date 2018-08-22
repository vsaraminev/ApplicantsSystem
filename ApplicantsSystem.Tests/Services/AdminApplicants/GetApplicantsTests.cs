namespace ApplicantsSystem.Tests.Services.AdminApplicants
{
    using ApplicantsSystem.Services.Admin.Implementation;
    using Data;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Mocks;
    using Models;
    using System.Linq;

    [TestClass]
    public class GetApplicantsTests
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
        public void ApplicantsAll_WithFewApplicants_ShouldReturnAll()
        {
            //Arrange

            this.dbContext.Applicants.Add(new Applicant() { Id = 1, FirstName = "First Applicant" });
            this.dbContext.Applicants.Add(new Applicant() { Id = 2, FirstName = "Second Applicant" });
            this.dbContext.Applicants.Add(new Applicant() { Id = 3, FirstName = "Third Applicant" });

            this.dbContext.SaveChanges();
            
            //Act

            var applicants = this.service.All();

            //Assert

            Assert.AreEqual(3, applicants.Count());
        }

        [TestMethod]
        public void ApplicantsAll_WithNoApplicants_ShouldReturnNone()
        {
            //Arrange
            
            //Act

            var applicants = this.service.All();

            //Assert

            Assert.AreEqual(0, applicants.Count());
        }
    }
}
