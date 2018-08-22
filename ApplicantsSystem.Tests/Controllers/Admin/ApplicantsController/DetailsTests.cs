using Microsoft.Extensions.Caching.Memory;

namespace ApplicantsSystem.Tests.Controllers.Admin.ApplicantsController
{
    using ApplicantsSystem.Services.Admin;
    using Common.Admin.ViewModels;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using System.Threading.Tasks;
    using Web.Areas.Admin.Controllers;

    [TestClass]
    public class DetailsTests
    {
        [TestMethod]
        public async Task Details_ShouldReturnApplicant()
        {
            //Arrange
            var applicantModel = new AdminApplicantDetailsViewModel()
            {
                Id = 1,
                FirstName = "FirstName",
                LastName = "LastName"
            };

            bool serviceCalled = false;

            var mockRepository = new Mock<IAdminApplicantService>();

            mockRepository.Setup(service => service.Details(It.IsAny<int>()))
                .ReturnsAsync(applicantModel)
                .Callback(() => serviceCalled = true);
           
            var controller = new ApplicantsController(mockRepository.Object);

            //Act
            var result = await controller.Details(1);

            //Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            Assert.IsTrue(serviceCalled);
        }
    }
}
