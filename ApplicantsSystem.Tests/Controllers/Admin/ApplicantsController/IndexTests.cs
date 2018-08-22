using Microsoft.Extensions.Caching.Memory;

namespace ApplicantsSystem.Tests.Controllers.Admin.ApplicantsController
{
    using ApplicantsSystem.Services.Admin;
    using Common.Admin.ViewModels;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using Web.Areas.Admin.Controllers;

    [TestClass]
    public class IndexTests
    {
        [TestMethod]
        public void Index_ReturnAllApplicants()
        {
            //Arrange
            var applicantModel = new AdminApplicantListingViewModel()
            {
                Id = 1,
                FirstName = "FirstName",
                LastName = "LastName"
            };

            bool methodCalled = false;

            var mockRepository = new Mock<IAdminApplicantService>();

            mockRepository
            .Setup(s => s.All())
            .Returns(new[] { applicantModel })
            .Callback(() => methodCalled = true);

            var controller = new ApplicantsController(mockRepository.Object);
            //Act
            var result = controller.Index();

            //Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));

            var resultView = result as ViewResult;

            Assert.IsNotNull(resultView.Model);
            Assert.IsTrue(methodCalled);
        }
    }
}
