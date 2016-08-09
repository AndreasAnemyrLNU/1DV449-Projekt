using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using MVC.Models;

namespace MVC.Controllers
{
    public class GrainOfGoldController : ApiController
    {
        private DataModel db = new DataModel();

        // GET: api/MyNewEntities
        public IQueryable<GrainOfGold> GetGrainsOfGold()
        {
            return db.GrainsOfGold;
        }

        // GET: api/MyNewEntities/5
        [ResponseType(typeof(GrainOfGold))]
        public IHttpActionResult GetMyNewEntity(int id)
        {
            GrainOfGold myNewEntity = db.GrainsOfGold.Find(id);
            if (myNewEntity == null)
            {
                return NotFound();
            }

            return Ok(myNewEntity);
        }

        // PUT: api/MyNewEntities/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutGrainOfGold(int id, GrainOfGold grainOfFGold)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != grainOfFGold.Id)
            {
                return BadRequest();
            }

            db.Entry(grainOfFGold).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GrainOfGoldExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/MyNewEntities
        [ResponseType(typeof(GrainOfGold))]
        public IHttpActionResult PostGrainOfGold(GrainOfGold grainOfGold)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.GrainsOfGold.Add(grainOfGold);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = grainOfGold.Id }, grainOfGold);
        }

        // DELETE: api/MyNewEntities/5
        [ResponseType(typeof(GrainOfGold))]
        public IHttpActionResult DeleteGrainOfGold(int id)
        {
            GrainOfGold grainOfGold = db.GrainsOfGold.Find(id);
            if (grainOfGold == null)
            {
                return NotFound();
            }

            db.GrainsOfGold.Remove(grainOfGold);
            db.SaveChanges();

            return Ok(grainOfGold);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GrainOfGoldExists(int id)
        {
            return db.GrainsOfGold.Count(e => e.Id == id) > 0;
        }
    }
}