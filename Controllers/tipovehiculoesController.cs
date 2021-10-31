using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProyectoClase;

namespace ProyectoClase.Controllers
{
    public class tipovehiculoesController : Controller
    {
        private EstacionamientoEntities db = new EstacionamientoEntities();

        // GET: tipovehiculoes
        public ActionResult Index()
        {
            return View(db.tipovehiculo.ToList());
        }

        // GET: tipovehiculoes/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipovehiculo tipovehiculo = db.tipovehiculo.Find(id);
            if (tipovehiculo == null)
            {
                return HttpNotFound();
            }
            return View(tipovehiculo);
        }

        // GET: tipovehiculoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tipovehiculoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Idtipo,descripcion")] tipovehiculo tipovehiculo)
        {
            if (ModelState.IsValid)
            {
                db.tipovehiculo.Add(tipovehiculo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipovehiculo);
        }

        // GET: tipovehiculoes/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipovehiculo tipovehiculo = db.tipovehiculo.Find(id);
            if (tipovehiculo == null)
            {
                return HttpNotFound();
            }
            return View(tipovehiculo);
        }

        // POST: tipovehiculoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Idtipo,descripcion")] tipovehiculo tipovehiculo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipovehiculo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipovehiculo);
        }

        // GET: tipovehiculoes/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipovehiculo tipovehiculo = db.tipovehiculo.Find(id);
            if (tipovehiculo == null)
            {
                return HttpNotFound();
            }
            return View(tipovehiculo);
        }

        // POST: tipovehiculoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            tipovehiculo tipovehiculo = db.tipovehiculo.Find(id);
            db.tipovehiculo.Remove(tipovehiculo);
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
