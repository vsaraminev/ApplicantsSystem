using Microsoft.Extensions.Caching.Memory;

namespace ApplicantsSystem.Tests.Controllers.Admin.ApplicantsController
{
    using ApplicantsSystem.Services.Admin;
    using Common.Admin.BindingModels;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using Web.Areas.Admin.Controllers;

    [TestClass]
    public class CreateTests
    {
        [TestMethod]
        public void Create_WithValidApplicant_ShouldCallService()
        {
            //Arrange
            var model = new CreateApplicantBindingModel();

            bool serviceCalled = false;

            var mockRepository = new Mock<IAdminApplicantService>();

            mockRepository.Setup(r => r.Create(model))
                .Callback(() => serviceCalled = true);

            var controller = new ApplicantsController(mockRepository.Object);

            //Act
            var result = controller.Create(model);

            //Assert
            Assert.IsTrue(serviceCalled);
        }
    }
}
