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

        public ParkController(IParkDAL parkDal)
        {
            this.parkDal = parkDal;
        }

        // GET: Park
        [HttpGet]
        public ActionResult Index()
        {
            List<Park> parks = parkDal.GetAllParks();
            if (parks == null)
            {
                return HttpNotFound();
            }
            return View("Index", parks);
        }

        [HttpGet]
        public ActionResult Detail(string parkCode)
        {
            string tempScale = GetTempScale();
            Park park = parkDal.GetPark(parkCode);
            if (park == null)
            {
                return HttpNotFound();
            }
            return View("Detail", park);
        }

        [HttpPost]
        public ActionResult Detail(Park park)
        {
            Session["tempScale"] = park.TempScale;
            park = parkDal.GetPark(park.ParkCode);
            park.TempScale = (string)Session["tempScale"];
            return View("Detail", park);
        }

        private string GetTempScale()
        {
            string tempScale = Convert.ToString(Session["tempScale"]);
            if (Session["tempScale"] == null)
            {
                tempScale = "F";
                Session["tempScale"] = tempScale;
            }
            return tempScale;
        }
    }
}