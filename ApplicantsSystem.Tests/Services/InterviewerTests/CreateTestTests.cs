using System;
using ApplicantsSystem.Common.Admin.BindingModels;

namespace ApplicantsSystem.Tests.Services.InterviewerTests
{
    using ApplicantsSystem.Services.Interviewer.Implementation;
    using Common.Interviewer.BindingModels;
    using Data;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Mocks;
    using System.Linq;
    using System.Threading.Tasks;

    [TestClass]
    public class CreateTestTests
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
        public async Task CreateTest_WithProperTest_ShouldCreateCorrectly()
        {
            //Arrange

            var id = 1;
            var name = "New test";
            var description = "New test description";

            var testModel = new InterviewerTestBindingModel
            {
                Id = id,
                Name = name,
                Description = description
            };

            //Act
            await this.service.Create(testModel);

            //Assert

            var test = this.dbContext.Tests.First();

            Assert.AreEqual(name, test.Name);
            Assert.AreEqual(description, test.Description);
        }

        [TestMethod]
        public async Task CreateApplicant_WithNullApplicant_ShouldThrowException()
        {
            //Arrange

            InterviewerTestBindingModel testtModel = null;

            //Act
            Func<Task> createTest = () => this.service.Create(testtModel);

            //Assert
            await Assert.ThrowsExceptionAsync<ArgumentNullException>(createTest);
        }
    }
}
