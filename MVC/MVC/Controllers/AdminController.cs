using MVC.Models;
using MVC.ViewModels;
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
            AdminViewModel model = new AdminViewModel
            {
                Apps = db.Apps.ToList<App>(),
                Categories = db.Categories.ToList<Category>(),
                Places = db.Places.ToList<Place>()
            };
                
            return View(model);
        }
    }
}