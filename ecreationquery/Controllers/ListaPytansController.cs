using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ecreationquery.Models;

namespace ecreationquery.Controllers
{
    public class ListaPytansController : Controller
    {
        private BazaAnkiett db = new BazaAnkiett();

        // GET: ListaPytans
        public ActionResult Index(int? id)
        {
            return View(db.ListaPytans.ToList());
        }

        // GET: ListaPytans/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ListaPytan listaPytan = db.ListaPytans.Find(id);
            if (listaPytan == null)
            {
                return HttpNotFound();
            }
            return View(listaPytan);
        }

        // GET: ListaPytans/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ListaPytans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Pytanie")] ListaPytan listaPytan)
        {
            if (ModelState.IsValid)
            {
                db.ListaPytans.Add(listaPytan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(listaPytan);
        }

        // GET: ListaPytans/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ListaPytan listaPytan = db.ListaPytans.Find(id);
            if (listaPytan == null)
            {
                return HttpNotFound();
            }
            return View(listaPytan);
        }

        // POST: ListaPytans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Pytanie")] ListaPytan listaPytan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(listaPytan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(listaPytan);
        }

        // GET: ListaPytans/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ListaPytan listaPytan = db.ListaPytans.Find(id);
            if (listaPytan == null)
            {
                return HttpNotFound();
            }
            return View(listaPytan);
        }

        // POST: ListaPytans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ListaPytan listaPytan = db.ListaPytans.Find(id);
            db.ListaPytans.Remove(listaPytan);
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
