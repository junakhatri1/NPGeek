using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Capstone.Web.DAL;
using System.Data.SqlClient;
using System.Web.Configuration;
using Capstone.Web.Models;

namespace Capstone.Web.Tests.DAL
{
    [TestClass]
    public class WeatherSqlDALTests
    {
        //Commenting out the test to make it work in app harbor
        //string connectionString = @"Data Source=.\sqlexpress;Initial Catalog=NPGeek;User ID=te_student;Password=sqlserver1";

        //[TestMethod]
        //public void GetFiveDaysWeatherTests()
        //{

        //    using (SqlConnection conn = new SqlConnection(connectionString))
        //    {
        //        SqlCommand cmd;
        //        conn.Open();
        //        cmd = new SqlCommand("SELECT Count(*) FROM weather WHERE parkCode = 'CVNP';", conn);
        //    }
        //    WeatherSqlDAL weatherSql = new WeatherSqlDAL(connectionString);

        //    List<Weather> weathers = weatherSql.GetFiveDaysWeather("CVNP");

        //    Assert.IsNotNull(weathers);
        //    Assert.AreEqual(5, weathers.Count);
        //}
    }
}
