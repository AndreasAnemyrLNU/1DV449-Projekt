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

namespace MVC.Controllers
{
    public class CategoriesController : Controller
    {
        private WebAppContext db = new WebAppContext();

        // GET: Categories
        public ActionResult Index()
        {
            return View(db.Categories.ToList());
        }

        // GET: Categories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            //Add selected Category in categoryViewModel
            CategoryViewModel categoryViewModel = new CategoryViewModel
            {
                Category = db.Categories.Find(id)
            };

            //Add Apps for specfic cateory
            categoryViewModel.Apps = categoryViewModel.Category.Apps;

            if (categoryViewModel.Category == null)
            {
                return HttpNotFound();
            }
            return View(categoryViewModel);
        }

        // GET: Categories/Create
        public ActionResult Create()
        {
            CategoryViewModel categoryViewModel = new CategoryViewModel()
            {
                Apps = db.Apps.ToList()
            };

            return View(categoryViewModel);
        }

        // POST: Categories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create
        (
            [Bind(Include = "Category, SelectedApps")]CategoryViewModel categoryViewModel,
            [Bind(Include = "Name")]Category Category
        )
        {
            //Need this in view if modelstate is NOT valid. 
            //Selectlist get's this...
            categoryViewModel.Apps = db.Apps.ToList();

            if (ModelState.IsValid)
            {
                categoryViewModel.Category.User = User.Identity.Name;
                //Save New App
                db.Categories.Add(categoryViewModel.Category);

                if (categoryViewModel.SelectedApps != null)
                {
                    //Add Categories For new App
                    //TODO Replace by lambda expression!
                    for (int i = 0; i < categoryViewModel.SelectedApps.Count(); i++)
                    {
                        //Iterating over selection...
                        categoryViewModel.Category.Apps.Add(db.Apps.Find(categoryViewModel.SelectedApps[i]));
                    }
                }

                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(categoryViewModel);
        }

        // GET: Categories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] Category category)
        {
            if (ModelState.IsValid)
            {
                db.Entry(category).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);
        }

        // GET: Categories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Category category = db.Categories.Find(id);
            db.Categories.Remove(category);
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
