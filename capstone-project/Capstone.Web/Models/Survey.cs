using Capstone.Web.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone.Web.Models
{
    public class Survey
    {
       public int SurveyId { get; set; }
       public string ParkCode { get; set; }
       public string EmailAddress { get; set; }
       public string State { get; set; }
       public string ActivityLevel { get; set; }



        private ParkSqlDAL parkDal;
       List<Park> parks = new List<Park>();

        public Survey(ParkSqlDAL parkDal)
        {
            this.parkDal = parkDal;
        }
       
        parkDal.
    }
}