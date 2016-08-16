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

namespace MVC.Controllers
{
    public class PlacesController : Controller
    {
        private WebAppContext db = new WebAppContext();

        // GET: Places
        public ActionResult Index()
        {
            return View(db.Places.ToList());
        }

        // GET: Places/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlaceViewModel placeViewModel = new PlaceViewModel()
            {
                Place = db.Places.Find(id)
            }; 
            
            if (placeViewModel.Place == null)
            {
                return HttpNotFound();
            }
            return View(placeViewModel);
        }

        // GET: Places/Create
        public ActionResult Create()
        {
            PlaceViewModel placeViewModel = new PlaceViewModel()
            {
                Categories = db.Categories.ToList()
            };

            return View(placeViewModel);
        }

        // POST: Places/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create
        (
            [Bind(Include = "Place, SelectedCategories")]PlaceViewModel placeViewModel,
            [Bind(Include = "Name, Address, Longitude, Latitude, Categories")]Place Place
        )
        {
            //Need this in view if modelstate is NOT valid. 
            //Selectlist get's this...
            placeViewModel.Categories = db.Categories.ToList();

            if (ModelState.IsValid)
            {
                placeViewModel.Place.User = User.Identity.Name;
                //Save New Place
                db.Places.Add(placeViewModel.Place);

                if (placeViewModel.SelectedCategories != null)
                {
                    //Add Categories For new Place
                    //TODO Replace by lambda expression!
                    for (int i = 0; i < placeViewModel.SelectedCategories.Count(); i++)
                    {
                        //Iterating over selection...
                        placeViewModel.Place.Categories.Add(db.Categories.Find(placeViewModel.SelectedCategories[i]));
                    }
                }

                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(placeViewModel);}

        // GET: Places/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Place place = db.Places.Find(id);
            if (place == null)
            {
                return HttpNotFound();
            }
            return View(place);
        }

        // POST: Places/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] Place place)
        {
            if (ModelState.IsValid)
            {
                db.Entry(place).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(place);
        }

        // GET: Places/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Place place = db.Places.Find(id);
            if (place == null)
            {
                return HttpNotFound();
            }
            return View(place);
        }

        // POST: Places/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Place place = db.Places.Find(id);
            db.Places.Remove(place);
            db.SaveChanges();
            return RedirectToAction("Index");
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
