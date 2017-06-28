using Capstone.Web.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Capstone.Web.DAL
{
    public class WeatherSqlDAL: IWeatherDAL
    {
        private string connectionString;


        private const string SQL_GetWeather = "SELECT* FROM Weather where parkCode = @parkCode;";

        public WeatherSqlDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Weather> GetFiveDaysWeather(string parkCode)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    List<Weather> fiveDaysWeather = conn.Query<Weather>(SQL_GetWeather, new { parkCode = parkCode }).ToList();
                    return fiveDaysWeather;

                }
            }
            catch (SqlException ex)
            {
                throw;
            }
        }
    }
}