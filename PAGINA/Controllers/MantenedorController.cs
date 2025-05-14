using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PAGINA.Controllers
{
    public class MantenedorController : Controller
    {
        // GET: Mantenedor
        public ActionResult Productos()
        {
            return View();
        }
        public ActionResult Proveedores()
        {
            return View();
        }
        public ActionResult Categorias_productos()
        {
            return View();
        }
    }
}