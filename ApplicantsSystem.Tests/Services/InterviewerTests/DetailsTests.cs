namespace ApplicantsSystem.Tests.Services.InterviewerTests
{
    using ApplicantsSystem.Services.Interviewer.Implementation;
    using Data;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Mocks;
    using Models;
    using System.Threading.Tasks;

    [TestClass]
    public class DetailsTests
    {
        private ApplicantsSystemDbContext dbContext;
        private InterviewerTestsService service;

        [TestInitialize]
        public void InitializeTests()
        {
            this.dbContext = MockDbContext.GetContext();
            this.service = new InterviewerTestsService(dbContext, MockAutoMapper.GetAutoMapper());
        }

        [TestMethod]
        public async Task TestDetails_WithTestId_ShouldReturnTest()
        {
            //Arrange

            var id = 1;
            var name = "New test";
            var description = "New test description";

            this.dbContext.Tests.Add(new Test() { Id = id, Name = name, Description = description });

            this.dbContext.SaveChanges();

            //Act
            var test = await this.service.Details(1);

            ////Assert
            Assert.AreEqual(name, test.Name);
        }

        [TestMethod]
        public async Task TestDetails_WithNotExistingTest_ShouldReurnNull()
        {
            //Arrange

            var id = 1;
            var name = "New test";
            var description = "New test description";

            this.dbContext.Tests.Add(new Test() { Id = id, Name = name, Description = description });

            this.dbContext.SaveChanges();

            //Act
            var applicant = await this.service.Details(2);

            //Assert
            Assert.AreEqual(null, applicant);
        }
    }
}
