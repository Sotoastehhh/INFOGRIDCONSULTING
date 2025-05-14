using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace PAGINA.Models
{
    public class Categorias_ProductosController : Controller
    {
        private KERLY3 db = new KERLY3();

        // GET: Categorias_Productos
        public ActionResult Index()
        {
            return View(db.Categorias_Productos.ToList());
        }

        // GET: Categorias_Productos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categorias_Productos categorias_Productos = db.Categorias_Productos.Find(id);
            if (categorias_Productos == null)
            {
                return HttpNotFound();
            }
            return View(categorias_Productos);
        }

        // GET: Categorias_Productos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categorias_Productos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_categoria,nombre_categoria")] Categorias_Productos categorias_Productos)
        {
            if (ModelState.IsValid)
            {
                db.Categorias_Productos.Add(categorias_Productos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(categorias_Productos);
        }

        // GET: Categorias_Productos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categorias_Productos categorias_Productos = db.Categorias_Productos.Find(id);
            if (categorias_Productos == null)
            {
                return HttpNotFound();
            }
            return View(categorias_Productos);
        }

        // POST: Categorias_Productos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_categoria,nombre_categoria")] Categorias_Productos categorias_Productos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(categorias_Productos).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categorias_Productos);
        }

        // GET: Categorias_Productos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categorias_Productos categorias_Productos = db.Categorias_Productos.Find(id);
            if (categorias_Productos == null)
            {
                return HttpNotFound();
            }
            return View(categorias_Productos);
        }

        // POST: Categorias_Productos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Categorias_Productos categorias_Productos = db.Categorias_Productos.Find(id);
            db.Categorias_Productos.Remove(categorias_Productos);
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
