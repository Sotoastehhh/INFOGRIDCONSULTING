using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;


//-- Tabla de Categorías de Productos
//CREATE TABLE Categorias_Productos (
//  ID_categoria INT PRIMARY KEY IDENTITY(1,1),
//nombre_categoria VARCHAR(200) NOT NULL
//
namespace CapaDatos
{
    public class Categorias_Productos
    {
        public int ID_categoria {  get; set; }
        public string nombre_categoria { get; set; }



    }
}

