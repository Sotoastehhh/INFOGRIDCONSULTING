using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace CapaConexion
{
    public class CD_productos
    {
        public List<Productos> Listar()
        {
            List<Productos> lista = new List<Productos>();
            string connectionString = ConfigurationManager.ConnectionStrings["KERLY6Entities"]?.ConnectionString;

            if (string.IsNullOrEmpty(connectionString))
                throw new Exception("La cadena de conexión es nula o no está configurada.");


            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                   

                    SqlCommand cmd = new   SqlCommand("SELECT [ID_producto],[nombre_producto],[ID_categoria],[precio],[stock]  FROM [dbo].[Productos]", oconexion);
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();

                    using (SqlDataReader dr= cmd.ExecuteReader() )
                    {
                        while (dr.Read()) {
                            lista.Add(
                                new Productos()
                                {
                                    ID_producto = Convert.ToInt32(dr["ID_producto"]),
                                    Nombre_producto = dr["nombre_producto"].ToString(),
                                    ID_categoria = Convert.ToInt32(dr["ID_categoria"]),
                                    Stock = Convert.ToInt32(dr["stock"]),
                                    Precio = Convert.ToDecimal(dr["precio"])
                                }
                                );
                    }

                    
                     }
                }
            
        }catch(Exception ex){
                string error = ex.Message;
                
                lista = new List<Productos>();
            
            
        }
            return lista;
        }
}
}
