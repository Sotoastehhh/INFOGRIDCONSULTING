using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace PAGINA.Models
{
    public class ProductoTestsSimulados
    {
        public List<string> EjecutarPruebas()
        {
            var resultados = new List<string>();

            var productos1 = new List<Productos>
            {
                new Productos { ID_producto = 1, nombre_producto = "Jugo", codigo_barras = "ABC123", stock = 5 }
            };
            var service1 = new ProductoService(productos1);
            var r1 = service1.DescontarStock("ABC123");
            resultados.Add(r1 == "Producto descontado correctamente." && productos1[0].stock == 4
                ? "✅ Test 1: Producto con stock -> OK"
                : "❌ Test 1: Producto con stock -> Falló");

            var productos2 = new List<Productos>
            {
                new Productos { ID_producto = 2, nombre_producto = "Pan", codigo_barras = "PAN001", stock = 0 }
            };
            var service2 = new ProductoService(productos2);
            var r2 = service2.DescontarStock("PAN001");
            resultados.Add(r2 == "Stock agotado."
                ? "✅ Test 2: Producto sin stock -> OK"
                : "❌ Test 2: Producto sin stock -> Falló");

            var productos3 = new List<Productos>();
            var service3 = new ProductoService(productos3);
            var r3 = service3.DescontarStock("INEXISTENTE");
            resultados.Add(r3 == "Producto no encontrado."
                ? "✅ Test 3: Producto no encontrado -> OK"
                : "❌ Test 3: Producto no encontrado -> Falló");

            return resultados;
        }
    }
}
