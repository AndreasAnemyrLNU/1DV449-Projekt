using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Applikationens syfte";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Kontakta mig";

            return View();
        }
    }
}