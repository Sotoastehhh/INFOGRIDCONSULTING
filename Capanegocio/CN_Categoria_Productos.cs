using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using CapaConexion;


namespace Capanegocio
{
    public class CN_categoria_productos
    {
        private CN_categoria_productos objCapaConex = new CN_categoria_productos();
        public List<Categorias_Productos> Listar()
        {
            return objCapaConex.Listar();
        }
    }
}
