using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SeguimientoProyectosASP.NET.Models;

namespace SeguimientoProyectosASP.NET.Controllers
{
    public class ResponsablesController : BaseController
    {
        private SeguimientoProyectosEntities db = new SeguimientoProyectosEntities();

        public ResponsablesController()
        {
            ViewBag.opcionMenu[3] = "active";
        }

        // GET: Responsables
        public ActionResult Index()
        {
            var responsable = db.Responsable.Include(r => r.Tarea).Include(r => r.Usuario);
            return View(responsable.ToList());
        }

        // GET: Responsables/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Responsable responsable = db.Responsable.Find(id);
            if (responsable == null)
            {
                return HttpNotFound();
            }
            return View(responsable);
        }

        // GET: Responsables/Create
        public ActionResult Create()
        {
            ViewBag.codigo_tarea = new SelectList(db.Tarea, "codigo", "nombre");
            ViewBag.codigo_usuario = new SelectList(db.Usuario, "codigo", "nombres");
            return View();
        }

        // POST: Responsables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "codigo,codigo_tarea,codigo_usuario")] Responsable responsable)
        {
            if (ModelState.IsValid)
            {
                db.Responsable.Add(responsable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.codigo_tarea = new SelectList(db.Tarea, "codigo", "nombre", responsable.codigo_tarea);
            ViewBag.codigo_usuario = new SelectList(db.Usuario, "codigo", "nombres", responsable.codigo_usuario);
            return View(responsable);
        }

        // GET: Responsables/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Responsable responsable = db.Responsable.Find(id);
            if (responsable == null)
            {
                return HttpNotFound();
            }
            ViewBag.codigo_tarea = new SelectList(db.Tarea, "codigo", "nombre", responsable.codigo_tarea);
            ViewBag.codigo_usuario = new SelectList(db.Usuario, "codigo", "nombres", responsable.codigo_usuario);
            return View(responsable);
        }

        // POST: Responsables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "codigo,codigo_tarea,codigo_usuario")] Responsable responsable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(responsable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.codigo_tarea = new SelectList(db.Tarea, "codigo", "nombre", responsable.codigo_tarea);
            ViewBag.codigo_usuario = new SelectList(db.Usuario, "codigo", "nombres", responsable.codigo_usuario);
            return View(responsable);
        }

        // GET: Responsables/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Responsable responsable = db.Responsable.Find(id);
            if (responsable == null)
            {
                return HttpNotFound();
            }
            return View(responsable);
        }

        // POST: Responsables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            Responsable responsable = db.Responsable.Find(id);
            db.Responsable.Remove(responsable);
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
