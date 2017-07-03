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
    public class PARKSqlDALTests
    {
        IWeatherDAL weatherDAL;
        string connectionString = @"Data Source=.\sqlexpress;Initial Catalog=NPGeek;User ID=te_student;Password=sqlserver1";
        int numOfParks = 0;
        string parkCode = "CVNP";
        //[TestInitialize]
        //{
        //using (SqlConnection conn = new SqlConnection(connectionString))
        //    {
        //        SqlCommand cmd;
        //conn.Open();
        //        cmd = new SqlCommand("SELECT * FROM park;", conn);
        //}   


        [TestMethod]
        public void GetAllParksTest()
        {

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd;
                conn.Open();
                cmd = new SqlCommand("SELECT Count(*) FROM park;", conn);
                numOfParks = (int)cmd.ExecuteScalar();
            }
            ParkSqlDAL parkSql = new ParkSqlDAL(connectionString, weatherDAL);

            List<Park> parks = parkSql.GetAllParks();

            Assert.IsNotNull(parks);
            Assert.AreEqual(numOfParks, parks.Count);
        }

        [TestMethod]
        public void GetParkByParkCodeTest()
        {
            string parkName;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd;
                conn.Open();
                cmd = new SqlCommand("SELECT parkName FROM park WHERE parkCode = 'CVNP';", conn);
                parkName = (string)cmd.ExecuteScalar();
            }
            ParkSqlDAL parkSql = new ParkSqlDAL(connectionString, weatherDAL);
            Assert.IsNotNull(true);
            Assert.AreEqual("Cuyahoga Valley National Park", parkName);

        }
    }
    
}
