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
using WebPinterest.DAL;
using WebPinterest.Models;

namespace WebPinterest.Controllers
{
    public class Pins1Controller : ApiController
    {
        private PinterestContext db = new PinterestContext();

        // GET: api/Pins1
        public IQueryable<Pin> GetPins()
        {
            return db.Pins;
        }

        // GET: api/Pins1/5
        [ResponseType(typeof(Pin))]
        public IHttpActionResult GetPin(int id)
        {
            Pin pin = db.Pins.Find(id);
            if (pin == null)
            {
                return NotFound();
            }

            return Ok(pin);
        }

        // PUT: api/Pins1/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPin(int id, Pin pin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pin.PinID)
            {
                return BadRequest();
            }

            db.Entry(pin).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PinExists(id))
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

        // POST: api/Pins1
        [ResponseType(typeof(Pin))]
        public IHttpActionResult PostPin(Pin pin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Pins.Add(pin);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = pin.PinID }, pin);
        }

        // DELETE: api/Pins1/5
        [ResponseType(typeof(Pin))]
        public IHttpActionResult DeletePin(int id)
        {
            Pin pin = db.Pins.Find(id);
            if (pin == null)
            {
                return NotFound();
            }

            db.Pins.Remove(pin);
            db.SaveChanges();

            return Ok(pin);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PinExists(int id)
        {
            return db.Pins.Count(e => e.PinID == id) > 0;
        }
    }
}