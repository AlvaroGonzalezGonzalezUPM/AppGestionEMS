using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AplicacionGestionEMS.Models;
using Microsoft.AspNet.Identity;

namespace AplicacionGestionEMS.Controllers
{
    public class MatriculasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Matriculas
        public ActionResult Index()
        {
            int grupo = getGrupoClase();
            var matriculas = db.Matriculas.Include(m => m.Curso).Include(m => m.GrupoClase).Include(m => m.User).Where(p => p.codGrupoClase == grupo).ToList();
            return View(matriculas.ToList());
        }

        // GET: Matriculas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Matriculas matriculas = db.Matriculas.Find(id);
            if (matriculas == null)
            {
                return HttpNotFound();
            }
            return View(matriculas);
        }

        // GET: Matriculas/Create
        public ActionResult Create()
        {
            ViewBag.codCurso = new SelectList(db.Cursos, "codCurso", "nombre");
            ViewBag.codGrupoClase = new SelectList(db.GrupoClases, "codGrupoClase", "nombre");
            ViewBag.UserId = new SelectList(db.Users, "Id", "Name");
            return View();
        }

        // POST: Matriculas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdMatricula,codCurso,codGrupoClase,UserId")] Matriculas matriculas)
        {
            if (ModelState.IsValid)
            {
                db.Matriculas.Add(matriculas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.codCurso = new SelectList(db.Cursos, "codCurso", "nombre", matriculas.codCurso);
            ViewBag.codGrupoClase = new SelectList(db.GrupoClases, "codGrupoClase", "nombre", matriculas.codGrupoClase);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Name", matriculas.UserId);
            return View(matriculas);
        }

        // GET: Matriculas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Matriculas matriculas = db.Matriculas.Find(id);
            if (matriculas == null)
            {
                return HttpNotFound();
            }
            ViewBag.codCurso = new SelectList(db.Cursos, "codCurso", "nombre", matriculas.codCurso);
            ViewBag.codGrupoClase = new SelectList(db.GrupoClases, "codGrupoClase", "nombre", matriculas.codGrupoClase);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Name", matriculas.UserId);
            return View(matriculas);
        }

        // POST: Matriculas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdMatricula,codCurso,codGrupoClase,UserId")] Matriculas matriculas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(matriculas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.codCurso = new SelectList(db.Cursos, "codCurso", "nombre", matriculas.codCurso);
            ViewBag.codGrupoClase = new SelectList(db.GrupoClases, "codGrupoClase", "nombre", matriculas.codGrupoClase);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Name", matriculas.UserId);
            return View(matriculas);
        }

        // GET: Matriculas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Matriculas matriculas = db.Matriculas.Find(id);
            if (matriculas == null)
            {
                return HttpNotFound();
            }
            return View(matriculas);
        }

        // POST: Matriculas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Matriculas matriculas = db.Matriculas.Find(id);
            db.Matriculas.Remove(matriculas);
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

        private int getGrupoClase()
        {
            string currentUserId = User.Identity.GetUserId();
            var grupos = db.AsignacionDocentes.Where(p => p.UserId == currentUserId).ToList();
            if (grupos.Count == 0) {
                return -1;
            }
            else return grupos.First().GrupoClase.codGrupoClase;
        }
    }
}
