using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC.Models;
using MVC.ViewModels;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using MVC.Models.Services;

namespace MVC.Controllers
{
    public class AppsController : Controller
    {
        private WebAppContext db = new WebAppContext();

        // GET: Apps
        public ActionResult Index()
        {
            return View(db.Apps.ToList());
        }

        // GET: Apps/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            //Add selected app in appViewModel
            AppViewModel appViewModel = new AppViewModel
            {
                App = db.Apps.Find(id)
            };

            //Add Categories for specfic app
            appViewModel.Categories = appViewModel.App.Categories;

            if (appViewModel.App == null)
            {
                return HttpNotFound();
            }
            return View(appViewModel);
        }

        // GET: Apps/Create
        public ActionResult Create()
        {
            AppViewModel appViewModel = new AppViewModel()
            {
                Categories = db.Categories.ToList()
            };
            
            return View(appViewModel);
        }

        // POST: Apps/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create
        (
            [Bind(Include = "App, SelectedCategories")]AppViewModel appViewModel,
            [Bind(Include = "AppName")]App App 
        )
        {
            //Need this in view if modelstate is NOT valid. 
            //Selectlist get's this...
            appViewModel.Categories = db.Categories.ToList();

            if (ModelState.IsValid)
            {
                appViewModel.App.User = User.Identity.Name;
                //Save New App
                db.Apps.Add(appViewModel.App);

                if(appViewModel.SelectedCategories != null)
                {
                    //Add Categories For new App
                    //TODO Replace by lambda expression!
                    for (int i = 0; i < appViewModel.SelectedCategories.Count(); i++)
                    {
                        //Iterating over selection...
                        appViewModel.App.Categories.Add(db.Categories.Find(appViewModel.SelectedCategories[i]));
                    }
                }
                
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(appViewModel);
        }

        // GET: Apps/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            //Final App in db using ef
            AppViewModel appViewModel = new AppViewModel()
            {
                App = db.Apps.Find(id),
                Categories = db.Categories
            };
            
            if (appViewModel.App == null)
            {
                return HttpNotFound();
            }
            return View(appViewModel);
        }

        // POST: Apps/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit
        (
            [Bind(Include = "App, SelectedCategories")]AppViewModel appViewModel,
            [Bind(Include = "AppName")]App App
        )
        {
            //Load Previous data to model!
            //Need this for making model complete (Selectlist)
            appViewModel.PreviousApp = db.Apps.Find(appViewModel.App.Id);

            if (ModelState.IsValid)
            {
                appViewModel.App.Categories = appViewModel.PreviousApp.Categories;
                appViewModel.App.Categories.Clear();

                if (appViewModel.SelectedCategories != null)
                {
                    //Add new selected Categories For App
                    //TODO Replace by lambda expression!
                    for (int i = 0; i < appViewModel.SelectedCategories.Count(); i++)
                    {                        
                        //Iterating over selection...
                        appViewModel.App.Categories.Add(db.Categories.Find(appViewModel.SelectedCategories[i]));
                    }

                }

                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(appViewModel);
        }

        // GET: Apps/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            App app = db.Apps.Find(id);
            if (app == null)
            {
                return HttpNotFound();
            }
            return View(app);
        }

        // POST: Apps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            App app = db.Apps.Find(id);
            db.Apps.Remove(app);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult GetApps()
        {

            AppViewModel appViewModel = new AppViewModel();

            IEnumerable<App> apps = db.Apps;

            if(apps.FirstOrDefault() == null)
            {
                return HttpNotFound();
            }

            var jsonResult = JsonConvert.SerializeObject(apps, Formatting.None,
                              new JsonSerializerSettings
                              {
                                  ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                              });

            return Json(jsonResult, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetAppCategories(int? id)
        {
            AppViewModel appViewModel = new AppViewModel();

            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Include your id!");
            }

            if (db.Apps.FirstOrDefault() == null)
            {
                return HttpNotFound("No apps in db yet!");
            }

            if (db.Apps.Find(id) == null){
                return HttpNotFound("Please, check your app id before next request!");
            }
            
            if (db.Apps.Find(id).Categories.FirstOrDefault() == null)
            {
                return HttpNotFound("No categories for selected app yet!");
            }

            IEnumerable<Category> categories = db.Apps.Find(id).Categories;

            var jsonResult = JsonConvert.SerializeObject(categories, Formatting.None,
                              new JsonSerializerSettings
                              {
                                  ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                              });

            return Json(jsonResult, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetCategoryPlaces(int? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Include your id!");
            }

            if (db.Categories.FirstOrDefault() == null)
            {
                return HttpNotFound("No categories in db yet!");
            }

            if (db.Categories.Find(id) == null)
            {
                return HttpNotFound("Please, check your category id before next request!");
            }

            if (db.Categories.Find(id).Places.FirstOrDefault() == null)
            {
                return HttpNotFound("No categories for selected place yet!");
            }

            IEnumerable<Place> categoryPlaces = db.Categories.Find(id).Places;

            var jsonResult = JsonConvert.SerializeObject(categoryPlaces, Formatting.None,
                              new JsonSerializerSettings
                              {
                                  ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                              });

            return Json(jsonResult, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetPlaceForecasts(int? id)
        {
            /*TODO Implement cache strategy for forecasts!
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Include your id!");
            }

            if (db.Places.FirstOrDefault() == null)
            {
                return HttpNotFound("No places in db yet!");
            }

            if (db.Places.Find(id) == null)
            {
                return HttpNotFound("Please, check your place id before next request!");
            }

            if (db.Places.Find(id).Forecasts.FirstOrDefault() == null)
            {
                return HttpNotFound("No forecasts for selected place yet!");
            }
            */
            //To avoid calling openweather for common requests.....

            Place place = db.Places.Find(id);


            IEnumerable<Forecast> forecasts = new WeatherService(db).RefreshForecast(place.Latitude, place.Longitude);

            if(!forecasts.Any())
            {
                return HttpNotFound("Openweathermap API down?");
            }

            var jsonResult = JsonConvert.SerializeObject(forecasts, Formatting.None,
                              new JsonSerializerSettings
                              {
                                  ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                              });

            return Json(jsonResult, JsonRequestBehavior.AllowGet);

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

