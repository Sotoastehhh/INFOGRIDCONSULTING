using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaDatos;
using Capanegocio;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace PAGINA.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CerrarSesion() {
            Session["usuario"]=null ;
            return RedirectToAction("Login", "Acceso");
        }
        [HttpGet]
        public JsonResult ListarProductos()
        {
            List<Productos> olista = new List<Productos>();
            olista = new CN_Productos().Listar();

            return Json(new {data = olista } , JsonRequestBehavior.AllowGet);
        }
        public JsonResult ListarCategorias_productos()
        {
            List<Categorias_Productos> olista = new List<Categorias_Productos>();
            

            return Json(new { data = olista }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Catalogo()
        {
            using (var db = new Models.KERLY3())
            {
                var productos = db.Productos.ToList();
                return View(productos);
            }
        }



    }
}