using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebPinterest.DAL;
using WebPinterest.Models;

namespace WebPinterest.Controllers
{
    public class PinsController : Controller
    {
        private PinterestContext db = new PinterestContext();

        // GET: Pins
        public ActionResult Index()
        {
            return View(db.Pins.ToList());
        }

        // GET: Pins/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pin pin = db.Pins.Find(id);
            if (pin == null)
            {
                return HttpNotFound();
            }
            return View(pin);
        }

        // GET: Pins/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pins/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PinID,Title,Text,Picture")] Pin pin)
        {
            if (ModelState.IsValid)
            {
                db.Pins.Add(pin);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pin);
        }

        // GET: Pins/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pin pin = db.Pins.Find(id);
            if (pin == null)
            {
                return HttpNotFound();
            }
            return View(pin);
        }

        // POST: Pins/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PinID,Title,Text,Picture")] Pin pin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pin);
        }

        // GET: Pins/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pin pin = db.Pins.Find(id);
            if (pin == null)
            {
                return HttpNotFound();
            }
            return View(pin);
        }

        // POST: Pins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pin pin = db.Pins.Find(id);
            db.Pins.Remove(pin);
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
