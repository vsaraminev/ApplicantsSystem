using Microsoft.Extensions.Caching.Memory;

namespace ApplicantsSystem.Tests.Controllers.Admin.ApplicantsController
{
    using ApplicantsSystem.Services.Admin;
    using Common.Admin.BindingModels;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using Web.Areas.Admin.Controllers;

    [TestClass]
    public class ChangeStatusTests
    {
        [TestMethod]
        public void ChangeStatus_WithValidStatus_ShouldCallService()
        {
            //Arrange
            var model = new AdminChangeApplicantsStatus();

            bool serviceCalled = false;

            var mockRepository = new Mock<IAdminApplicantService>();

            mockRepository.Setup(r => r.ChangeStatus(model))
                .Callback(() => serviceCalled = true);
            
            var controller = new ApplicantsController(mockRepository.Object);

            //Act
            var result = controller.ChangeStatus(model);

            //Assert
            Assert.IsTrue(serviceCalled);
        }
    }
}
