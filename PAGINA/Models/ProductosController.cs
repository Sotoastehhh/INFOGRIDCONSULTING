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
    public class ProductosController : Controller
    {
        private KERLY3 db = new KERLY3();

        // GET: Productos
        public ActionResult Index()
        {
            var productos = db.Productos.Include(p => p.Categorias_Productos).Include(p => p.Proveedores);
            return View(productos.ToList());
        }

        // GET: Productos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Productos productos = db.Productos.Find(id);
            if (productos == null)
            {
                return HttpNotFound();
            }
            return View(productos);
        }

        // GET: Productos/Create
        public ActionResult Create()
        {
            ViewBag.ID_categoria = new SelectList(db.Categorias_Productos, "ID_categoria", "nombre_categoria");
            ViewBag.ID_proveedor = new SelectList(db.Proveedores, "ID_proveedor", "nombre_proveedor");
            return View();
        }

        // POST: Productos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_producto,nombre_producto,ID_categoria,precio,stock,ID_proveedor,fecha_entrada,fecha_expiracion,codigo_barras")] Productos productos)
        {
            if (ModelState.IsValid)
            {
                db.Productos.Add(productos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_categoria = new SelectList(db.Categorias_Productos, "ID_categoria", "nombre_categoria", productos.ID_categoria);
            ViewBag.ID_proveedor = new SelectList(db.Proveedores, "ID_proveedor", "nombre_proveedor", productos.ID_proveedor);
            return View(productos);
        }

        // GET: Productos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Productos productos = db.Productos.Find(id);
            if (productos == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_categoria = new SelectList(db.Categorias_Productos, "ID_categoria", "nombre_categoria", productos.ID_categoria);
            ViewBag.ID_proveedor = new SelectList(db.Proveedores, "ID_proveedor", "nombre_proveedor", productos.ID_proveedor);
            return View(productos);
        }

        // POST: Productos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_producto,nombre_producto,ID_categoria,precio,stock,ID_proveedor,fecha_entrada,fecha_expiracion,codigo_barras")] Productos productos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productos).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_categoria = new SelectList(db.Categorias_Productos, "ID_categoria", "nombre_categoria", productos.ID_categoria);
            ViewBag.ID_proveedor = new SelectList(db.Proveedores, "ID_proveedor", "nombre_proveedor", productos.ID_proveedor);
            return View(productos);
        }

        // GET: Productos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Productos productos = db.Productos.Find(id);
            if (productos == null)
            {
                return HttpNotFound();
            }
            return View(productos);
        }

        // POST: Productos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Productos productos = db.Productos.Find(id);
            db.Productos.Remove(productos);
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
        public ActionResult EscanearQR()
        {
            return View();
        }
        [HttpPost]
        public JsonResult DescontarStock(string codigo)
        {
            using (var db = new KERLY3())
            {
                var producto = db.Productos.FirstOrDefault(p => p.codigo_barras == codigo);
                if (producto != null)
                {
                    if (producto.stock > 0)
                    {
                        producto.stock -= 1;
                        db.SaveChanges();
                        return Json(new { mensaje = "Producto descontado correctamente." });
                    }
                    else
                    {
                        return Json(new { mensaje = "Stock agotado." });
                    }
                }
                else
                {
                    return Json(new { mensaje = "Producto no encontrado." });
                }
            }
        }

    }
}
