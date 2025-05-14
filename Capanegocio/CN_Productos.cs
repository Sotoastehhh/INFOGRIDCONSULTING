using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using CapaConexion;


namespace Capanegocio
{
    public class CN_Productos
    {
        private CD_productos objCapaConex = new CD_productos();
        public List<Productos> Listar() 
        {
            return objCapaConex.Listar();
        }
    }
}
