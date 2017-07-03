using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Capstone.Web.Models;

namespace Capstone.Web.Tests.Models
{
    [TestClass]
    public class ParkTests
    {
        [TestMethod]
        public void ChangeToCelsiusTest_ReturnZero()
        {
            Park park = new Park();

            double result = park.ChangeToCelsius(32);

            Assert.AreEqual(0, result);
        }
        [TestMethod]
        public void ChangeToCelsiusTest_ReturnNegative()
        {
            Park park = new Park();

            double result = park.ChangeToCelsius(10);

            Assert.AreEqual(-12, result);
        }
        [TestMethod]
        public void ChangeToCelsiusTest_ReturnPositive()
        {
            Park park = new Park();

            double result = park.ChangeToCelsius(70);

            Assert.AreEqual(21, result);
        }

    }
}
