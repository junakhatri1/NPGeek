﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Capstone.Web.Models;
using System.Data.SqlClient;


namespace Capstone.Web.DAL
{
    public class SurveySqlDAL :  ISurveyDAL
    {
        readonly string connectionString;
        readonly ISurveyDAL surveyDal;


        const string SQL_SaveNewSurvey = "INSERT INTO survey_result VALUES (@parkCode, @emailAddress, @state, @activityLevel);";

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
    }
}