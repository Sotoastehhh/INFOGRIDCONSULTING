using System.Web.Mvc;
using PAGINA.Models;
 

namespace PAGINA.Controllers
{
    public class PruebasController : Controller
    {
        public ActionResult Resultados()
        {
            var tester = new ProductoTestsSimulados();
            var resultados = tester.EjecutarPruebas();
            return View(resultados);
        }
    }

}
