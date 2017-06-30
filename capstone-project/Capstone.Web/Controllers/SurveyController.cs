using Capstone.Web.DAL;
using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capstone.Web.Controllers
{
    public class SurveyController : Controller
    {
        private ISurveyDAL surveyDAL;
        private IParkDAL parkDAL;


        public SurveyController(ISurveyDAL surveyDAL, IParkDAL parkDAL)
        {
            this.surveyDAL = surveyDAL;
            this.parkDAL = parkDAL;
        }

        // GET: Survey

        public ActionResult Survey()
        {
            return View("Survey");
        }


        [HttpPost]
        public ActionResult Survey(Survey survey)
        {
            //List<Park> AllParks = parkDAL.GetAllParks();
            if (ModelState.IsValid)
            {
                surveyDAL.SaveSurvey(survey);
                return RedirectToAction("FavoriteParks", "Survey");
            }
            else
            {
                return View("Survey");
            }
        }

        [HttpPost]
        public ActionResult FavoriteParks(Survey survey)
        {
            Park park = parkDAL.GetPark(survey.ParkCode);
            return View("FavoriteParks");
           
        }

        

    }
}