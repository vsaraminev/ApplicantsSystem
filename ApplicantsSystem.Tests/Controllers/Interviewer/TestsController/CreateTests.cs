namespace ApplicantsSystem.Tests.Controllers.Interviewer.TestsController
{
    using ApplicantsSystem.Services.Interviewer;
    using Common.Interviewer.BindingModels;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using Web.Areas.Interviewer.Controllers;

    [TestClass]
    public class CreateTests
    {
        [TestMethod]
        public void Create_WithValidApplicant_ShouldCallService()
        {
            //Arrange
            var model = new InterviewerTestBindingModel();

            bool serviceCalled = false;

            var mockRepository = new Mock<IInterviewerTestsService>();

            mockRepository.Setup(r => r.Create(model))
                .Callback(() => serviceCalled = true);

            var controller = new TestsController(mockRepository.Object);

            //Act
            var result = controller.Create(model);

            //Assert
            Assert.IsTrue(serviceCalled);
        }
    }
}
