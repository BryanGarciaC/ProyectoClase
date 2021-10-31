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
    public class ParqueosController : Controller
    {
        private EstacionamientoEntities db = new EstacionamientoEntities();

        // GET: Parqueos
        public ActionResult Index()
        {
            var parqueo = db.Parqueo.Include(p => p.Registro).Include(p => p.Usuario).Include(p => p.Vehiculo);
            return View(parqueo.ToList());
        }

        // GET: Parqueos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Parqueo parqueo = db.Parqueo.Find(id);
            if (parqueo == null)
            {
                return HttpNotFound();
            }
            return View(parqueo);
        }

        // GET: Parqueos/Create
        public ActionResult Create()
        {
            ViewBag.facturaid = new SelectList(db.Registro, "idfactura", "idfactura");
            ViewBag.Usuarioid = new SelectList(db.Usuario, "IdUsuario", "Nombre");
            ViewBag.vehiculoid = new SelectList(db.Vehiculo, "IdVehiculo", "placa");
            return View();
        }

        // POST: Parqueos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Idregistro,fecha,horaentrada,horasalida,Usuarioid,facturaid,vehiculoid")] Parqueo parqueo)
        {
            if (ModelState.IsValid)
            {
                db.Parqueo.Add(parqueo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.facturaid = new SelectList(db.Registro, "idfactura", "idfactura", parqueo.facturaid);
            ViewBag.Usuarioid = new SelectList(db.Usuario, "IdUsuario", "Nombre", parqueo.Usuarioid);
            ViewBag.vehiculoid = new SelectList(db.Vehiculo, "IdVehiculo", "placa", parqueo.vehiculoid);
            return View(parqueo);
        }

        // GET: Parqueos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Parqueo parqueo = db.Parqueo.Find(id);
            if (parqueo == null)
            {
                return HttpNotFound();
            }
            ViewBag.facturaid = new SelectList(db.Registro, "idfactura", "idfactura", parqueo.facturaid);
            ViewBag.Usuarioid = new SelectList(db.Usuario, "IdUsuario", "Nombre", parqueo.Usuarioid);
            ViewBag.vehiculoid = new SelectList(db.Vehiculo, "IdVehiculo", "placa", parqueo.vehiculoid);
            return View(parqueo);
        }

        // POST: Parqueos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Idregistro,fecha,horaentrada,horasalida,Usuarioid,facturaid,vehiculoid")] Parqueo parqueo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(parqueo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.facturaid = new SelectList(db.Registro, "idfactura", "idfactura", parqueo.facturaid);
            ViewBag.Usuarioid = new SelectList(db.Usuario, "IdUsuario", "Nombre", parqueo.Usuarioid);
            ViewBag.vehiculoid = new SelectList(db.Vehiculo, "IdVehiculo", "placa", parqueo.vehiculoid);
            return View(parqueo);
        }

        // GET: Parqueos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Parqueo parqueo = db.Parqueo.Find(id);
            if (parqueo == null)
            {
                return HttpNotFound();
            }
            return View(parqueo);
        }

        // POST: Parqueos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Parqueo parqueo = db.Parqueo.Find(id);
            db.Parqueo.Remove(parqueo);
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
