using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class AdminController : Controller
    {
        private WebAppContext db = new WebAppContext();

        // GET: Admin
        public ActionResult Index()
        {
            return View(db.Apps.ToList());
        }
    }
}