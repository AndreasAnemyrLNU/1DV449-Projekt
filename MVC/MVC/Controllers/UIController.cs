﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class UIController : Controller
    {
        // GET: Jaktlag
        public ActionResult Index()
        {
            return View();
        }
    }
}