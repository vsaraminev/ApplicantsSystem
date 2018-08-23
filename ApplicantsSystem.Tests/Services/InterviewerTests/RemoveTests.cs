namespace ApplicantsSystem.Tests.Services.InterviewerTests
{
    using ApplicantsSystem.Services.Interviewer.Implementation;
    using Data;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Mocks;
    using Models;
    using System.Linq;
    using System.Threading.Tasks;

    [TestClass]
    public class RemoveTests
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
        public async Task RemoveTest_WithTestId_ShouldRemoveTest()
        {
            //Arrange

            this.dbContext.Tests.Add(new Test() { Id = 1, Name = "Test 1", Description = "Test 1 Description" });
            this.dbContext.Tests.Add(new Test() { Id = 2, Name = "Test 2", Description = "Test 2 Description" });

            this.dbContext.SaveChanges();

            //Act
            await this.service.Remove(1);

            //Assert

            var tests = this.dbContext.Tests;

            Assert.AreEqual(1, tests.Count());
        }
    }
}
