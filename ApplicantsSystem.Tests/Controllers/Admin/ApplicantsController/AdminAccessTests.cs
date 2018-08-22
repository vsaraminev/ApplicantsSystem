namespace ApplicantsSystem.Tests.Controllers.Admin.ApplicantsController
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Linq;
    using Web.Areas.Admin.Controllers;
    using Microsoft.AspNetCore.Authorization;
    using static ApplicantsSystem.Common.Constants.WebConstants;

    [TestClass]
    public class AdminAccessTests
    {
        [TestMethod]
        public void ApplicantController_ShouldBeInAdminArea()
        {
            //Arrange

            var area = typeof(ApplicantsController)
                .GetCustomAttributes(true)
                .FirstOrDefault(a => a is AreaAttribute) as AreaAttribute;

            //Act

            //Assert
            Assert.IsNotNull(area);
            Assert.AreEqual(AdminArea, area.RouteValue);
        }

        [TestMethod]
        public void ApplicantController_ShouldAuthorizeAdmins()
        {
            //Arrange

            var authorization = typeof(ApplicantsController)
                .GetCustomAttributes(true)
                .FirstOrDefault(a => a is AuthorizeAttribute) as AuthorizeAttribute;

            //Act

            //Assert
            Assert.IsNotNull(authorization);
            Assert.AreEqual(AdministratorRole, authorization.Roles);
        }
    }
}
