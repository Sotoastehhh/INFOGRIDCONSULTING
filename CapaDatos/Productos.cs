using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class Productos
    {
        public int ID_producto { get; set; }

        public int ID_categoria { get; set; }

        public int Stock {  get; set; }

        public decimal Precio { get; set; }

        public string Nombre_producto { get; set; }


    }
}
