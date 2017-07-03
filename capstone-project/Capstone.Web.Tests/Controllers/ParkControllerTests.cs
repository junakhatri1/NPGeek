using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Capstone.Web.Tests.Controllers
{
    [TestClass()]
    public class ParkControllerTests
    {
        [TestMethod()]
        public void Index_HttpGet_ReturnIndexView()
        {
            //Arrange
            ParkController controller = new ParkController(null);

            //Act
            ViewResult result = controller.Index() as ViewResult;

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.ViewName);
        }
    }
}
