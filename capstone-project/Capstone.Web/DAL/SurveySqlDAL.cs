using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Capstone.Web.Models;
using System.Data.SqlClient;
using Dapper;

namespace Capstone.Web.DAL
{
    public class SurveySqlDAL : ISurveyDAL
    {
        readonly string connectionString;
        readonly ISurveyDAL surveyDal;


        const string SQL_SaveNewSurvey = "INSERT INTO survey_result VALUES (@parkCode, @emailAddress, @state, @activityLevel);";
        const string SQL_GetAllSurveyList = "Select * FROM survey_result";
        //const string SQL_GetUniqueSurvey = "SELECT parkCode, COUNT(parkCode) FROM survey_result GROUP BY parkCode;";
        int numberOfSurveys;
        public SurveySqlDAL(string connectionString)
        {
            this.connectionString = connectionString;


        }

        public bool SaveSurvey(Survey newSurvey)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(SQL_SaveNewSurvey, conn);
                    cmd.Parameters.AddWithValue("@parkCode", newSurvey.ParkCode);
                    cmd.Parameters.AddWithValue("@emailAddress", newSurvey.EmailAddress);
                    cmd.Parameters.AddWithValue("@state", newSurvey.State);
                    cmd.Parameters.AddWithValue("@activityLevel", newSurvey.ActivityLevel);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;

                }
            }
            catch (SqlException ex)
            {
                throw;
            }
        }

        public List<Survey> GetAllSurveys()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    List<Survey> surveys = conn.Query<Survey>(SQL_GetAllSurveyList).ToList();
                    return surveys;
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
        }


        public Dictionary<List<string>, int> GetUniqueParks()
        {
            Dictionary<List<string>, int> allParksInSurvey = new Dictionary<List<string>, int>();
           
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT survey_result.parkCode,  park.parkName, COUNT(survey_result.parkCode) as surveyCount FROM survey_result JOIN park on park.parkCode = survey_result.parkCode GROUP BY survey_result.parkCode, park.ParkName ORDER BY ParkCode;", conn);                   
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        List<string> surveyKeys = new List<string>();
                        surveyKeys.Add(Convert.ToString(reader["parkCode"]));
                        surveyKeys.Add(Convert.ToString(reader["ParkName"]));
                       
                        
                        allParksInSurvey[surveyKeys] = Convert.ToInt32(reader["surveyCount"]);

                    }

                }
            }
            catch (SqlException ex)
            {
                throw;
            }
            return allParksInSurvey;
        }
    }
}