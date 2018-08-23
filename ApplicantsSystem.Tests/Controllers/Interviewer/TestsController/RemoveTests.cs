namespace ApplicantsSystem.Tests.Controllers.Interviewer.TestsController
{
    using ApplicantsSystem.Services.Interviewer;
    using Common.Interviewer.ViewModels;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using Web.Areas.Interviewer.Controllers;

    [TestClass]
    public class RemoveTests
    {
        [TestMethod]
        public void Remove_WithValidTest_ShouldCallService()
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

            mockRepository.Setup(service => service.Remove(1))
                .Callback(() => serviceCalled = true);

            var controller = new TestsController(mockRepository.Object);

            //Act
            var result = controller.Remove(1);

            //Assert
            Assert.IsTrue(serviceCalled);
        }
    }
}
