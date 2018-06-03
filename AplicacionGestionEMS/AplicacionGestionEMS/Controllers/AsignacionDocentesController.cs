using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AplicacionGestionEMS.Models;

namespace AplicacionGestionEMS.Controllers
{
    [Authorize(Roles = "tipoAdmin")]
    public class AsignacionDocentesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AsignacionDocentes
        public ActionResult Index()
        {
            var asignacionDocentes = db.AsignacionDocentes.Include(a => a.Curso).Include(a => a.GrupoClase).Include(a => a.User);
            return View(asignacionDocentes.ToList());
        }

        // GET: AsignacionDocentes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AsignacionDocentes asignacionDocentes = db.AsignacionDocentes.Find(id);
            if (asignacionDocentes == null)
            {
                return HttpNotFound();
            }
            return View(asignacionDocentes);
        }

        // GET: AsignacionDocentes/Create
        public ActionResult Create()
        {
            ViewBag.codCurso = new SelectList(db.Cursos, "codCurso", "nombre");
            ViewBag.codGrupoClase = new SelectList(db.GrupoClases, "codGrupoClase", "nombre");
            ViewBag.UserId = new SelectList(db.Users, "Id", "Name");
            return View();
        }

        // POST: AsignacionDocentes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,codCurso,codGrupoClase,UserId")] AsignacionDocentes asignacionDocentes)
        {
            if (ModelState.IsValid)
            {
                db.AsignacionDocentes.Add(asignacionDocentes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.codCurso = new SelectList(db.Cursos, "codCurso", "nombre", asignacionDocentes.codCurso);
            ViewBag.codGrupoClase = new SelectList(db.GrupoClases, "codGrupoClase", "nombre", asignacionDocentes.codGrupoClase);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Name", asignacionDocentes.UserId);
            return View(asignacionDocentes);
        }

        // GET: AsignacionDocentes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AsignacionDocentes asignacionDocentes = db.AsignacionDocentes.Find(id);
            if (asignacionDocentes == null)
            {
                return HttpNotFound();
            }
            ViewBag.codCurso = new SelectList(db.Cursos, "codCurso", "nombre", asignacionDocentes.codCurso);
            ViewBag.codGrupoClase = new SelectList(db.GrupoClases, "codGrupoClase", "nombre", asignacionDocentes.codGrupoClase);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Name", asignacionDocentes.UserId);
            return View(asignacionDocentes);
        }

        // POST: AsignacionDocentes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,codCurso,codGrupoClase,UserId")] AsignacionDocentes asignacionDocentes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(asignacionDocentes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.codCurso = new SelectList(db.Cursos, "codCurso", "nombre", asignacionDocentes.codCurso);
            ViewBag.codGrupoClase = new SelectList(db.GrupoClases, "codGrupoClase", "nombre", asignacionDocentes.codGrupoClase);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Name", asignacionDocentes.UserId);
            return View(asignacionDocentes);
        }

        // GET: AsignacionDocentes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AsignacionDocentes asignacionDocentes = db.AsignacionDocentes.Find(id);
            if (asignacionDocentes == null)
            {
                return HttpNotFound();
            }
            return View(asignacionDocentes);
        }

        // POST: AsignacionDocentes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AsignacionDocentes asignacionDocentes = db.AsignacionDocentes.Find(id);
            db.AsignacionDocentes.Remove(asignacionDocentes);
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
