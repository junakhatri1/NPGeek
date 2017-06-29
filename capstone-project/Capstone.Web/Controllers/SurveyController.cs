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
        private IParkDAL parkDAL;

        public SurveyController(IParkDAL parkDAL)
        {
            this.parkDAL = parkDAL;
        }
        // GET: Survey
        public ActionResult Survey()
        {
            return View("Survey");
        }


        [HttpPost]
        public ActionResult Survey(Survey model)
        {
            List<Park> AllParks = parkDAL.GetAllParks();
        }
    }
}