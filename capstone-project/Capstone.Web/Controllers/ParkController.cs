using Capstone.Web.DAL;
using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capstone.Web.Controllers
{
    public class ParkController : Controller
    {

        private IParkDAL parkDal;
       // private IWeatherDAL weatherDal;

        public ParkController (IParkDAL parkDal)

        {
            this.parkDal = parkDal;
           
        }


        // GET: Park
        [HttpGet]
        public ActionResult Index()
        {
            List<Park> parks = parkDal.GetAllParks();
            if(parks == null)
            {
                return HttpNotFound();
            }
            return View("Index", parks);
        }

        [HttpGet]
        public ActionResult Detail(string parkCode)
        {
            Park park = parkDal.GetPark(parkCode);
            return View("Detail", park);
        }

    }
}