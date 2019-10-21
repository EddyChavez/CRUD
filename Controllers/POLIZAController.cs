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
using CRUD.Models;

namespace CRUD.Controllers
{
    [RoutePrefix("api/POLIZA")]
    public class POLIZAController : ApiController
    {
        private CRUD1Entities db = new CRUD1Entities();

        // GET: api/POLIZA
        public IQueryable<POLIZA> GetPOLIZA()
        {
            return db.POLIZA;
        }

        // GET: api/POLIZA/5
        [ResponseType(typeof(POLIZA))]
        public IHttpActionResult GetPOLIZA(int id)
        {
            POLIZA pOLIZA = db.POLIZA.Find(id);
            if (pOLIZA == null)
            {
                return NotFound();
            }

            return Ok(pOLIZA);
        }

        // PUT: api/POLIZA/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPOLIZA(int id, POLIZA pOLIZA)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pOLIZA.ID_POLIZA)
            {
                return BadRequest();
            }

            db.Entry(pOLIZA).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!POLIZAExists(id))
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

        // POST: api/POLIZA
        [ResponseType(typeof(POLIZA))]
        public IHttpActionResult PostPOLIZA(POLIZA pOLIZA)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.POLIZA.Add(pOLIZA);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = pOLIZA.ID_POLIZA }, pOLIZA);
        }

        // DELETE: api/POLIZA/5
        [ResponseType(typeof(POLIZA))]
        public IHttpActionResult DeletePOLIZA(int id)
        {
            POLIZA pOLIZA = db.POLIZA.Find(id);
            if (pOLIZA == null)
            {
                return NotFound();
            }

            db.POLIZA.Remove(pOLIZA);
            db.SaveChanges();

            return Ok(pOLIZA);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool POLIZAExists(int id)
        {
            return db.POLIZA.Count(e => e.ID_POLIZA == id) > 0;
        }
    }
}