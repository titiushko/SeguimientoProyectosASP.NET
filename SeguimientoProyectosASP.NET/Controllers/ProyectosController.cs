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
    public class ProyectosController : BaseController
    {
        private SeguimientoProyectosEntities db = new SeguimientoProyectosEntities();
        
        public ProyectosController()
        {
            ViewBag.opcionMenu = new string[] { "", "active", "", "", "" };
        }

        // GET: Proyectos
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Title = "Lista Proyectos";

            var proyecto = db.Proyecto.Include(p => p.Usuario);
            
            return View(proyecto.ToList());
        }

        // GET: Proyectos/Details/5
        [HttpGet]
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Proyecto proyecto = db.Proyecto.Find(id);
            if (proyecto == null)
            {
                return HttpNotFound();
            }

            return View(proyecto);
        }

        // GET: Proyectos/Create
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.responsable = new SelectList(db.Usuario, "codigo", "nombres");

            return View();
        }

        // POST: Proyectos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "codigo,nombre,descripcion,fecha_inicio,fecha_fin,responsable")] Proyecto proyecto)
        {
            if (ModelState.IsValid)
            {
                db.Proyecto.Add(proyecto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.responsable = new SelectList(db.Usuario, "codigo", "nombres", proyecto.responsable);
            return View(proyecto);
        }

        // GET: Proyectos/Edit/5
        [HttpGet]
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Proyecto proyecto = db.Proyecto.Find(id);
            if (proyecto == null)
            {
                return HttpNotFound();
            }

            ViewBag.responsable = new SelectList(db.Usuario, "codigo", "nombres", proyecto.responsable);
            return View(proyecto);
        }

        // POST: Proyectos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "codigo,nombre,descripcion,fecha_inicio,fecha_fin,responsable")] Proyecto proyecto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(proyecto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.responsable = new SelectList(db.Usuario, "codigo", "nombres", proyecto.responsable);
            return View(proyecto);
        }

        // GET: Proyectos/Delete/5
        [HttpGet]
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Proyecto proyecto = db.Proyecto.Find(id);
            if (proyecto == null)
            {
                return HttpNotFound();
            }

            return View(proyecto);
        }

        // POST: Proyectos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            Proyecto proyecto = db.Proyecto.Find(id);
            db.Proyecto.Remove(proyecto);
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
