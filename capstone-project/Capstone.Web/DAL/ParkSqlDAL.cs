using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Dapper;

namespace Capstone.Web.DAL
{
    public class ParkSqlDAL : IParkDAL
    {
        readonly string connectionString;
        readonly IWeatherDAL weatherDal;
   

        const string SQL_GetAllParks = "SELECT * FROM park;";
        const string SQL_GetParkByParkCode = "SELECT * FROM park WHERE parkCode = @parkCode;";

        public ParkSqlDAL(string connectionString, IWeatherDAL weatherDal)
        {
            this.connectionString = connectionString;
            this.weatherDal = weatherDal;
           
        }

        public List<Park> GetAllParks()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    List<Park> parks = conn.Query<Park>(SQL_GetAllParks).ToList();
                    return parks;
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
        }

        public Park GetPark(string parkCode)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    Park park = conn.QueryFirstOrDefault<Park>(SQL_GetParkByParkCode, new { parkCode = parkCode });
                    park.fiveDaysWeather = weatherDal.GetFiveDaysWeather(park.ParkCode);
                    return park;
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
        }
    }
}