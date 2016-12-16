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
    [Authorize]
    public class ListaAnkietsController : Controller
    {
        private BazaAnkiett db = new BazaAnkiett();

        // GET: ListaAnkiets
        public ActionResult Index()
        {
            List<ListaAnkiet> listaAnkiet = db.ListaAnkiets.Where(x => x.nazwaUzytko == User.Identity.Name).ToList();
            return View(listaAnkiet);
        }

        // GET: ListaAnkiets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ListaAnkiet listaAnkiet = db.ListaAnkiets.Find(id);
            if (listaAnkiet == null)
            {
                return HttpNotFound();
            }
            return View(listaAnkiet);
        }

        // GET: ListaAnkiets/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ListaAnkiets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "nazwaAnkiety,Aktywna,Pytanie")] ListaAnkiet listaAnkiet)
        {
            if (ModelState.IsValid)
            {
                listaAnkiet.nazwaUzytko = User.Identity.Name;
                listaAnkiet.dataDodania = DateTime.Now;
                listaAnkiet.dataZakonczenia = DateTime.Now;
                listaAnkiet.idUzyt = 1;
                listaAnkiet.liczbaAnkietowanych = 0;
                db.ListaAnkiets.Add(listaAnkiet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(listaAnkiet);
        }

        // GET: ListaAnkiets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ListaAnkiet listaAnkiet = db.ListaAnkiets.Find(id);
            if (listaAnkiet == null)
            {
                return HttpNotFound();
            }
            return View(listaAnkiet);
        }

        // POST: ListaAnkiets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nazwaAnkiety,dataDodania,dataZakonczenia,Aktywna,liczbaAnkietowanych,Pytanie,idUzyt,nazwaUzytko")] ListaAnkiet listaAnkiet)
        {
            
            if (ModelState.IsValid)
            {
                db.Entry(listaAnkiet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(listaAnkiet);
        }

        // GET: ListaAnkiets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ListaAnkiet listaAnkiet = db.ListaAnkiets.Find(id);
            if (listaAnkiet == null)
            {
                return HttpNotFound();
            }
            return View(listaAnkiet);
        }

        // POST: ListaAnkiets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ListaAnkiet listaAnkiet = db.ListaAnkiets.Find(id);
            db.ListaAnkiets.Remove(listaAnkiet);
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
