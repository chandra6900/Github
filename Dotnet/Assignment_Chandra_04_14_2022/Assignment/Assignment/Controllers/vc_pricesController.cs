using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Assignment.Models;

namespace Assignment.Controllers
{
    public class vc_pricesController : Controller
    {
        private DBModel db = new DBModel();

        // GET: vc_prices
        public ActionResult Index()
        {
            return View(db.vc_prices.ToList());
        }

        // GET: vc_prices/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vc_prices vc_prices = db.vc_prices.Find(id);
            if (vc_prices == null)
            {
                return HttpNotFound();
            }
            return View(vc_prices);
        }

        // GET: vc_prices/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: vc_prices/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "surrogate,pricedate,delivdat,price,status")] vc_prices vc_prices)
        {
            DateTime priceFromDate = DateTime.Parse("7/1/2018");
            DateTime priceToDate = DateTime.Parse("8/5/2018");
            DateTime deliveryFromDate = DateTime.Parse("8/1/2018");
            DateTime deliveryToDate = DateTime.Parse("10/1/2018");
            if (ModelState.IsValid)
            {
               double? avgPrice= db.vc_prices
                    .Where(vc => vc.pricedate >= priceFromDate.Date 
                    && vc.pricedate <= priceToDate.Date 
                    && vc.delivdat >= deliveryFromDate.Date 
                    && vc.delivdat <= deliveryToDate.Date).Select(vc=>vc.price).Average();
                if (avgPrice != null)
                    vc_prices.price = Convert.ToInt32(avgPrice);
                db.vc_prices.Add(vc_prices);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vc_prices);
        }

        // GET: vc_prices/New
        public ActionResult New()
        {
            return View();
        }

        // POST: vc_prices/New
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult New([Bind(Include = "surrogate,pricedate,delivdat,price,status")] vc_prices vc_prices)
        {
            if (ModelState.IsValid)
            {
                db.vc_prices.Add(vc_prices);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vc_prices);
        }

        // GET: vc_prices/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vc_prices vc_prices = db.vc_prices.Find(id);
            if (vc_prices == null)
            {
                return HttpNotFound();
            }
            return View(vc_prices);
        }

        // POST: vc_prices/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "surrogate,pricedate,delivdat,price,status")] vc_prices vc_prices)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vc_prices).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vc_prices);
        }

        // GET: vc_prices/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vc_prices vc_prices = db.vc_prices.Find(id);
            if (vc_prices == null)
            {
                return HttpNotFound();
            }
            return View(vc_prices);
        }

        // POST: vc_prices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            vc_prices vc_prices = db.vc_prices.Find(id);
            db.vc_prices.Remove(vc_prices);
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
