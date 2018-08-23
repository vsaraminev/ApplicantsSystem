namespace ApplicantsSystem.Tests.Controllers.Interviewer.TestsController
{
    using ApplicantsSystem.Services.Interviewer;
    using Common.Interviewer.ViewModels;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using System.Threading.Tasks;
    using Web.Areas.Interviewer.Controllers;

    [TestClass]
    public class DetailsTests
    {
        [TestMethod]
        public async Task Details_ShouldReturnTest()
        {
            //Arrange
            var testModel = new InterviewerTestDetailsViewModel()
            {
                Id = 1,
                Name = "Test 1",
                Url = "https://www.mysite.bg/"
            };

            bool serviceCalled = false;

            var mockRepository = new Mock<IInterviewerTestsService>();

            mockRepository.Setup(service => service.Details(It.IsAny<int>()))
                .ReturnsAsync(testModel)
                .Callback(() => serviceCalled = true);

            var controller = new TestsController(mockRepository.Object);

            //Act
            var result = await controller.Details(1);

            //Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            Assert.IsTrue(serviceCalled);
        }
    }
}
